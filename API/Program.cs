using Application.Activities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.Extensions.DependencyInjection;

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

builder.Services.AddMediatR(typeof(List.Handler));

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
    context.Database.Migrate();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error durring migration");
}


                            // Running API
app.Run();
