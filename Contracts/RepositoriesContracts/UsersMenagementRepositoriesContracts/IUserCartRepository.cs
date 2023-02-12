using Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoriesContracts.UsersMenagementRepositoriesContracts
{
    public interface IUserCartRepository : IGenericRepository<UserCart>
    {
        UserCart GetByUserId(int UserId);
    }
}
