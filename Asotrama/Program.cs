var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Agregar configuraci�n de sesi�n
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configurar el proveedor de configuraci�n
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Agregar middleware de sesi�n
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
