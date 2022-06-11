using GraphQL;
using GraphQL.Types;
using GraphQLProject.Intefaces;
using GraphQLProject.Model;
using GraphQLProject.Type;

namespace GraphQLProject.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IproductServices productServices)
        {
            Field<ProductType>("Createproduct", arguments: new QueryArguments(new QueryArgument<ProductInputType>() { Name = "Product" }),
                 resolve: context =>
                 {
                     return productServices.AddProduct(context.GetArgument<Product>("Product"));
                 });
            Field<ProductType>("UpdateProduct", arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name = "id" }, new QueryArgument<ProductInputType>() { Name = "Product" }),
                resolve: context =>
                {
                    return productServices.UpdateProduct(context.GetArgument<int>("id"), context.GetArgument<Product>("Product"));
                });

           
            Field<StringGraphType>("DeleteProduct", arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name = "id" }),
             resolve: context =>
             {
                 var productID = context.GetArgument<int>("id");
                 productServices.deleteProduct(productID);
                 return $"these product with id: {productID} is deleted";
             });
        }
    }
}
