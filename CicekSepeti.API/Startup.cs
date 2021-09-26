using CicekSepeti.Application.Basket.Handlers.CommandHandlers;
using CicekSepeti.Application.Product.Handlers.CommandHandlers;
using CicekSepeti.Application.Stock.Handlers.CommandHandlers;
using CicekSepeti.Application.User.Handlers.CommandHandlers;
using CicekSepeti.Core.Repositories;
using CicekSepeti.Core.Repositories.Base;
using CicekSepeti.Infrastructure.Data;
using CicekSepeti.Infrastructure.Repositories;
using CicekSepeti.Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CicekSepeti.API
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
            services.AddControllers();
            services.AddDbContext<CicekSepetiContext>(
                 m => m.UseSqlite(Configuration.GetConnectionString("CicekSepetiDB")), ServiceLifetime.Scoped);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CicekSepeti.API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateBasketHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateUserHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateProductHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateStockHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CicekSepeti.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
