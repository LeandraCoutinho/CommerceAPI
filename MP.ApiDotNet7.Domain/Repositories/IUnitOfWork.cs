namespace MP.ApiDotNet7.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransaction();
    Task Commit();
    Task Rollback();
}