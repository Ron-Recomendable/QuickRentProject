SELECT b.BookingId, u.FirstName, u.LastName, b.StartDate, b.EndDate
FROM Booking b
JOIN AspNetUsers u ON b.RenterId = u.Id;

