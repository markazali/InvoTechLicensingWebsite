/****** Object:  StoredProcedure [dbo].[SyncItemDefinitions]    Script Date: 1/13/2020 9:27:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SyncItemDefinitions](@syncblob NVARCHAR(MAX), @ipdaddress varchar(30))
AS

     -- some variables 
     DECLARE @batchNo AS INT;
     DECLARE @customercode AS INT;
     DECLARE @batchdt TABLE
     (customercode INT, 
      itemdefno    INT, 
      idtype       NVARCHAR(50), 
      idstyle      NVARCHAR(50)
     );

     -- throw blob into temp table
     INSERT INTO @batchdt
     (customercode, 
      itemdefno, 
      idtype, 
      idstyle
     )
            SELECT *
            FROM OPENJSON(@syncblob) WITH(customercode INT '$.customerCode', idno INT '$.itemDefinitionNo', idtype NVARCHAR(50) '$.type', idstyle NVARCHAR(50) '$.style');

     -- get new batch number
     SELECT TOP 1 @customercode = customercode
     FROM @batchdt;
     INSERT INTO SyncBatches(customercode)
     VALUES(@customercode);
     SELECT @batchNo = SCOPE_IDENTITY();

	 if not exists (select * 
					from LicensingIPRanges 
					where customerCode = @customercode 
					and deleted = 0 
					and dbo.IsIPAddressInRange(@ipdaddress,start_ip_address,end_ip_address) = 1 ) begin
	 return 
	 end
	 
     -- old stuff is invalid now...
     UPDATE ItemDefinitions
       SET 
           deleted = 1
     WHERE customercode  in (select customerCode from @batchdt);

     -- update itemdefinitions
     INSERT INTO ItemDefinitions
     (customercode, 
      itemdefinitionNo, 
      type, 
      style
     )
            SELECT customercode, 
                   itemdefno, 
                   idtype, 
                   idstyle
            FROM @batchdt;
GO


