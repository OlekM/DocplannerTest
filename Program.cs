using DocPlannerTest.Entities.Core;
using DocPlannerTest.Managers.Abstract;
using DocPlannerTest.Managers.Concrete;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
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
builder.Services.AddScoped<IDoctorAvailabilityManager, DoctorAvailabilityManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();
app.MapControllers();
app.Run();