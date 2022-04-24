using Application.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Permissions
{
    public class Details
    {
        public class Query : IRequest<Result<Permission>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Permission>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Permission>> Handle(Query request, CancellationToken cancellationToken)
            {
                var permission = await _context.Permissions.Include(p => p.PermissionType).FirstOrDefaultAsync(x=> x.Id == request.Id);
                return Result<Permission>.Success(permission);
            }
        }
    }
}