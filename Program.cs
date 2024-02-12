using KoktelosAPIKezdemeny.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServerVersion sv = ServerVersion.AutoDetect("SERVER=127.0.0.1;USER=root;PASSWORD=;");
builder.Services.AddDbContext<Koktelok_Adatbazisa>(
   o => o.UseMySql("SERVER=127.0.0.1;USER=root;PASSWORD=;DATABASE=koktelok_adatbazisa;", sv)
);
builder.Services.AddControllers();
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
