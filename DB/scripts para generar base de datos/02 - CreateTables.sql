USE [BLOG]
GO



/****** Object:  Table User_Perfil    Script Date: 04/06/2024 20:07:20 ******/
/* CREATE TABLE User_Perfil*/
CREATE TABLE [dbo].[User_Perfil](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [ntext] NOT NULL,
 CONSTRAINT [PK_User_Perfil] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO





/****** Object:  Table [dbo].[User_Perfil_Function]    Script Date: 04/06/2024 20:07:20 ******/
/* CREATE TABLE USER_PERFIL_FUNCTION*/

CREATE TABLE [dbo].[User_Perfil_Function](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [ntext] NOT NULL,
 CONSTRAINT [PK_User_Perfil_Function] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[User_PerfilFunctionActive]    Script Date: 04/06/2024 20:49:40 ******/
/* CREATE TABLE USER_PERFILFUNCTIONACTIVE*/
CREATE TABLE [dbo].[User_PerfilFunctionActive](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Perfil] [int] NOT NULL,
	[id_Perfil_Function] [int] NOT NULL,
	[Active] [int] NULL,
 CONSTRAINT [PK_User_PerfilFunctionActive] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[User_PerfilFunctionActive]  WITH CHECK ADD  CONSTRAINT [FK_Perfil] FOREIGN KEY([id_Perfil])
REFERENCES [dbo].[User_Perfil] ([id])
GO

ALTER TABLE [dbo].[User_PerfilFunctionActive] CHECK CONSTRAINT [FK_Perfil]
GO

ALTER TABLE [dbo].[User_PerfilFunctionActive]  WITH CHECK ADD  CONSTRAINT [FK_Perfil_Function] FOREIGN KEY([id_Perfil_Function])
REFERENCES [dbo].[User_Perfil_Function] ([id])
GO

ALTER TABLE [dbo].[User_PerfilFunctionActive] CHECK CONSTRAINT [FK_Perfil_Function]
GO

/****** Object:  Table [dbo].[User]    Script Date: 21/05/2024 15:40:22 ******/
/*CREATE TABLE USER*/

CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [ntext] NULL,
	[username] [nvarchar](128) NOT NULL,
	[password] [ntext] NOT NULL,
	[id_perfil] [int] NOT NULL,
 CONSTRAINT [PK] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_id_perfil] FOREIGN KEY([id])
REFERENCES [dbo].[User_Perfil] ([id])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_id_perfil]
GO

ALTER TABLE [dbo].[User] NOCHECK CONSTRAINT [FK_id_perfil]