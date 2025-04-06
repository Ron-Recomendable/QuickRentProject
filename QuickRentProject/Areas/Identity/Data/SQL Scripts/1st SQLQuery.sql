SET IDENTITY_INSERT Item ON;

INSERT INTO Item (ItemId, Name, Description, Category, Price, IsAvailable, Location, OwnerId) 
VALUES
(1, 'Luxury Penthouse', '3-bedroom penthouse with rooftop pool', 'Apartment', 450.00, 1, 'New York', '3'),
(2, 'Tesla Model S', '2022 Electric car with autopilot', 'Car', 180.00, 1, 'San Francisco', '4'),
(3, 'Beachfront Villa', 'Private beach access, 4 bedrooms', 'House', 600.00, 0, 'Miami', '5'),
(4, 'Mountain Cabin', 'Cozy A-frame with hot tub', 'Cottage', 220.00, 1, 'Denver', '6'),
(5, 'DJI Drone Pro', '4K camera with 3 batteries', 'Equipment', 65.00, 1, 'Chicago', '7'),
(6, 'Vintage Camera', 'Leica M6 film camera', 'Equipment', 55.00, 1, 'Portland', '8'),
(7, 'Jetski', '30ft yacht for coastal trips', 'Vehicle', 350.00, 1, 'Seattle', '9'),
(8, 'Workspace Office', 'Shared desk in coworking space', 'Office', 25.00, 1, 'Austin', '10'),
(9, 'Mountain Bike', 'Full-suspension trail bike', 'Sport', 40.00, 0, 'Boulder', '3'),
(10, 'Photography Kit', 'Canon R5 + 3 lenses', 'Equipment', 95.00, 1, 'Los Angeles', '4');
SET IDENTITY_INSERT Item OFF;

