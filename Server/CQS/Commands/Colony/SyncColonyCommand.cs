using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.CQS.DTOs;
using Server.DataModels;

namespace Server.CQS.Commands.Colony
{
    public class SyncColonyCommand : IRequest<IEnumerable<ColonyDto>>
    {
        public List<ColonyDto> Colonies { get; set; }
    }

    public class SyncColonyCommandHandler : IRequestHandler<SyncColonyCommand, IEnumerable<ColonyDto>>
    {
        private readonly Context _db;

        public SyncColonyCommandHandler(Context db)
        {
            _db = db;
        }
        public Task<IEnumerable<ColonyDto>> Handle(SyncColonyCommand request, CancellationToken cancellationToken)
        {
            //TODO: add in full data mapping
            var colonies = request.Colonies ?? new List<ColonyDto>();
            foreach (var appColonys in colonies)
            {
                var localColony = _db.Colony.FirstOrDefault(u => u.Id == appColonys.Id);
                DataModels.Colony.Colony colony = new DataModels.Colony.Colony()
                {
                    Id = appColonys.Id,
                    IsActive = appColonys.IsActive,
                    CreatedDate = appColonys.CreatedDate,
                    CreatedBy = appColonys.CreatedBy,
                    LastModifiedDate = appColonys.LastModifiedDate,
                    LastModifiedBy = appColonys.LastModifiedBy
                };

                if (localColony == null)
                {
                    _db.Colony.Add(colony);
                }
                else if (appColonys.LastModifiedDate > localColony.LastModifiedDate)
                {
                    _db.Colony.Remove(localColony);
                    _db.Colony.Add(colony);
                }
                else
                {
                    appColonys.IsActive = localColony.IsActive;
                    appColonys.CreatedDate = localColony.CreatedDate;
                    appColonys.CreatedBy = localColony.CreatedBy;
                    appColonys.LastModifiedDate = localColony.LastModifiedDate;
                    appColonys.LastModifiedBy = localColony.LastModifiedBy;
                }
            }

            var appColonysIDs = colonies.Select(u => u.Id).ToList();
            var uniqueLocalColonys = _db.Colony.Where(u => !appColonysIDs.Contains(u.Id)).Select(u => new ColonyDto()
            {
                Id = u.Id,
                IsActive = u.IsActive,
                CreatedDate = u.CreatedDate,
                CreatedBy = u.CreatedBy,
                LastModifiedDate = u.LastModifiedDate,
                LastModifiedBy = u.LastModifiedBy
            }).ToList();

            colonies.AddRange(uniqueLocalColonys);
            _db.SaveChanges();

            return Task.FromResult<IEnumerable<ColonyDto>>(colonies);
        }
    }
}
