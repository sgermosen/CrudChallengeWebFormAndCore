using FormApp.Models;
using System.Collections.Generic;

namespace FormApp.Services
{
    public class ApiService : IDataService
    {
        public Response<bool> CreatePermission(PermissionSave model)
        {
            throw new System.NotImplementedException();
        }

        public Response<bool> DeletePermission(int selectedId)
        {
            throw new System.NotImplementedException();
        }

        public Response<Permission> GetPermission(int id)
        {
            throw new System.NotImplementedException();
        }

        public Response<List<Permission>> GetPermissions()
        {
            throw new System.NotImplementedException();
        }

        public Response<List<PermissionType>> GetPermissionTypes()
        {
            throw new System.NotImplementedException();
        }

        public Response<int> GetSelectedPermissionId()
        {
            throw new System.NotImplementedException();
        }

        public void SetPermissionId(int v)
        {
            throw new System.NotImplementedException();
        }

        public Response<bool> UpdatePermission(int permissionId, PermissionSave model)
        {
            throw new System.NotImplementedException();
        }
    }
}