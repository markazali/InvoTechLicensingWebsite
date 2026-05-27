
CREATE FUNCTION dbo.IsIPAddressInRange
(
    @IPAddress varchar(20),
    @StartRange varchar(20),
    @EndRange varchar(20)
)
RETURNS INT
AS
BEGIN
    DECLARE @MAXRANGE BIGINT = 256
    RETURN 
    CASE 
    WHEN PARSENAME(@IPAddress,1) + @MAXRANGE * PARSENAME(@IPAddress,2) + 
    @MAXRANGE * @MAXRANGE * PARSENAME(@IPAddress ,3) + @MAXRANGE * @MAXRANGE * @MAXRANGE * PARSENAME(@IPAddress ,4)
    BETWEEN
    PARSENAME(@StartRange,1) + @MAXRANGE * PARSENAME(@StartRange,2) + 
    @MAXRANGE * @MAXRANGE * PARSENAME(@StartRange ,3) + @MAXRANGE * @MAXRANGE * @MAXRANGE * PARSENAME(@StartRange ,4)
    AND
    PARSENAME(@EndRange,1) + @MAXRANGE * PARSENAME(@EndRange,2) + 
    @MAXRANGE * @MAXRANGE * PARSENAME(@EndRange ,3) + @MAXRANGE * @MAXRANGE * @MAXRANGE * PARSENAME(@EndRange ,4)
    THEN 1
    ELSE 0
    END     
END