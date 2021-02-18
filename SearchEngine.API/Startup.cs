using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SearchEngine.Core.AppServices;
using SearchEngine.Core.AppServices.Implementation;
using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using SearchEngine.Infrastructure;

namespace SearchEngine.API
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
            services.Configure<SearchEngineDatabaseSettings>(Configuration.GetSection(nameof(SearchEngineDatabaseSettings)));

            services.AddSingleton<ISearchEngineDatabaseSettings, SearchEngineDatabaseSettings>(sp => 
                sp.GetRequiredService<IOptions<SearchEngineDatabaseSettings>>().Value);

            services.AddScoped<IDocumentRepo, DocumentRepo>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IClient, Client>();


            services.AddControllers();

            services.AddMvc();
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
        }
    }
}
