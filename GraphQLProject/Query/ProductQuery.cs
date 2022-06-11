using GraphQL;
using GraphQL.Types;
using GraphQLProject.Intefaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IproductServices productServices)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productServices.getAllProduct(); });
            Field<ProductType>("product", arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    return productServices.GetProductById(context.GetArgument<int>("id"));
                });
        }
    }
}
