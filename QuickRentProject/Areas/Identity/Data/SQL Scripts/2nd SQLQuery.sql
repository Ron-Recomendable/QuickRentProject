SET IDENTITY_INSERT Booking ON;
INSERT INTO Booking (BookingId, StartDate, EndDate, TotalCost, Status, RenterId, ItemId) 
VALUES
(1, '2023-06-01', '2023-06-07', 3150.00, 'Completed', '5', 1),
(2, '2023-06-10', '2023-06-12', 360.00, 'Confirmed', '6', 2),
(3, '2023-07-01', '2023-07-14', 8400.00, 'Pending', '7', 3),
(4, '2023-06-15', '2023-06-18', 660.00, 'Cancelled', '8', 4),
(5, '2023-07-05', '2023-07-07', 130.00, 'Confirmed', '9', 5),
(6, '2023-08-01', '2023-08-03', 110.00, 'Pending', '10', 6),
(7, '2023-06-20', '2023-06-25', 1750.00, 'Completed', '3', 7),
(8, '2023-07-10', '2023-07-11', 25.00, 'Confirmed', '4', 8),
(9, '2023-08-15', '2023-08-17', 80.00, 'Pending', '5', 9),
(10, '2023-09-01', '2023-09-03', 190.00, 'Confirmed', '6', 10);
SET IDENTITY_INSERT Booking OFF;

