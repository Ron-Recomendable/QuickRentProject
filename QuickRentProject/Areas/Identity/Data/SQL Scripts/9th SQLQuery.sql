SELECT u.FirstName, u.LastName
FROM AspNetUsers u
LEFT JOIN Booking b ON u.Id = b.RenterId
WHERE b.BookingId IS NULL;

