using DMS.Data;
using DMS.Data.EF.Interfaces;
using DMS.Objects;
using Microsoft.OpenApi.Models;

namespace DMS
{
    public static partial class IServiceCollectionExtensions
    {
        public static string SSOUserId = "Guest";

        public static void AddModelBuildProviders(this IServiceCollection services, IConfiguration config)
        {
            switch (config.GetSection("Settings")["DbType"])
            {
                case "sqlite":
                    services.AddTransient<IDMSModelBuildProvider, DMSSQLiteModelBuildProvider>();
                    break;
                default:
                    services.AddTransient<IDMSModelBuildProvider, DMSMSSQLModelBuildProvider>();
                    break;
            }
        }

        public static void AddAspNetCore(this IServiceCollection services)
        {
            _ = services.AddResponseCompression();
            _ = services.AddMvcCore(options =>
            {
                options.MaxIAsyncEnumerableBufferLimit = int.MaxValue;
                options.MaxModelBindingCollectionSize = 10000;
                options.MaxModelBindingRecursionDepth = 10;
            })
                .AddDataAnnotations()
                .AddCors(options => options.AddDefaultPolicy(builder =>
                {
                    _ = builder.AllowAnyHeader();
                    _ = builder.AllowAnyMethod();
                    _ = builder.SetIsOriginAllowed(origin => true);
                    _ = builder.AllowCredentials();
                }));
        }

        public static void AddMetadata(this IServiceCollection services)
        {
            _ = services.AddEndpointsApiExplorer();

            _ = services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = @"Authorization header using the Bearer scheme. \r\n\r\n 
                        Enter 'Bearer' [space] and then your token in the text input below.
                        \r\n\r\nExample: 'bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer"
                });
            });
        }

        public static void AddAuthInfo(this IServiceCollection services)
            => services.AddTransient<IDMSAuthInfo, DMSAuthInfo>(ctx =>  new DMSAuthInfo { SSOUserId = SSOUserId });
    }
}