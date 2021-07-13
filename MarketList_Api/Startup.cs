using System.IO;
using MarketList_Business;
using MarketList_Business.Interfaces;
using MarketList_Data;
using MarketList_Repository;
using MarketList_Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MarketList_Api
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
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<MarketListContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItemBL, ItemBL>();
            services.AddTransient<IItemListaRepository, ItemListaRepository>();
            services.AddTransient<IItemListaBL, ItemListaBL>();
            services.AddTransient<IListaRepository, ListaRepository>();
            services.AddTransient<IListaBL, ListaBL>();
            services.AddTransient<IPerfilUsuarioRepository, PerfilUsuarioRepository>();
            services.AddTransient<IPerfilUsuarioBL, PerfilUsuarioBL>();
            services.AddTransient<ISessaoRepository, SessaoRepository>();
            services.AddTransient<ISessaoBL, SessaoBL>();
            services.AddTransient<IStatusItemListaRepository, StatusItemListaRepository>();
            services.AddTransient<IStatusItemListaBL, StatusItemListaBL>();
            services.AddTransient<IStatusUsuarioRepository, StatusUsuarioRepository>();
            services.AddTransient<IStatusUsuarioBL, StatusUsuarioBL>();
            services.AddTransient<IUnidadeRepository, UnidadeRepository>();
            services.AddTransient<IUnidadeBL, UnidadeBL>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioBL, UsuarioBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseCors(options =>
                options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
        }
    }
}
