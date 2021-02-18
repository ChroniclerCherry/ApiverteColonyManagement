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
    public class GetAreasQuery : IRequest<IEnumerable<LookupDto>>
    {
        public class GetAreasQueryHandler : IRequestHandler<GetAreasQuery, IEnumerable<LookupDto>>
        {
            private readonly Context _db;

            public GetAreasQueryHandler(Context db)
            {
                _db = db;
            }
            public async Task<IEnumerable<LookupDto>> Handle(GetAreasQuery request, CancellationToken cancellationToken)
            {
                return await _db.Area.Select(a => new LookupDto()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }

}
