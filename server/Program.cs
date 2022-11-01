using server.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication;

// creating a builder
var builder = WebApplication.CreateBuilder(args);

// Adding services to the container.

// Default Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//---------------------
// AppleDB Service
builder.Services.AddDbContext<AppleDBContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppleDBContext") ?? throw new InvalidOperationException("Connection string 'AppleDBContext' not found.")
        ));
//---------------------
// CORS Service
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        });
});
//---------------------
// another CORS service
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//         policy =>
//         {
//             policy.WithOrigins("http://localhost:3000");
//         });
// });
//---------------------
// JWT Service
// builder.Services.AddAuthentication()
//         .AddCookie(options =>
//         {
//             options.LoginPath = "/Account/Unauthorized/";
//             options.AccessDeniedPath = "/Account/Forbidden/";
//         })
//         .AddJwtBearer(options =>
//         {
//             options.Audience = "http://localhost:5001/";
//             options.Authority = "http://localhost:5000/";
//         });
//---------------------


// running the builder
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Default Services
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// 
app.UseCors();
// app.UseStaticFiles();
// app.UseRouting();

app.Run();
