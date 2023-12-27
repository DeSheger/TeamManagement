using System.Text;
using Application.Activities;
using API.Services;
using API.Services.AuthorizationServices;
using Application.AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Configuration;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(opt=>{
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        });

        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "TeamManagementSwagger", Version = "v1" }); 
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        { 
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        services.AddDbContext<DataContext>(opt => 
        {
            opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddCors(opt => {
            opt.AddPolicy("CorsPolicy",policy => {
                policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
            });
        });

        services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
        }).AddEntityFrameworkStores<DataContext>();

        var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(configuration["TokenKey"] ?? throw new OperationCanceledException()));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt => {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        services.AddScoped<TokenService>();

        services.AddTransient<IAuthorizationHandler, CompanyLeaderAuthorizationHandler>();
        
        services.AddTransient<IAuthorizationHandler, GroupLeaderAuthorization>();
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("IsLeaderInCompany", policy =>
                policy.Requirements.Add(new CompanyLeaderRequirement())
            );
        
        options.AddPolicy("IsLeaderInGroup", policy =>
            policy.Requirements.Add(new GroupLeaderRequirement()));
        });
                    
        services.AddSingleton<IAuthorizationHandler, CompanyLeaderAuthorizationHandler>();
        
        services.AddSingleton<IAuthorizationHandler, GroupLeaderAuthorization>();
        
        services.AddMediatR(typeof(List.Handler));

        services.AddAutoMapper(typeof(MappingProfile));
    }

    public static async void ConfigureServices(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("CorsPolicy");
        
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}