CREATE DATABASE ProyectoFinal
GO

USE ProyectoFinal
GO

CREATE TABLE Usuarios (
    UsuarioID int identity(1,1) PRIMARY KEY,
    Nombre varchar(50) NOT NULL,
    CorreoElectronico varchar(50),
    Telefono varchar(15) CONSTRAINT uc_Telefono UNIQUE (Telefono)  /**/
)
GO

CREATE TABLE Equipos (
    EquipoID int identity(1,1) PRIMARY KEY,
    TipoEquipo varchar(50) NOT NULL,
    Modelo varchar(50),
    UsuarioID int,
    CONSTRAINT fk_usuarioID FOREIGN KEY(UsuarioID) REFERENCES Usuarios(UsuarioID)
)
GO

CREATE TABLE Tecnicos (
    TecnicoID int identity(1,1) PRIMARY KEY,
    Nombre varchar(50),
    Especialidad varchar(20),
	UserID varchar NOT NULL
)
GO

CREATE TABLE Reparaciones (
    ReparacionID int identity(1,1) PRIMARY KEY,
    EquipoID int,
    FechaSolicitud DATETIME CONSTRAINT df_FechaSolicitud DEFAULT GETDATE(), /**/
    Estado char(1),
    CONSTRAINT fk_equipoID FOREIGN KEY(EquipoID) REFERENCES Equipos(EquipoID)
)
GO


CREATE TABLE DetallesReparacion (
    DetalleID int identity(1,1) PRIMARY KEY,
    ReparacionID int,
    Descripcion varchar(50),
    FechaInicio DATETIME CONSTRAINT df_FechaInicio DEFAULT GETDATE(),
    FechaFin DATETIME,
    CONSTRAINT fk_reparacionID FOREIGN KEY(ReparacionID) REFERENCES Reparaciones(ReparacionID)
)
GO


CREATE TABLE Asignaciones (
    AsignacionID int identity(1,1) PRIMARY KEY,
    ReparacionID int,
    TecnicoID int,
    FechaAsignacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT fk_asignaciones_reparacionID FOREIGN KEY(ReparacionID) REFERENCES Reparaciones(ReparacionID),
    CONSTRAINT fk_asignaciones_tecnicoID FOREIGN KEY(TecnicoID) REFERENCES Tecnicos(TecnicoID)
)
GO

CREATE TABLE SystemUsers (
	LogInUser varchar(15) NOT NULL,
	UsuarioID int NOT NULL,
	Clave varchar(15) NOT NULL,
	CONSTRAINT PK_login PRIMARY KEY (LogInUser),
	CONSTRAINT UQ_login UNIQUE (LogInUser),
	CONSTRAINT fk_usuarioIDSystem FOREIGN KEY(UsuarioID) REFERENCES Usuarios(UsuarioID)
)
GO

CREATE TABLE Roles (
	RolID int identity (1,1),
	nombreRol varchar(15) NOT NULL,
	CONSTRAINT PK_RolID PRIMARY KEY (RolID)
)
GO


INSERT INTO Roles VALUES ('Administrador'), ('Tecnico'), ('Usuario')

GO

CREATE TABLE UserRoles (
	LogInUser varchar(15),
	RolID int,
	CONSTRAINT fk_LogInUser FOREIGN KEY(LogInUser) REFERENCES SystemUsers(LogInUser),
	CONSTRAINT fk_rolID FOREIGN KEY(RolID) REFERENCES Roles(RolID)
)
GO

select * from SystemUsers
select * from UserRoles

INSERT INTO UserRoles VALUES('oscar', 1), ('pedro', 1), ('tom', 2)


CREATE PROCEDURE ReporteGeneral
	AS
	BEGIN
		SELECT CONVERT(VARCHAR(20), U.UsuarioID) + '-' + U.Nombre AS [ID Usuario], U.Telefono, U.CorreoElectronico, CONVERT(VARCHAR(20), E.EquipoID) + '-' + E.Modelo AS [ID Equipo], D.Descripcion AS [Detalle reparacion],
		R.Estado, D.FechaInicio AS [Fecha Inicio], D.FechaFin AS [Fecha Fin], CONVERT(VARCHAR(20), T.TecnicoID) + '-' + T.Nombre AS [ID Tecnico], R.ReparacionID AS [ID Reparacion],
		R.FechaSolicitud
		FROM Usuarios U
		INNER JOIN Equipos E ON U.UsuarioID = E.UsuarioID
		INNER JOIN Reparaciones R ON E.EquipoID = R.EquipoID
		INNER JOIN DetallesReparacion D ON D.ReparacionID = R.ReparacionID
		INNER JOIN Asignaciones A ON R.ReparacionID = A.ReparacionID
		INNER JOIN Tecnicos T ON A.TecnicoID = T.TecnicoID
	END
GO


EXEC ReporteGeneral
GO


SELECT * FROM Usuarios
GO
SELECT * FROM Equipos
GO
SELECT * FROM Reparaciones
GO
SELECT * FROM DetallesReparacion
GO
SELECT * FROM Tecnicos
GO
SELECT * FROM Asignaciones
GO


