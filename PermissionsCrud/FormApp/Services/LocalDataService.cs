using Domain.Entities;
using System.Collections.Generic;
using System.Web;

namespace FormApp.Services
{
    public class LocalDataService: IDataService
    {
        public List<Permission> GetPermissions()
        {
            var permissions = (List<Permission>)HttpContext.Current.Session["Permissions"];
            if (permissions == null)
                permissions = new List<Permission>();   // new Permission{Id = 0, EmployeeLastname =string.Empty, EmployeeName =string.Empty, PermissionDate = new DateTime(), PermissionType  = new PermissionType { Id= 1, Description = string.Empty }, PermissionTypeId =1 } };
            return permissions;
        }

        public List<PermissionType> GetPermissionTypess()
        {
            var permissions = (List<PermissionType>)HttpContext.Current.Session["PermissionTypes"];
            if (permissions == null)
                permissions = new List<PermissionType>();
            return permissions;
        }

        public Permission GetPermission(int id)
        {
            var permission = GetPermissions().Find(x => x.Id == id);
            if (permission == null)
                return new Permission();
            return permission;
        }
    }
}