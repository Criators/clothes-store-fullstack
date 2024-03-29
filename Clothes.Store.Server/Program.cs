using Clothes.Store.Application.Interfaces;
using Clothes.Store.Domain.Models;
using Clothes.Store.Domain.Validators.Custumer;
using Clothes.Store.Repository;
using Clothes.Store.Repository.Repository;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
//using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region DbContext
var connection = builder.Configuration.GetConnectionString("ClothesStore");
builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(connection, b => b.MigrationsAssembly("Clothes.Store.Server")));
// builder.Services.AddDbContext<DBContext>(o => o.UseInMemoryDatabase("ClothesStore"));
#endregion

#region Managemente objects
builder.Services.AddAutoMapper(typeof(CustumerProfile).Assembly);
#endregion

#region Interface and Repository
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(GenericRepository<>));
builder.Services.AddSingleton<ICustumer, CustumerRepository>();
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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
