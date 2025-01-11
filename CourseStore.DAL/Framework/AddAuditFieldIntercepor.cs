using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class AddAuditFieldInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SetShadowProperties(eventData);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        SetShadowProperties(eventData);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void SetShadowProperties(DbContextEventData eventData)
    {
        var dateNow = DateTime.Now;

        var changerTracker = eventData.Context.ChangeTracker;

        var addedEntities = changerTracker.Entries().Where(p => p.State == EntityState.Added);
        var moddifiedEntities = changerTracker.Entries().Where(p => p.State == EntityState.Modified);

        foreach (var item in addedEntities)
        {
            item.Property("CreateBy").CurrentValue = "1";
            item.Property("UpdateBy").CurrentValue = "1";
            item.Property("CreateDate").CurrentValue = dateNow;
            item.Property("UpdateDate").CurrentValue = dateNow;
        }

        foreach (var item in moddifiedEntities)
        {
            item.Property("UpdateBy").CurrentValue = "22";
            item.Property("UpdateDate").CurrentValue = dateNow;
        }
    }
}