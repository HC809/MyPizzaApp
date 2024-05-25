using AlbaPizzaApp.Domain.Abstractions;
using MediatR;

namespace AlbaPizzaApp.Application.Abstractions.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
