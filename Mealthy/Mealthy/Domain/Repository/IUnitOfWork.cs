namespace Mealthy.Mealthy.Domain.Repository;

public interface IUnitOfWork
{
    Task CompleteAsync();
}