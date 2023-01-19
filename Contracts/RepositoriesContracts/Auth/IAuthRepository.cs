using Models.DTO;
using Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoriesContracts.Auth
{
    public interface IAuthRepository
    {
        int Register(User user, string password);
        AuthenticatedResponse Login(string userName, string password);
        bool UserExist(string username);
        bool IsAdmin(int id);

    }
}
