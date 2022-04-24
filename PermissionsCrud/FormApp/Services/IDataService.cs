using FormApp.Models;
using System.Collections.Generic;

namespace FormApp.Services
{
    public interface IDataService
    {
        List<Permission> GetPermissions();
        List<PermissionType> GetPermissionTypess();
        Permission GetPermission(int id); 
    }
}
