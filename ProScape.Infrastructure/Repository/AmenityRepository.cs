using ProScape.Application.Common.Interfaces;
using ProScape.Domain.Entities;
using ProScape.Infrastructure.Data;

namespace ProScape.Infrastructure.Repository;

public class AmenityRepository : Repository<Amenity>, IAmenityRepository
{
    public readonly ApplicationDbContext _db;

    public AmenityRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Amenity entity)
    {
        _db.Amenities.Update(entity);
    }
}
