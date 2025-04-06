SELECT 
    i.ItemId,
    i.Name AS 'Item',
    i.Price AS 'Daily Rate',
    CONCAT(u.FirstName, ' ', u.LastName) AS 'Owner',
    u.PhoneNumber AS 'Owner Phone'
FROM Item i
JOIN AspNetUsers u ON i.OwnerId = u.Id
WHERE i.IsAvailable = 1
  AND i.Price BETWEEN 50 AND 200
ORDER BY i.Price DESC;

