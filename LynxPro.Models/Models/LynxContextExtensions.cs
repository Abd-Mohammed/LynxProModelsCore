namespace LynxPro.Models
{
    public static class LynxContextExtensions
    {
        public static void SaveChangesWithAwareness(this LynxContext context)
        {
            context.ChangeTenantAwareAddedOrModifiedEntries();
            context.ChangeFranchiseAwareAddedOrModifiedEntries();
            context.SaveChanges();
        }

        public static async Task SaveChangesWithAwarenessAsync(this LynxContext context, CancellationToken cancellationToken = default)
        {
            context.ChangeTenantAwareAddedOrModifiedEntries();
            context.ChangeFranchiseAwareAddedOrModifiedEntries();
            await context.SaveChangesAsync(cancellationToken);
        }

        public static void InsertEntities<T>(this LynxContext context, IEnumerable<T> entities, bool includeGraph) where T : class
        {
            var entityList = Transform(entities);
            context.ChangeTenantAwareEntries(entityList, includeGraph);
            context.ChangeFranchiseAwareEntries(entityList, includeGraph);

            foreach (var entity in entityList)
            {
                context.Set<T>().Add(entity);
            }

            context.SaveChanges();
        }

        public static async Task InsertEntitiesAsync<T>(this LynxContext context, IEnumerable<T> entities, bool includeGraph, CancellationToken cancellationToken = default) where T : class
        {
            var entityList = Transform(entities);
            context.ChangeTenantAwareEntries(entityList, includeGraph);
            context.ChangeFranchiseAwareEntries(entityList, includeGraph);

            foreach (var entity in entityList)
            {
                await context.Set<T>().AddAsync(entity, cancellationToken);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        public static void UpdateEntities<T>(this LynxContext context, IEnumerable<T> entities) where T : class
        {
            var entityList = Transform(entities);
            context.ChangeTenantAwareEntries(entityList, false);
            context.ChangeFranchiseAwareEntries(entityList, false);

            foreach (var entity in entityList)
            {
                context.Set<T>().Update(entity);
            }

            context.SaveChanges();
        }

        public static async Task UpdateEntitiesAsync<T>(this LynxContext context, IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class
        {
            var entityList = Transform(entities);
            context.ChangeTenantAwareEntries(entityList, false);
            context.ChangeFranchiseAwareEntries(entityList, false);

            foreach (var entity in entityList)
            {
                context.Set<T>().Update(entity);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        public static void UpdateEntities<T>(this LynxContext context, IEnumerable<T> entities, Action<EntityBulkOperation<T>> bulkOperationFactory) where T : class
        {
            var entityList = Transform(entities);
            context.ChangeTenantAwareEntries(entityList, false);
            context.ChangeFranchiseAwareEntries(entityList, false);

            var bulkOperation = new EntityBulkOperation<T>();
            bulkOperationFactory(bulkOperation);

            foreach (var entity in entityList)
            {
                context.Set<T>().Update(entity);
                bulkOperation.Apply(context, entity);
            }

            context.SaveChanges();
        }

        public static async Task UpdateEntitiesAsync<T>(this LynxContext context, IEnumerable<T> entities, Action<EntityBulkOperation<T>> bulkOperationFactory, CancellationToken cancellationToken = default) where T : class
        {
            var entityList = Transform(entities);
            context.ChangeTenantAwareEntries(entityList, false);
            context.ChangeFranchiseAwareEntries(entityList, false);

            var bulkOperation = new EntityBulkOperation<T>();
            bulkOperationFactory(bulkOperation);

            foreach (var entity in entityList)
            {
                context.Set<T>().Update(entity);
                bulkOperation.Apply(context, entity);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        private static List<T> Transform<T>(IEnumerable<T> entities) where T : class
        {
            return entities is IList<T> list ? list.ToList() : entities.ToList();
        }

        public class EntityBulkOperation<T> where T : class
        {
            public Action<LynxContext, T> Apply { get; set; } = (ctx, entity) => { };

            public void SetCustomAction(Action<LynxContext, T> customAction)
            {
                Apply = customAction;
            }
        }
    }
}