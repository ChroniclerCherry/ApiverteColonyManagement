using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.DataModels;

namespace Server.Commands.EditLookups
{
    public class EditAreaCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class EditAreaCommandHandler : IRequestHandler<EditAreaCommand, Guid>
        {
            private readonly Context _db;

            public EditAreaCommandHandler(Context db)
            {
                _db = db;
            }
            public async Task<Guid> Handle(EditAreaCommand request, CancellationToken cancellationToken)
            {
                var area = await _db.Area.FirstOrDefaultAsync(a => a.Id == request.Id);
                if (area == null) return Guid.Empty;

                area.Name = request.Name;
                _db.SaveChanges();

                return area.Id;
            }
        }
    }
}
