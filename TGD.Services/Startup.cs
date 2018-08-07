using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RH.CrossCutting.Logging;
using RH.Infrastructure.BaseContext;
using RH.Infrastructure.BaseContext.Enumerations;
using RH.Infrastructure.SessionFactories;
using RH.Persistence.Base.Classes;
using RH.Persistence.Base.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using TGD.Application.ApplicationServices.Place;
using TGD.Domain.DomainServices.Place;
using TGD.Persistence.Entities.Place;
using TGD.Persistence.Mappings.Place;


namespace TGD.Services
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
            //services.AddCors<ICorsHandler, CorsHandler>();
            //Setting up CORS           
            services.AddCors();


            //Place
            services.AddScoped<IPlaceApplicationServices, PlaceApplicationServices>();
            services.AddScoped<IPlaceDomainServices, PlaceDomainServices>();

            //Repositories
            services.AddScoped<IRepository<PlaceEntity>, Repository<PlaceEntity>>();
            services.AddScoped<IPlaceMap, PlaceMap>();


            services.AddScoped<ILogger, Logger>();
            services.AddScoped<ISessionFactoriesManager, SessionFactoriesManager>();
            services.AddSingleton<BasicEntity>();

            ISessionFactoriesManager sessionFactoriesManager = new SessionFactoriesManager();
            var connectionString = Configuration["Logging:DbContextSettings:ConnectionString"];

            sessionFactoriesManager.AddSessionFactoryForNamespaceOf<IPlaceEntity, IPlaceMap>(EAvailableDBMS.PostgreSQL.ToString(), connectionString, true, true, true);
            services.AddSingleton(sessionFactoriesManager);

            services.AddScoped<IDBCurrentSessionContext, CurrentNhSessionContext>();
            //services.AddSingleton<AppSessionFactory>();
            //services.AddScoped(x => x.GetService<AppSessionFactory>().OpenSession());



            services.AddMvc();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "My template",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Hamida REBAI", Email = "didourebai@gmail.com", Url = "www.http://rebai-hamida.azurewebsites.net/.com" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
