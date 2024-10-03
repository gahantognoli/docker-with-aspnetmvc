using Microsoft.EntityFrameworkCore;
using mvc1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

var host = builder.Configuration["DBHOST"] ?? "0.0.0.0";
var port = builder.Configuration["DBPORT"] ?? "3306";
var password = builder.Configuration["DBPASSWORD"] ?? "numsey";
builder.Services.AddDbContext<AppDbContext>(options 
    => options.UseMySql(ServerVersion.AutoDetect($"Server={host};Database=produtosdb;User=root;Password={password};")));

builder.Services.AddTransient<IRepository, ProdutoRepository>();

var app = builder.Build();

PopulaDb.IncluiDadosDB(app);

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
