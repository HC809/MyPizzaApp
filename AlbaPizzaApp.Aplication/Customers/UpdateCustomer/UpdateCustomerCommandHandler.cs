using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Customers;

namespace AlbaPizzaApp.Application.Customers.UpdateCustomer;
internal sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);

        if (customer is null)
        {
            return Result.Failure(CustomerErrors.NotFound);
        }

        if (await _customerRepository.ExistCustomerByEmailExcludingId(request.Email, customer.Id, cancellationToken))
        {
            return Result.Failure(CustomerErrors.ExistsEmail);
        }

        if (await _customerRepository.ExistCustomerByPhoneExcludingId(request.Phone, customer.Id, cancellationToken))
        {
            return Result.Failure(CustomerErrors.ExistsPhone);
        }

        customer.Update(request.Name, request.Email, request.Phone);

        _customerRepository.Update(customer);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

