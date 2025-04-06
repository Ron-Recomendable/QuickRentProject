IF (SELECT COUNT(*) FROM Item WHERE Category = 'Apartment') > 5
BEGIN
    UPDATE Item
    SET Price = Price * 1.1
    WHERE Category = 'Apartment';
END


