using Microsoft.EntityFrameworkCore.Storage;
using CommerceAPI.Domain.Repositories;
using CommerceAPI.Infra.Data.Context;

namespace CommerceAPI.Infra.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    private IDbContextTransaction _transaction;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task BeginTransaction()
    {
        _transaction = await _db.Database.BeginTransactionAsync();
    }
    
    public async Task Rollback()
    {
        await _transaction.RollbackAsync();
    }
    
    public async Task Commit()
    {
        await _transaction.CommitAsync();
    }
    
    public void Dispose()
    {
        _transaction?.Dispose();
    }
    
}