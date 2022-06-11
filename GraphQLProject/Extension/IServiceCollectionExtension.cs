using GraphQL.Server;
using GraphQL.Types;
using GraphQLProject.Data;
using GraphQLProject.Intefaces;
using GraphQLProject.Mutations;
using GraphQLProject.Query;
using GraphQLProject.Schema;
using GraphQLProject.Services;
using GraphQLProject.Type;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLProject.Extension
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection addMyCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IproductServices, ProductDBServices>();
            services.AddScoped<ProductType>();
            services.AddScoped<ProductQuery>();
            services.AddScoped<ProductMutation>();
            services.AddScoped<ISchema, ProductSchema>();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;

            }).AddSystemTextJson();
            services.AddDbContext<GraphQLDbContext>(options =>
            {
                options.UseSqlServer("Data Source=10.6.7.11;User ID=basiljose;Password=Basil@123;Initial Catalog=GraphQLDB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            });

            return services;
        }
    }
}
