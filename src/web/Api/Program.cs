using Api.Configurations;
using Infrastructure.Configurations;
using Infrastructure.Providers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllerConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidation();
builder.Services.AddSwagger();
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapper();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
using var scope = app.Services.CreateScope();
scope.RunMigration();

app.Run();