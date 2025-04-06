SELECT 
    u.FirstName,
    COUNT(b.BookingId) AS TotalBookings
FROM AspNetUsers u
LEFT JOIN Booking b ON u.Id = b.RenterId
GROUP BY u.FirstName;

