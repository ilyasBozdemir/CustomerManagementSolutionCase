using CustomerManagement.Persistence;
using CustomerManagement.Application;
using CustomerManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

#region Katmanlarýn servis kayýtlarý

builder.Services.AddApplicationRegistration();
await builder.Services.AddPersistenceRegistration();
builder.Services.AddInfrastructureServices();

#endregion




builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
