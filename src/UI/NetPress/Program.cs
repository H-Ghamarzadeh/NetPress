using HGO.Hub;
using NetPress.Application.Contracts.Persistence;
using NetPress.Persistence;
using System.Reflection;
using HGO.Hub.Interfaces;
using NetPress.Application.Actions;
using NetPress.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var assemblies = GetAssembliesToRegister();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHgoHub(configuration =>
{
    configuration.HubServiceLifetime = ServiceLifetime.Scoped;
    configuration.HandlersDefaultLifetime = ServiceLifetime.Scoped;
    configuration.RegisterServicesFromAssemblies(assemblies.ToArray());
});

builder.Services.AddNetPressPersistenceServices(builder.Configuration);
builder.Services.AddNetPressInfrastructureServices(builder.Configuration);

// generate lowercase URLs
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

//Do all registered actions after build the application
await app.Services.CreateScope().ServiceProvider.GetRequiredService<IHub>().DoActionAsync(new AfterBuildApplicationAction(app), true);

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
app.UseAntiforgery();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Do all registered actions before run the application (e.g.: DbInitializer)
await app.Services.CreateScope().ServiceProvider.GetRequiredService<IHub>().DoActionAsync(new BeforeAppRunAction(app), true);

app.Run();

//Get all assemblies to register in the application
List<Assembly> GetAssembliesToRegister()
{
    var result = new List<Assembly>
    {
        Assembly.GetExecutingAssembly(), //Register NetPress Assembly
        typeof(IPostRepository).Assembly, //Register NetPress.Application Assembly
        typeof(NetPressDbContext).Assembly //Register NetPress.Application Assembly
    };

    return result;
}