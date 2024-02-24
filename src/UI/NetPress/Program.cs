using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NetPress.Domain.Repository;
using NetPress.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// MongoDB configuration
var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
var client = new MongoClient(mongoDbSettings.ConnectionString);
var database = client.GetDatabase(mongoDbSettings.DatabaseName);

// Register the MongoDB context or direct collections
builder.Services.AddSingleton(database);

// Register the generic repository for dependency injection
// Note: You might need a factory or custom logic to handle collection names for different types
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
