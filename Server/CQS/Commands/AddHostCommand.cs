using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.DataModels;
using Server.DataModels.Colony;

namespace Server.CQS.Commands
{
    public class AddHostCommand : IRequest<Guid>
    {
        public Guid Id;
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public class AddHostCommandHandler : IRequestHandler<AddHostCommand, Guid>
        {
            private readonly Context _db;

            public AddHostCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(AddHostCommand request, CancellationToken cancellationToken)
            {
                var host = new Host()
                {
                    Id = request.Id,
                    Name = request.Name,
                    IsActive = request.IsActive
                };
                await _db.Host.AddAsync(host, cancellationToken);
                _db.SaveChanges();
                return host.Id;
            }
        }
    }
}
