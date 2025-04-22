using ProScape.Application.Common.Interfaces;
using ProScape.Domain.Entities;
using ProScape.Infrastructure.Data;

namespace ProScape.Infrastructure.Repository;

public class VillaNumberRepository : BaseRepository<VillaNumber>, IVillaNumberRepository
{
    private readonly ApplicationDbContext _db;

    public VillaNumberRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(VillaNumber entity)
    {
        _db.VillaNumbers.Update(entity);
    }
}
