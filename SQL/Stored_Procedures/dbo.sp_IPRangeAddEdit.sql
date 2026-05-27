IF object_id('sp_IPRangeAddEdit') IS not  NULL
  drop proc sp_IPRangeAddEdit 
GO

CREATE PROC dbo.sp_IPRangeAddEdit @customerCode INT = 0  
  , @rangeName NVARCHAR(150) = ''  
  , @start_ip_address VARCHAR(16) = ''  
  , @end_ip_address VARCHAR(16) = ''  
  , @action CHAR(1)  
AS  
  
-- edit  
IF @action = 'E'  
BEGIN  
  IF EXISTS (  
      SELECT *  
      FROM LicensingIPRanges  
      WHERE rangeName = @rangeName  
	  and customerCode = @customerCode
      )  
  BEGIN  
    UPDATE LicensingIPRanges  
    SET start_ip_address = @start_ip_address  
      , end_ip_address = @end_ip_address  
    WHERE rangeName = @rangeName  
	and customerCode = @customerCode
  END  
  ELSE  
  BEGIN  
    INSERT INTO LicensingIPRanges  
    (customercode, rangename, start_ip_address, end_ip_address)  
    VALUES (  
      @customerCode  
      , @rangeName  
      , @start_ip_address  
      , @end_ip_address  
      )  
  END  
END  
  
  
-- delete  
IF @action = 'D'  
BEGIN  
  update LicensingIPRanges  
  set deleted = 1   
  where deleted = 0  
  and rangename = @rangeName  
END  