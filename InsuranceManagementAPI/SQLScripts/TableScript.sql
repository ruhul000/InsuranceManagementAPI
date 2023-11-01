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
	[BranchName] [varchar](200) NULL,
	[BankId] [int] NULL,
	[BranchAddress] [varchar](500) NULL,
	[SwiftCode] [varchar](50) NULL,
	[RoutingNumber] [varchar](50) NULL,
	[Status] [bit] NULL,
	[EntryUserID] [int] NULL,
	[EntryTime] [datetime] NULL,
	[UpdateUserID] [int] NULL,
	[UpdateTime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsuranceCompany]    Script Date: 21/09/2023 17:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsuranceCompany](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[status] [bit] NULL,
	[EntryUserID] [int] NULL,
	[EntryTime] [datetime] NULL,
	[UpdateUserID] [int] NULL,
	[UpdateTime] [datetime] NULL,
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

