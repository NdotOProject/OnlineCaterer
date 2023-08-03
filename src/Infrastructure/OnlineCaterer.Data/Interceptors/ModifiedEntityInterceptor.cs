
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

using OnlineCaterer.Application.Common.Interfaces;
using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Data.Interceptors;

public class ModifiedEntityInterceptor : SaveChangesInterceptor
{
    private readonly IUser _user;
    private readonly IDateTime _dateTime;

    public ModifiedEntityInterceptor(IUser user, IDateTime dateTime)
    {
        _user = user;
        _dateTime = dateTime;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        ModifiedEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        ModifiedEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void ModifiedEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
        {
            var entity = entry.Entity;
            if (entry.State== EntityState.Added)
            {
                entity.CreatedBy = _user.Id;
                entity.CreatedDate = _dateTime.Now;
            }

            if (entry.State == EntityState.Added
                || entry.State== EntityState.Modified
                || entry.HasChangedOwnedEntities())
            {
                entity.LastModifiedBy = _user.Id;
                entity.LastModifiedDate = _dateTime.Now;
            }

        }

    }

}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}