using System.Collections.Generic;
using ProjectNA.DataLayer.Entities.Permissions;
using ProjectNA.DataLayer.Entities.User;

namespace ProjectNA.Core.Services.Interfaces
{
    public interface IPermissionService
    {
        #region Roles

        List<Role> GetRoles();
        void AddRolesToUser(List<int> roleIds, int userId);
        void EditRolesUser(int userId, List<int> rolesId);
        int AddRole(Role role);
        Role GetRoleById(int roleId);
        void UpdateRole(Role role);
        void DeleteRole(Role role);

        #endregion

        #region Permissions

        List<Permission> getAllPermissions();
        void AddPermissionsToRole(int roleId,List<int> permission);
        List<int> PermissionsRole(int roleId);
        void UpdatePermissionsRole(int roleId,List<int> newPermission);
        bool CheckPermission(int permissionId, string userName);

        #endregion
    }
}