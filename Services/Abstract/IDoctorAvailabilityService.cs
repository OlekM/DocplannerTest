using DocPlannerTest.Entities.Core;
using DocPlannerTest.Entities.GetAvailability;
using DocPlannerTest.Entities.TakeSlot;

namespace DocPlannerTest.Services.Abstract;
public interface IDoctorAvailabilityService
{
    public Task<Result<AvailabilityInfo>> GetAvailability(string date);
    public Task<Result<bool>> TakeSlot(Slot slot);
}