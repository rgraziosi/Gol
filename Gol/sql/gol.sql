CREATE DATABASE Gol
USE [Gol]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airplane](
	[Id] [uniqueidentifier] NOT NULL,
	[DateInsert] [datetime] NULL,
	[DateUpdate] [datetime] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passager](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateInsert] [datetime] NULL,
	[DateUpdate] [datetime] NULL,
	[Type] [nvarchar](50) NULL,
	[Seat] [nvarchar](50) NULL,
	[IdAirplane] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Passager]  WITH CHECK ADD FOREIGN KEY([IdAirplane])
REFERENCES [dbo].[Airplane] ([Id])
GO
