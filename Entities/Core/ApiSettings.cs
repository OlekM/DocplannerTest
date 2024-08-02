namespace DocPlannerTest.Entities.Core;

public class ApiSettings
{
    public const string ConfigurationSection = "ApiSettings";
    public string BaseUrl { get; init; }
    public string Username { get; init; }
    public string Password { get; init; }
}