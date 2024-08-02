using DocPlannerTest.Entities.Core;
using DocPlannerTest.Entities.GetAvailability;
using DocPlannerTest.Entities.TakeSlot;

namespace DocPlannerTest.Managers.Abstract;
public interface IDoctorAvailabilityManager
{
    public Task<Result<AvailabilityInfo>> GetAvailability(string date);
    public Task<Result<bool>> TakeSlot(Slot slot);
}