using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pluralize.NET;

namespace ProjectUserPost.Common.Utilities;

public static class ModelBuilderExtensions
{
    public static void AddPluralizingTableNameConvention(this ModelBuilder modelBuilder)
    {
        Pluralizer pluralize = new Pluralizer();
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            string tableName = entityType.GetTableName();
            entityType.SetTableName(pluralize.Pluralize(tableName));
        }
    }

    public static void AddRestrictDeleteBehaviorConvention(this ModelBuilder modelBuilder)
    {
        IEnumerable<IMutableForeignKey> cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        foreach (IMutableForeignKey fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
    }


    public static void RegisterEntityTypeConfiguration(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        MethodInfo applyGenericMethod = typeof(ModelBuilder).GetMethods()
            .First(_ => _.Name == nameof(modelBuilder.ApplyConfiguration));
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic);

        foreach (Type type in types)
        {
            foreach (Type iface in type.GetInterfaces())
            {
                if (iface.IsConstructedGenericType &&
                    iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                {
                    MethodInfo applyConcreteMethod =
                        applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                    applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                }
            }
        }
    }

    public static void RegisterAllEntities<BaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies.SelectMany(_ => _.GetExportedTypes())
            .Where(__ => __.IsClass && !__.IsAbstract && __.IsPublic && typeof(BaseType).IsAssignableFrom(__));

        foreach (Type type in types)
        {
            modelBuilder.Entity(type);
        }
    }
}