using GraphQLProject.Model;
using System.Collections.Generic;

namespace GraphQLProject.Intefaces
{
    public interface IproductServices
    {
        List<Product> getAllProduct();
        Product AddProduct(Product product);
        Product UpdateProduct(int Id, Product product);
        void deleteProduct(int Id);
        Product GetProductById(int Id);
    }
}
