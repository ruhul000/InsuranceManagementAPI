USE [Policy]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 21/09/2023 17:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[BankId] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [nvarchar](200) NULL,
	[EUser] [int] NULL,
	[EDate] [datetime] NULL,
	[UUser] [int] NULL,
	[UDate] [datetime] NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankBranch]    Script Date: 21/09/2023 17:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankBranch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](200) NULL,
	[BankId] [int] NOT NULL,
	[BranchAddress] [nvarchar](500) NULL,
	[SwiftCode] [varchar](50) NULL,
	[RoutingNumber] [varchar](50) NULL,
	[Status] [bit] NULL,
	[EUser] [int] NULL,
	[EDate] [datetime] NULL,
	[UUsar] [int] NULL,
	[UDate] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BankBranch]  WITH CHECK ADD  CONSTRAINT [FK_BankBranch_Bank] FOREIGN KEY([BankId])
REFERENCES [dbo].[Bank] ([BankId])
GO

ALTER TABLE [dbo].[BankBranch] CHECK CONSTRAINT [FK_BankBranch_Bank]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsuranceCompany](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[status] [bit] NULL,
	[EUser] [int] NULL,
	[EDate] [datetime] NULL,
	[UUser] [int] NULL,
	[UDate] [datetime] NULL,
 CONSTRAINT [PK_InsuranceCompany] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefreshToken]    Script Date: 21/09/2023 17:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefreshToken](
	[UserName] [nvarchar](100) NOT NULL,
	[TokenID] [nvarchar](max) NOT NULL,
	[RefreshToken] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_BranchInfo]    Script Date: 21/09/2023 17:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_BranchInfo](
	[BranchKey] [int] IDENTITY(1,1) NOT NULL,
	[ComKey] [int] NOT NULL,
	[BranchID] [varchar](50) NULL,
	[BranchOrderKey] [int] NULL,
	[Branch_Open_Date] [smalldatetime] NULL,
	[BranchName] [varchar](100) NULL,
	[ShortName] [varchar](50) NULL,
	[ZoneKey] [int] NULL,
	[Address] [varchar](200) NULL,
	[Branch_Address_2] [varchar](200) NULL,
	[Branch_Address_3] [varchar](200) NULL,
	[Phone] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[EMail] [varchar](50) NULL,
	[EmpKeyIncharge] [int] NULL,
	[IssuingPlace] [varchar](500) NULL,
	[IssuingPlace_2] [varchar](500) NULL,
	[IssuingPlace_3] [varchar](500) NULL,
	[Computerized] [bit] NULL,
	[Seal] [varchar](max) NULL,
	[Signatore_Name_A] [varchar](200) NULL,
	[Signatore_A] [varchar](max) NULL,
	[Signatore_Name_B] [varchar](200) NULL,
	[Signatore_B] [varchar](max) NULL,
	[Signatore_Name_C] [varchar](200) NULL,
	[Signatore_C] [varchar](max) NULL,
	[Status] [bit] NULL,
	[BackupType] [bit] NOT NULL,
 CONSTRAINT [PK_BranchInfo] PRIMARY KEY CLUSTERED 
(
	[BranchKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_Client]    Script Date: 21/09/2023 17:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_Client](
	[ClientKey] [bigint] IDENTITY(1,1) NOT NULL,
	[BranchKey] [int] NOT NULL,
	[ClientName] [varchar](1000) NULL,
	[ClientNameExtar] [varchar](1000) NULL,
	[ClientAddress] [varchar](1000) NULL,
	[ClientMobile] [varchar](100) NULL,
	[ClientType] [varchar](100) NULL,
	[ClientTypeTwo] [varchar](100) NULL,
	[ClientSector] [varchar](100) NULL,
	[ClientVATNo] [varchar](100) NULL,
	[ClientBINNo] [varchar](100) NULL,
	[ClientTINNo] [varchar](100) NULL,
	[Client_VAT_Exemption] [int] NULL,
	[GroupKey] [int] NULL,
	[ClientPhone] [varchar](100) NULL,
	[ClientFax] [varchar](100) NULL,
	[ClientEMail] [varchar](100) NULL,
	[ClientRelation] [varchar](100) NULL,
	[ClientWeb] [varchar](100) NULL,
	[ClientContractPer] [varchar](100) NULL,
	[ClientDesignation] [varchar](100) NULL,
	[SpecDiscount] [numeric](18, 0) NULL,
	[EmpKeyDirectorRef] [int] NULL,
	[Status] [bit] NULL,
	[Int_A] [numeric](18, 0) NULL,
	[Int_B] [numeric](18, 0) NULL,
	[Int_C] [numeric](18, 0) NULL,
	[Int_D] [numeric](18, 0) NULL,
	[Str_A] [varchar](250) NULL,
	[Str_B] [varchar](250) NULL,
	[Str_C] [varchar](250) NULL,
	[Str_D] [varchar](250) NULL,
	[Date_A] [smalldatetime] NULL,
	[Date_B] [smalldatetime] NULL,
	[Date_C] [smalldatetime] NULL,
	[BackupType] [bit] NULL,
	[EUser] [int] NULL,
	[EDate] [datetime] NULL,
	[UUser] [int] NULL,
	[UDate] [datetime] NULL,
 CONSTRAINT [PK_tab_Client] PRIMARY KEY CLUSTERED 
(
	[ClientKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_Client_Details]    Script Date: 21/09/2023 17:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_Client_Details](
	[ClientKey] [bigint] NOT NULL,
	[BranchKey] [int] NOT NULL,
	[Applican_Name] [varchar](50) NULL,
	[Customer_Pic_A] [image] NULL,
	[Customer_Pic_B] [image] NULL,
	[Customer_Pic_C] [image] NULL,
	[Customer_Pic_D] [image] NULL,
	[Customer_Pic_E] [image] NULL,
	[Customer_Pic_F] [image] NULL,
	[AccountNo] [varchar](100) NULL,
	[Mother_Name] [varchar](100) NULL,
	[Father_Name] [varchar](100) NULL,
	[Spouse_Name] [varchar](100) NULL,
	[DOB] [datetime] NULL,
	[Profession] [varchar](500) NULL,
	[PresentAddress] [varchar](1000) NULL,
	[PermanentAddress] [varchar](1000) NULL,
	[Nominee] [varchar](250) NULL,
	[Nominee_Relation] [varchar](250) NULL,
	[Speciment_Signature] [image] NULL,
	[Nationality] [varchar](100) NULL,
	[National_ID_No] [varchar](100) NULL,
	[Passport_No] [varchar](100) NULL,
	[EmpSex] [varchar](50) NULL,
	[Monthly_Income] [numeric](18, 0) NULL,
	[Income_A] [numeric](18, 0) NULL,
	[Income_B] [numeric](18, 0) NULL,
	[Income_C] [numeric](18, 0) NULL,
	[Income_D] [numeric](18, 0) NULL,
	[Str_A] [varchar](250) NULL,
	[Str_B] [varchar](250) NULL,
	[Str_C] [varchar](250) NULL,
	[Str_D] [varchar](250) NULL,
	[Date_A] [smalldatetime] NULL,
	[Date_B] [smalldatetime] NULL,
	[Date_C] [smalldatetime] NULL,
	[Remarks] [varchar](2500) NULL,
 CONSTRAINT [PK_tab_Client_Details] PRIMARY KEY CLUSTERED 
(
	[ClientKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_CompanyInfo]    Script Date: 21/09/2023 17:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_CompanyInfo](
	[ComKey] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[ShortName] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
	[Phone] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[EMail] [varchar](50) NULL,
	[Web] [varchar](50) NULL,
	[Logo1] [image] NULL,
	[LHead1] [image] NULL,
	[IssuingPlaceHO] [varchar](500) NULL,
	[BackupType] [bit] NULL,
	[Logo] [varchar](max) NULL,
	[LHead] [varchar](max) NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[ComKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21/09/2023 17:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](max) NULL,
	[Salt] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_InsuranceCompany]    Script Date: 21/09/2023 17:07:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_InsuranceCompany] ON [dbo].[InsuranceCompany]
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tab_BranchInfo]    Script Date: 21/09/2023 17:07:59 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tab_BranchInfo] ON [dbo].[tab_BranchInfo]
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InsuranceCompany] ADD  CONSTRAINT [DF_InsuranceCompany_EntryTime]  DEFAULT (getdate()) FOR [EntryTime]
GO

