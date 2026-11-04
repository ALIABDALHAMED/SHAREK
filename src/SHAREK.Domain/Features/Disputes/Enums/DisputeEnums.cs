namespace SHAREK.Domain.Features.Disputes.Enums;

public enum ConditionPhase
{
    Before,
    After
}

public enum DamageAssessmentStatus
{
    Pending,
    NoDamage,
    DamageFound,
    Accepted,
    Disputed,
    NeedsAdminReview,
    Resolved
}
