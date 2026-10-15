
using Microsoft.EntityFrameworkCore;
using ProiectPractica.DBModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=CozyStayDB;Server=DESKTOP-3D5AP7A\\SQLEXPRESS01;Encrypt=True;TrustServerCertificate=true;";
builder.Services.AddDbContext<CozyStayDBContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
