using ApiCityEvents.Core.Interface;
using ApiCityEvents.Core.Service;
using ApiCityEvents.Data.Repository;
using ApiCityEvents.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<LogAuthorizationGenerateCode>();
    options.Filters.Add<GeneralExceptionFilter>();
});

builder.Services.AddScoped<ICityEventRepository, CityEventRepository>();
builder.Services.AddScoped<ICityEventService, CityEventService>();
builder.Services.AddScoped<LogActionFilterCheckExictsCityEventForId>();

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
