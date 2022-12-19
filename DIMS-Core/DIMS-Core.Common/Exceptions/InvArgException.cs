namespace DIMS_Core.Common.Exceptions;

public class InvArgException : BaseException
{
    public string MethodName { get; set; }
    
    public InvArgException(string methodName, string message) : base(message)
    {
        MethodName = methodName;
    }
}