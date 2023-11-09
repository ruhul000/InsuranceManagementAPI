USE [Policy]
GO
/****** Object:  UserDefinedFunction [dbo].[LPAD]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



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

--insert into HM_ConsultantInfo values(@ConKey,dbo.LPad(@ConKey,0,3))


GO
/****** Object:  StoredProcedure [dbo].[AddClient]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddClient]
(
	@ClientKey [bigint] OUT,
	@BranchKey [int],
	@ClientName varchar(1000) = NULL,
	@ClientNameExtar [varchar](1000) = NULL,
	@ClientAddress [varchar](1000) = NULL,
	@ClientMobile [varchar](100) = NULL,
	@ClientType [varchar](100) = NULL,
	@ClientTypeTwo [varchar](100) = NULL,
	@ClientSector [varchar](100) = NULL,
	@ClientVATNo [varchar](100) = NULL,
	@ClientBINNo [varchar](100) = NULL,
	@ClientTINNo [varchar](100) = NULL,
	@Client_VAT_Exemption [int] = NULL,
	@GroupKey [int] = NULL,
	@ClientPhone [varchar](100) = NULL,
	@ClientFax [varchar](100) = NULL,
	@ClientEMail [varchar](100) = NULL,
	@ClientRelation [varchar](100) = NULL,
	@ClientWeb [varchar](100) = NULL,
	@ClientContractPer [varchar](100) = NULL,
	@ClientDesignation [varchar](100) = NULL,
	@SpecDiscount [numeric](18, 0) = NULL,
	@EmpKeyDirectorRef [int] = NULL,
	@Status [bit] = NULL,
	@Int_A [numeric](18, 0) = NULL,
	@Int_B [numeric](18, 0) = NULL,
	@Int_C [numeric](18, 0) = NULL,
	@Int_D [numeric](18, 0) = NULL,
	@Str_A [varchar](250) = NULL,
	@Str_B [varchar](250) = NULL,
	@Str_C [varchar](250) = NULL,
	@Str_D [varchar](250) = NULL,
	@Date_A [smalldatetime] = NULL,
	@Date_B [smalldatetime] = NULL,
	@Date_C [smalldatetime] = NULL,
	@BackupType [bit] = NULL
)
As

BEGIN
	INSERT INTO dbo.tab_Client
	(
		BranchKey,
		ClientName,
		ClientNameExtar,
		ClientAddress,
		ClientMobile,
		ClientType,
		ClientTypeTwo,
		ClientSector,
		ClientVATNo,
		ClientBINNo,
		ClientTINNo,
		Client_VAT_Exemption,
		GroupKey,
		ClientPhone,
		ClientFax,
		ClientEMail,
		ClientRelation,
		ClientWeb,
		ClientContractPer,
		ClientDesignation,
		SpecDiscount,
		EmpKeyDirectorRef,
		Status,
		Int_A,
		Int_B,
		Int_C,
		Int_D,
		Str_A,
		Str_B,
		Str_C,
		Str_D,
		Date_A,
		Date_B,
		Date_C,
		BackupType
	)
	VALUES
	(	
		@BranchKey,
		@ClientName,
		@ClientNameExtar,
		@ClientAddress,
		@ClientMobile,
		@ClientType,
		@ClientTypeTwo,
		@ClientSector,
		@ClientVATNo,
		@ClientBINNo,
		@ClientTINNo,
		@Client_VAT_Exemption,
		@GroupKey,
		@ClientPhone,
		@ClientFax,
		@ClientEMail,
		@ClientRelation,
		@ClientWeb,
		@ClientContractPer,
		@ClientDesignation,
		@SpecDiscount,
		@EmpKeyDirectorRef,
		@Status,
		@Int_A,
		@Int_B,
		@Int_C,
		@Int_D,
		@Str_A,
		@Str_B,
		@Str_C,
		@Str_D,
		@Date_A,
		@Date_B,
		@Date_C,
		@BackupType
	)
	SET @ClientKey=SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[BankBranchAdd]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BankBranchAdd]
	@BranchId [int] OUT,
	@BankId [int],
	@BranchName varchar(200) = NULL,
	@BranchAddress [varchar](1000) = NULL,
	@SwiftCode [varchar](1000) = NULL,	
	@RoutingNumber [varchar](100) = NULL,
	@Status bit = NULL,
	@EntryUserID [varchar](100) = NULL,
	@EntryTime [varchar](100) = NULL,
	@UpdateUserID [varchar](100) = NULL,
	@UpdateTime [varchar](100) = NULL
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO dbo.BankBranch
	(
		BranchName,
		BankId,
		BranchAddress,
		SwiftCode,
		RoutingNumber,
		[Status],
		EntryUserID,
		EntryTime,
		UpdateUserID,
		UpdateTime
	)
	VALUES
	(	
		@BranchName,
		@BankId,
		@BranchAddress,
		@SwiftCode,
		@RoutingNumber,
		@Status,
		@EntryUserID,
		@EntryTime,
		@UpdateUserID,
		@UpdateTime
	)
	SET @BranchId=SCOPE_IDENTITY()
    
END
GO
/****** Object:  StoredProcedure [dbo].[BankBranchUpdate]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[BankBranchUpdate]
	@Result [int] OUT,
	@BranchId int,
	@BranchName varchar(100),
	@BankId  int,
	@BranchAddress nvarchar(500),
	@SwiftCode varchar(50),
	@RoutingNumber varchar(50),
	@Status bit,
	@UpdateUserID int,
	@UpdateTime datetime
AS
BEGIN
	UPDATE BankBranch SET BranchName=@BranchName, BankId=@BankId,BranchAddress=@BranchAddress,SwiftCode=@SwiftCode,
	RoutingNumber=@RoutingNumber,Status=@Status,UpdateUserID=@UpdateUserID,UpdateTime=@UpdateTime WHEre BranchId=@BranchId
	SET @Result = 1
END
GO
/****** Object:  StoredProcedure [dbo].[BankUpdate]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[BankUpdate]
	@Result [int] OUT,
	@BankId int,
	@BankName varchar(100)
AS
BEGIN
	UPDATE Bank SET BankName=@BankName WHEre BankId=@BankId
	SET @Result = 1
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllBankBranches]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllBankBranches] 
	@BankName nvarchar(200) ,
	@Branchname nvarchar(200) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Bank.BankName,BankBranch.BranchId,BankBranch.BranchName,BankBranch.BranchAddress,BankBranch.SwiftCode,BankBranch.RoutingNumber,BankBranch.BankId, BankBranch.EntryTime,BankBranch.UpdateTime,BankBranch.EntryUserID,BankBranch.UpdateUserID,BankBranch.Status  from BankBranch inner join Bank on BankBranch.BankId= Bank.BankId
	WHERe Bank.BankName like '%' + @BankName +'%' AND BankBranch.BranchName like '%' + @Branchname +'%'
	Order by Bank.BankName, BankBranch.BranchName
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllInsuranceCompanies]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllInsuranceCompanies]
	
AS
BEGIN
	SELECT * FROM InsuranceCompany
END
GO
/****** Object:  StoredProcedure [dbo].[GetBankBranchById]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetBankBranchById] 
	@BranchId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Bank.BankName,BankBranch.BranchId,BankBranch.BranchName,BankBranch.BranchAddress,BankBranch.SwiftCode,BankBranch.RoutingNumber,BankBranch.BankId, BankBranch.EntryTime,BankBranch.UpdateTime,BankBranch.EntryUserID,BankBranch.UpdateUserID,BankBranch.Status  from BankBranch inner join Bank on BankBranch.BankId= Bank.BankId
	WHERe BankBranch.Branchid= @BranchId
	
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetBankBranches]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[GetBankBranches] 
	@BankId int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Bank.BankName,BankBranch.BranchId,BankBranch.BranchName,BankBranch.BranchAddress,BankBranch.SwiftCode,BankBranch.RoutingNumber,BankBranch.BankId, BankBranch.EntryTime,BankBranch.UpdateTime,BankBranch.EntryUserID,BankBranch.UpdateUserID,BankBranch.Status  from BankBranch inner join Bank on BankBranch.BankId= Bank.BankId
	WHERe BankBranch.BankId= @BankId
	
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetInsuranceCompanyById]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInsuranceCompanyById] 
	@CompanyId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * from InsuranceCompany
	WHERe InsuranceCompany.CompanyId= @CompanyId
	
    
END
GO
/****** Object:  StoredProcedure [dbo].[InsuranceCompanyAdd]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsuranceCompanyAdd]
	@CompanyId int out,
	@CompanyName varchar(100),
	@status bit,
	@EntryUserID int,
	@EntryTime datetime,
	@UpdateUserID int,
	@UpdateTime datetime

AS
BEGIN
	INSERT INTO dbo.InsuranceCompany (CompanyName,status,EntryUserID,EntryTime,UpdateUserID,UpdateTime) values(@CompanyName,@status,@EntryUserID,@EntryTime,@UpdateUserID,@UpdateTime)

    SET @CompanyId=SCOPE_IDENTITY()
	
END
GO
/****** Object:  StoredProcedure [dbo].[InsuranceCompanyUpdate]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsuranceCompanyUpdate]
	@Result bit output,
	@CompanyId int,
	@CompanyName varchar(100),
	@status bit,
	@UpdateUserId int,
	@UpdateTime datetime
AS

BEGIN
	
	DECLARE @ThisCount AS INT
	SELECT @ThisCount=COUNT(*) FROM InsuranceCompany WHERE CompanyId=@CompanyId

	IF @ThisCount > 0
	BEGIN
		UPDATE InsuranceCompany SET CompanyName=@CompanyName,status= @status,UpdateUserId=@UpdateUserId,UpdateTime=@UpdateTime WHERE CompanyId=@CompanyId
		SET @Result = 1
	END
	ELSE
	BEGIN
		SET @Result = 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Branch_Add]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Branch_Add]

@BranchKey	int OUT,
@ComKey	int = 0,
@BranchID	varchar(100) = NULL,
@BranchOrderKey		INT=0,
@Branch_Open_Date	smalldatetime = NULL,
@BranchName			varchar(100) = NULL,
@ShortName			varchar(50) = NULL,
@ZoneKey			INT=0,
@Address			varchar(200) = NULL,
@Branch_Address_2	varchar(200) = NULL,
@Branch_Address_3	varchar(200) = NULL,
@Phone				varchar(50) = NULL,
@Mobile				varchar(50) = NULL,
@Fax				varchar(50) = NULL,
@EMail				varchar(50) = NULL,
@EmpKeyIncharge		int = 0,
@IssuingPlace		varchar(500) = NULL,
@IssuingPlace_2		varchar(500) = NULL,
@IssuingPlace_3		varchar(500) = NULL,
@Computerized		bit=0,
@Seal				varchar(MAX) = NULL,
@Signatore_Name_A	varchar(200) = NULL,
@Signatore_A		varchar(MAX) = NULL,
@Signatore_Name_B	varchar(200) = NULL,
@Signatore_B		varchar(MAX) = NULL,
@Signatore_Name_C	varchar(200) = NULL,
@Signatore_C		varchar(MAX) = NULL,
@Status				bit = 0,
@BackupType			bit = 0
AS
BEGIN
	declare @temp int
	SET @temp = (select  max(BranchKey) as BranchKey from tab_BranchInfo)
	SET @BranchID = dbo.LPad(@temp,0,2)
	INSERT INTO tab_BranchInfo (	
			ComKey,			
			BranchID,
			BranchOrderKey,
			Branch_Open_Date,
			BranchName,
			ShortName,
			ZoneKey,
			Address,
			Branch_Address_2,
			Branch_Address_3,
			Phone,
			Mobile,
			Fax,
			EMail,
			EmpKeyIncharge,
			IssuingPlace,
			IssuingPlace_2,
			IssuingPlace_3,
			Computerized,
			Seal,
			Signatore_Name_A,
			Signatore_A,
			Signatore_Name_B,
			Signatore_B,
			Signatore_Name_C,
			Signatore_C,
			Status,			
			BackupType) 
			
			VALUES (
			@ComKey,			
			@BranchID,
			@BranchOrderKey,
			@Branch_Open_Date,
			@BranchName,
			@ShortName,
			@ZoneKey,
			@Address,
			@Branch_Address_2,
			@Branch_Address_3,
			@Phone,
			@Mobile,
			@Fax,
			@EMail,
			@EmpKeyIncharge,
			@IssuingPlace,
			@IssuingPlace_2,
			@IssuingPlace_3,
			@Computerized,
			@Seal,
			@Signatore_Name_A,
			@Signatore_A,
			@Signatore_Name_B,
			@Signatore_B,
			@Signatore_Name_C,
			@Signatore_C,
			@Status,			
			@BackupType)

			SET @BranchKey =SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Branch_Update]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Branch_Update]
@Result int OUT,
@BranchKey	int,
@ComKey	int = 0,
@BranchID	varchar(100) = NULL,
@BranchOrderKey		INT=0,
@Branch_Open_Date	smalldatetime = NULL,
@BranchName			varchar(100) = NULL,
@ShortName			varchar(50) = NULL,
@ZoneKey			INT=0,
@Address			varchar(200) = NULL,
@Branch_Address_2	varchar(200) = NULL,
@Branch_Address_3	varchar(200) = NULL,
@Phone				varchar(50) = NULL,
@Mobile				varchar(50) = NULL,
@Fax				varchar(50) = NULL,
@EMail				varchar(50) = NULL,
@EmpKeyIncharge		int = 0,
@IssuingPlace		varchar(500) = NULL,
@IssuingPlace_2		varchar(500) = NULL,
@IssuingPlace_3		varchar(500) = NULL,
@Computerized		bit=0,
@Seal				varchar(MAX) = NULL,
@Signatore_Name_A	varchar(200) = NULL,
@Signatore_A		varchar(MAX) = NULL,
@Signatore_Name_B	varchar(200) = NULL,
@Signatore_B		varchar(MAX) = NULL,
@Signatore_Name_C	varchar(200) = NULL,
@Signatore_C		varchar(MAX) = NULL,
@Status				bit = 0,
@BackupType			bit = 0
AS
BEGIN
	
	UPDATE tab_BranchInfo SET	
			ComKey = @ComKey,			
			BranchID = @BranchID,
			BranchOrderKey =@BranchOrderKey,
			Branch_Open_Date = @Branch_Open_Date,
			BranchName = @BranchName,
			ShortName = @ShortName,
			ZoneKey =@ZoneKey,
			Address =@Address,
			Branch_Address_2 =@Branch_Address_2,
			Branch_Address_3 =@Branch_Address_3,
			Phone = @Phone,
			Mobile = @Mobile,
			Fax =@Fax,
			EMail = @EMail,
			EmpKeyIncharge = @EmpKeyIncharge,
			IssuingPlace = @IssuingPlace,
			IssuingPlace_2 = @IssuingPlace_2,
			IssuingPlace_3 =@IssuingPlace_3,
			Computerized =@Computerized,
			Seal =@Seal,
			Signatore_Name_A = @Signatore_Name_A,
			Signatore_A = @Signatore_A,
			Signatore_Name_B = @Signatore_Name_B,
			Signatore_B = @Signatore_B,
			Signatore_Name_C = @Signatore_Name_C,
			Signatore_C = @Signatore_C,
			Status = @Status,			
			BackupType = @BackupType
			WHERE BranchKey= @BranchKey
			
			SET @Result = 1
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Company_Add]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Company_Add]
	@ComKey int OUT,
	@CompanyName varchar(100) ,
	@ShortName varchar(10) ,
	@Address varchar(500) ,
	@Phone varchar(50) ,
	@Fax varchar(50) ,
	@Mobile varchar(50) ,
	@Email varchar(50) ,
	@IssuingPlaceHO varchar(50) ,
	@Web varchar(50) ,
	@Logo varchar(MAX) null ,
	@Banner varchar(MAX) null,
	@BackupType bit
AS
BEGIN
	INSERT INTO dbo.tab_CompanyInfo ([CompanyName],ShortName,[Address],Phone,Fax,Mobile,Email,IssuingPlaceHO,Web,Logo,LHead,BackupType)
	VALUES(@CompanyName,@ShortName,@Address,@Phone,@Fax,@Mobile,@Email,@IssuingPlaceHO,@Web,@Logo,@Banner,@BackupType)
	SET @ComKey =SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Company_Update]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Company_Update]
	@result int Out,
	@ComKey int,
	@CompanyName varchar(100) ,
	@ShortName varchar(10) ,
	@Address varchar(500) ,
	@Phone varchar(50) ,
	@Fax varchar(50) ,
	@Mobile varchar(50) ,
	@Email varchar(50) ,
	@IssuingPlaceHO varchar(50) ,
	@Web varchar(50) ,
	@Logo varchar(MAX) null ,
	@Banner varchar(MAX) null,
	@BackupType bit
AS
BEGIN
	DECLARE @ThisClientCount AS INT
	SELECT @ThisClientCount=COUNT(*) FROM tab_CompanyInfo WHERE  ComKey=@ComKey

	IF @ThisClientCount > 0
	BEGIN
		UPDATE dbo.tab_CompanyInfo SET [CompanyName] = @CompanyName ,ShortName =@ShortName,[Address]=@Address,Phone=@Phone,Fax=@Fax,Mobile=@Mobile,Email=@Email,IssuingPlaceHO=@IssuingPlaceHO,Web=@Web,Logo=@Logo,LHead=@Banner,BackupType=@BackupType WHERE ComKey=@ComKey
		SET @result = 1
	
	END
	ELSE
	BEGIN
		SET @result =0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateClient]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateClient]
(
	@Result bit OUTPUT,
	@ClientKey [bigint],
	@BranchKey [int],
	@ClientName varchar(1000) = NULL,
	@ClientNameExtar [varchar](1000) = NULL,
	@ClientAddress [varchar](1000) = NULL,
	@ClientMobile [varchar](100) = NULL,
	@ClientType [varchar](100) = NULL,
	@ClientTypeTwo [varchar](100) = NULL,
	@ClientSector [varchar](100) = NULL,
	@ClientVATNo [varchar](100) = NULL,
	@ClientBINNo [varchar](100) = NULL,
	@ClientTINNo [varchar](100) = NULL,
	@Client_VAT_Exemption [int] = NULL,
	@GroupKey [int] = NULL,
	@ClientPhone [varchar](100) = NULL,
	@ClientFax [varchar](100) = NULL,
	@ClientEMail [varchar](100) = NULL,
	@ClientRelation [varchar](100) = NULL,
	@ClientWeb [varchar](100) = NULL,
	@ClientContractPer [varchar](100) = NULL,
	@ClientDesignation [varchar](100) = NULL,
	@SpecDiscount [numeric](18, 0) = NULL,
	@EmpKeyDirectorRef [int] = NULL,
	@Status [bit] = NULL,
	@Int_A [numeric](18, 0) = NULL,
	@Int_B [numeric](18, 0) = NULL,
	@Int_C [numeric](18, 0) = NULL,
	@Int_D [numeric](18, 0) = NULL,
	@Str_A [varchar](250) = NULL,
	@Str_B [varchar](250) = NULL,
	@Str_C [varchar](250) = NULL,
	@Str_D [varchar](250) = NULL,
	@Date_A [smalldatetime] = NULL,
	@Date_B [smalldatetime] = NULL,
	@Date_C [smalldatetime] = NULL,
	@BackupType [bit] = NULL
)
As

BEGIN
	DECLARE @ThisClientCount AS INT
	SELECT @ThisClientCount=COUNT(*) FROM tab_Client WHERE ClientKey=@ClientKey

	IF @ThisClientCount > 0
	BEGIN
		UPDATE tab_Client
		SET 
		BranchKey = @BranchKey,
		ClientName = @ClientName,
		ClientNameExtar	= @ClientNameExtar,
		ClientAddress = @ClientAddress,
		ClientMobile = @ClientMobile,
		ClientType = @ClientType,
		ClientTypeTwo = @ClientTypeTwo,
		ClientSector = @ClientSector,
		ClientVATNo = @ClientVATNo,
		ClientBINNo = @ClientBINNo,
		ClientTINNo = @ClientTINNo,
		Client_VAT_Exemption = @Client_VAT_Exemption,
		GroupKey = @GroupKey,
		ClientPhone = @ClientPhone,
		ClientFax = @ClientFax,
		ClientEMail = @ClientEMail,
		ClientRelation = @ClientRelation,
		ClientWeb = @ClientWeb,
		ClientContractPer = @ClientContractPer,
		ClientDesignation = @ClientDesignation,
		SpecDiscount = @SpecDiscount,
		EmpKeyDirectorRef = @EmpKeyDirectorRef,
		[Status] = @Status,
		Int_A = @Int_A,
		Int_B = @Int_B,
		Int_C = @Int_C,
		Int_D = @Int_D,
		Str_A = @Str_A,
		Str_B = @Str_B,
		Str_C = @Str_C,
		Str_D = @Str_D,
		Date_A = @Date_A,
		Date_B = @Date_B,
		Date_C = @Date_C,
		BackupType = @BackupType
		WHERE 
		ClientKey = @ClientKey

		SET @Result = 1
	END
	ELSE
	BEGIN
		SET @Result = 0
	END
END
GO

CREATE PROCEDURE [dbo].[SpMC_Tariff]
AS
BEGIN 
	Select Distinct Tariff_Catagory, null as ItemName, null as Per, null as TariffKey, null as TypeA, null as TypeB, null as TypeC, null as TypeOfRisk from Marine_Cargo_Tariff
END


GO

/****** Object:  NumberedStoredProcedure [dbo].[SpMC_Tariff];2    Script Date: 09/11/2023 17:01:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpMC_Tariff];2
@Tariff_Catagory VARCHAR(50)=NULL,
@TypeOfRisk	 VARCHAR(50)=NULL
AS
BEGIN
	Select Distinct null Tariff_Catagory, ItemName, null as Per, null as TariffKey, null as TypeA, null as TypeB, null as TypeC, null as TypeOfRisk 
			 from Marine_Cargo_Tariff
			 where Tariff_Catagory=@Tariff_Catagory
			       AND TypeOfRisk=@TypeOfRisk
	
END
GO

/****** Object:  NumberedStoredProcedure [dbo].[SpMC_Tariff];3    Script Date: 09/11/2023 17:01:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpMC_Tariff];3
@Tariff_Catagory VARCHAR(50)=NULL,
@TypeOfRisk	 VARCHAR(50)=NULL,
@ItemName	 VARCHAR(250)=NULL

AS
BEGIN

	DECLARE @RecordCount as int
	SELECT @RecordCount =  COUNT( Distinct TypeA ) 
			 from Marine_Cargo_Tariff
			 where Tariff_Catagory=@Tariff_Catagory
			       AND TypeOfRisk=@TypeOfRisk
			       AND ItemName=@ItemName
				AND TypeA IS NOT NULL

	IF(@RecordCount >0)
	BEGIN
	Select Distinct TypeA , null as Tariff_Catagory, null as ItemName, null as Per, null as TariffKey,  null as TypeB, null as TypeC, null as TypeOfRisk 
			 from Marine_Cargo_Tariff
			 where Tariff_Catagory=@Tariff_Catagory
			       AND TypeOfRisk=@TypeOfRisk
			       AND ItemName=@ItemName
				AND TypeA IS NOT NULL

	END
	ELSE
	BEGIN
	Select ISNULL(Per,0)AS Per, null as TypeA , null as Tariff_Catagory, null as ItemName,  null as TariffKey,  null as TypeB, null as TypeC, null as TypeOfRisk 
			 From Marine_Cargo_Tariff
			 where
	 		 Tariff_Catagory=@Tariff_Catagory
  		  	 AND TypeOfRisk=@TypeOfRisk
  		  	 AND ItemName=@ItemName
	
	END
	
END


GO

/****** Object:  NumberedStoredProcedure [dbo].[SpMC_Tariff];4    Script Date: 09/11/2023 17:01:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpMC_Tariff];4
@Tariff_Catagory VARCHAR(50)=NULL,
@TypeOfRisk	 VARCHAR(50)=NULL,
@ItemName	 VARCHAR(250)=NULL,
@TypeA		 VARCHAR(250)=NULL
AS
BEGIN

	DECLARE @RecordCount as int
	SELECT @RecordCount =  COUNT( Distinct TypeB ) 
			 from Marine_Cargo_Tariff
			 where Tariff_Catagory=@Tariff_Catagory
			       AND TypeOfRisk=@TypeOfRisk
			       AND ItemName=@ItemName
				   AND TypeA=@TypeA
				AND TypeB IS NOT NULL

	IF(@RecordCount >0)
		BEGIN
			Select Distinct TypeB, null as Tariff_Catagory, null as ItemName, null as Per, null as TariffKey,  null as TypeA, null as TypeC, null as TypeOfRisk 
				 from Marine_Cargo_Tariff
				 where Tariff_Catagory=@Tariff_Catagory
					   AND TypeOfRisk=@TypeOfRisk
					   AND ItemName=@ItemName
					   AND TypeA=@TypeA
	                 		AND TypeB IS NOT NULL

		END
	ELSE
		BEGIN
			Select ISNULL(Per,0)AS Per, null as Tariff_Catagory, null as ItemName, null as TariffKey,  null as TypeA, null as TypeB, null as TypeC, null as TypeOfRisk 
				 From Marine_Cargo_Tariff
				 where
	 			 Tariff_Catagory=@Tariff_Catagory
  		  		 AND TypeOfRisk=@TypeOfRisk
  		  		 AND ItemName=@ItemName
  		  		 AND TypeA=@TypeA
		END
	
END


GO

/****** Object:  NumberedStoredProcedure [dbo].[SpMC_Tariff];5    Script Date: 09/11/2023 17:01:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpMC_Tariff];5
@Tariff_Catagory VARCHAR(50)=NULL,
@TypeOfRisk	 VARCHAR(50)=NULL,
@ItemName	 VARCHAR(250)=NULL,
@TypeA		 VARCHAR(250)=NULL,
@TypeB		 VARCHAR(250)=NULL
AS
BEGIN

	DECLARE @RecordCount as int
	SELECT @RecordCount =  COUNT( Distinct TypeC ) 
			 from Marine_Cargo_Tariff
			 where Tariff_Catagory=@Tariff_Catagory
			       AND TypeOfRisk=@TypeOfRisk
			       AND ItemName=@ItemName
				   AND TypeA=@TypeA
				   AND TypeB = @TypeB
				AND TypeB IS NOT NULL
    IF(@RecordCount > 0)
	BEGIN
		Select Distinct TypeC, null as Tariff_Catagory, null as ItemName, null as Per, null as TariffKey,  null as TypeA, null as TypeB, null as TypeOfRisk 
			 from Marine_Cargo_Tariff
			 where Tariff_Catagory=@Tariff_Catagory
			       AND TypeOfRisk=@TypeOfRisk
			       AND ItemName=@ItemName
			       AND TypeA=@TypeA
			       AND TypeB=@TypeB
                         	AND TypeC IS NOT NULL

	END
	ELSE
	BEGIN

		Select ISNULL(Per,0)AS Per,null as Tariff_Catagory, null as ItemName,  null as TariffKey,  null as TypeA,null as TypeB, null as TypeC, null as TypeOfRisk 
			 From Marine_Cargo_Tariff
			 where
	 		 Tariff_Catagory=@Tariff_Catagory
  		  	 AND TypeOfRisk=@TypeOfRisk
  		  	 AND ItemName=@ItemName
  		  	 AND TypeA=@TypeA
  		  	 AND TypeB=@TypeB
	END
END


GO

/****** Object:  NumberedStoredProcedure [dbo].[SpMC_Tariff];6    Script Date: 09/11/2023 17:01:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpMC_Tariff];6
@Tariff_Catagory VARCHAR(50)=NULL,
@TypeOfRisk	 VARCHAR(50)=NULL,
@ItemName	 VARCHAR(250)=NULL,
@TypeA		 VARCHAR(250)=NULL,
@TypeB		 VARCHAR(250)=NULL,
@TypeC		 VARCHAR(250)=NULL
AS
BEGIN

	
		Select ISNULL(Per,0)AS Per,null as Tariff_Catagory, null as ItemName,  null as TariffKey,  null as TypeA,null as TypeB, null as TypeC, null as TypeOfRisk 
			 From Marine_Cargo_Tariff
			 where
	 		 Tariff_Catagory=@Tariff_Catagory
  		  	 AND TypeOfRisk=@TypeOfRisk
  		  	 AND ItemName=@ItemName
  		  	 AND TypeA=@TypeA
  		  	 AND TypeB=@TypeB
			 AND TypeC=@TypeC
END


GO

/****** Object:  NumberedStoredProcedure [dbo].[SpMC_Tariff];7    Script Date: 09/11/2023 17:01:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SpMC_Tariff];7
AS
BEGIN 
	Select * from Marine_Cargo_Tariff_FBIG order by Item_Name
END


GO
