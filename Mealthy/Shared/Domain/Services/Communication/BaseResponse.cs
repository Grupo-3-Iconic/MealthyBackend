namespace Mealthy.Mealthy.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; } //T?
    public IEnumerable<T> Resources { get; set; }
    protected BaseResponse(T resource)
    {
        Success = true;
        Message = string.Empty;
        Resource = resource;
    }

    protected BaseResponse(IEnumerable<T> resources)
    {
        Success = true;
        Message = string.Empty;
        Resources = resources;

    }
    protected BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }
}