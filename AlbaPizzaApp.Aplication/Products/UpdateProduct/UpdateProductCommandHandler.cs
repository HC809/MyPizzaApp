using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Products;

namespace AlbaPizzaApp.Application.Products.UpdateProduct;
internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
        {
            return Result.Failure(ProductErrors.NotFound);
        }

        if (await _productRepository.ExistProductByDescriptionExcludingId(request.Description, product.Id, cancellationToken))
        {
            return Result.Failure(ProductErrors.ExistsDescription);
        }

        if (!Enum.TryParse<ProductTaxType>(request.TaxType, true, out var taxType))
        {
            return Result.Failure<Guid>(ProductErrors.NotValidTaxType);
        }

        product.Update(request.Description, request.Price, taxType);

        _productRepository.Update(product);
        await _unitOfWork.SaveChangesAsync();


        return Result.Success();
    }
}
