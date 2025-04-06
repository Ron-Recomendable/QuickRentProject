SELECT Role, COUNT(*) AS UserCount
FROM AspNetUsers
GROUP BY Role;

