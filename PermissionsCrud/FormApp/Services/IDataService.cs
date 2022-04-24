using FormApp.Models;
using System.Collections.Generic;

namespace FormApp.Services
{
    public interface IDataService
    {
        Response<List<Permission>> GetPermissions();
        Response<List<PermissionType>> GetPermissionTypes();
        Response<Permission> GetPermission(int id);
        Response<bool> DeletePermission(int selectedId);
        void SetPermissionId(int v);
        Response<int> GetSelectedPermissionId();
        Response<bool> UpdatePermission(int permissionId, PermissionSave model);
        Response<bool> CreatePermission(PermissionSave model);
    }
}
