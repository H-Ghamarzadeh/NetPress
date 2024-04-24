using HGO.Hub;
using NetPress.Application.Contracts.Persistence;
using NetPress.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHgoHub(configuration =>
{
    configuration.HubServiceLifetime = ServiceLifetime.Scoped;
    configuration.HandlersDefaultLifetime = ServiceLifetime.Scoped;
    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); //Register NetPress Assembly
    configuration.RegisterServicesFromAssemblyContaining<IPostRepository>(); //Register NetPress.Application Assembly
});

builder.Services.AddNetPressPersistenceServices(builder.Configuration);

// generate lowercase URLs
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

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

//Generate Fake Data for DataBase
DbInitializer.Seed(app);

app.Run();
