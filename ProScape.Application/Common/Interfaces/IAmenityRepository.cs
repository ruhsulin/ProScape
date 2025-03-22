using ProScape.Domain.Entities;

namespace ProScape.Application.Common.Interfaces;

public interface IAmenityRepository : IRepository<Amenity>
{
    void Update(Amenity entity);
}
