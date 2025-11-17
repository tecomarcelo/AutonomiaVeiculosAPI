using AutonomiaVeiculosAPI.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddCorsPolicy();

var app = builder.Build();

app.UseSwaggerDoc();

app.UseAuthorization();
app.UseCorsPolicy();

app.MapControllers();

app.Run();
