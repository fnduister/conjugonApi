using AutoMapper;
using ConjugonApi.Configuration.Options;
using ConjugonApi.Core;
using ConjugonApi.Core.Interfaces;
using ConjugonApi.Filters;
using ConjugonApi.Models;
using ConjugonApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Options;

namespace ConjugonApi.Configuration.Extensions
{

    [ExcludeFromCodeCoverage]
    public static class ServiceStartupExtensions
    {
        public static void ConfigureBuilder(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            var kestrelKeepAliveTimeout = double.Parse(builder.Configuration["Kestrel:KeepAliveTimeoutMinutes"] ?? Constants.Kestrel.KeepAliveTimeoutMinutes);
            builder.WebHost.ConfigureKestrel(opts => opts.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(kestrelKeepAliveTimeout));

            Log.Logger = new LoggerConfiguration().CreateLogger();

            builder.Host.UseSerilog();

            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                System.Diagnostics.Debug.WriteLine(msg);
            });

            services.AddLogging(x =>
            {
                x.ClearProviders();
                x.AddSerilog(dispose: true);
            });

            var mapper = new MapperConfiguration(e => e.AddProfile(new AutoMapperProfiles()));

            services.AddSingleton(mapper.CreateMapper());

            services.AddSingleton(Log.Logger);
            services.AddScoped<DomainWork>();
        }

        public static void ConfigureJwt(this WebApplicationBuilder builder)
        {

            var config = builder.Configuration;

            //Authentication JWT Bearer
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["JwtSettings:Key"] ?? "")),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
        }

        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

            builder.Services.AddScoped<DomainWork>();

            builder.Services.AddScoped<VerbsService>();
            
            builder.Services.AddScoped<UsersService>();


        }

        public static void ConfigureMongo(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddOptions<MongoSettings>()
                .Bind(builder.Configuration.GetSection(MongoSettings.SectionName));
        }
        public static void ConfigureSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(
                options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ConjugonApi",
                    Version = "v1"
                });
            });
        }

        public static void ConfigureApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
        }

        public static string GetString(this WebApplicationBuilder builder, string key)
        {
            return builder.Configuration.GetValue<string>(key) ?? throw new KeyNotFoundException($"Configuration not found (key={key}).");
        }
    }

}
