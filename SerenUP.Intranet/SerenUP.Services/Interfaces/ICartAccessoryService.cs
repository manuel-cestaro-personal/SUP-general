using SerenUP.ApplicationCore.Entities;

namespace SerenUP.Services.Interfaces
{
    public interface ICartAccessoryService
    {
        Task<IEnumerable<Accessory>> GetByCartId(Guid id);
    }
}