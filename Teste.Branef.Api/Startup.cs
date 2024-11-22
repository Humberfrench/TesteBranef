using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using static Teste.Branef.Ioc.Bootstraper;

namespace Teste.Branef.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
                options.DescribeAllParametersInCamelCase();
            });

            Initializer(services, Configuration);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger(c => c.SerializeAsV2 = true);

            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet("/themes/3.x/theme-feeling-blue.css");
                c.EnableTryItOutByDefault();

                c.DocumentTitle = "Teste.Branef";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste.Branef v1");
                c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
                var aspnetcore_urls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? string.Empty;

                var match = Regex.Match(aspnetcore_urls, @"(http:\/\/)([a-zA-Z0-9&_\.*-]{0,100})(:)([0-9]{0,5})");

                if (match.Success)
                {
                    var swaggerBaseRoute = aspnetcore_urls.Substring(match.Length, aspnetcore_urls.Length - match.Length);

                    if (!swaggerBaseRoute.StartsWith("/"))
                        swaggerBaseRoute = $"/{swaggerBaseRoute}";

                    if (!swaggerBaseRoute.EndsWith("/"))
                        swaggerBaseRoute = $"{swaggerBaseRoute}/";

                }
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
