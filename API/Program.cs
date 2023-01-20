using API.Middleware;
using Negocio;
using Repositorio;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AgregarNegocioDI();
builder.Services.AgregarRepositorioDI(builder.Configuration);

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

app.UseMiddleware<GestionExcepcionesMiddleware>();

app.MapControllers();

app.Run();
