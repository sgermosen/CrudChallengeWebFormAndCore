using FormApp.Models;
using FormApp.Utils;
using System;
using System.Collections.Generic;
using System.Web;

namespace FormApp.Services
{
    public class LocalDataService : IDataService
    {

        public Response<List<Permission>> GetPermissions()
        {
            var permissions = (List<Permission>)HttpContext.Current.Session["Permissions"];
            if (permissions != null)
                return new Response<List<Permission>> { IsSuccess = true, Value = permissions };
            permissions = new List<Permission>();   // new Permission{Id = 0, EmployeeLastname =string.Empty, EmployeeName =string.Empty, PermissionDate = new DateTime(), PermissionType  = new PermissionType { Id= 1, Description = string.Empty }, PermissionTypeId =1 } };
            return new Response<List<Permission>> { IsSuccess = false, Value = permissions, Error = "Error retreaving data" };
        }

        public Response<List<PermissionType>> GetPermissionTypes()
        {
            var permissionsTypes = (List<PermissionType>)HttpContext.Current.Session["PermissionTypes"];
            if (permissionsTypes == null)
                permissionsTypes = new List<PermissionType>();
            return new Response<List<PermissionType>> { IsSuccess = true, Value = permissionsTypes };
        }

        public Response<PermissionType> GetPermissionType(int id)
        {
            var request = GetPermissionTypes();
            if (request.IsSuccess)
            {
                var permissionType = request.Value.Find(x => x.Id == id);
                if (permissionType != null)
                    return new Response<PermissionType> { IsSuccess = true, Value = permissionType };
            }
            return new Response<PermissionType> { IsSuccess = true, Error = "We coulnt find this object" };
        }

        public Response<Permission> GetPermission(int id)
        {
            var request = GetPermissions();
            if (request.IsSuccess)
            {
                var permission = request.Value.Find(x => x.Id == id);
                if (permission != null)
                    return new Response<Permission> { IsSuccess = true, Value = permission };
            }
            return new Response<Permission> { IsSuccess = true, Error = "We coulnt find this object" };
        }

        public Response<bool> DeletePermission(int selectedId)
        {
            var request = GetPermissions();
            if (request.IsSuccess)
            {
                var permissions = request.Value;
                var permission = permissions.Find(x => x.Id == selectedId);
                if (permission != null)
                {
                    permissions.Remove(permission);
                    HttpContext.Current.Session["Permissions"] = permissions;
                    return new Response<bool> { IsSuccess = true, Value = true };
                }
            }
            return new Response<bool> { IsSuccess = false, Error = "We coulnt delete this object" };

        }

        public void SetPermissionId(int v) => HttpContext.Current.Session["PermissionId"] = v;

        public Response<int> GetSelectedPermissionId() => new Response<int> { IsSuccess = true, Value = Convert.ToInt32(HttpContext.Current.Session["PermissionId"]) };

        public Response<bool> UpdatePermission(int permissionId, PermissionSave model)
        {
            var request = GetPermissions();
            if (request.IsSuccess)
            {
                var permissions = request.Value;
                var permissionDb = permissions.Find(x => x.Id == permissionId);
                if (permissionDb != null)
                {
                    permissions.Remove(permissionDb);
                    PermissionModelToPermission(model, permissionDb);

                    permissions.Add(permissionDb);
                    HttpContext.Current.Session["Permissions"] = permissions;
                    return new Response<bool> { IsSuccess = true, Value = true };
                }
            }
            return new Response<bool> { IsSuccess = false, Error = "We coulnt update this object" };
        }

        public Response<bool> CreatePermission(PermissionSave model)
        {
            var request = GetPermissions();
            if (request.IsSuccess)
            {
                var permissions = request.Value;
                var newId = permissions.Count + 1;
                var permissionDb = new Permission();

                PermissionModelToPermission(model, permissionDb);

                permissionDb.Id = newId;
                permissions.Add(permissionDb);
                HttpContext.Current.Session["Permissions"] = permissions;
                SetPermissionId(0);
                return new Response<bool> { IsSuccess = true, Value = true };

            }
            return new Response<bool> { IsSuccess = false, Error = "We coulnt create this object" };

        }

        private void PermissionModelToPermission(PermissionSave model, Permission permissionDb)
        {

            var requestTypes = GetPermissionType(model.PermissionTypeId);
            if (requestTypes.IsSuccess)
                permissionDb.PermissionType = requestTypes.Value;
            permissionDb.EmployeeLastname = model.EmployeeLastname;
            permissionDb.EmployeeName = model.EmployeeName;
            permissionDb.PermissionDate = Dates.ConvertToDate(model.DateFromView);
            permissionDb.PermissionTypeId = model.PermissionTypeId;
        }


    }
}