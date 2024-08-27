using Concs.Id;
using Concs.Id.Configs;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfigurationSection webConfigSettingsSection = builder.Configuration.GetSection(nameof(WebConfig));

var webConfig = webConfigSettingsSection.Get<WebConfig>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencies(builder.Configuration);


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(webConfig.Policy,
                      policy =>
                      {
                          policy.WithOrigins(webConfig.Origin);
                      });
});

var app = builder.Build();

await app.AddMigrationsAsync();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(webConfig.Policy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();