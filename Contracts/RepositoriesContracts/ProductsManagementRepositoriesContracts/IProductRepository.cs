using Models.ProductsManagement;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoriesContracts.ProductsManagementRepositoriesContracts
{
    public interface IProductRepository: IGenericRepository<Product>
    {

        IEnumerable<Product> GetProductsFromCategory(int categoryId);

    }
}
