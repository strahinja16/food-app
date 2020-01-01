using FoodApp.DbContexts;
using FoodApp.Repository;
using FoodApp.Repository.Interfaces;
using FoodApp.Schema.Input.User;
using FoodApp.Schema.Model;
using FoodApp.Schema.Mutation;
using FoodApp.Schema.Query;
using FoodApp.Service;
using FoodApp.Service.Interfaces;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            // Add GraphQL Services
            services.AddGraphQL(sb => SchemaBuilder.New()
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .AddType<UserType>()
                .AddServices(sb)
                .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL("/graphql");


            //app
            //    .UseGraphQLHttpPost(new HttpPostMiddlewareOptions { Path = "/graphql" })
            //    .UseGraphQLHttpGetSchema(new HttpGetSchemaMiddlewareOptions { Path = "/graphql/schema" });
        }
    }
}
