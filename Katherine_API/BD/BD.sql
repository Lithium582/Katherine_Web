--CREATE DATABASE Katherine;

GO

USE Katherine;

GO

CREATE TABLE Usuarios(
	ID				INTEGER IDENTITY(1,1) PRIMARY KEY,
	Usuario			VARCHAR(100) NOT NULL UNIQUE,
	Nombre			VARCHAR(100) NOT NULL,
	Nombre2			VARCHAR(100) NOT NULL,
	Apellido		VARCHAR(100) NOT NULL,
	Apellido2		VARCHAR(100) NOT NULL,
	Email			VARCHAR(100) NOT NULL,
	Telefono		VARCHAR(20) NOT NULL,
	Telefono2		VARCHAR(20) NOT NULL,
	Direccion		VARCHAR(1000) NOT NULL,
	UltimoAcceso	DATETIME DEFAULT GETDATE(),
	Activo			BIT DEFAULT 1
);

CREATE TABLE Libros(
	ID					INTEGER IDENTITY(1,1) PRIMARY KEY,
	ISBN				VARCHAR(100) NOT NULL UNIQUE,
	Titulo				VARCHAR(100) NOT NULL,
	Subtitulo			VARCHAR(1000) NOT NULL,
	Idioma				VARCHAR(100) NOT NULL,
	Descripcion			VARCHAR(MAX) NOT NULL,
	Autor				VARCHAR(200) NOT NULL, --Tabla
	Tipo				VARCHAR(200) NOT NULL, --Tabla
	Editorial			VARCHAR(200) NOT NULL, --Tabla
	Coleccion			VARCHAR(200) NOT NULL, --Tabla
	Precio				DECIMAL(10,2) NOT NULL,
	CantPaginas			INTEGER NOT NULL,
	FechaPublicacion	DATE NOT NULL,
	Activo				BIT DEFAULT 1
);

