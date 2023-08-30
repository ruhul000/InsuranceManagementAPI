USE [Policy]
GO

-- AddClient
IF OBJECT_ID('AddClient', 'P') IS NOT NULL
    DROP PROCEDURE AddClient
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
Print 'Sproc Created Successfully : AddClient'
GO

-- UpdateClient
IF OBJECT_ID('UpdateClient', 'P') IS NOT NULL
    DROP PROCEDURE UpdateClient
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
		Status = @Status,
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
Print 'Sproc Created Successfully : UpdateClient'
GO

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

USE [Policy]
GO

/****** Object:  StoredProcedure [dbo].[BankBranchAdd]    Script Date: 8/31/2023 5:26:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Omar Faruk
-- Create date: 31/08/2023
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BankBranchAdd]
	@BranchId [int] OUT,
	@BankId [int],
	@BranchName varchar(200) = NULL,
	@BranchAddress [varchar](1000) = NULL,
	@SwiftCode [varchar](1000) = NULL,
	@ClientMobile [varchar](100) = NULL,
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




