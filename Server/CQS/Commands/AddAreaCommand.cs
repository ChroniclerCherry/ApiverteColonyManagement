using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.DataModels;
using Server.DataModels.Colony;

namespace Server.Commands.AddLookups
{
    public class AddAreaCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<AddAreaCommand, Guid>
        {
            private readonly Context _db;

            public UpdateProductCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(AddAreaCommand request, CancellationToken cancellationToken)
            {
                var area = new Area()
                {
                    Name = request.Name
                };
                await _db.Area.AddAsync(area, cancellationToken);
                _db.SaveChanges();
                return area.Id;
            }
        }
    }
}
