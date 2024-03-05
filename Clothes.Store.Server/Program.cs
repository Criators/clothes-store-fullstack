using Clothes.Store.Application.Interfaces;
using Clothes.Store.Application.Interfaces.Services;
using Clothes.Store.Application.Models;
using Clothes.Store.Application.Validators.Custumer;
using Clothes.Store.Repository;
using Clothes.Store.Repository.Repository;
using Clothes.Store.Repository.Services;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Serilog;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region DbContext
var connection = builder.Configuration.GetConnectionString("ClothesStore");
builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(
    connection,
    b => b.MigrationsAssembly("Clothes.Store.Server")
    ));

// builder.Services.AddDbContext<DBContext>(o => o.UseInMemoryDatabase("ClothesStore"));
#endregion

#region Management objects
builder.Services.AddAutoMapper(typeof(CustumerProfile).Assembly);
#endregion

#region Interface and Repository
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICustumer, CustumerRepository>();
#endregion

#region Services
builder.Services.AddScoped<ICustumerService, CustumerService>();
builder.Services.AddScoped<ITokenService, TokenService>();
#endregion

#region Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
#endregion

builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<AddCustumerValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ClothesStore",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Allan, \nArthur, \nTM, \nCamargo",
            Email = "lima.allancontato@gmail.com",
            Url = new Uri("https://github.com/Criators/clothes-store-fullstack")
        }
    });

    var xmlFile = "Clothes.Store.Server.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();