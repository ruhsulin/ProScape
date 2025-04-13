using ProScape.Domain.Entities;

namespace ProScape.Application.Common.Interfaces;

public interface IBookingRepository : IRepository<Booking>
{
    void Update(Booking entity);
}
