using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.ServicesInterfaces
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
        IEnumerable<User> GetAllUsers();
        //void AssignRoleToUser(int userId, int roleId);
        void AssignRoleToUser(string userEmail, string roleName);
    }
}
