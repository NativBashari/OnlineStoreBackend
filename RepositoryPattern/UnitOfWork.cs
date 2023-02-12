using Contracts;
using Contracts.RepositoriesContracts.ProductsManagementRepositoriesContracts;
using Contracts.RepositoriesContracts.UsersMenagementRepositoriesContracts;
using Entities;
using RepositoryPattern.ProductsManagementRepository;
using RepositoryPattern.UsersManagementRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private OnlineStoreDbContext dbContext;
        private ICategoryRepository? categoryRepository;
        private IProductRepository? productRepository;
        private IDiscountRepository? discountRepository;
        private IUserCartRepository? userCartRepository;
        public UnitOfWork(OnlineStoreDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null) productRepository = new ProductRepository(dbContext);
                return productRepository;
            }
        }

        public IDiscountRepository DiscountRepository
        {
            get
            {
                if(discountRepository == null) discountRepository = new DiscountRepository(dbContext);
                return discountRepository;
            }
        }


        public ICategoryRepository CategoryRepository
        {
            get 
            {
                if (categoryRepository == null) categoryRepository = new CategoryRepository(dbContext);
                return categoryRepository;
            }
        }
        public IUserCartRepository UserCartRepository
        {
            get
            {
                if (userCartRepository == null) userCartRepository = new UserCartRepository(dbContext);
                return userCartRepository;
            }
        }
      

        public void Complete()
        {
            this.dbContext.SaveChanges();
        }
    }
}
