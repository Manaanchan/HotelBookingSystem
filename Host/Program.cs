using Application.Interfaces;
using Application.Repository;
using Application.Services;
using Infrastructure;
using Infrastructure.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HotelDbContext>(config => config.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingServices, BookingServices>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerServices>();
builder.Services.AddScoped<IPaymentRepository , PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentServices>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleServices>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomServices>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
