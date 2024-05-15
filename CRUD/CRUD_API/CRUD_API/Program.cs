using CRUD_API.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((corsPolicy) =>
{
    corsPolicy.AddPolicy("MyPolicy", (options) =>
    {
        options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
}
);

builder.Services.AddDbContext<API_DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnectionString")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
