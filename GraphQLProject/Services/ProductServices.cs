using GraphQLProject.Intefaces;
using GraphQLProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLProject.Services
{
    public class ProductServices : IproductServices
    {
        private static List<Product> products = new List<Product>()
        {
            new Product(){Id=1,Name="Pepsi",Price=20},
            new Product(){Id=2,Name="Coke",Price=30},
            new Product(){Id=3,Name="Fanta",Price=20},
            new Product(){Id=4,Name="Mirinda",Price=10}
        };


        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public void deleteProduct(int Id)
        {
            products.Remove(products.FirstOrDefault(x => x.Id == Id));
        }

        public List<Product> getAllProduct()
        {

            return products;
        }

        public Product GetProductById(int Id)
        {
            return products.Any(x => x.Id == Id) ? products.Find(x => x.Id == Id) : null;
        }

        public Product UpdateProduct(int Id, Product product)
        {
            products[Id] = product;
            return product;
        }
    }
}
