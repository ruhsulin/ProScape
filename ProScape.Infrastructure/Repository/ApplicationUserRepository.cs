using ProScape.Application.Common.Interfaces;
using ProScape.Domain.Entities;
using ProScape.Infrastructure.Data;

namespace ProScape.Infrastructure.Repository;

public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
{
    private readonly ApplicationDbContext _db;

    public ApplicationUserRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}
