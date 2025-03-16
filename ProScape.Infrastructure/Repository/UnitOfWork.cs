using ProScape.Application.Common.Interfaces;
using ProScape.Infrastructure.Data;

namespace ProScape.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public IVillaRepository Villa { get; private set; }

    // Constructor
    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Villa = new VillaRepository(_db);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
