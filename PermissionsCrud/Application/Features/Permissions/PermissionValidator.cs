using Domain.Entities;
using FluentValidation;

namespace Application.Features.Permissions
{
    public class PermissionValidator : AbstractValidator<Permission>
    {
        public PermissionValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty();
            RuleFor(x => x.EmployeeLastname).NotEmpty();
        }
    }

}