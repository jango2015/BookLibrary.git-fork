namespace BookLibrary.Core.Event
{
    public class EntityCreatedEvent<TEntity>
    {
        public  TEntity Entity { get; }

        public EntityCreatedEvent(TEntity entity)
        {
            Entity = entity;
        }
    }

    public class EntityUpdatedEvent<TEntity>
    {
        public TEntity Entity { get; }

        public EntityUpdatedEvent(TEntity entity)
        {
            Entity = entity;
        }
    }

    public class EntityDeletedEvent<TEntity>
    {
        public TEntity Entity { get; }
        public EntityDeletedEvent(TEntity entity)
        {
            Entity = entity;
        }
    }
}