INSERT INTO Usuarios(Nombre, CorreoElectronico, Telefono) VALUES
('Oscar Isaac', 'oscar@examen2.net', '89898989'),
('Jose Pedro', 'pedro@examen2.net', '87878787'),
('Tom Holland', 'tom@examen2.net', '81818181'),
('Zendaya', 'zendaya@examen2.net', '82828282')
GO

INSERT INTO Equipos(TipoEquipo, Modelo, UsuarioID) VALUES
('Computadora Escritorio', 'Asus', '1'),
('VR Headset', 'Oculus', '4'), 
('Nintendo Switch', 'Nintendo', '2')
GO

INSERT INTO Reparaciones(EquipoID, Estado) VALUES
(1, 'A'),
(2, 'B'),
(3, 'C')
GO

INSERT INTO DetallesReparacion(ReparacionID, Descripcion) VALUES
(1, 'Arreglar fuente de poder'),
(2, 'Puerto de carga no funciona'),
(3, 'Arreglar joycon')
GO


INSERT INTO Tecnicos(Nombre, Especialidad) VALUES
('Edward', 'Técnico en cómputo'),
('Jacob', 'Técnico electricista')
GO

INSERT INTO Asignaciones(ReparacionID, TecnicoID) VALUES
(1, 1),
(2, 2),
(3, 1)
GO


/*DBCC CHECKIDENT ('Tecnicos', RESEED, 0);*/


CREATE PROCEDURE CONSULTAR_EQUIPOS
AS
	BEGIN
		SELECT * FROM Equipos
	END
GO

CREATE PROCEDURE CONSULTAR_USUARIOS
AS
	BEGIN
		SELECT * FROM Usuarios
	END
GO

CREATE PROCEDURE CONSULTAR_TECNICOS
AS
	BEGIN
		SELECT * FROM Tecnicos
	END
GO

CREATE PROCEDURE CONSULTAR_EQUIPOS_ID
@CODIGO INT
 AS
	BEGIN
	  SELECT * FROM Equipos WHERE EquipoID = @CODIGO
	END
GO

CREATE PROCEDURE CONSULTAR_USUARIOS_ID
@CODIGO INT
 AS
	BEGIN
	  SELECT * FROM Usuarios WHERE UsuarioID = @CODIGO
	END
GO

CREATE PROCEDURE CONSULTAR_TECNICOS_ID
@CODIGO INT
 AS
	BEGIN
	  SELECT * FROM Tecnicos WHERE TecnicoID = @CODIGO
	END
GO

CREATE PROCEDURE INSERTAR_EQUIPO
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
 AS 
	BEGIN
		INSERT INTO Equipos(TipoEquipo, Modelo, UsuarioID) VALUES (@TIPOEQUIPO, @MODELO, @USUARIOID)
	END
GO

CREATE PROCEDURE INSERTAR_USUARIO
@NOMBRE VARCHAR(50),
@CORREOELECTRONICO VARCHAR(50),
@TELEFONO VARCHAR(15)
 AS 
	BEGIN
		INSERT INTO Usuarios(Nombre, CorreoElectronico, Telefono) VALUES (@NOMBRE, @CORREOELECTRONICO, @TELEFONO)
	END
GO

CREATE PROCEDURE INSERTAR_TECNICO
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS 
	BEGIN
		INSERT INTO Tecnicos(Nombre, Especialidad) VALUES (@NOMBRE, @ESPECIALIDAD)
	END
GO

CREATE PROCEDURE BORRAREQUIPO
@CODIGO INT
 AS
	BEGIN
	  DELETE Equipos WHERE EquipoID = @CODIGO
END
GO

CREATE PROCEDURE BORRARUSUARIO
@CODIGO INT
 AS
	BEGIN
	  DELETE Usuarios WHERE UsuarioID = @CODIGO
END
GO

CREATE PROCEDURE BORRARTECNICO
@CODIGO INT
 AS
	BEGIN
	  DELETE Tecnicos WHERE TecnicoID = @CODIGO
END
GO

CREATE PROCEDURE ACTUALIZAR_EQUIPOID
@CODIGO INT,
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
AS
	BEGIN
		UPDATE Equipos SET TipoEquipo = @TIPOEQUIPO, Modelo = @MODELO, UsuarioID = @USUARIOID WHERE EquipoID=@CODIGO
	END
GO

CREATE PROCEDURE ACTUALIZAR_USUARIOID
@CODIGO INT,
@NOMBRE VARCHAR(50),
@CORREOELECTRONICO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
	BEGIN
		UPDATE Usuarios SET Nombre = @NOMBRE, CorreoElectronico = @CORREOELECTRONICO, Telefono = @TELEFONO WHERE UsuarioID=@CODIGO
	END
GO

CREATE PROCEDURE ACTUALIZAR_TECNICOID
@CODIGO INT,
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
	BEGIN
		UPDATE Tecnicos SET Nombre = @NOMBRE, Especialidad = @ESPECIALIDAD WHERE TecnicoID=@CODIGO
	END
GO

CREATE PROCEDURE VALIDAR_USUARIO
@loginuser varchar(15),
@clave varchar(15)

	As
		Begin
			Select LogInUser, Clave FROM SystemUsers WHERE LogInUser = @loginuser and Clave = @clave
		End

GO