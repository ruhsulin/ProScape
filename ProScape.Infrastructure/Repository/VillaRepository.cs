using ProScape.Application.Common.Interfaces;
using ProScape.Domain.Entities;
using ProScape.Infrastructure.Data;

namespace ProScape.Infrastructure.Repository;

public class VillaRepository : Repository<Villa>, IVillaRepository
{
    private readonly ApplicationDbContext _db;

    public VillaRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Villa entity)
    {
        _db.Villas.Update(entity);
    }
}
