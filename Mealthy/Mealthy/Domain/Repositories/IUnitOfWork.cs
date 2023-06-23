namespace Mealthy.Mealthy.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}