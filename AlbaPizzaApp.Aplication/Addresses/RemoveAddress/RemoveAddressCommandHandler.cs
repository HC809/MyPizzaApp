using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Addresses;

namespace AlbaPizzaApp.Application.Addresses.RemoveAddress;
internal sealed class RemoveAddressCommandHandler : ICommandHandler<RemoveAddressCommand>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveAddressCommandHandler(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
    {
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.GetByIdAsync(request.Id, cancellationToken);

        if (address is null)
        {
            return Result.Failure(AddressErrors.NotFound);
        }

        _addressRepository.Remove(address);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

