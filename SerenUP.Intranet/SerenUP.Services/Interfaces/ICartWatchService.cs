using SerenUP.ApplicationCore.Entities;

namespace SerenUP.Services.Interfaces
{
    public interface ICartWatchService
    {
        Task<IEnumerable<Watch>> GetByCartId(Guid id);
    }
}