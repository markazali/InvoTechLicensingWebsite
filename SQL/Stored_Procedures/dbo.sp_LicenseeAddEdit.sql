IF object_id('sp_LicenseeAddEdit') IS not  NULL
  drop proc sp_LicenseeAddEdit 
GO

CREATE PROC [dbo].sp_LicenseeAddEdit (
  @userNo INT
  , @customerCode INT = NULL
  , @license VARCHAR(50) = NULL
  , @customer NVARCHAR(50) = ''
  , @locale NVARCHAR(50) = ''
  , @onhold BIT = 0
  , @productCode VARCHAR(5) = NULL
  , @expirationDate DATE = NULL
  , @deleted BIT = 0
  )
AS
IF @customerCode IS NOT NULL
  -- delete
BEGIN
  IF @deleted = 1
  BEGIN
    UPDATE licensing
    SET deleted = 1
    OUTPUT inserted.customercode
      , inserted.customer
      , inserted.productCode
      , inserted.license
      , inserted.expirationDate
      , inserted.locale
      , inserted.deleted
      , inserted.onhold
      , @userno
      , getdate()
      , inserted.ipaddress
    INTO LicensingTransactions
    WHERE customerCode = @customerCode
  END
      -- update
  ELSE
  BEGIN
    UPDATE licensing
    SET license = @license
      , customer = @customer
      , deleted = @deleted
      , expirationDate = @expirationDate
      , locale = @locale
      , productcode = @productCode
      , onhold = @onhold
    OUTPUT inserted.customercode
      , inserted.customer
      , inserted.productCode
      , inserted.license
      , inserted.expirationDate
      , inserted.locale
      , inserted.deleted
      , inserted.onhold
      , @userno
      , getdate()
      , inserted.ipaddress
    INTO LicensingTransactions
    WHERE customerCode = @customerCode
  END
END
ELSE
  -- add
BEGIN
  INSERT INTO licensing (
    license
    , customer
    , locale
    , productCode
    , expirationDate
    )
  OUTPUT inserted.customercode
    , inserted.customer
    , inserted.productCode
    , inserted.license
    , inserted.expirationDate
    , inserted.locale
    , inserted.deleted
    , inserted.onhold
    , @userno
    , getdate()
    , inserted.ipaddress
  INTO LicensingTransactions
  VALUES (
    @license
    , @customer
    , @locale
    , @productCode
    , @expirationDate
    )
END

GO


