using AlbaPizzaApp.Domain.Abstractions;
using MediatR;

namespace AlbaPizzaApp.Application.Abstractions.Messaging;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse> { }
