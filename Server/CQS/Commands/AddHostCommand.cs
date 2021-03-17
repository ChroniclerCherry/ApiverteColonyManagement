using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.DataModels;
using Server.DataModels.Colony;

namespace Server.Commands.AddLookups
{
    public class AddHostCommand : IRequest<Guid>
    {
        public string Name { get; set; }

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
                    Name = request.Name
                };
                await _db.Host.AddAsync(host, cancellationToken);
                _db.SaveChanges();
                return host.Id;
            }
        }
    }
}
