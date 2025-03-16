using ProScape.Domain.Entities;

namespace ProScape.Application.Common.Interfaces;

public interface IVillaRepository : IRepository<Villa>
{
    void Update(Villa entity);
}
