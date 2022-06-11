using GraphQLProject.Data;
using GraphQLProject.Intefaces;
using GraphQLProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLProject.Services
{
    public class ProductDBServices : IproductServices
    {
        private readonly GraphQLDbContext dbContext;

        public ProductDBServices(GraphQLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Product AddProduct(Product product)
        {
            this.dbContext.Products.Add(product);
            DBSaveChanges();
            return product;
        }

        public void deleteProduct(int Id)
        {
            dbContext.Remove<Product>(GetProductById(Id));
            DBSaveChanges();
        }

        public List<Product> getAllProduct()
        {
            return dbContext.Products.ToList();
        }

        public Product GetProductById(int Id)
        {
            return dbContext.Products.Find(Id);
        }

        public Product UpdateProduct(int Id, Product product)
        {
            var Product = dbContext.Products.Find(Id);
            Product.Name = product.Name;
            Product.Price = product.Price;
            DBSaveChanges();
            return Product;
        }

        private void DBSaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
