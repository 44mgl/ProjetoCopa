using DotNet_React_CopaDoMundo.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte para explorar endpoints da API, permitindo a geração de documentação e testes interativos usando ferramentas como Swagger.
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=copadomundo.db"));
    
var app = builder.Build();

if (app.Environment.IsDevelopment())

{

app.UseSwagger();
app.UseSwaggerUI();
app.MapOpenApi();

}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();