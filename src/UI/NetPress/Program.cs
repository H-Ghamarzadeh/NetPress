using HGO.Hub;
using NetPress.Application.Contracts.Persistence;
using NetPress.Persistence;
using System.Reflection;
using HGO.Hub.Interfaces;
using NetPress.Application.Actions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHgoHub(configuration =>
{
    configuration.HubServiceLifetime = ServiceLifetime.Scoped;
    configuration.HandlersDefaultLifetime = ServiceLifetime.Scoped;
    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); //Register NetPress Assembly
    configuration.RegisterServicesFromAssemblyContaining<IPostRepository>(); //Register NetPress.Application Assembly
    configuration.RegisterServicesFromAssemblyContaining<NetPressDbContext>(); //Register NetPress.Application Assembly
});

builder.Services.AddNetPressPersistenceServices(builder.Configuration);

// generate lowercase URLs
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

//Do all registered actions after build the application
app.Services.CreateScope().ServiceProvider.GetRequiredService<IHub>().DoActionAndHandleExceptionsAsync(new AfterBuildApplicationAction(app));

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

//Do all registered actions before run the application (e.g.: DbInitializer)
app.Services.CreateScope().ServiceProvider.GetRequiredService<IHub>().DoActionAndHandleExceptionsAsync(new BeforeAppRunAction(app));

app.Run();

//Do all registered actions after run the application
app.Services.CreateScope().ServiceProvider.GetRequiredService<IHub>().DoActionAndHandleExceptionsAsync(new AfterAppRunAction(app));
