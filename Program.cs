using DotNet_React_CopaDoMundo.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=copadomundo.db"));

var app = builder.Build();

if (app.Environment.IsDevelopment())

{

app.MapOpenApi();

}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();