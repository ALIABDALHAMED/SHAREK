namespace SHAREK.API.Common.Interfaces;

public interface IFileStorage
{
    Task<string> SaveAsync(
        Stream content,
        string fileName,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        string filePath,
        CancellationToken cancellationToken = default);
}
