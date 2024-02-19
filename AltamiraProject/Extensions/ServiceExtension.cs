using Contracts;
using Contracts.Repository;
using Contracts.Services;
using Entities;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using Repository;
using Services;
using Swashbuckle.AspNetCore.Filters;
using System.Runtime.CompilerServices;
using System.Text;

namespace AltamiraProject.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration config)
        {
            var key = config["Jwt:Key"] ?? string.Empty;

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudience = config["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
           services.AddSingleton<ILoggerManager,LoggerManager>();           
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();

        }
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:sqlConnection"];

            services.AddDbContext<RepositoryContext>(o => 
            {
                o.UseSqlServer(connectionString);
                o.EnableSensitiveDataLogging();
            });
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                option.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService,AccountService>();
        }
    }

}
