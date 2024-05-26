using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Addresses;

namespace AlbaPizzaApp.Application.Addresses.RegisterAddress;
internal sealed class RegisterAddressCommandHandler : ICommandHandler<RegisterAddressCommand, Guid>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterAddressCommandHandler(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
    {
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterAddressCommand request, CancellationToken cancellationToken)
    {
        var address = Address.Create(request.CustomerId, request.Country, request.State, request.City, request.Street, request.ZipCode);

        _addressRepository.Add(address);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(address.Id);
    }
}

