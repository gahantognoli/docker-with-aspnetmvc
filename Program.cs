using Microsoft.EntityFrameworkCore;
using mvc1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

var host = Environment.GetEnvironmentVariable("DBHOST") ?? "localhost";
var port =  Environment.GetEnvironmentVariable("DBPORT") ?? "3306";
var password = Environment.GetEnvironmentVariable("DBPASSWORD") ?? "numsey";

var connectionString = $"server={host};user=root;password={password};database=produtosdb;SslMode=None;";
var serverVersion = new MySqlServerVersion(new Version(5, 7));

builder.Services.AddDbContext<AppDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion, options => {})
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

builder.Services.AddTransient<IRepository, ProdutoRepository>();

var app = builder.Build();

// PopulaDb.IncluiDadosDB(app);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
