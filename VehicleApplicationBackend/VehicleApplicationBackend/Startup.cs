using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehicleApplicationBackend.Repositories;
using VehicleApplicationBackend.Services;

namespace VehicleApplicationBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            PopulateSettings();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IVehicleRepository, VehicleRespository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void PopulateSettings()
        {
            Settings.ConnectionString = Configuration.GetConnectionString("main");
        }
    }
}
