using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.DataModels;
using Server.DataModels.Colony;

namespace Server.CQS.Commands
{
    public class AddUserCommand : IRequest<Guid>
    {
        public Guid Id;
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
        {
            private readonly Context _db;

            public AddUserCommandHandler(Context db)
            {
                _db = db;
            }
            public Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User()
                {
                    Id = request.Id,
                    Name = request.Name,
                    IsActive = request.IsActive
                };
                _db.User.Add(user);
                _db.SaveChanges();
                return Task.FromResult(user.Id);
            }
        }
    }
}
