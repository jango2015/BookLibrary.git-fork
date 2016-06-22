namespace BookLibrary.Core.Event
{
    public interface IEntityCreatedEvent { }
    public interface IEntityUpdatedEvent { }
    public interface IEntityDeletedEvent { }

    public class EntityCreatedEvent<TEntity>:IEntityCreatedEvent
    {
        public  TEntity Entity { get; }

        public EntityCreatedEvent(TEntity entity)
        {
            Entity = entity;
        }
    }

    public class EntityUpdatedEvent<TEntity>:IEntityUpdatedEvent
    {
        public TEntity Entity { get; }

        public EntityUpdatedEvent(TEntity entity)
        {
            var a=new EntityCreatedEvent<string>("");
            Entity = entity;
        }
    }

    public class EntityDeletedEvent<TEntity>:IEntityDeletedEvent
    {
        public TEntity Entity { get; }
        public EntityDeletedEvent(TEntity entity)
        {
            Entity = entity;
        }
    }
}