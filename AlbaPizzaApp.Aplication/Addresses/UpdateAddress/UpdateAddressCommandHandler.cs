using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Addresses;

namespace AlbaPizzaApp.Application.Addresses.UpdateAddress;
internal sealed class UpdateAddressCommandHandler : ICommandHandler<UpdateAddressCommand>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAddressCommandHandler(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
    {
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await _addressRepository.GetByIdAsync(request.Id, cancellationToken);

        if (address is null)
        {
            return Result.Failure(AddressErrors.NotFound);
        }

        address.Update(request.Street, request.City, request.State, request.ZipCode, request.Country);

        _addressRepository.Update(address);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

