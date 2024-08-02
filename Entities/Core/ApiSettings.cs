﻿namespace DocPlannerTest.Entities.Core;

public class ApiSettings
{
    public const string ConfigurationSection = "ApiSettings";
    public string BaseUrl { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}