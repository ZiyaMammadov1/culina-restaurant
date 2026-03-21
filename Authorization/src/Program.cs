using AuthService.Application.Repositories;
using AuthService.Application.Users;
using AuthService.Infrastructure;
using AuthService.Infrastructure.Middlewares;
using AuthService.Infrastructure.Profiles;
using AuthService.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

#region SeriLogConfiguration
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();
#endregion

#region MassTransitConfiguration
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"], h =>
        {
            h.Username(builder.Configuration["RabbitMQ:Username"]);
            h.Password(builder.Configuration["RabbitMQ:Password"]);
        });
    });
});
#endregion

#region Mediator
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<RegisterUserCommandHandler>();
});
#endregion

#region DependencyInjection
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

#region DbContext
builder.Services.AddDbContext<CulinaDbContext>(options => options.UseInMemoryDatabase("CulinaDb"));
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(cfg => { cfg.AddProfile<UserMappingProfile>(); });
#endregion

var app = builder.Build();


app.UseSerilogRequestLogging();
app.UseMiddleware(typeof(CorrellationMiddleware));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();