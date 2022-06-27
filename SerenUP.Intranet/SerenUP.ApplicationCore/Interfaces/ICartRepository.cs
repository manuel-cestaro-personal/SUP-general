using SerenUP.ApplicationCore.Entities;

namespace SerenUP.ApplicationCore.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAll();
        Task<Cart> GetById(Guid id);
        Task Insert(Cart model);
        Task Update(Cart model);
        Task Delete(Guid id);
        Task<Cart> GetByUserId(Guid id);
    }
}
