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
    public class GetTypicalInspectionQuery : IRequest<IEnumerable<TypicalInspectionDto>>
    {
        public class GetTypicalInspectionQueryHandler : IRequestHandler<GetTypicalInspectionQuery, IEnumerable<TypicalInspectionDto>>
        {
            private readonly Context _db;

            public GetTypicalInspectionQueryHandler(Context db)
            {
                _db = db;
            }
            public async Task<IEnumerable<TypicalInspectionDto>> Handle(GetTypicalInspectionQuery request, CancellationToken cancellationToken)
            {
                return await _db.TypicalInspection.Select(a => new TypicalInspectionDto()
                {
                    Id = a.Id,
                    IsActive = a.IsActive,
                    UserId = a.UserID,
                    ColonyId = a.ColonyId,
                    Weather = a.Weather,
                    Population = a.Population,
                    Mood = a.Mood,
                    Fitness = a.Fitness,
                    BroodChambers = a.BroodChambers,
                    HoneyChamber = a.HoneyChamber,
                    MouseGuard = a.MouseGuard,
                    WaspGuard = a.WaspGuard,
                    PollenCollector = a.PollenCollector,
                    HiveBottom = a.HiveBottom,
                    Vents = a.Vents,
                    Brood = a.Brood,
                    Honey = a.Honey,
                    BroodPattern = a.BroodPattern,
                    Issues = a.Issues,
                    Growth = a.Growth,
                    Seasonal = a.Seasonal,
                    Status = a.Status,
                    Cells = a.Cells,
                    SwarmStatus = a.SwarmStatus,
                    Excluder = a.Excluder
                }).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
