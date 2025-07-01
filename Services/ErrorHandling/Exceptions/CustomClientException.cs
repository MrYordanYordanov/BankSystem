using System.Net;

namespace Services.ErrorHandling.Exceptions;

public abstract class CustomClientException : Exception
{
    public string ErrorMessage { get; set; }

    public HttpStatusCode? StatusCode { get; set; }

    public abstract object GetErrorModel();
}

public abstract class CustomClientException<T> : CustomClientException
    where T : class
{
    public T Arguments { protected get; set; }
}