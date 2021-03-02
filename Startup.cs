using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using pruebaSellnowapi.Models;
using pruebaSellnowapi.Services;

namespace pruebaSellnowapi
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
            // requires using Microsoft.Extensions.Options
            services.AddCors();

            //Productos
            services.Configure<ProductosDatabaseSettings>(
            Configuration.GetSection(nameof(ProductosDatabaseSettings)));
            services.AddSingleton<IProductosDatabaseSettings>(sp => 
            sp.GetRequiredService<IOptions<ProductosDatabaseSettings>>().Value);
            services.AddSingleton<ProductService>();

            //Pedidos
            services.Configure<PedidoDatabaseSettings>(
            Configuration.GetSection(nameof(PedidoDatabaseSettings)));
            services.AddSingleton<IPedidoDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<PedidoDatabaseSettings>>().Value);
            services.AddSingleton<PedidoService>();

            //Clientes
            services.Configure<ClientesDatabaseSettings>(
            Configuration.GetSection(nameof(ClientesDatabaseSettings)));
            services.AddSingleton<IClientesDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<ClientesDatabaseSettings>>().Value);
            services.AddSingleton<ClientesService>();

            //Vendedor
            services.Configure<VendedorDatabaseSettings>(
            Configuration.GetSection(nameof(VendedorDatabaseSettings)));
            services.AddSingleton<IVendedorDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<VendedorDatabaseSettings>>().Value);
            services.AddSingleton<VendedorService>();

            //Admin
            services.Configure<AdminDatabaseSettings>(
            Configuration.GetSection(nameof(AdminDatabaseSettings)));
            services.AddSingleton<IAdminDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<AdminDatabaseSettings>>().Value);
            services.AddSingleton<AdminService>();

             //Carrito
            services.Configure<cartListDatabaseSettings>(
            Configuration.GetSection(nameof(cartListDatabaseSettings)));
            services.AddSingleton<IcartListDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<cartListDatabaseSettings>>().Value);
            services.AddSingleton<cartListService>();



            services.AddControllers();
         }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("https://localhost:3000");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
