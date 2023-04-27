using Microsoft.EntityFrameworkCore;
using ThreeLayerArchitecture.BAL;
using ThreeLayerArchitecture.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<MvcprojectContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ThreeLayerMVC")
    ));


builder.Services.AddScoped<IUserRepository, UserRepositorySQLDB>();

//IUserRepository userRepository;
//UserRepositorySQLDB userRepositorySQLDB = new UserRepositorySQLDB();
//userRepository = userRepositorySQLDB;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
