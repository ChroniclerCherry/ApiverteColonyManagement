using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.DataModels;
using Server.Queries.DTOs;

namespace Server.Queries.GetLookups
{
    public class GetHostsQuery : IRequest<IEnumerable<LookupDto>>
    {
        public class GetHostsQueryHandler : IRequestHandler<GetHostsQuery, IEnumerable<LookupDto>>
        {
            private readonly Context _db;

            public GetHostsQueryHandler(Context db)
            {
                _db = db;
            }

            public async Task<IEnumerable<LookupDto>> Handle(GetHostsQuery request, CancellationToken cancellationToken)
            {
                return await _db.Host.Select(a => new LookupDto()
                {
                    Id = a.Id,
                    Name = a.Name,
                    IsActive = a.IsActive
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
