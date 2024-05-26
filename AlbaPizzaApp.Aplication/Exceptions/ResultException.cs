using AlbaPizzaApp.Domain.Abstractions;

namespace AlbaPizzaApp.Application.Exceptions;
public class ResultException : Exception
{
    public Error Error { get; }

    public ResultException(Error error) : base(error.Description)
    {
        Error = error;
    }
}
