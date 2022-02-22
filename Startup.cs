using ArtGallery.Data;
using ArtGallery.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Other DI initializations
            services.AddCors();
            //services.AddMvc();
            //"Host=localhost:5432;Database=test;Username=postgres;Password=postgres"
            services.AddDbContext<ArtGalleryDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ArtDb")));
            services.AddScoped<IArtProvider, ArtProvider>();
            services.AddControllers();

        }
    }
}
