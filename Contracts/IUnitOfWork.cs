using Contracts.RepositoriesContracts.ProductsManagementRepositoriesContracts;
using Contracts.RepositoriesContracts.UsersMenagementRepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUnitOfWork
    {
        //PRODUCTS MANAGEMENT
        IProductRepository ProductRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        //USERS MANAGEMENT
        IUserCartRepository UserCartRepository { get; }
        void Complete();
    }
}
