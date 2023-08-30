using Application.Activities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using Microsoft.AspNetCore.Identity;
using Application.Mapping;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

                        //// Add services to the container ////

builder.Services.AddControllers(opt=>{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

                                // Swagger for now

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

                              // Connections with DB

builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

                    // Until client-app is in developement stage

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy",policy => {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

                    // Add UserIdentity and Authentication

builder.Services.AddIdentityCore<User>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<DataContext>();

var key = new SymmetricSecurityKey(Encoding.UTF8
    .GetBytes(builder.Configuration["TokenKey"]));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddScoped<TokenService>();


builder.Services.AddMediatR(typeof(List.Handler));

                        // Add AutoMapper to DI

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

                    // Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

                        // Seed data and migartions for DB

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetService<UserManager<User>>();
    context.Database.Migrate();
    await Seed.SeedData(context, userManager);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error durring migration");
}


                            // Running API
app.Run();
