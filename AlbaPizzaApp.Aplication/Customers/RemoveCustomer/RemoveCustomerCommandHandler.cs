using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Customers;

namespace AlbaPizzaApp.Application.Customers.RemoveCustomer;
internal sealed class RemoveCustomerCommandHandler : ICommandHandler<RemoveCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);

        if (customer is null)
        {
            return Result.Failure(CustomerErrors.NotFound);
        }

        _customerRepository.Remove(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

