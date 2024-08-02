using System.Text;
using System.Text.Json;
using DocPlannerTest.Entities.Core;
using DocPlannerTest.Entities.GetAvailability;
using DocPlannerTest.Entities.TakeSlot;
using DocPlannerTest.Managers.Abstract;

namespace DocPlannerTest.Managers.Concrete;

public class DoctorAvailabilityManager(IHttpClientFactory clientFactory) : IDoctorAvailabilityManager
{
    private readonly HttpClient _httpClient = clientFactory.CreateClient("draliatest");

    public async Task<Result<AvailabilityInfo>> GetAvailability(string date)
    {
        var response = await _httpClient.GetAsync($"GetWeeklyAvailability/{date}");
        var repsString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) 
            return Result<AvailabilityInfo>.Failure($"Error getting doctor's availability. {repsString}");

        var data = JsonSerializer.Deserialize<AvailabilityInfo>(repsString);
        return Result<AvailabilityInfo>.Success(data);
    }

    public async Task<Result<bool>> TakeSlot(Slot slot)
    {
        var json = JsonSerializer.Serialize(slot);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("TakeSlot", content);

        if (response.IsSuccessStatusCode)
        {
            return Result<bool>.Success(true);
        }
        var responseContentText = await response.Content.ReadAsStringAsync();
        return Result<bool>.Failure(responseContentText);
    }
}