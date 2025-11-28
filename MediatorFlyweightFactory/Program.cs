using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using MediatorFlyweightFactory.FlyWeight.Factory;
using MediatorFlyweightFactory.Mediator;
using MediatorFlyweightFactory.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    try
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MediatorFlyweigthFactory", Version = "v1" });

        //Добавляем схему авторизации
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Введите токен в формате: Bearer {токен}",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        
    }
    catch (Exception ex)
    {
        Console.WriteLine("Swagger ex: " + ex.Message);
        throw;
    }
});


// DI
builder.Services.AddSingleton<RoleFactory>();
builder.Services.AddSingleton<IMediator, Mediator>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthService API V1");
    c.RoutePrefix = string.Empty;
});

app.UseCors();
app.UseRouting();
app.MapControllers();


app.Run();