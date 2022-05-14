namespace Vulder.Admin.Infrastructure.Database.Interfaces;

public interface IUnitOfWork
{
    Task CompleteAsync();
}