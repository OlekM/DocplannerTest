using DocPlannerTest.Entities.TakeSlot;
using DocPlannerTest.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DocPlannerTest.Controllers;

public class SlotsController(IDoctorAvailabilityService doctorsService) : BaseApiController
{
    [HttpGet("{date}")]
    public async Task<IActionResult> GetWeeklyAvailability(string date)
    {
        var result = await doctorsService.GetAvailability(date);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> TakeSlot(Slot slot)
    {
        var result = await doctorsService.TakeSlot(slot);
        return HandleResult(result);
    }
}