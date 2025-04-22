using ProScape.Application.Common.Interfaces;
using ProScape.Application.Common.Utility;
using ProScape.Domain.Entities;
using ProScape.Infrastructure.Data;

namespace ProScape.Infrastructure.Repository;

public class BookingRepository : BaseRepository<Booking>, IBookingRepository
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

    public void UpdateStatus(int bookingId, string bookingStatus)
    {
        var bookingFromDb = _db.Bookings.FirstOrDefault(m => m.Id == bookingId);
        if (bookingFromDb != null)
        {
            bookingFromDb.Status = bookingStatus;
            if (bookingStatus == StaticDetails.StatusCheckedIn)
            {
                bookingFromDb.ActualCheckInDate = DateTime.Now;
            }
            if (bookingStatus == StaticDetails.StatusCompleted)
            {
                bookingFromDb.ActualCheckOutDate = DateTime.Now;
            }
        }
    }

    public void UpdateStripePaymentID(int bookingId, string sessionId, string paymentIntentId)
    {
        var bookingFromDb = _db.Bookings.FirstOrDefault(m => m.Id == bookingId);
        if (bookingFromDb != null)
        {
            if (!string.IsNullOrEmpty(sessionId))
            {
                bookingFromDb.StripeSessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                bookingFromDb.StripePaymentIntentId = paymentIntentId;
                bookingFromDb.PaymentDate = DateTime.Now;
                bookingFromDb.IsPaymentSuccessful = true;
            }
        }
    }
}
