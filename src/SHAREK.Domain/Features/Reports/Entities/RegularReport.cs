namespace SHAREK.Domain.Features.Reports.Entities;

public sealed class RegularReport
{
    public Guid ReportId { get; set; }
    public string? PlatformIssueDetails { get; set; }
}
