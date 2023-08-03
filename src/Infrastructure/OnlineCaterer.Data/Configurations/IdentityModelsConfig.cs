
namespace OnlineCaterer.Data.Configurations;

public static class IdentityModelsConfig
{
    public static ModelBuilder AddIdentityModelsConfig(this ModelBuilder modelBuilder)
    {
        foreach (var entityModel in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityModel.GetTableName();

            if (tableName != null && tableName.StartsWith("AspNet"))
            {
                entityModel.SetTableName(tableName[6..]);
            }
        }

        return modelBuilder;
    }
}
