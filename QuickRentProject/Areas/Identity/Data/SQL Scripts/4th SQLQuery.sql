SET IDENTITY_INSERT Review ON;
INSERT INTO Review (ReviewId, Rating, Comment, ReviewDate, ItemId, UserId) VALUES
(1, 5, 'Great views! Loved it!', '2023-06-08', 1, '5'),
(2, 4, 'Nice car but hard to charge', '2023-06-13', 2, '6'),
(3, 3, 'Beach was smaller than expected', '2023-07-16', 3, '7'),
(4, 5, 'Perfect mountain vacation!', '2023-06-19', 4, '8'),
(5, 4, 'Good drone but batteries drain fast', '2023-07-08', 5, '9'),
(6, 2, 'Camera was broken', '2023-08-04', 6, '10'),
(7, 5, 'Amazing boat trip!', '2023-06-26', 7, '3'),
(8, 3, 'Too noisy during day', '2023-07-12', 8, '4'),
(9, 4, 'Bike had issues but fixed quickly', '2023-08-18', 9, '5'),
(10, 5, 'Great camera equipment', '2023-09-04', 10, '6');
SET IDENTITY_INSERT Review OFF;