using System;

namespace BookLibrary.Core.Event
{
    public interface IEntityCreatedEvent { }
    public interface IEntityUpdatedEvent { }
    public interface IEntityDeletedEvent { }

    //public class EntityCreatedEvent:IEntityCreatedEvent
    //{
    //    public EntityCreatedEvent(object entity,Type entityType)
    //    {
    //        Entity = entity;
    //        EntityType = entityType;
    //    }
    //    public object Entity { get; }
    //    public Type EntityType { get; }
    //}

    //public class EntityUpdatedEvent<TEntity>:IEntityUpdatedEvent
    //{
    //    public TEntity Entity { get; }

    //    public EntityUpdatedEvent(TEntity entity)
    //    {
    //        var a=new EntityCreatedEvent<string>("");
    //        Entity = entity;
    //    }
    //}

    //public class EntityDeletedEvent<TEntity>:IEntityDeletedEvent
    //{
    //    public TEntity Entity { get; }
    //    public EntityDeletedEvent(TEntity entity)
    //    {
    //        Entity = entity;
    //    }
    //}
}