CREATE TABLE [dbo].[tab_DepartmentInfo](
	[DepKey] [int] NOT NULL,
	[DepName] [varchar](50) NOT NULL,
	[DepNameShort] [varchar](10) NULL,
	[DepOrderKey] [int] NULL,
 CONSTRAINT [PK_DepartmentInfo] PRIMARY KEY CLUSTERED 
(
	[DepKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tab_DesignationInfo](
	[DegKey] [int] NOT NULL,
	[Deg_Name] [varchar](100) NULL,
	[ShortDeg] [varchar](50) NULL,
	[GradeName] [varchar](250) NULL,
	[Salary_Scale] [varchar](50) NULL,
	[OrderKey] [int] NULL,
 CONSTRAINT [PK_DesignationInfo] PRIMARY KEY CLUSTERED 
(
	[DegKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tab_EmployeeInfo](
	[EmpKey] [int] NOT NULL,
	[EmpID] [varchar](50) NULL,
	[EmpCode] [int] NULL,
	[EmpKey_Group] [int] NULL,
	[BranchKey] [int] NULL,
	[BranchIncharge] [bit] NULL,
	[Boughkey] [int] NULL,
	[Title] [varchar](50) NULL,
	[EmpName] [varchar](100) NULL,
	[EmpSurName] [varchar](50) NULL,
	[EmpShortName] [varchar](50) NULL,
	[DepKey] [int] NULL,
	[DepIncharge] [bit] NULL,
	[DegKey] [int] NULL,
	[EmpType] [varchar](50) NULL,
	[EmpType_B] [varchar](50) NULL,
	[EmpType_C] [varchar](50) NULL,
	[EmpSex] [varchar](50) NULL,
	[Director] [bit] NULL,
	[JobContinue] [bit] NULL,
	[DOJ] [datetime] NULL,
	[DOC] [datetime] NULL,
	[DOB] [datetime] NULL,
	[DOB_Original] [datetime] NULL,
	[AGE] [varchar](255) NULL,
	[Resign_Date] [datetime] NULL,
	[Release_Date] [datetime] NULL,
	[Retirement_Date] [datetime] NULL,
	[Father_Name] [varchar](100) NULL,
	[Mother_Name] [varchar](100) NULL,
	[Spouse_Name] [varchar](100) NULL,
	[Nominee] [varchar](100) NULL,
	[Nominee_Image] [image] NULL,
	[Merital_Status] [varchar](100) NULL,
	[Marriage_Date] [datetime] NULL,
	[Religion] [varchar](100) NULL,
	[Nationality] [varchar](100) NULL,
	[National_ID_No] [varchar](100) NULL,
	[Passport_No] [varchar](100) NULL,
	[TIN_No] [varchar](100) NULL,
	[Blood_Group] [varchar](100) NULL,
	[Height] [varchar](100) NULL,
	[PresentAddress] [varchar](1000) NULL,
	[PermanentAddress] [varchar](1000) NULL,
	[Native_Land] [varchar](1000) NULL,
	[Home_District] [varchar](50) NULL,
	[Phone] [varchar](255) NULL,
	[Mobile] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Emp_Image] [varchar](max) NULL,
	[Active] [bit] NULL,
	[LastPromotion_Date] [smalldatetime] NULL,
	[LastIncrement_Date] [smalldatetime] NULL,
	[PF_Join_Date] [smalldatetime] NULL,
	[Extended] [bit] NULL,
	[ExtendedDate] [smalldatetime] NULL,
	[AsEmpCode] [int] NULL,
	[Probation_Period] [int] NULL,
	[Probation_Date] [smalldatetime] NULL,
	[Mobile_Set_Name] [varchar](500) NULL,
	[Mobile_Bill_Amount] [numeric](18, 0) NULL,
	[Car_Fuel_Amount] [numeric](18, 0) NULL,
	[Car_Maintains_Amount] [numeric](18, 0) NULL,
	[Other_Maintains_Amount] [numeric](18, 0) NULL,
	[Facility_Remarks] [varchar](500) NULL,
	[Contract_Date] [smalldatetime] NULL,
	[Remarks] [varchar](2500) NULL,
	[PicImage_A] [image] NULL,
	[PicImage_B] [image] NULL,
	[PicImage_C] [image] NULL,
	[PicImage_D] [image] NULL,
	[PicImage_E] [image] NULL,
	[PicImage_F] [image] NULL,
	[EUser] [int] NULL,
	[EDate] [datetime] NULL,
	[UUser] [int] NULL,
	[UDate] [datetime] NULL,
	[BackupType] [bit] NULL,
 CONSTRAINT [PK_EmployeeInfo_1] PRIMARY KEY CLUSTERED 
(
	[EmpKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[tab_AgentInfo](
	[BranchKey] [int] NULL,
	[AgentKey] [int] NOT NULL,
	[AgentID] [varchar](50) NULL,
	[AgentCode] [varchar](100) NULL,
	[Agent_Title] [varchar](50) NULL,
	[AgentName] [varchar](200) NULL,
	[Agent_Address] [varchar](500) NULL,
	[Agent_License_No] [varchar](200) NULL,
	[Agent_Bank_Name] [varchar](200) NULL,
	[Agent_Bank_Branch_Name] [varchar](200) NULL,
	[Agent_Bank_Account_No] [varchar](200) NULL,
	[Ref_EmpKey] [int] NULL,
	[Validity_From] [smalldatetime] NULL,
	[Validity_To] [smalldatetime] NULL,
	[Remarks] [varchar](200) NULL,
	[Agent_Status] [int] NULL,
	[NIDNo] [varchar](100) NULL,
	[TINNo] [varchar](100) NULL,
	[Agent_MobileNo] [varchar](100) NULL,
	[EUser] [int] NULL,
	[EDate] [datetime] NULL,
	[UUser] [int] NULL,
	[UDate] [datetime] NULL,
 CONSTRAINT [PK_Agent_Info] PRIMARY KEY CLUSTERED 
(
	[AgentKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CurrencyInfo](
	[CurrencyKey] [int] NOT NULL,
	[CurrencyName] [varchar](5) NULL,
	[Coll] [numeric](18, 2) NULL,
	[BankRate] [numeric](18, 4) NULL,
	[BackupType] [bit] NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tab_Final_MR](
	[FinalMRKey] [bigint] IDENTITY(1,1) NOT NULL,
	[FinalMRKeyREF] [bigint] NULL,
	[BranchKey] [int] NOT NULL,
	[Class_Name] [varchar](50) NOT NULL,
	[Sub_Class_Name] [varchar](50) NULL,
	[YearName] [smallint] NOT NULL,
	[MRType] [varchar](50) NULL,
	[MRType_2] [varchar](50) NULL,
	[MRType_3] [varchar](50) NULL,
	[MRType_4] [varchar](50) NULL,
	[MRCode] [int] NOT NULL,
	[MRCode_Dis] [varchar](50) NULL,
	[MRDate] [smalldatetime] NULL,
	[DocCode] [int] NULL,
	[DocNo] [varchar](500) NOT NULL,
	[DocDate] [smalldatetime] NULL,
	[CoverNoteNo] [varchar](500) NOT NULL,
	[CNDate] [smalldatetime] NULL,
	[PolicyNo] [varchar](500) NULL,
	[PODate] [smalldatetime] NULL,
	[CoIns] [bit] NOT NULL,
	[ComKeyCoIns] [int] NULL,
	[LeaderDocNo] [varchar](500) NULL,
	[CoInsPer] [numeric](18, 2) NULL,
	[We_Leader] [bit] NOT NULL,
	[SumInsured] [numeric](18, 0) NULL,
	[SumInsuredCoIns] [numeric](18, 0) NULL,
	[MRNetPremium] [numeric](18, 2) NULL,
	[NetPremium] [numeric](18, 2) NULL,
	[VatAmount] [numeric](18, 2) NULL,
	[StampDuty] [numeric](18, 2) NULL,
	[OthersAmount] [numeric](18, 0) NULL,
	[Ref_SumInsured] [numeric](18, 0) NULL,
	[Ref_SumInsuredCoIns] [numeric](18, 0) NULL,
	[Ref_NetPremium] [numeric](18, 2) NULL,
	[Ref_VatAmount] [numeric](18, 2) NULL,
	[Ref_StampDuty] [numeric](18, 2) NULL,
	[Ref_ChargeAmount] [numeric](18, 2) NULL,
	[Ref_DocNo] [varchar](1000) NULL,
	[Ref_CoInsSumInsured] [numeric](18, 0) NULL,
	[Ref_CoInsNetPremium] [numeric](18, 2) NULL,
	[Active] [bit] NULL,
	[DepositDate] [smalldatetime] NULL,
	[Depo_NetPremium] [numeric](18, 0) NULL,
	[Depo_NetPremium_CoIns] [numeric](18, 0) NULL,
	[Depo_VatAmount] [numeric](18, 0) NULL,
	[Depo_StampDuty] [numeric](18, 0) NULL,
	[MR_Allowable] [int] NULL,
	[Business] [int] NULL,
	[ClientKey] [bigint] NULL,
	[BankKey] [bigint] NULL,
	[ClientKey_Old] [bigint] NULL,
	[BankKey_Old] [bigint] NULL,
	[EmpKey] [int] NULL,
	[AgentKey] [int] NULL,
	[PeriodFrom] [smalldatetime] NULL,
	[PeriodTo] [smalldatetime] NULL,
	[Text_Field_1] [varchar](500) NULL,
	[Text_Field_2] [varchar](500) NULL,
	[Text_Field_3] [varchar](500) NULL,
	[Text_Field_4] [varchar](500) NULL,
	[Text_Field_5] [varchar](500) NULL,
	[Text_Field_6] [varchar](500) NULL,
	[Text_Field_7] [varchar](500) NULL,
	[Text_Field_8] [varchar](500) NULL,
	[Text_Field_9] [varchar](500) NULL,
	[Text_Field_10] [varchar](500) NULL,
	[Text_Field_11] [varchar](500) NULL,
	[Text_Field_12] [varchar](500) NULL,
	[Text_Field_13] [varchar](500) NULL,
	[Text_Field_14] [varchar](500) NULL,
	[Text_Field_15] [varchar](500) NULL,
	[Text_Field_16] [varchar](500) NULL,
	[Text_Field_17] [varchar](500) NULL,
	[Text_Field_18] [varchar](500) NULL,
	[Text_Field_19] [varchar](500) NULL,
	[Text_Field_20] [varchar](500) NULL,
	[Text_Field_21] [varchar](500) NULL,
	[Text_Field_22] [varchar](500) NULL,
	[Text_Field_23] [varchar](500) NULL,
	[Text_Field_24] [varchar](500) NULL,
	[Text_Field_25] [varchar](500) NULL,
	[Text_Field_26] [varchar](500) NULL,
	[Text_Field_27] [varchar](500) NULL,
	[Text_Field_28] [varchar](500) NULL,
	[Text_Field_29] [varchar](500) NULL,
	[Text_Field_30] [varchar](500) NULL,
	[Num_Field_1] [numeric](18, 4) NULL,
	[Num_Field_2] [numeric](18, 4) NULL,
	[Num_Field_3] [numeric](18, 4) NULL,
	[Num_Field_4] [numeric](18, 4) NULL,
	[Num_Field_5] [numeric](18, 4) NULL,
	[Num_Field_6] [numeric](18, 4) NULL,
	[Num_Field_7] [numeric](18, 4) NULL,
	[Num_Field_8] [numeric](18, 4) NULL,
	[Num_Field_9] [numeric](18, 4) NULL,
	[Num_Field_10] [numeric](18, 4) NULL,
	[Num_Field_11] [numeric](18, 4) NULL,
	[Num_Field_12] [numeric](18, 4) NULL,
	[Num_Field_13] [numeric](18, 4) NULL,
	[Num_Field_14] [numeric](18, 4) NULL,
	[Num_Field_15] [numeric](18, 4) NULL,
	[Num_Field_16] [numeric](18, 4) NULL,
	[Num_Field_17] [numeric](18, 4) NULL,
	[Num_Field_18] [numeric](18, 4) NULL,
	[Num_Field_19] [numeric](18, 4) NULL,
	[Num_Field_20] [numeric](18, 4) NULL,
	[Num_Field_21] [numeric](18, 4) NULL,
	[Num_Field_22] [numeric](18, 4) NULL,
	[Num_Field_23] [numeric](18, 4) NULL,
	[Num_Field_24] [numeric](18, 4) NULL,
	[Num_Field_25] [numeric](18, 4) NULL,
	[Num_Field_26] [numeric](18, 4) NULL,
	[Num_Field_27] [numeric](18, 4) NULL,
	[Num_Field_28] [numeric](18, 4) NULL,
	[Num_Field_29] [numeric](18, 4) NULL,
	[Num_Field_30] [numeric](18, 4) NULL,
	[Date_Field_1] [smalldatetime] NULL,
	[Date_Field_2] [smalldatetime] NULL,
	[Date_Field_3] [smalldatetime] NULL,
	[Bank_Guarantee] [int] NULL,
	[Coll_Our_Share] [varchar](50) NULL,
	[NewClient] [int] NULL,
	[WithChargeAmount] [int] NULL,
	[DocCancel] [bit] NOT NULL,
	[DocCancelDate] [smalldatetime] NULL,
	[NotUtilized] [bit] NULL,
	[DocEdit] [bit] NOT NULL,
	[ReinsuranceAmount] [numeric](18, 2) NULL,
	[ClaimAmount] [numeric](18, 2) NULL,
	[VoucherKey] [bigint] NULL,
	[HO] [bit] NULL,
	[Pay_Status] [bit] NOT NULL,
	[BoughKey] [int] NULL,
	[TargetKey] [numeric](18, 0) NULL,
	[Remarks] [varchar](1000) NULL,
	[PaymentType] [varchar](50) NULL,
	[CurrencyName] [varchar](50) NULL,
	[FCurrText] [varchar](50) NULL,
	[AmountInWord] [varchar](1000) NULL,
	[BankName] [varchar](50) NULL,
	[BranchName] [varchar](50) NULL,
	[ChequeNo] [varchar](50) NULL,
	[ChequeDate] [smalldatetime] NULL,
	[ChargeAmount] [numeric](18, 0) NULL,
	[PrintStatus] [bit] NULL,
	[PrintStatus_CN] [bit] NULL,
	[PrintStatus_PO] [bit] NULL,
	[Transfer] [int] NULL,
	[VATStop] [bit] NULL,
	[EmpKeyOld] [int] NULL,
	[BlockPIN] [bit] NULL,
	[CoInsBillRec] [bit] NULL,
	[CoInsBillDetails] [varchar](500) NULL,
	[LockData] [bit] NULL,
	[LockData_Yearly] [bit] NULL,
	[DelFlag] [bit] NULL,
	[PC_Name] [varchar](100) NULL,
	[EUser] [int] NULL,
	[EDate] [smalldatetime] NULL,
	[UUser] [int] NULL,
	[UDate] [smalldatetime] NULL,
	[BackupType] [bit] NOT NULL,
 CONSTRAINT [PK_tab_Final_MR] PRIMARY KEY CLUSTERED 
(
	[FinalMRKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Index [IX_tab_Final_MR]    Script Date: 22/11/2023 15:38:37 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tab_Final_MR] ON [dbo].[tab_Final_MR]
(
	[DocCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique DocCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_Final_MR', @level2type=N'INDEX',@level2name=N'IX_tab_Final_MR'
GO



