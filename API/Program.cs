using Negocio;
using Repositorio;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AgregarNegocioDI();
builder.Services.AgregarRepositorioDI();

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
