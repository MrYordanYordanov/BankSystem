using Services.ErrorHandling.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Services.ErrorHandling;

public interface IGuard<TExceptionArguments>
    where TExceptionArguments : class
{
    void AgainstNull<T>(
        [NotNull]
        T value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);

    void AgainstNotNull<T>(
        [MaybeNull]
        T value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);

    void AgainstDefault<T>(
        T value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null)
        where T : struct;

    void AgainstNullOrEmpty(
        [NotNull]
        string value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);

    void AgainstNullOrWhiteSpace(
        [NotNull]
        string value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);

    void AgainstTrue(
        bool condition,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);

    void AgainstFalse(
        bool condition,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);

    void AgainstRegex(
        string value,
        string pattern,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);

    void AgainstMissingOrInvalidEmail(
        string email,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);

    void AgainstEmpty<T>(
        IEnumerable<T> value,
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);

    void ThrowException(
        string errorMessage = null,
        HttpStatusCode? statusCode = null,
        TExceptionArguments arguments = null);
}

public interface IGuard : IGuard<ExceptionArguments>
{
}
