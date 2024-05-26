using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Customers;

namespace AlbaPizzaApp.Application.Customers.RegisterCustomer;
internal class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand, Guid>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        if (await _customerRepository.ExistCustomerByEmail(request.Email, cancellationToken))
        {
            return Result.Failure<Guid>(CustomerErrors.ExistsEmail);
        }

        if (await _customerRepository.ExistCustomerByPhone(request.Phone, cancellationToken))
        {
            return Result.Failure<Guid>(CustomerErrors.ExistsPhone);
        }

        var customer = Customer.Create(request.Name, request.Email, request.Phone);

        _customerRepository.Add(customer);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(customer.Id);
    }
}

