using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHAREK.Domain.Features.Products.Entities;
using SHAREK.Domain.Features.Reports.Entities;
using SHAREK.Domain.Features.Wallet.Entities;
using WalletEntity = SHAREK.Domain.Features.Wallet.Entities.Wallet;

namespace SHAREK.Infrastructure.Persistence.Seed;

public static class DevelopmentSeed
{
    private static readonly string[] Roles = ["User", "Merchant", "Admin"];
    private static readonly string[] Categories = ["Electronics", "Home & Garden", "Fashion"];
    private static readonly string[] ReportTypes =
    [
        "Inappropriate content",
        "Fraud",
        "Safety concern"
    ];

    public static async Task SeedAsync(IServiceProvider services, CancellationToken cancellationToken = default)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        foreach (var roleName in Roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Could not seed role '{roleName}': {string.Join("; ", result.Errors.Select(x => x.Description))}");
                }
            }
        }

        var dbContext = services.GetRequiredService<AppDbContext>();
        if (!await dbContext.Wallets.AnyAsync(x => x.IsPlatform, cancellationToken))
        {
            dbContext.Wallets.Add(new WalletEntity { IsPlatform = true });
        }

        var existingCategories = await dbContext.Categories
            .Select(x => x.Name)
            .ToListAsync(cancellationToken);
        foreach (var categoryName in Categories.Except(existingCategories, StringComparer.Ordinal))
        {
            dbContext.Categories.Add(new Category { Name = categoryName });
        }

        var existingReportTypes = await dbContext.ReportTypes
            .Select(x => x.TypeName)
            .ToListAsync(cancellationToken);
        foreach (var reportTypeName in ReportTypes.Except(existingReportTypes, StringComparer.Ordinal))
        {
            dbContext.ReportTypes.Add(new ReportType { TypeName = reportTypeName });
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
