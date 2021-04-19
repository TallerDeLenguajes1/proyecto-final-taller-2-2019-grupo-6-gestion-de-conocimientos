CREATE TABLE [dbo].[Usuarios] (
    [id_user]       INT          IDENTITY (0, 1) NOT NULL,
    [nombre]        VARCHAR (50) NOT NULL,
    [apellido]      VARCHAR (50) NOT NULL,
    [pais_origen]   VARCHAR (50) NOT NULL,
    [email]         VARCHAR (50) NOT NULL,
    [password]      VARCHAR (50) NOT NULL,
    [fecha_ingreso] DATE         DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_user] ASC)
);

INSERT INTO dbo.Usuarios 
(nombre, apellido, pais_origen, email, password, fecha_ingreso) 
VALUES(
	'Anon', 
	'Anon', 
	'4chan', 
	'anon@4chan.org', 
	'password', 
	'1/1/1753'
);

CREATE TABLE [dbo].[Preguntas] (
    [id_user]     INT          DEFAULT ((0)) NOT NULL,
    [id_pregunta] INT          IDENTITY (1, 1) NOT NULL,
    [id_solucion] INT          NULL,
    [titulo]      VARCHAR (50) NOT NULL,
    [descripcion] VARCHAR (50) NOT NULL,
    [url_imagen]  VARCHAR (50) NULL,
    [fecha]       DATE         DEFAULT (getdate()) NOT NULL,
    [estado]      VARCHAR (50) DEFAULT 'Activa' NOT NULL,
    PRIMARY KEY CLUSTERED ([id_pregunta] ASC)
);

CREATE TABLE [dbo].[Tags] (
    [id_pregunta] INT          NOT NULL,
    [nombre_tag]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_pregunta] ASC, [nombre_tag] ASC)
);

CREATE TABLE [dbo].[Respuestas] (
    [id_user]      INT          DEFAULT ((0)) NOT NULL,
    [id_pregunta]  INT          NOT NULL,
    [id_respuesta] INT          IDENTITY (1, 1) NOT NULL,
    [titulo]       VARCHAR (50) NOT NULL,
    [descripcion]  VARCHAR (50) NOT NULL,
    [url_imagen]   VARCHAR (50) NULL,
    [fecha]        DATE         DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_respuesta] ASC)
);

CREATE TABLE [dbo].[Notificaciones] (
    [id_user]      INT NOT NULL,
    [id_pregunta] INT NOT NULL,
    [id_notificacion] INT IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_notificacion] ASC)
);

CREATE TABLE [dbo].[Likes] (
    [id_user]      INT NOT NULL,
    [id_respuesta] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id_user] ASC, [id_respuesta] ASC)
);

ALTER TABLE [dbo].[Likes]
ADD CONSTRAINT [FK_Like_User] FOREIGN KEY ([id_user]) REFERENCES [dbo].[Usuarios] ([id_user]);
ALTER TABLE [dbo].[Likes]
ADD CONSTRAINT [FK_Like_Respuesta] FOREIGN KEY ([id_respuesta]) REFERENCES [dbo].[Respuestas] ([id_respuesta]);

ALTER TABLE [dbo].[Preguntas]
ADD CONSTRAINT [FK_Pregunta_Solucion] FOREIGN KEY ([id_solucion]) REFERENCES [dbo].[Respuestas] ([id_respuesta]);
ALTER TABLE [dbo].[Preguntas]
ADD CONSTRAINT [FK_Pregunta_User] FOREIGN KEY ([id_user]) REFERENCES [dbo].[Usuarios] ([id_user]);

ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [FK_Tag_Pregunta] FOREIGN KEY ([id_pregunta]) REFERENCES [dbo].[Preguntas] ([id_pregunta]);

ALTER TABLE [dbo].[Respuestas]
ADD CONSTRAINT [FK_Respuesta_Pregunta] FOREIGN KEY ([id_pregunta]) REFERENCES [dbo].[Preguntas] ([id_pregunta]);
ALTER TABLE [dbo].[Respuestas]
ADD CONSTRAINT [FK_Respuesta_User] FOREIGN KEY ([id_user]) REFERENCES [dbo].[Usuarios] ([id_user]);

ALTER TABLE [dbo].[Notificaciones]
ADD CONSTRAINT [FK_Notificacion_Pregunta] FOREIGN KEY ([id_pregunta]) REFERENCES [dbo].[Preguntas] ([id_pregunta]);
ALTER TABLE [dbo].[Notificaciones]
ADD CONSTRAINT [FK_Notificacion_User] FOREIGN KEY ([id_user]) REFERENCES [dbo].[Usuarios] ([id_user]);




GO

CREATE TRIGGER [DELETE_User]
   ON dbo.Usuarios
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 UPDATE Preguntas SET id_user = 0, estado = 'Suspendida' WHERE id_user IN (SELECT id_user FROM DELETED)
 UPDATE Respuestas SET id_user = 0 WHERE id_user IN (SELECT id_user FROM DELETED)
 DELETE FROM Notificaciones WHERE id_user IN (SELECT id_user FROM DELETED)
 DELETE FROM Likes WHERE id_user IN (SELECT id_user FROM DELETED)
 DELETE FROM Usuarios WHERE id_user IN (SELECT id_user FROM DELETED)
END


GO

CREATE TRIGGER [DELETE_Respuesta]
   ON dbo.Respuestas
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 UPDATE Preguntas SET id_solucion = NULL WHERE id_solucion IN (SELECT id_respuesta FROM DELETED)
 DELETE FROM Likes WHERE id_respuesta IN (SELECT id_respuesta FROM DELETED)
 DELETE FROM Respuestas WHERE id_respuesta IN (SELECT id_respuesta FROM DELETED)
END


GO

CREATE TRIGGER [DELETE_Pregunta]
   ON dbo.Preguntas
   INSTEAD OF DELETE
AS 
BEGIN
 SET NOCOUNT ON;
 DELETE FROM Notificaciones WHERE id_pregunta IN (SELECT id_pregunta FROM DELETED)
 DELETE FROM Tags WHERE id_pregunta IN (SELECT id_pregunta FROM DELETED)
 DELETE FROM Respuestas WHERE id_pregunta IN (SELECT id_pregunta FROM DELETED)
 DELETE FROM Preguntas WHERE id_pregunta IN (SELECT id_pregunta FROM DELETED)
END