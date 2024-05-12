CREATE FUNCTION [dbo].[LPAD]  (@STR VARCHAR(8000), @FORMAT_STR CHAR(1), @PAD_LEN INT) 
RETURNS VARCHAR(8000) 
AS
BEGIN 
	IF (@FORMAT_STR IS NULL)
	BEGIN
		SET @FORMAT_STR = ''
	END
	DECLARE @REMAIN AS BIGINT 
	SET @REMAIN = @PAD_LEN - LEN(@STR)
	DECLARE @i AS INT
	SET @i = 0
	IF (@REMAIN > 0) 
	BEGIN	
		WHILE @i < @REMAIN
		BEGIN
			SET @STR = @FORMAT_STR + @STR
			SET @i = @i + 1
		END
	END

	RETURN @STR
END
GO

CREATE FUNCTION [dbo].[FnGetDocCode](@Class_Name varchar(100), @Sub_Class_Name varchar(100), @YearName int)
RETURNS int
AS
-- Returns the stock level for the product.
BEGIN
    
	Declare @DocCode int;

	
	select @DocCode = MAX(DocCode) from tab_Final_MR WHERE YearName = @YearName AND Class_Name=@Class_Name and Sub_Class_Name = @Sub_Class_Name
	if(@DocCode is null)
		begin
			set @DocCode = 1
		end
	else
		begin
			set @DocCode = @DocCode + 1
		end
	

	RETURN @DocCode
END;
GO

CREATE FUNCTION [dbo].[FnGetDocNo](@Class_Name varchar(100), @Sub_Class_Name varchar(100), @BranchKey int, @YearName int)
RETURNS varchar(100)
AS
-- Returns the stock level for the product.
BEGIN
    Declare @DocNo varchar(100) = '';
	Declare @CompanyCode varchar(5);
	Declare @BranchCode varchar(10);
    Declare @ClassCode varchar(20);
	Declare @SerialNo varchar(10);
	Declare @DocCode int;

	SET @CompanyCode = 'UIC';

	if(@Class_Name ='Marine Cargo' and @Sub_Class_Name = 'Cover Note') 
	begin
		SET @ClassCode = 'MC'
	end


	select @BranchCode = ShortName from tab_BranchInfo WHERE BranchKey=@BranchKey
	select @DocCode = MAX( DocCode) from tab_Final_MR WHERE YearName = @YearName AND Class_Name=@Class_Name and Sub_Class_Name = @Sub_Class_Name
	if(@DocCode is null)
		begin
			set @DocCode = 1
		end
	else
		begin
			set @DocCode = @DocCode + 1
		end
	
	select @SerialNo= right('0000' + cast(@DocCode as varchar(4)), 4)
	
	SET @DocNo = @CompanyCode+'/' + @BranchCode + '/' + @ClassCode + '-' + @SerialNo + '/' + CONVERT(varchar(2), MONTH(GETDATE())) + '/' + CONVERT(varchar(4), @YearName)
	
	--SET @DocNo = 'abc' + '/' + 'def'

	RETURN @DocNo
END;
GO