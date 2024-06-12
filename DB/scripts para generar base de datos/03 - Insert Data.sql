USE [BLOG]
GO

INSERT INTO [dbo].[User_Perfil] ([description])
     VALUES ('Aministrador')

INSERT INTO [dbo].[User_Perfil_Function] ([description])
     VALUES ('Iniciar Sesion')

INSERT INTO [dbo].[User_PerfilFunctionActive] ([id_Perfil],[id_Perfil_Function],[Active])
     VALUES (1,1,1)