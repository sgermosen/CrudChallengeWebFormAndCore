using Application.Core;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Permissions
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Permission Permission { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Permission).SetValidator(new PermissionValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if(request.Permission.Id ==0)
                {
                    request.Permission.Id = _context.Permissions.Count() + 1;
                }
                _context.Permissions.Add(request.Permission);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Fail to create permission");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}