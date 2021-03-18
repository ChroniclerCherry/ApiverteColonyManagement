using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.DataModels;
using Server.Queries.DTOs;

namespace Server.CQS.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<LookupDto>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<LookupDto>>
        {
            private readonly Context _db;

            public GetUsersQueryHandler(Context db)
            {
                _db = db;
            }
            public async Task<IEnumerable<LookupDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                return await _db.User.Select(a => new LookupDto()
                {
                    Id = a.Id,
                    Name = a.Name,
                    IsActive = a.IsActive
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
