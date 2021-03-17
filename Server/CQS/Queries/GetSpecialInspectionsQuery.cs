using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.CQS.Commands;
using Server.DataModels;

namespace Server.CQS.Queries
{
    public class GetSpecialInspectionsQuery : IRequest<IEnumerable<SpecialInspectionDto>>
    {
        public class GetSpecialInspectionsQueryHandler : IRequestHandler<GetSpecialInspectionsQuery, IEnumerable<SpecialInspectionDto>>
        {
            private readonly Context _db;

            public GetSpecialInspectionsQueryHandler(Context db)
            {
                _db = db;
            }
            public async Task<IEnumerable<SpecialInspectionDto>> Handle(GetSpecialInspectionsQuery request, CancellationToken cancellationToken)
            {
                return await _db.SpecialInspection.Select(a => new SpecialInspectionDto()
                {
                    Id = a.Id,
                    IsActive = a.IsActive,
                    UserId = a.UserID,
                    ColonyId = a.ColonyId,
                    Harvest = a.Harvest,
                    Feeds = a.Feeds,
                    Treatments = a.Treatments,
                    TreatmentDetails = a.TreatmentDetails,
                    Wintering = a.Wintering,
                    Growth = a.Growth
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
