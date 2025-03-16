using ProScape.Domain.Entities;

namespace ProScape.Application.Common.Interfaces;

public interface IVillaNumberRepository : IRepository<VillaNumber>
{
    void Update(VillaNumber entity);
}
