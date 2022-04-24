using FormApp.Models;
using System.Collections.Generic;

namespace FormApp.Services
{
    public interface IDataService
    {
        List<Permission> GetPermissions();
        List<PermissionType> GetPermissionTypes();
        Permission GetPermission(int id);
        bool DeletePermission(int selectedId);
        void SetPermissionId(int v);
        int GetSelectedPermissionId();
        bool UpdatePermission(int permissionId, PermissionSave model);
        bool CreatePermission(PermissionSave model);
    }
}
