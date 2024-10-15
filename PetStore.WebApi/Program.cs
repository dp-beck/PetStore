using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetStore;
using PetStore.ConsoleApp.Logic;
using PetStore.Data;
using PetStore.Data.Models;
using System.ComponentModel;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

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
