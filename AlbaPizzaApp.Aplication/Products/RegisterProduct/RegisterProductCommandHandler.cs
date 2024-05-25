using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.Application.Products.RegisterProduct;
internal class RegisterProductCommandHandler : ICommandHandler<RegisterProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
    {
        if (await _productRepository.ExistProductByDescription(request.Description))
        {
            return Result.Failure<Guid>(ProductErrors.ExistsDescription);
        }

        if (!Enum.TryParse<ProductTaxType>(request.TaxType, true, out var taxType))
        {
            return Result.Failure<Guid>(ProductErrors.NotValidTaxType);
        }

        var product = Product.Create(request.Description, request.Price, taxType);

        _productRepository.Add(product);
        await _unitOfWork.SaveChangesAsync();

        return product.Id;
    }
}
