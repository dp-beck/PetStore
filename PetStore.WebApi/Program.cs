using PetStore.Data;
using System.Text.Json.Serialization;
using PetStore.WebApi.Logic;

var builder = WebApplication.CreateBuilder(args);

//Add Services
builder.Services.AddControllers().AddJsonOptions(x => 
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddTransient<IProductLogic, ProductLogic>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderLogic, OrderLogic>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => {
    return  Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
});

app.Run();
