USE [Policy]
GO
/****** Object:  UserDefinedFunction [dbo].[LPAD]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER FUNCTION [dbo].[LPAD]  (@STR VARCHAR(8000), @FORMAT_STR CHAR(1), @PAD_LEN INT) 
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

ALTER PROCEDURE [dbo].[AddClient]
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
ALTER PROCEDURE [dbo].[BankBranchAdd]
	@BranchId [int] OUT,	
	@BranchName nvarchar(200) = NULL,
	@BankId [int],
	@BranchAddress nvarchar(500) = NULL,
	@SwiftCode varchar(50) = NULL,
	@RoutingNumber varchar(50) = NULL,
	@Status bit = NULL,
	@EUser int = NULL,	
	@UUser int = NULL
	
AS
BEGIN
	DECLARE @EDate smalldatetime
	DECLARE @UDate smalldatetime
	SET @EDate = GETDATE()
	SET @UDate = GETDATE()

	SET NOCOUNT ON;
	INSERT INTO dbo.BankBranch
	(
		BranchName,
		BankId,
		BranchAddress,
		SwiftCode,
		RoutingNumber,
		Status,
		EUser,
		EDate,
		UUser,
		UDate
	)
	VALUES
	(	
		@BranchName,
		@BankId,
		@BranchAddress,
		@SwiftCode,
		@RoutingNumber,
		@Status,
		@EUser,
		@EDate,
		@UUser,
		@UDate
	)
	SET @BranchId=SCOPE_IDENTITY()
    
END
GO
/****** Object:  StoredProcedure [dbo].[BankBranchUpdate]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[BankBranchUpdate]
	@Result [int] OUT,
	@BranchId int,
	@BranchName varchar(100),
	@BankId  int,
	@BranchAddress nvarchar(500),
	@SwiftCode varchar(50),
	@RoutingNumber varchar(50),
	@Status bit,
	@UUser int
AS
BEGIN
	UPDATE BankBranch SET BranchName=@BranchName, BankId=@BankId,BranchAddress=@BranchAddress,SwiftCode=@SwiftCode,
	RoutingNumber=@RoutingNumber,Status=@Status,UUser=@UUser,UDate=GETDATE() WHEre BranchId=@BranchId
	SET @Result = 1
END
GO
/****** Object:  StoredProcedure [dbo].[BankUpdate]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[BankUpdate]
	@Result [int] OUT,
	@BankId int,
	@BankName varchar(100),
	@UUser int
AS
BEGIN
	Declare @UDate datetime
	set @UDate = GETDATE()
	UPDATE Bank SET BankName=@BankName, UUser=@UUser, UDate=@UDate WHEre BankId=@BankId
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
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetAllBankBranches] 
	@BankName nvarchar(200)= null ,
	@Branchname nvarchar(200) = null 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Bank.BankName,BankBranch.BranchId,BankBranch.BranchName,BankBranch.BranchAddress,BankBranch.SwiftCode,BankBranch.RoutingNumber,BankBranch.BankId, BankBranch.EDate,BankBranch.UDate,BankBranch.EUser,BankBranch.UUser,BankBranch.Status  from BankBranch inner join Bank on BankBranch.BankId= Bank.BankId
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
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetAllInsuranceCompanies]
	
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
ALTER PROCEDURE [dbo].[GetBankBranchById] 
	@BranchId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Bank.BankName,BankBranch.BranchId,BankBranch.BranchName,BankBranch.BranchAddress,BankBranch.SwiftCode,BankBranch.RoutingNumber,BankBranch.BankId, BankBranch.EDate,BankBranch.UDate,BankBranch.EUser,BankBranch.UUser,BankBranch.Status  from BankBranch inner join Bank on BankBranch.BankId= Bank.BankId
	WHERe BankBranch.Branchid= @BranchId
	
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetBankBranches]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[GetBankBranches] 
	@BankId int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Bank.BankName,BankBranch.BranchId,BankBranch.BranchName,BankBranch.BranchAddress,BankBranch.SwiftCode,BankBranch.RoutingNumber,BankBranch.BankId, BankBranch.EDate,BankBranch.UDate,BankBranch.EUser,BankBranch.UUser,BankBranch.Status  from BankBranch inner join Bank on BankBranch.BankId= Bank.BankId
	WHERe BankBranch.BankId= @BankId
	
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetInsuranceCompanyById]    Script Date: 21/09/2023 17:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetInsuranceCompanyById] 
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
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[InsuranceCompanyAdd]
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
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[InsuranceCompanyUpdate]
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
ALTER PROCEDURE [dbo].[SP_Branch_Add]

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
ALTER PROCEDURE [dbo].[SP_Branch_Update]
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

ALTER PROCEDURE [dbo].[SP_Company_Add]
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
	@Logo varchar(MAX) = null ,
	@Banner varchar(MAX) = null,
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


ALTER PROCEDURE [dbo].[SP_Company_Update]
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
	@Logo varchar(MAX) = null ,
	@Banner varchar(MAX) = null,
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

ALTER PROCEDURE [dbo].[UpdateClient]
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

ALTER PROCEDURE [dbo].[SpMC_Tariff]
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

ALTER PROCEDURE [dbo].[SpMC_Tariff];2
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

ALTER PROCEDURE [dbo].[SpMC_Tariff];3
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

ALTER PROCEDURE [dbo].[SpMC_Tariff];4
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

ALTER PROCEDURE [dbo].[SpMC_Tariff];5
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

ALTER PROCEDURE [dbo].[SpMC_Tariff];6
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




ALTER PROCEDURE [dbo].[SpMC_Tariff];7
AS
BEGIN 
	Select * from Marine_Cargo_Tariff_FBIG order by Item_Name
END


GO

ALTER PROCEDURE [dbo].[Sptab_Final_MR]
@FinalMRKey	bigint OUT ,
@FinalMRKeyREF	bigint = 0,
@BranchKey	int = 0,
@Class_Name	varchar(50) = NULL,
@Sub_Class_Name	varchar(50) = NULL,
@YearName	smallint = 0,
@MRType	varchar(50) = NULL,
@MRType_2	varchar(50) = NULL,
@MRType_3	varchar(50) = NULL,
@MRType_4	varchar(50) = NULL,
@MRCode	int = 0,
@MRCode_Dis	varchar(50) = NULL,
@MRDate	smalldatetime = NULL,
@DocCode	int = 0,
@DocNo	varchar(500) = NULL,
@DocDate	smalldatetime = NULL,
@CoverNoteNo	varchar(500) = NULL,
@CNDate	smalldatetime = NULL,
@PolicyNo	varchar(500) = NULL,
@PODate	smalldatetime = NULL,
@CoIns	bit = 0,
@ComKeyCoIns	int = 0,
@LeaderDocNo	varchar(500) = NULL,
@CoInsPer	numeric(18,2) = 0,
@We_Leader	bit = 0,
@SumInsured	numeric(18,0) = 0,
@SumInsuredCoIns	numeric(18,0) = 0,
@MRNetPremium	numeric(18,2) = 0,
@NetPremium	numeric(18,2) = 0,
@VatPer numeric(18,2) = 0,
@VatAmount	numeric(18,2) = 0,
@StampDuty	numeric(18,2) = 0,
@OthersAmount	numeric(18,0) = 0,
@Ref_SumInsured	numeric(18,0) = 0,
@Ref_SumInsuredCoIns	numeric(18,0) = 0,
@Ref_NetPremium	numeric(18,2) = 0,
@Ref_VatAmount	numeric(18,2) = 0,
@Ref_StampDuty	numeric(18,2) = 0,
@Ref_ChargeAmount	numeric(18,2) = 0,
@Ref_DocNo	varchar(1000) = NULL,
@Ref_CoInsSumInsured	numeric(18,0) = 0,
@Ref_CoInsNetPremium	numeric(18,2) = 0,
@Active	bit = 0,
@DepositDate	smalldatetime = NULL,
@Depo_NetPremium	numeric(18,0) = 0,
@Depo_NetPremium_CoIns	numeric(18,0) = 0,
@Depo_VatAmount	numeric(18,0) = 0,
@Depo_StampDuty	numeric(18,0) = 0,
@MR_Allowable	int = 0,
@Business	int = 0,
@ClientKey	bigint = 0,
@BankKey	bigint = 0,
@ClientKey_Old	bigint = 0,
@BankKey_Old	bigint = 0,
@EmpKey	int = 0,
@AgentKey	int = 0,
@PeriodFrom	smalldatetime = NULL,
@PeriodTo	smalldatetime = NULL,
@Text_Field_1	varchar(500) = NULL,
@Text_Field_2	varchar(500) = NULL,
@Text_Field_3	varchar(500) = NULL,
@Text_Field_4	varchar(500) = NULL,
@Text_Field_5	varchar(500) = NULL,
@Text_Field_6	varchar(500) = NULL,
@Text_Field_7	varchar(500) = NULL,
@Text_Field_8	varchar(500) = NULL,
@Text_Field_9	varchar(500) = NULL,
@Text_Field_10	varchar(500) = NULL,
@Text_Field_11	varchar(500) = NULL,
@Text_Field_12	varchar(500) = NULL,
@Text_Field_13	varchar(500) = NULL,
@Text_Field_14	varchar(500) = NULL,
@Text_Field_15	varchar(500) = NULL,
@Text_Field_16	varchar(500) = NULL,
@Text_Field_17	varchar(500) = NULL,
@Text_Field_18	varchar(500) = NULL,
@Text_Field_19	varchar(500) = NULL,
@Text_Field_20	varchar(500) = NULL,
@Text_Field_21	varchar(500) = NULL,
@Text_Field_22	varchar(500) = NULL,
@Text_Field_23	varchar(500) = NULL,
@Text_Field_24	varchar(500) = NULL,
@Text_Field_25	varchar(500) = NULL,
@Text_Field_26	varchar(500) = NULL,
@Text_Field_27	varchar(500) = NULL,
@Text_Field_28	varchar(500) = NULL,
@Text_Field_29	varchar(500) = NULL,
@Text_Field_30	varchar(500) = NULL,
@Num_Field_1	numeric(18,4) = 0,
@Num_Field_2	numeric(18,4) = 0,
@Num_Field_3	numeric(18,4) = 0,
@Num_Field_4	numeric(18,4) = 0,
@Num_Field_5	numeric(18,4) = 0,
@Num_Field_6	numeric(18,4) = 0,
@Num_Field_7	numeric(18,4) = 0,
@Num_Field_8	numeric(18,4) = 0,
@Num_Field_9	numeric(18,4) = 0,
@Num_Field_10	numeric(18,4) = 0,
@Num_Field_11	numeric(18,4) = 0,
@Num_Field_12	numeric(18,4) = 0,
@Num_Field_13	numeric(18,4) = 0,
@Num_Field_14	numeric(18,4) = 0,
@Num_Field_15	numeric(18,4) = 0,
@Num_Field_16	numeric(18,4) = 0,
@Num_Field_17	numeric(18,4) = 0,
@Num_Field_18	numeric(18,4) = 0,
@Num_Field_19	numeric(18,4) = 0,
@Num_Field_20	numeric(18,4) = 0,
@Num_Field_21	numeric(18,4) = 0,
@Num_Field_22	numeric(18,4) = 0,
@Num_Field_23	numeric(18,4) = 0,
@Num_Field_24	numeric(18,4) = 0,
@Num_Field_25	numeric(18,4) = 0,
@Num_Field_26	numeric(18,4) = 0,
@Num_Field_27	numeric(18,4) = 0,
@Num_Field_28	numeric(18,4) = 0,
@Num_Field_29	numeric(18,4) = 0,
@Num_Field_30	numeric(18,4) = 0,
@Date_Field_1	smalldatetime = NULL,
@Date_Field_2	smalldatetime = NULL,
@Date_Field_3	smalldatetime = NULL,
@Bank_Guarantee	int = 0,
@Coll_Our_Share	varchar(50) = null,
@NewClient	int = 0,
@WithChargeAmount	int = 0,
@DocCancel	bit = 0,
@DocCancelDate	smalldatetime = NULL,
@NotUtilized	bit = 0,
@DocEdit	bit = 0,
@ReinsuranceAmount	numeric(18,2) = 0,
@ClaimAmount	numeric(18,2) = 0,
@VoucherKey	bigint = 0,
@HO	bit = 0,
@Pay_Status	bit = 0,
@BoughKey	int = 0,
@TargetKey	numeric(18,0) = 0,
@Remarks	varchar(1000) = NULL,
@PaymentType	varchar(50) = NULL,
@CurrencyName	varchar(50) = NULL,
@FCurrText	varchar(50) = NULL,
@AmountInWord	varchar(1000) = NULL,
@BankName	varchar(50) = NULL,
@BranchName	varchar(50) = NULL,
@ChequeNo	varchar(50) = NULL,
@ChequeDate	smalldatetime = NULL,
@ChargeAmount	numeric(18,0) = 0,
@PrintStatus	bit = 0,
@PrintStatus_CN	bit = 0,
@PrintStatus_PO	bit = 0,
@Transfer	int = 0,
@VATStop	bit = 0,
@EmpKeyOld	int = 0,
@BlockPIN	bit = 0,
@CoInsBillRec	bit = 0,
@CoInsBillDetails	varchar(500) = NULL,
@LockData	bit = 0,
@LockData_Yearly	bit = 0,
@DelFlag	bit=0,
@PC_Name	varchar(100) = NULL,
@EUser	int = 0,
@UUser	int = 0,
@BackupType	bit = 0
AS
DECLARE @EDate smalldatetime
DECLARE @UDate smalldatetime
SET @EDate = GETDATE()
SET @UDate = GETDATE()
BEGIN

	BEGIN	
		set @DocNo =  dbo.FnGetDocNo(@Class_Name, @Sub_Class_Name, @BranchKey ,@YearName);
		set @DocCode = dbo.FnGetDocCode(@Class_Name, @Sub_Class_Name,@YearName);

		if(@Class_Name = 'Marine Cargo' and @Sub_Class_Name='Cover Note')
		BEGIN
			SET @CoverNoteNo = @DocNo
		END
	END
	
	BEGIN
	INSERT INTO dbo.tab_Final_MR
	(			
			FinalMRKeyREF,
			BranchKey,
			Class_Name,
			Sub_Class_Name,
			YearName,
			MRType,
			MRType_2,
			MRType_3,
			MRType_4,
			MRCode,
			MRCode_Dis,
			MRDate,
			DocCode,
			DocNo,
			DocDate,
			CoverNoteNo,
			CNDate,
			PolicyNo,
			PODate,
			CoIns,
			ComKeyCoIns,
			LeaderDocNo,
			CoInsPer,
			We_Leader,
			SumInsured,
			SumInsuredCoIns,
			MRNetPremium,
			NetPremium,
			VatPer,
			VatAmount,
			StampDuty,
			OthersAmount,
			Ref_SumInsured,
			Ref_SumInsuredCoIns,
			Ref_NetPremium,
			Ref_VatAmount,
			Ref_StampDuty,
			Ref_ChargeAmount,
			Ref_DocNo,
			Ref_CoInsSumInsured,
			Ref_CoInsNetPremium,
			Active,
			DepositDate,
			Depo_NetPremium,
			Depo_NetPremium_CoIns,
			Depo_VatAmount,
			Depo_StampDuty,
			MR_Allowable,
			Business,
			ClientKey,
			BankKey,
			ClientKey_Old,
			BankKey_Old,
			EmpKey,
			AgentKey,
			PeriodFrom,
			PeriodTo,
			Text_Field_1,
			Text_Field_2,
			Text_Field_3,
			Text_Field_4,
			Text_Field_5,
			Text_Field_6,
			Text_Field_7,
			Text_Field_8,
			Text_Field_9,
			Text_Field_10,
			Text_Field_11,
			Text_Field_12,
			Text_Field_13,
			Text_Field_14,
			Text_Field_15,
			Text_Field_16,
			Text_Field_17,
			Text_Field_18,
			Text_Field_19,
			Text_Field_20,
			Text_Field_21,
			Text_Field_22,
			Text_Field_23,
			Text_Field_24,
			Text_Field_25,
			Text_Field_26,
			Text_Field_27,
			Text_Field_28,
			Text_Field_29,
			Text_Field_30,
			Num_Field_1,
			Num_Field_2,
			Num_Field_3,
			Num_Field_4,
			Num_Field_5,
			Num_Field_6,
			Num_Field_7,
			Num_Field_8,
			Num_Field_9,
			Num_Field_10,
			Num_Field_11,
			Num_Field_12,
			Num_Field_13,
			Num_Field_14,
			Num_Field_15,
			Num_Field_16,
			Num_Field_17,
			Num_Field_18,
			Num_Field_19,
			Num_Field_20,
			Num_Field_21,
			Num_Field_22,
			Num_Field_23,
			Num_Field_24,
			Num_Field_25,
			Num_Field_26,
			Num_Field_27,
			Num_Field_28,
			Num_Field_29,
			Num_Field_30,
			Date_Field_1,
			Date_Field_2,
			Date_Field_3,
			Bank_Guarantee,
			Coll_Our_Share,
			NewClient,
			WithChargeAmount,
			DocCancel,
			DocCancelDate,
			NotUtilized,
			DocEdit,
			ReinsuranceAmount,
			ClaimAmount,
			VoucherKey,
			HO,
			Pay_Status,
			BoughKey,
			TargetKey,
			Remarks,
			PaymentType,
			CurrencyName,
			FCurrText,
			AmountInWord,
			BankName,
			BranchName,
			ChequeNo,
			ChequeDate,
			ChargeAmount,
			PrintStatus,
			PrintStatus_CN,
			PrintStatus_PO,
			Transfer,
			VATStop,
			EmpKeyOld,
			BlockPIN,
			CoInsBillRec,
			CoInsBillDetails,
			LockData,
			LockData_Yearly,
			DelFlag,
			PC_Name,
			EUser,
			EDate,
			UUser,
			UDate,
			BackupType
	)
	VALUES 
	(			
			@FinalMRKeyREF,
			@BranchKey,
			@Class_Name,
			@Sub_Class_Name,
			@YearName,
			@MRType,
			@MRType_2,
			@MRType_3,
			@MRType_4,
			@MRCode,
			@MRCode_Dis,
			@MRDate,
			@DocCode,
			@DocNo,
			@DocDate,
			@CoverNoteNo,
			@CNDate,
			@PolicyNo,
			@PODate,
			@CoIns,
			@ComKeyCoIns,
			@LeaderDocNo,
			@CoInsPer,
			@We_Leader,
			@SumInsured,
			@SumInsuredCoIns,
			@MRNetPremium,
			@NetPremium,
			@VatPer,
			@VatAmount,
			@StampDuty,
			@OthersAmount,
			@Ref_SumInsured,
			@Ref_SumInsuredCoIns,
			@Ref_NetPremium,
			@Ref_VatAmount,
			@Ref_StampDuty,
			@Ref_ChargeAmount,
			@Ref_DocNo,
			@Ref_CoInsSumInsured,
			@Ref_CoInsNetPremium,
			@Active,
			@DepositDate,
			@Depo_NetPremium,
			@Depo_NetPremium_CoIns,
			@Depo_VatAmount,
			@Depo_StampDuty,
			@MR_Allowable,
			@Business,
			@ClientKey,
			@BankKey,
			@ClientKey_Old,
			@BankKey_Old,
			@EmpKey,
			@AgentKey,
			@PeriodFrom,
			@PeriodTo,
			@Text_Field_1,
			@Text_Field_2,
			@Text_Field_3,
			@Text_Field_4,
			@Text_Field_5,
			@Text_Field_6,
			@Text_Field_7,
			@Text_Field_8,
			@Text_Field_9,
			@Text_Field_10,
			@Text_Field_11,
			@Text_Field_12,
			@Text_Field_13,
			@Text_Field_14,
			@Text_Field_15,
			@Text_Field_16,
			@Text_Field_17,
			@Text_Field_18,
			@Text_Field_19,
			@Text_Field_20,
			@Text_Field_21,
			@Text_Field_22,
			@Text_Field_23,
			@Text_Field_24,
			@Text_Field_25,
			@Text_Field_26,
			@Text_Field_27,
			@Text_Field_28,
			@Text_Field_29,
			@Text_Field_30,
			@Num_Field_1,
			@Num_Field_2,
			@Num_Field_3,
			@Num_Field_4,
			@Num_Field_5,
			@Num_Field_6,
			@Num_Field_7,
			@Num_Field_8,
			@Num_Field_9,
			@Num_Field_10,
			@Num_Field_11,
			@Num_Field_12,
			@Num_Field_13,
			@Num_Field_14,
			@Num_Field_15,
			@Num_Field_16,
			@Num_Field_17,
			@Num_Field_18,
			@Num_Field_19,
			@Num_Field_20,
			@Num_Field_21,
			@Num_Field_22,
			@Num_Field_23,
			@Num_Field_24,
			@Num_Field_25,
			@Num_Field_26,
			@Num_Field_27,
			@Num_Field_28,
			@Num_Field_29,
			@Num_Field_30,
			@Date_Field_1,
			@Date_Field_2,
			@Date_Field_3,
			@Bank_Guarantee,
			@Coll_Our_Share,
			@NewClient,
			@WithChargeAmount,
			@DocCancel,
			@DocCancelDate,
			@NotUtilized,
			@DocEdit,
			@ReinsuranceAmount,
			@ClaimAmount,
			@VoucherKey,
			@HO,
			@Pay_Status,
			@BoughKey,
			@TargetKey,
			@Remarks,
			@PaymentType,
			@CurrencyName,
			@FCurrText,
			@AmountInWord,
			@BankName,
			@BranchName,
			@ChequeNo,
			@ChequeDate,
			@ChargeAmount,
			@PrintStatus,
			@PrintStatus_CN,
			@PrintStatus_PO,
			@Transfer,
			@VATStop,
			@EmpKeyOld,
			@BlockPIN,
			@CoInsBillRec,
			@CoInsBillDetails,
			@LockData,
			@LockData_Yearly,
			@DelFlag,
			@PC_Name,
			@EUser,
			@EDate,
			@UUser,
			@UDate,
			@BackupType)

			SET @FinalMRKey=SCOPE_IDENTITY();
	END

END


GO

CREATE PROCEDURE [dbo].[Sptab_Final_MR_UPDATE]
@Result bit OUT,
@FinalMRKey	bigint = 0,
@FinalMRKeyREF	bigint = 0,
@BranchKey	int = 0,
@Class_Name	varchar(50) = NULL,
@Sub_Class_Name	varchar(50) = NULL,
@YearName	smallint = 0,
@MRType	varchar(50) = NULL,
@MRType_2	varchar(50) = NULL,
@MRType_3	varchar(50) = NULL,
@MRType_4	varchar(50) = NULL,
@MRCode	int = 0,
@MRCode_Dis	varchar(50) = NULL,
@MRDate	smalldatetime = NULL,
@DocCode	int = 0,
@DocNo	varchar(500) = NULL,
@DocDate	smalldatetime = NULL,
@CoverNoteNo	varchar(500) = NULL,
@CNDate	smalldatetime = NULL,
@PolicyNo	varchar(500) = NULL,
@PODate	smalldatetime = NULL,
@CoIns	bit = 0,
@ComKeyCoIns	int = 0,
@LeaderDocNo	varchar(500) = NULL,
@CoInsPer	numeric(18,2) = 0,
@We_Leader	bit = 0,
@SumInsured	numeric(18,0) = 0,
@SumInsuredCoIns	numeric(18,0) = 0,
@MRNetPremium	numeric(18,2) = 0,
@NetPremium	numeric(18,2) = 0,
@VatPer		numeric(18,2) = 0,
@VatAmount	numeric(18,2) = 0,
@StampDuty	numeric(18,2) = 0,
@OthersAmount	numeric(18,0) = 0,
@Ref_SumInsured	numeric(18,0) = 0,
@Ref_SumInsuredCoIns	numeric(18,0) = 0,
@Ref_NetPremium	numeric(18,2) = 0,
@Ref_VatAmount	numeric(18,2) = 0,
@Ref_StampDuty	numeric(18,2) = 0,
@Ref_ChargeAmount	numeric(18,2) = 0,
@Ref_DocNo	varchar(1000) = NULL,
@Ref_CoInsSumInsured	numeric(18,0) = 0,
@Ref_CoInsNetPremium	numeric(18,2) = 0,
@Active	bit = 0,
@DepositDate	smalldatetime = NULL,
@Depo_NetPremium	numeric(18,0) = 0,
@Depo_NetPremium_CoIns	numeric(18,0) = 0,
@Depo_VatAmount	numeric(18,0) = 0,
@Depo_StampDuty	numeric(18,0) = 0,
@MR_Allowable	int = 0,
@Business	int = 0,
@ClientKey	bigint = 0,
@BankKey	bigint = 0,
@ClientKey_Old	bigint = 0,
@BankKey_Old	bigint = 0,
@EmpKey	int = 0,
@AgentKey	int = 0,
@PeriodFrom	smalldatetime = NULL,
@PeriodTo	smalldatetime = NULL,
@Text_Field_1	varchar(500) = NULL,
@Text_Field_2	varchar(500) = NULL,
@Text_Field_3	varchar(500) = NULL,
@Text_Field_4	varchar(500) = NULL,
@Text_Field_5	varchar(500) = NULL,
@Text_Field_6	varchar(500) = NULL,
@Text_Field_7	varchar(500) = NULL,
@Text_Field_8	varchar(500) = NULL,
@Text_Field_9	varchar(500) = NULL,
@Text_Field_10	varchar(500) = NULL,
@Text_Field_11	varchar(500) = NULL,
@Text_Field_12	varchar(500) = NULL,
@Text_Field_13	varchar(500) = NULL,
@Text_Field_14	varchar(500) = NULL,
@Text_Field_15	varchar(500) = NULL,
@Text_Field_16	varchar(500) = NULL,
@Text_Field_17	varchar(500) = NULL,
@Text_Field_18	varchar(500) = NULL,
@Text_Field_19	varchar(500) = NULL,
@Text_Field_20	varchar(500) = NULL,
@Text_Field_21	varchar(500) = NULL,
@Text_Field_22	varchar(500) = NULL,
@Text_Field_23	varchar(500) = NULL,
@Text_Field_24	varchar(500) = NULL,
@Text_Field_25	varchar(500) = NULL,
@Text_Field_26	varchar(500) = NULL,
@Text_Field_27	varchar(500) = NULL,
@Text_Field_28	varchar(500) = NULL,
@Text_Field_29	varchar(500) = NULL,
@Text_Field_30	varchar(500) = NULL,
@Num_Field_1	numeric(18,4) = 0,
@Num_Field_2	numeric(18,4) = 0,
@Num_Field_3	numeric(18,4) = 0,
@Num_Field_4	numeric(18,4) = 0,
@Num_Field_5	numeric(18,4) = 0,
@Num_Field_6	numeric(18,4) = 0,
@Num_Field_7	numeric(18,4) = 0,
@Num_Field_8	numeric(18,4) = 0,
@Num_Field_9	numeric(18,4) = 0,
@Num_Field_10	numeric(18,4) = 0,
@Num_Field_11	numeric(18,4) = 0,
@Num_Field_12	numeric(18,4) = 0,
@Num_Field_13	numeric(18,4) = 0,
@Num_Field_14	numeric(18,4) = 0,
@Num_Field_15	numeric(18,4) = 0,
@Num_Field_16	numeric(18,4) = 0,
@Num_Field_17	numeric(18,4) = 0,
@Num_Field_18	numeric(18,4) = 0,
@Num_Field_19	numeric(18,4) = 0,
@Num_Field_20	numeric(18,4) = 0,
@Num_Field_21	numeric(18,4) = 0,
@Num_Field_22	numeric(18,4) = 0,
@Num_Field_23	numeric(18,4) = 0,
@Num_Field_24	numeric(18,4) = 0,
@Num_Field_25	numeric(18,4) = 0,
@Num_Field_26	numeric(18,4) = 0,
@Num_Field_27	numeric(18,4) = 0,
@Num_Field_28	numeric(18,4) = 0,
@Num_Field_29	numeric(18,4) = 0,
@Num_Field_30	numeric(18,4) = 0,
@Date_Field_1	smalldatetime = NULL,
@Date_Field_2	smalldatetime = NULL,
@Date_Field_3	smalldatetime = NULL,
@Bank_Guarantee	int = 0,
@Coll_Our_Share	nchar = 0,
@NewClient	int = 0,
@WithChargeAmount	int = 0,
@DocCancel	bit = 0,
@DocCancelDate	smalldatetime = NULL,
@NotUtilized	bit = 0,
@DocEdit	bit = 0,
@ReinsuranceAmount	numeric(18,2) = 0,
@ClaimAmount	numeric(18,2) = 0,
@VoucherKey	bigint = 0,
@HO	bit = 0,
@Pay_Status	bit = 0,
@BoughKey	int = 0,
@TargetKey	numeric(18,0) = 0,
@Remarks	varchar(1000) = NULL,
@PaymentType	varchar(50) = NULL,
@CurrencyName	varchar(50) = NULL,
@FCurrText	varchar(50) = NULL,
@AmountInWord	varchar(1000) = NULL,
@BankName	varchar(50) = NULL,
@BranchName	varchar(50) = NULL,
@ChequeNo	varchar(50) = NULL,
@ChequeDate	smalldatetime = NULL,
@ChargeAmount	numeric(18,0) = 0,
@PrintStatus	bit = 0,
@PrintStatus_CN	bit = 0,
@PrintStatus_PO	bit = 0,
@Transfer	int = 0,
@VATStop	bit = 0,
@EmpKeyOld	int = 0,
@BlockPIN	bit = 0,
@CoInsBillRec	bit = 0,
@CoInsBillDetails	varchar(500) = NULL,
@LockData	bit = 0,
@LockData_Yearly	bit = 0,
@DelFlag	bit=0,
@PC_Name	varchar(100) = NULL,
@UUser	int = 0,
@BackupType	bit = 0
AS
DECLARE @UDate smalldatetime

SET @UDate = GETDATE()
BEGIN


	
	UPDATE tab_Final_MR SET
		FinalMRKeyREF=@FinalMRKeyREF,
		BranchKey=@BranchKey,
		Class_Name=@Class_Name,
		Sub_Class_Name=@Sub_Class_Name,
		YearName=@YearName,
		MRType=@MRType,
		MRType_2=@MRType_2,
		MRType_3=@MRType_3,
		MRType_4=@MRType_4,
		MRCode=@MRCode,
		MRCode_Dis=@MRCode_Dis,
		MRDate=@MRDate,
		DocCode=@DocCode,
		DocNo=@DocNo,
		DocDate=@DocDate,
		CoverNoteNo=@CoverNoteNo,
		CNDate=@CNDate,
		PolicyNo=@PolicyNo,
		PODate=@PODate,
		CoIns=@CoIns,
		ComKeyCoIns=@ComKeyCoIns,
		LeaderDocNo=@LeaderDocNo,
		CoInsPer=@CoInsPer,
		We_Leader=@We_Leader,
		SumInsured=@SumInsured,
		SumInsuredCoIns=@SumInsuredCoIns,
		MRNetPremium=@MRNetPremium,
		NetPremium=@NetPremium,
		VatPer = @VatPer,
		VatAmount=@VatAmount,
		StampDuty=@StampDuty,
		OthersAmount=@OthersAmount,
		Ref_SumInsured=@Ref_SumInsured,
		Ref_SumInsuredCoIns=@Ref_SumInsuredCoIns,
		Ref_NetPremium=@Ref_NetPremium,
		Ref_VatAmount=@Ref_VatAmount,
		Ref_StampDuty=@Ref_StampDuty,
		Ref_ChargeAmount=@Ref_ChargeAmount,
		Ref_DocNo=@Ref_DocNo,
		Ref_CoInsSumInsured=@Ref_CoInsSumInsured,
		Ref_CoInsNetPremium=@Ref_CoInsNetPremium,
		Active=@Active,
		DepositDate=@DepositDate,
		Depo_NetPremium=@Depo_NetPremium,
		Depo_NetPremium_CoIns=@Depo_NetPremium_CoIns,
		Depo_VatAmount=@Depo_VatAmount,
		Depo_StampDuty=@Depo_StampDuty,
		MR_Allowable=@MR_Allowable,
		Business=@Business,
		ClientKey=@ClientKey,
		BankKey=@BankKey,
		ClientKey_Old=@ClientKey_Old,
		BankKey_Old=@BankKey_Old,
		EmpKey=@EmpKey,
		AgentKey=@AgentKey,
		PeriodFrom=@PeriodFrom,
		PeriodTo=@PeriodTo,
		Text_Field_1=@Text_Field_1,
		Text_Field_2=@Text_Field_2,
		Text_Field_3=@Text_Field_3,
		Text_Field_4=@Text_Field_4,
		Text_Field_5=@Text_Field_5,
		Text_Field_6=@Text_Field_6,
		Text_Field_7=@Text_Field_7,
		Text_Field_8=@Text_Field_8,
		Text_Field_9=@Text_Field_9,
		Text_Field_10=@Text_Field_10,
		Text_Field_11=@Text_Field_11,
		Text_Field_12=@Text_Field_12,
		Text_Field_13=@Text_Field_13,
		Text_Field_14=@Text_Field_14,
		Text_Field_15=@Text_Field_15,
		Text_Field_16=@Text_Field_16,
		Text_Field_17=@Text_Field_17,
		Text_Field_18=@Text_Field_18,
		Text_Field_19=@Text_Field_19,
		Text_Field_20=@Text_Field_20,
		Text_Field_21=@Text_Field_21,
		Text_Field_22=@Text_Field_22,
		Text_Field_23=@Text_Field_23,
		Text_Field_24=@Text_Field_24,
		Text_Field_25=@Text_Field_25,
		Text_Field_26=@Text_Field_26,
		Text_Field_27=@Text_Field_27,
		Text_Field_28=@Text_Field_28,
		Text_Field_29=@Text_Field_29,
		Text_Field_30=@Text_Field_30,
		Num_Field_1=@Num_Field_1,
		Num_Field_2=@Num_Field_2,
		Num_Field_3=@Num_Field_3,
		Num_Field_4=@Num_Field_4,
		Num_Field_5=@Num_Field_5,
		Num_Field_6=@Num_Field_6,
		Num_Field_7=@Num_Field_7,
		Num_Field_8=@Num_Field_8,
		Num_Field_9=@Num_Field_9,
		Num_Field_10=@Num_Field_10,
		Num_Field_11=@Num_Field_11,
		Num_Field_12=@Num_Field_12,
		Num_Field_13=@Num_Field_13,
		Num_Field_14=@Num_Field_14,
		Num_Field_15=@Num_Field_15,
		Num_Field_16=@Num_Field_16,
		Num_Field_17=@Num_Field_17,
		Num_Field_18=@Num_Field_18,
		Num_Field_19=@Num_Field_19,
		Num_Field_20=@Num_Field_20,
		Num_Field_21=@Num_Field_21,
		Num_Field_22=@Num_Field_22,
		Num_Field_23=@Num_Field_23,
		Num_Field_24=@Num_Field_24,
		Num_Field_25=@Num_Field_25,
		Num_Field_26=@Num_Field_26,
		Num_Field_27=@Num_Field_27,
		Num_Field_28=@Num_Field_28,
		Num_Field_29=@Num_Field_29,
		Num_Field_30=@Num_Field_30,
		Date_Field_1=@Date_Field_1,
		Date_Field_2=@Date_Field_2,
		Date_Field_3=@Date_Field_3,
		Bank_Guarantee=@Bank_Guarantee,
		Coll_Our_Share=@Coll_Our_Share,
		NewClient=@NewClient,
		WithChargeAmount=@WithChargeAmount,
		DocCancel=@DocCancel,
		DocCancelDate=@DocCancelDate,
		NotUtilized=@NotUtilized,
		DocEdit=@DocEdit,
		ReinsuranceAmount=@ReinsuranceAmount,
		ClaimAmount=@ClaimAmount,
		VoucherKey=@VoucherKey,
		HO=@HO,
		Pay_Status=@Pay_Status,
		BoughKey=@BoughKey,
		TargetKey=@TargetKey,
		Remarks=@Remarks,
		PaymentType=@PaymentType,
		CurrencyName=@CurrencyName,
		FCurrText=@FCurrText,
		AmountInWord=@AmountInWord,
		BankName=@BankName,
		BranchName=@BranchName,
		ChequeNo=@ChequeNo,
		ChequeDate=@ChequeDate,
		ChargeAmount=@ChargeAmount,
		PrintStatus=@PrintStatus,
		PrintStatus_CN=@PrintStatus_CN,
		PrintStatus_PO=@PrintStatus_PO,
		Transfer=@Transfer,
		VATStop=@VATStop,
		EmpKeyOld=@EmpKeyOld,
		BlockPIN=@BlockPIN,
		CoInsBillRec=@CoInsBillRec,
		CoInsBillDetails=@CoInsBillDetails,
		LockData=@LockData,
		LockData_Yearly=@LockData_Yearly,
		PC_Name=@PC_Name,		
		UUser=@UUser,
		UDate=@UDate,
		BackupType=@BackupType
	WHERE FinalMRKey = @FinalMRKey
	SET @Result = 1

END


GO

