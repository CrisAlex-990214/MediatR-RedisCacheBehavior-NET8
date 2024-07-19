using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Interfaces;
using MediatR;

namespace CleanArchitecture.Application
{
    public class GetProductsRequest : IRequest<IEnumerable<ProductDto>>, ICacheableRequest
    {
        public string Key => "Products";
    }

    public class GetProductsHandler(IProductRepo productRepo)
        : IRequestHandler<GetProductsRequest, IEnumerable<ProductDto>>
    {
        private readonly IProductRepo productRepo = productRepo;

        public async Task<IEnumerable<ProductDto>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await productRepo.GetAll();

            return products.Select(p => new ProductDto { Name = p.Name, Price = p.Price });
        }
    }
}
