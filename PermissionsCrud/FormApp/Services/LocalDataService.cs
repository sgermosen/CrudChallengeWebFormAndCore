using FormApp.Models;
using FormApp.Utils;
using System;
using System.Collections.Generic;
using System.Web;

namespace FormApp.Services
{
    public class LocalDataService : IDataService
    {
        public List<Permission> GetPermissions()
        {
            var permissions = (List<Permission>)HttpContext.Current.Session["Permissions"];
            if (permissions == null)
                permissions = new List<Permission>();   // new Permission{Id = 0, EmployeeLastname =string.Empty, EmployeeName =string.Empty, PermissionDate = new DateTime(), PermissionType  = new PermissionType { Id= 1, Description = string.Empty }, PermissionTypeId =1 } };
            return permissions;
        }

        public List<PermissionType> GetPermissionTypes()
        {
            var permissions = (List<PermissionType>)HttpContext.Current.Session["PermissionTypes"];
            if (permissions == null)
                permissions = new List<PermissionType>();
            return permissions;
        }

        public PermissionType GetPermissionType(int id)
        {
            var permissionType = GetPermissionTypes().Find(x => x.Id == id);
            if (permissionType == null)
                return new PermissionType();
            return permissionType;
        }
        public Permission GetPermission(int id)
        {
            var permission = GetPermissions().Find(x => x.Id == id);
            if (permission == null)
                return new Permission();
            return permission;
        }

        public bool DeletePermission(int selectedId)
        {
            var permissions = GetPermissions();
            var permissionDb = permissions.Find(x => x.Id == selectedId);
            permissions.Remove(permissionDb);
            HttpContext.Current.Session["Permissions"] = permissions;
            return true;
        }

        public void SetPermissionId(int v) => HttpContext.Current.Session["PermissionId"] = v;

        public int GetSelectedPermissionId() => Convert.ToInt32(HttpContext.Current.Session["PermissionId"]);

        public bool UpdatePermission(int permissionId, PermissionSave model)
        {
            var permissions = GetPermissions();
            var permissionDb = permissions.Find(x => x.Id == permissionId);
            if (permissionDb != null)
            {
                permissions.Remove(permissionDb);
                PermissionModelToPermission(model, permissionDb);

                permissions.Add(permissionDb);
                HttpContext.Current.Session["Permissions"] = permissions;
                return true;
            }
            return false;
        }

        public bool CreatePermission(PermissionSave model)
        {
            var permissions = GetPermissions();
            var newId = permissions.Count + 1;
            var permissionDb = new Permission();

            PermissionModelToPermission(model, permissionDb);

            permissionDb.Id = newId;
            permissions.Add(permissionDb);
            HttpContext.Current.Session["Permissions"] = permissions;
            SetPermissionId(0);
            return true;

        }

        private void PermissionModelToPermission(PermissionSave model, Permission permissionDb)
        {
            permissionDb.EmployeeLastname = model.EmployeeLastname;
            permissionDb.EmployeeName = model.EmployeeName;
            permissionDb.PermissionDate = Dates.ConvertToDate(model.DateFromView);
            permissionDb.PermissionTypeId = model.PermissionTypeId;
            permissionDb.PermissionType = GetPermissionType(model.PermissionTypeId);
        }


    }
}