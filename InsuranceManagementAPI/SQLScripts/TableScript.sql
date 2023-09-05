USE [Policy]
GO

-- Users
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Users]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[Users]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Print 'Table Created Successfully : Users'
GO

-- RefreshToken
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[RefreshToken]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[RefreshToken]
GO

CREATE TABLE [dbo].[RefreshToken](
	[UserName] [nvarchar](100) NOT NULL,
	[TokenID] [nvarchar](max) NOT NULL,
	[RefreshToken] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Print 'Table Created Successfully : RefreshToken'
GO

-- Bank
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[Bank]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[Bank]
GO

CREATE TABLE [dbo].[Bank](
	[BankId] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [nvarchar](200) NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Print 'Table Created Successfully : Bank'
GO

-- tab_Client
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[tab_Client]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[tab_Client]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Print 'Table Created Successfully : tab_Client'
GO



/****** Object:  Table [dbo].[BankBranch]    Script Date: 08/28/2023 11:56:23 PM ******/
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

SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_InsuranceCompany]    Script Date: 9/5/2023 2:50:28 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_InsuranceCompany] ON [dbo].[InsuranceCompany]
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

ALTER TABLE [dbo].[InsuranceCompany] ADD  CONSTRAINT [DF_InsuranceCompany_EntryTime]  DEFAULT (getdate()) FOR [EntryTime]
GO