using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SearchEngine.API.Core.ApplicationServices;
using SearchEngine.API.Core.ApplicationServices.Services;
using SearchEngine.API.Core.DomainServices;
using SearchEngine.API.Infrastructure;
using SearchEngine.API.Infrastructure.Client;
using SearchEngine.API.Infrastructure.Client.Database;

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

            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
            services.Configure<DatabaseMetadata>(Configuration.GetSection(nameof(DatabaseMetadata)));

            services.AddSingleton<IDatabaseSettings, DatabaseSettings>(sp => 
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddSingleton<IDatabaseMetadata, DatabaseMetadata>(sp => 
                sp.GetRequiredService<IOptions<DatabaseMetadata>>().Value);

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
