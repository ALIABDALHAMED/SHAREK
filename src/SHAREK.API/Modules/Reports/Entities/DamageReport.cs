namespace SHAREK.API.Modules.Reports.Entities;

public sealed class DamageReport
{
    public Guid ReportId { get; set; }
    public string? Photos { get; set; }
    public string? Video { get; set; }
}
