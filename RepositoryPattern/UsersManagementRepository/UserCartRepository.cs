using Contracts;
using Contracts.RepositoriesContracts.UsersMenagementRepositoriesContracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Models.ProductsManagement;
using Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.UsersManagementRepository
{
    public class UserCartRepository : GenericRepository<UserCart>, IUserCartRepository
    {
        public UserCartRepository(OnlineStoreDbContext dbContext): base(dbContext)
        {
        }

        public UserCart GetByUserId(int UserId)
        {
           var userCart = dbContext.UserCarts.FirstOrDefault(uc => uc.UserId == UserId);
            return userCart!; 
        }

        public IEnumerable<Product> GetUserCartProducts(int userCartId)
        {
            var p = dbContext.UserCarts.Include(uc => uc.Products).FirstOrDefault(uc => uc.Id == userCartId);
            return p.Products!; 
        }
    }
}
