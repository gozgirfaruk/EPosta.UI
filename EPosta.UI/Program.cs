using EPosta.Business.Abstract;
using EPosta.Business.Concrete;
using EPosta.DataAccess.Abstract;
using EPosta.DataAccess.Concrete;
using EPosta.DataAccess.EntityFramework;
using EPosta.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EPostaContext>();

builder.Services.AddScoped<IAppMessageDal,EfAppMessageDal>();
builder.Services.AddScoped<IAppMessageService,AppMessageMenager>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<EPostaContext>();

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
app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
