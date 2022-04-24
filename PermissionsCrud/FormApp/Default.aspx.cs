using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace FormApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Permissions"] == null)
            {
                var permissionTypes = new List<PermissionType>();
                permissionTypes.Add(new PermissionType { Id = 1, Description = "Adbsense" });
                permissionTypes.Add(new PermissionType { Id = 2, Description = "Medical Reason" });
                permissionTypes.Add(new PermissionType { Id = 3, Description = "Family Themes" });
                Session["PermissionTypes"] = permissionTypes;

                var permissions = new List<Permission> {
                    new Permission { Id = 1,EmployeeLastname = "Perez", EmployeeName ="Juan",  PermissionDate = DateTime.Now.AddDays(-3), PermissionTypeId = 1, PermissionType = permissionTypes[0] },
                    new Permission { Id = 2,EmployeeLastname = "Almonte", EmployeeName ="Carlos",  PermissionDate = DateTime.Now.AddDays(-3), PermissionTypeId = 3, PermissionType = permissionTypes[2]},
                    new Permission {  Id = 3,EmployeeLastname = "Cabrera", EmployeeName ="Grey", PermissionDate = DateTime.Now.AddDays(-3), PermissionTypeId = 1, PermissionType = permissionTypes[1]},
                    new Permission { Id = 4, EmployeeLastname = "Cruz", EmployeeName ="Penelope",  PermissionDate = DateTime.Now.AddDays(-3), PermissionTypeId = 2, PermissionType = permissionTypes[1]},
                };
                Session["Permissions"] = permissions;

            }
        }
    }
}