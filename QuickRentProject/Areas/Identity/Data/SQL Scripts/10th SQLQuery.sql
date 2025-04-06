SELECT TOP 1 i.Name, COUNT(b.BookingId) AS BookingCount
FROM Booking b
JOIN Item i ON b.ItemId = i.ItemId
GROUP BY i.Name
ORDER BY BookingCount Desc;

