public class Report
{
    public int ReportId { get; set; }
    public int ReportTypeId { get; set; }
    public int ReporterUserId { get; set; }
    public int ProductId { get; set; }
    public string Reason { get; set; }
    public string Comments { get; set; }
    public double Penalty { get; set; }
    public string Status { get; set; } // Pending, Resolved
    public DateTime CreatedAt { get; set; }
    public DateTime ResolvedAt { get; set; }
}