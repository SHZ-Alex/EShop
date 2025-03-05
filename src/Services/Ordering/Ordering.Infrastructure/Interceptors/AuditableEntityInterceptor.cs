using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Domain.Abstractions;

namespace Ordering.Infrastructure.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateEntities(DbContext? context)
    {
        if (context is null)
            return;

        foreach (var entity in context.ChangeTracker.Entries<IEntity>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedBy = "Admin";
                entity.Entity.CreatedAt = DateTimeOffset.Now;
            }

            if (entity.State is EntityState.Added or EntityState.Modified)
            {
                entity.Entity.LastModifiedBy = "Admin";
                entity.Entity.LastModified = DateTimeOffset.Now;
            }
        }
    }
}

public static class Extensions
{
    public static bool IsAuditable(this EntityEntry contextEntityEntry) =>
        contextEntityEntry.References
            .Any(x => x.TargetEntry != null
                      && x.TargetEntry.Metadata.IsOwned()
                      && x.TargetEntry.State is EntityState.Added or EntityState.Modified);
}