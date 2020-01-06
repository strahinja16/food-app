using FoodApp.DbContexts;
using FoodApp.Graphql.ErrorFIlter;
using FoodApp.Graphql.Mutation;
using FoodApp.Graphql.Query;
using FoodApp.Graphql.Type;
using FoodApp.Repository;
using FoodApp.Repository.Interfaces;
using FoodApp.Services;
using FoodApp.Services.Interfaces;
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
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<ITagRepository, TagRepository>();

            services.AddScoped<IMutationService, MutationService>();


            // Add GraphQL Services
            services.AddGraphQL(sb =>
            {
                var schema = SchemaBuilder.New()
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .AddType<UserType>()
                .AddType<RecipeType>()
                .AddType<TagType>()
                .AddServices(sb)
                .Create();

                schema.MakeExecutable(new QueryExecutionOptions
                {
                    IncludeExceptionDetails = true
                });

                return schema;
            });

            services.AddDataLoaderRegistry();

            services.AddErrorFilter<ExceptionErrorFilter>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL("/graphql");
        }
    }
}
