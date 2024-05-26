using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Addresses.RemoveAddress;
public sealed record RemoveAddressCommand(Guid Id) : ICommand;

