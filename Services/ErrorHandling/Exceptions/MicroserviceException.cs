using System.Net;

namespace Services.ErrorHandling.Exceptions;

public class MicroserviceException : CustomClientException<ExceptionArguments>
{
    public MicroserviceException()
    {
        this.StatusCode = HttpStatusCode.BadRequest;
    }

    public MicroserviceException(string errorMessage, HttpStatusCode statusCode)
    {
        this.ErrorMessage = errorMessage;
        this.StatusCode = statusCode;
    }

    public override object GetErrorModel()
    {
        var arguments = this.Arguments;
        return new ErrorModel
        {
            ErrorCode = this.ErrorMessage,
            Properties = arguments?.Properties ?? []
        };
    }
}