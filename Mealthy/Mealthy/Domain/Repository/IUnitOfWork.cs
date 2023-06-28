namespace Mealthy.Mealthy.Domain.Repository;

public interface IUnitOfWork
{
    public Task CompleteAsync();
}