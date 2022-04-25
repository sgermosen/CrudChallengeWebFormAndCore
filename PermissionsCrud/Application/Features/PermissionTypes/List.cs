using Application.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PermissionTypes
{
    public class List
    {
        public class Query : IRequest<Result<List<PermissionType>>> { }

        public class Handler : IRequestHandler<Query, Result<List<PermissionType>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<PermissionType>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<PermissionType>>.Success(await _context.PermissionTypes.ToListAsync(cancellationToken));
            }
        }
    }
}