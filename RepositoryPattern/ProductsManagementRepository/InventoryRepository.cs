using Contracts.RepositoriesContracts.ProductsManagementRepositoriesContracts;
using Entities;
using Models.ProductsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.ProductsManagementRepository
{
    public class InventoryRepository : GenericRepository<Inventory> , IInventoryRepository
    {
        public InventoryRepository(OnlineStoreDbContext dbContext): base(dbContext)
        {

        }
    }
}
