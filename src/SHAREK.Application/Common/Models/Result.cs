namespace SHAREK.Application.Common.Models;

public sealed record Result(bool IsSuccess, string? Error)
{
    public bool IsFailure => !IsSuccess;

    public static Result Success() => new(true, null);

    public static Result Failure(string error) => new(false, error);
}
