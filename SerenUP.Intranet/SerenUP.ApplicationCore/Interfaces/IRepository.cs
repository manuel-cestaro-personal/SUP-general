using SerenUP.ApplicationCore.Entities;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface IRepository <TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        Task<IEnumerable<TEntity>> GetAll ();
        Task<TEntity> GetById (TPrimaryKey id);
        Task Insert (TEntity model);
        Task Update (TEntity model);
        Task Delete (TPrimaryKey Id);
    }
}
