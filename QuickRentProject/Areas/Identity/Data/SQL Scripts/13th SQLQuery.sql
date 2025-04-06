SELECT 
    YEAR(StartDate) AS Year,
    MONTH(StartDate) AS Month, 
    SUM(TotalCost) AS MonthlyEarnings
FROM Booking
GROUP BY YEAR(StartDate), MONTH(StartDate)
ORDER BY Year, Month;

