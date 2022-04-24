using Application.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Permissions
{
    public class List
    {
        public class Query : IRequest<Result<List<Permission>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Permission>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Permission>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Permission>>.Success(await _context.Permissions.Include(p=> p.PermissionType).ToListAsync(cancellationToken));
            }
        }
    }
}