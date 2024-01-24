using AspCoreAPI01_CURD.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DemoDBConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
//builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors((g) => g.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
   // app.UseCors(
   //    options => options.WithOrigins("http://localhost:3000/").AllowAnyMethod()
   //);
   // app.UseMvc();

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
