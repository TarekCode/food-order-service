using food_order_service.Data_layer;
using food_order_service.Data_layer.Repositories;
using food_order_service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FoodServiceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("food-db")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Configuration["USE_SWAGGER"]?.ToLower() == "true")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
