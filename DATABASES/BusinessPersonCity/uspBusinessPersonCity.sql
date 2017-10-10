CREATE PROC dbo.uspBusinessPersonCity
@City nvarchar(30) = NULL,
@BusinessEntityID int = NULL,
@FirstName nvarchar(30) = NULL,
@LastName nvarchar(30) = NULL
AS
SET NOCOUNT ON
SELECT PP.FirstName, PP.LastName, PA.City, PB.BusinessEntityID
FROM Person.[Address] AS PA
INNER JOIN Person.BusinessEntityAddress AS PB
ON PA.AddressID = PB.AddressID
INNER JOIN Person.Person AS PP
ON PB.BusinessEntityID = PP.BusinessEntityID
WHERE PA.City LIKE '%' + ISNULL(@City,PA.City) + '%'
AND PB.BusinessEntityID = ISNULL(@BusinessEntityID,PB.BusinessEntityID)
AND PP.FirstName LIKE '%' + ISNULL(@FirstName,PP.FirstName) + '%'
AND PP.LastName LIKE '%' + ISNULL (@LastName, PP.LastName) + '%'
GO