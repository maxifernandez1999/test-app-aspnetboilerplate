using Abp.Authorization;
using myTestProject.Authorization.Roles;
using myTestProject.Authorization.Users;

namespace myTestProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
