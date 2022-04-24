using Application.Core;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Permissions
{
    public class Edit
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
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var permission = await _context.Permissions.FindAsync(request.Permission.Id);

                if (permission == null) return null;

                _mapper.Map(request.Permission, permission);
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Fail to update permission");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}