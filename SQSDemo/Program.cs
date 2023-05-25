using Amazon.SQS;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SQSDemo.Helpers;
using SQSDemo.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var appSettingsSection = Configuration.GetSection("ServiceConfiguration");
builder.Services.AddAWSService<IAmazonSQS>();
//builder.Services.Configure<ServiceConfiguration>(appSettingsSection);
builder.Services.AddTransient<IAWSSQSService, AWSSQSService>();
builder.Services.AddTransient<IAWSSQSHelper, AWSSQSHelper>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

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
