namespace DocPlannerTest.Entities.GetAvailability;

public class DayOfWeek
{
    public WorkPeriod WorkPeriod { get; set; }
    public List<BusySlot> BusySlots { get; set; }
}