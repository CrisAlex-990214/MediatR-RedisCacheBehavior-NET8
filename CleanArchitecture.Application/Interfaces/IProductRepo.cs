using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
