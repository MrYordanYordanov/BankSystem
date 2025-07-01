namespace Services.ErrorHandling.Exceptions;

public class ExceptionArguments
{
    public string[] Properties { get; set; }

    public ExceptionArguments()
    {
    }

    public ExceptionArguments(params string[] properties)
    {
        Properties = properties;
    }
}