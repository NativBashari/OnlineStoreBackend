using Contracts.RepositoriesContracts.ProductsManagementRepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        void Complete();
    }
}
