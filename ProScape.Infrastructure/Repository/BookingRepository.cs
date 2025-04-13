using ProScape.Application.Common.Interfaces;
using ProScape.Domain.Entities;
using ProScape.Infrastructure.Data;

namespace ProScape.Infrastructure.Repository;

public class BookingRepository : Repository<Booking>, IBookingRepository
{
    public readonly ApplicationDbContext _db;

    public BookingRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Booking entity)
    {
        _db.Bookings.Update(entity);
    }
}
