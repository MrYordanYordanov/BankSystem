namespace Services.ErrorHandling.Exceptions;

public class ErrorModel
{
    public string ErrorCode { get; set; }

    public string[] Properties { get; set; }
}