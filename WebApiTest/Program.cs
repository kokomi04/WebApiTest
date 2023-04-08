using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiTest.EF;
using WebApiTest.Entities;
using WebApiTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
                option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Life cycle DI: AddSingleton(), AddTransient(), AddScoped()
builder.Services.AddTransient<IProductServices, ProductServices>();
//builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
//builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
//builder.Services.AddTransient<RoleManager<IdentityRole>, RoleManager<IdentityRole>>();

//builder.Services.AddTransient<IRoleService, RoleService>();
//builder.Services.AddTransient<IUserService, UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
