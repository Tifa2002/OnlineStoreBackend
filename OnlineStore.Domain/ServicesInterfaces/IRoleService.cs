using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.ServicesInterfaces
{
    public interface IRoleService
    {
        IdentityRole GetRoleByName(string roleName);
        IEnumerable<IdentityRole> GetAllRoles();
        void CreateRole(string roleName);
        bool RoleExists(string roleName);
    }
}
