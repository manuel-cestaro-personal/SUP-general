using SerenUP.ApplicationCore.Entities;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface IOrderRepository <TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        IEnumerable<TEntity> GetAll ();
        TEntity GetById (TPrimaryKey id);
        void Insert (TEntity model);
        void Update (TEntity model);
        void Delete (TPrimaryKey Id);
    }
}
