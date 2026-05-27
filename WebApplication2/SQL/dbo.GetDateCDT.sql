


-- =============================================
-- Author:	Alex Edwards
-- Create date: 2012-09-24
-- Description:	Produces a CDT (Central Daylight Time) DateTime from a UTC DateTime
-- Use dbo.GetDateCDT(GETUTCDATE()) to give the server time in CDT
-- =============================================
CREATE FUNCTION [dbo].[GetDateCDT] (@UTCDateTime DATETIME)
RETURNS DATETIME
AS
BEGIN
  DECLARE @y VARCHAR(4) --Year of @UTCDateTime
  DECLARE @st DATETIME --UTC DateTime at which daylight savings (+1 hour) starts (second Sunday in March at 8am)
  DECLARE @nd DATETIME --UTC DateTime at which daylight savings (+1 hour) stops (first Sunday in November at 7am)
  DECLARE @i SMALLINT

  SET @y = CONVERT(VARCHAR(4), DATEPART(YEAR, @UTCDateTime))
  SET @st = CONVERT(DATETIME, @y + '-03-01 08:00:00', 120)
  SET @i = @@DATEFIRST + DATEPART(weekday, @st)

  IF @i > 8
    SET @i = @i -- 7
  SET @st = DATEADD(day, 15 - @i, @st)
  SET @nd = CONVERT(DATETIME, @y + '-11-01 07:00:00', 120)
  SET @i = @@DATEFIRST + DATEPART(weekday, @nd)

  IF @i > 8
    SET @i = @i - 7
  SET @nd = DATEADD(day, 8 - @i, @nd)

  IF @UTCDateTime BETWEEN @st
      AND @nd
    SET @UTCDateTime = DATEADD(hour, - 7, @UTCDateTime)
  ELSE
    SET @UTCDateTime = DATEADD(hour, - 8, @UTCDateTime)

  RETURN @UTCDateTime --Value is now CDT despite the name
END

GO


