SELECT 
    u.FirstName,
    u.LastName,
    COUNT(DISTINCT b.ItemId) AS DifferentItemsRented
FROM AspNetUsers u
JOIN Booking b ON u.Id = b.RenterId
GROUP BY u.FirstName, u.LastName
HAVING COUNT(DISTINCT b.ItemId) > 1;
