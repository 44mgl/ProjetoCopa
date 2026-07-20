using DotNet_React_CopaDoMundo.Data;
using Microsoft.EntityFrameworkCore;
using DotNet_React_CopaDoMundo.Services;
using DotNet_React_CopaDoMundo.Services.Interfaces;
using DotNet_React_CopaDoMundo.Services.Clube;
using DotNet_React_CopaDoMundo.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte para explorar endpoints da API, permitindo a geração de documentação e testes interativos usando ferramentas como Swagger.
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=copadomundo.db"));

builder.Services.AddScoped<ISelecaoService, SelecaoService>(); // Quando alguem solicitar ISelecaoService, crie e entregue um SelecaoService.
builder.Services.AddScoped<IClubeService, ClubeService>(); // Quando alguem solicitar IClubeService, crie e entregue um ClubeService.

var app = builder.Build();

if (app.Environment.IsDevelopment())

{

app.UseSwagger();
app.UseSwaggerUI();
app.MapOpenApi();

}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

