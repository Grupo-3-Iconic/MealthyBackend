using System.Globalization;

namespace Mealthy.Security.Exceptions;

public class SecurityException : Exception
{
    public AppException() : base() {}
    public AppException(string message) : base(message) {}
    public AppException(string message, params object[] args) : 
    base(String.Format(CultureInfo.CurrentCulture, message,arg)){}
}