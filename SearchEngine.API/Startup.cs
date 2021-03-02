using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SearchEngine.Core.ApplicationServices;
using SearchEngine.Core.ApplicationServices.Services;
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
            services.AddCors(options => {
                options.AddPolicy("AllowAny",
                builder => {
                    builder.WithOrigins("http://localhost:3000");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowCredentials();
                });
            });

            services.Configure<SearchEngineDatabaseSettings>(Configuration.GetSection(nameof(SearchEngineDatabaseSettings)));

            services.AddSingleton<ISearchEngineDatabaseSettings, SearchEngineDatabaseSettings>(sp => 
                sp.GetRequiredService<IOptions<SearchEngineDatabaseSettings>>().Value);

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>(); 
            services.AddScoped<ITermRepository, TermRepository>();
            services.AddScoped<ITermService, TermService>();
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

            app.UseCors("AllowAny");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
