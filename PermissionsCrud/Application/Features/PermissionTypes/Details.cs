using Application.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PermissionTypes
{
    public class Details
    {
        public class Query : IRequest<Result<PermissionType>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PermissionType>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<PermissionType>> Handle(Query request, CancellationToken cancellationToken)
            {
                var permission = await _context.PermissionTypes.FirstOrDefaultAsync(x=> x.Id == request.Id);
                return Result<PermissionType>.Success(permission);
            }
        }
    }
}