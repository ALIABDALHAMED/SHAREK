using SHAREK.Domain.Features.Reports.Enums;

namespace SHAREK.Domain.Features.Reports.Entities;

public sealed class Report
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ReportTypeId { get; set; }
    public Guid ReporterUserId { get; set; }
    public Guid? ProductId { get; set; }
    public Guid? OrderId { get; set; }
    public Guid? MessageId { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string? Comments { get; set; }
    public ReportStatus Status { get; set; } = ReportStatus.Open;
    public decimal? Penalty { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ResolvedAt { get; set; }
    public Guid? ResolvedByAdminId { get; set; }
    public string? ResolutionNote { get; set; }
}
