namespace SHAREK.Domain.Features.Reports.Entities;

public sealed class ReportType
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string TypeName { get; set; } = string.Empty;
}
