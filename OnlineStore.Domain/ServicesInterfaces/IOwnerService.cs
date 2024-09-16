using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.ServicesInterfaces
{
    public interface IOwnerService
    {
        IEnumerable<User> GetAllOwners();
        void DemoteOwnerToCustomer(string ownerMail);
    }
}
