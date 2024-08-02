using DocPlannerTest.Entities.Core;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using DocPlannerTest.Services.Abstract;
using DocPlannerTest.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions<ApiSettings>()
    .BindConfiguration(ApiSettings.ConfigurationSection);
builder.Services.AddHttpClient("draliatest", (serviceProvider, httpClient) =>
{
    var apiSettings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;
    var byteArray = Encoding.ASCII.GetBytes($"{apiSettings.Username}:{apiSettings.Password}");

    httpClient.BaseAddress = new Uri(apiSettings.BaseUrl);
    httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
});
builder.Services.AddScoped<IDoctorAvailabilityService, DoctorAvailabilityService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();
app.MapControllers();
app.Run();