namespace DocPlannerTest.Entities;

public class Facility
{
    //TODO check if nullable reference type is required here
    public Guid FacilityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}