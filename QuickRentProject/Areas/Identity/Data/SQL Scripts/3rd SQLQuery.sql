SET IDENTITY_INSERT Payment ON;
INSERT INTO Payment (PaymentId, Amount, PaymentDate, PaymentMethod, BookingId) 
VALUES
(1, 3150.00, '2023-05-25', 'Bank Transfer', 1),
(2, 360.00, '2023-06-05', 'Credit Card', 2),
(3, 2000.00, '2023-06-20', 'Bank Transfer', 3),
(4, 660.00, '2023-06-10', 'PayPal', 4),
(5, 130.00, '2023-07-01', 'Credit Card', 5),
(6, 110.00, '2023-07-25', 'Venmo', 6),
(7, 1750.00, '2023-06-15', 'Credit Card', 7),
(8, 25.00, '2023-07-05', 'PayPal', 8),
(9, 80.00, '2023-08-10', 'Credit Card', 9),
(10, 190.00, '2023-08-28', 'Apple Pay', 10);
SET IDENTITY_INSERT Payment OFF;