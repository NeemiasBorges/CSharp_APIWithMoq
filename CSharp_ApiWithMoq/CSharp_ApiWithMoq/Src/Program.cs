using CSharp_ApiWithMoq.Data;
using CSharp_ApiWithMoq.Data.Interface;
using CSharp_ApiWithMoq.Src.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Feriados", Version = "v1" });
});

builder.Services.AddScoped<FeriadosService>();
builder.Services.AddScoped<IFeriadoRepository, FeriadosRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Feriados V1");
    c.RoutePrefix = "swagger"; 
});

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
