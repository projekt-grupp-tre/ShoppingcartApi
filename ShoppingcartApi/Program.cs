using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace ShoppingcartApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
			builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
			builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
			builder.Services.AddScoped<ICartItemService, CartItemService>();


            var connectionString = builder.Configuration["Connectionstrings:Database"];
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

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
		}
	}
}
