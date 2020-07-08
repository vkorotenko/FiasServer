/****** Script for SelectTopNRows command from SSMS  ******/
SELECT count(Name) 
  FROM [FIAS_622].[dbo].[HOUSE_HOUSENUM]
  SELECT count(distinct(Name)) 
  FROM [FIAS_622].[dbo].[HOUSE_HOUSENUM]


  SELECT 
    Name,     
    COUNT(*) occurrences
FROM HOUSE_HOUSENUM
GROUP BY
    Name    
HAVING 
    COUNT(*) > 1;


WITH cte AS (
    SELECT
        Name,         
        COUNT(*) occurrences
    FROM HOUSE_HOUSENUM
    GROUP BY 
        Name         
    HAVING 
        COUNT(*) > 1
)

SELECT 
    HOUSE_HOUSENUM.ID, 
    HOUSE_HOUSENUM.Name     
FROM HOUSE_HOUSENUM
    INNER JOIN cte ON 
        cte.Name = HOUSE_HOUSENUM.Name 
ORDER BY 
    HOUSE_HOUSENUM.Name;