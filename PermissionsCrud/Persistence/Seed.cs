using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {

            if (!context.Permissions.Any())
            {
                var permissionTypes = new List<PermissionType>();
                permissionTypes.Add(new PermissionType { Id = 1, Description = "Adbsense" });
                permissionTypes.Add(new PermissionType { Id = 2, Description = "Medical Reason" });
                permissionTypes.Add(new PermissionType { Id = 3, Description = "Family Themes" });
                await context.PermissionTypes.AddRangeAsync(permissionTypes);

                var permissions = new List<Permission> {
                    new Permission { Id = 1,EmployeeLastname = "Perez", EmployeeName ="Juan",  PermissionDate = DateTime.Now.AddDays(-3), PermissionTypeId = 1, PermissionType = permissionTypes[0] },
                    new Permission { Id = 2,EmployeeLastname = "Almonte", EmployeeName ="Carlos",  PermissionDate = DateTime.Now.AddDays(-3), PermissionTypeId = 3, PermissionType = permissionTypes[2]},
                    new Permission {  Id = 3,EmployeeLastname = "Cabrera", EmployeeName ="Grey", PermissionDate = DateTime.Now.AddDays(-3), PermissionTypeId = 1, PermissionType = permissionTypes[1]},
                    new Permission { Id = 4, EmployeeLastname = "Cruz", EmployeeName ="Penelope",  PermissionDate = DateTime.Now.AddDays(-3), PermissionTypeId = 2, PermissionType = permissionTypes[1]},
                };
                await context.Permissions.AddRangeAsync(permissions);

                await context.SaveChangesAsync();
            }
        }
    }
}