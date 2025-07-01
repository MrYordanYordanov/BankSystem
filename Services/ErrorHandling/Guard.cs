using Services.ErrorHandling.Exceptions;
using System.Net;
using System.Text.RegularExpressions;

namespace Services.ErrorHandling;

public class Guard<TException, TExceptionArguments> : IGuard<TExceptionArguments>
    where TException : CustomClientException<TExceptionArguments>, new()
    where TExceptionArguments : class
{
    public void AgainstNull<T>(
        T value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
    {
        if (value == null)
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void AgainstNotNull<T>(
        T value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
    {
        if (value != null)
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void AgainstDefault<T>(
        T value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
        where T : struct
    {
        if (value.Equals(default(T)))
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void AgainstNullOrEmpty(
        string value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
    {
        if (string.IsNullOrEmpty(value))
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void AgainstNullOrWhiteSpace(
        string value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void AgainstTrue(
        bool condition,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
    {
        if (condition)
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void AgainstFalse(
        bool condition,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
    {
        if (!condition)
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void AgainstRegex(
        string value,
        string pattern,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
    {
        if (!Regex.IsMatch(value, pattern))
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void AgainstMissingOrInvalidEmail(
        string email,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw BuildException(errorMessage, statusCode, arguments);

        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)(\.[\w\-]+)*(\.\w{2,})$");
        if (!regex.Match(email).Success)
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void AgainstEmpty<T>(
        IEnumerable<T> value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
    {
        if (!value.Any())
            throw BuildException(errorMessage, statusCode, arguments);
    }

    public void ThrowException(
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = default)
        => throw BuildException(errorMessage, statusCode, arguments);

    private static TException BuildException(
        string errorMessage,
        HttpStatusCode? statusCode,
        TExceptionArguments arguments)
    {
        var exception = new TException
        {
            ErrorMessage = errorMessage,
            Arguments = arguments
        };

        if (statusCode.HasValue)
            exception.StatusCode = statusCode;

        return exception;
    }
}

public class Guard : Guard<MicroserviceException, ExceptionArguments>, IGuard;