using PicPaySimplificado.Infra;
using PicPaySimplificado.Repositories;
using PicPaySimplificado.Services;
using PicPaySimplificado.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<CarteiraRepository>();
builder.Services.AddScoped<CarteiraService>();

builder.Services.AddScoped<TransacaoRepository>();
builder.Services.AddScoped<TransacaoService>();

builder.Services.AddScoped<EncontrarCarteira>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();