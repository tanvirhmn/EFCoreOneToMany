

using EFCorePractice.Data;
using Microsoft.EntityFrameworkCore;

var pacticeAllowedOrigins = "_inspectionAllowedOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PracticeDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PracticeConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: pacticeAllowedOrigins,
    builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(pacticeAllowedOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
