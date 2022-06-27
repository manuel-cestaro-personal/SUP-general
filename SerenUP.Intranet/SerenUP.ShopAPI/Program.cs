using SerenUP.ApplicationCore.Interfaces;
using SerenUP.Infrastructure.Data;
using SerenUP.Services.Interfaces;
using SerenUP.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IWatchService, WatchService>();
builder.Services.AddSingleton<IWatchRepository, WatchRepository>();

builder.Services.AddSingleton<ICartService,CartService>();
builder.Services.AddSingleton<ICartRepository, CartRepository>();

builder.Services.AddSingleton<IAccessoryService, AccessoryService>();
builder.Services.AddSingleton<IAccessoryRepository, AccessoryRepository>();

builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

builder.Services.AddSingleton<ICartAccessoryService, CartAccessoryService>();
builder.Services.AddSingleton<ICartAccessoryRepository, CartAccessoryRepository>();


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
