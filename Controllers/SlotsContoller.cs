using DocPlannerTest.Entities.TakeSlot;
using DocPlannerTest.Managers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DocPlannerTest.Controllers;

public class SlotsController(IDoctorAvailabilityManager doctorManager) : BaseApiController
{
    [HttpGet("{date}")]
    public async Task<IActionResult> GetWeeklyAvailability(string date)
    {
        var result = await doctorManager.GetAvailability(date);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> TakeSlot(Slot slot)
    {
        var result = await doctorManager.TakeSlot(slot);
        return HandleResult(result);
    }
}