
USE [IngressF_MTecn]
GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 13/01/2024 2:21:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [varchar](5) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [DocumentType_P1] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 13/01/2024 2:21:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [uniqueidentifier] NOT NULL,
	[IdentificaionCode] [varchar](5) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [Role_p1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13/01/2024 2:21:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[DocumentType] [varchar](5) NOT NULL,
	[DocumentNumber] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](250) NULL,
	[Role] [uniqueidentifier] NOT NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [User_p1] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DocumentType] ([Id], [Code], [Description], [State]) VALUES (N'892a430c-87ef-45c9-9776-470d754b989f', N'CC', N'Cédula de ciudadania', 1)
INSERT [dbo].[DocumentType] ([Id], [Code], [Description], [State]) VALUES (N'2c0e702e-6a4f-4cf5-888f-ee50a61de724', N'CE', N'Cédula de extranjería', 1)
INSERT [dbo].[DocumentType] ([Id], [Code], [Description], [State]) VALUES (N'155b47d2-95e1-4e13-bda8-fe43b2d86328', N'PA', N'Pasaporte', 1)
GO
INSERT [dbo].[Role] ([Id], [IdentificaionCode], [Description], [State]) VALUES (N'2a5591a4-68ba-4ac3-a6d2-447e1d70aba7', N'DEF', N'Default', 1)
INSERT [dbo].[Role] ([Id], [IdentificaionCode], [Description], [State]) VALUES (N'8013cfe1-b7d2-4795-a2fe-b21558c21c9f', N'ADM', N'Administrador', 1)
GO
INSERT [dbo].[User] ([Id], [DocumentType], [DocumentNumber], [FirstName], [LastName], [Email], [Password], [Role], [State]) VALUES (N'03d3976d-94a1-4e62-9d70-aa5bd7c924c8', N'CC', N'112826543', N'David', N'Ciro', N'ciro@mail.com', N'8f210c0d1c4d52dcf56a2c2d9ef13763', N'8013cfe1-b7d2-4795-a2fe-b21558c21c9f', 1)
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Users_DocumentType] FOREIGN KEY([DocumentType])
REFERENCES [dbo].[DocumentType] ([Code])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_Users_DocumentType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([Role])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_Users_Role]
GO
