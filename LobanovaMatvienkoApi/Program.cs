using LobanovaMatvienkoApi.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddOpenApiDocument();

const string connection = "DESKTOP-1C0DJTF\\SQLEXPRESS;Database=LobMatPract;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContextFactory<ClientContext>(o => o.UseSqlServer(connection));
builder.Services.AddDbContextFactory<GymContext>(o => o.UseSqlServer(connection));
builder.Services.AddDbContextFactory<SubscriptionContext>(o => o.UseSqlServer(connection));
builder.Services.AddDbContextFactory<TrainerContext>(o => o.UseSqlServer(connection));
builder.Services.AddDbContextFactory<WorkoutContext>(o => o.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
