using Application.Activities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using Microsoft.AspNetCore.Identity;
using Application.Mapping;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

                        //// Add services to the container ////

builder.Services.AddControllers();/*.AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);*/

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

builder.Services.AddAuthentication();

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
