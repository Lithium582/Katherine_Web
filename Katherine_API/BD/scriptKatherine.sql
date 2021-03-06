USE [master]
GO
/****** Object:  Database [Katherine]    Script Date: 8/3/2022 16:40:37 ******/
CREATE DATABASE [Katherine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Katherine', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Katherine.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Katherine_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Katherine_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Katherine] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Katherine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Katherine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Katherine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Katherine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Katherine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Katherine] SET ARITHABORT OFF 
GO
ALTER DATABASE [Katherine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Katherine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Katherine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Katherine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Katherine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Katherine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Katherine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Katherine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Katherine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Katherine] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Katherine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Katherine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Katherine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Katherine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Katherine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Katherine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Katherine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Katherine] SET RECOVERY FULL 
GO
ALTER DATABASE [Katherine] SET  MULTI_USER 
GO
ALTER DATABASE [Katherine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Katherine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Katherine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Katherine] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Katherine] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Katherine] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Katherine', N'ON'
GO
ALTER DATABASE [Katherine] SET QUERY_STORE = OFF
GO
USE [Katherine]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 8/3/2022 16:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [varchar](100) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Subtitulo] [varchar](1000) NOT NULL,
	[Idioma] [varchar](100) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Autor] [varchar](200) NOT NULL,
	[Tipo] [varchar](200) NOT NULL,
	[Editorial] [varchar](200) NOT NULL,
	[Coleccion] [varchar](200) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[CantPaginas] [int] NOT NULL,
	[FechaPublicacion] [date] NOT NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 8/3/2022 16:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Nombre2] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Apellido2] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Telefono2] [varchar](20) NOT NULL,
	[Direccion] [varchar](1000) NOT NULL,
	[UltimoAcceso] [datetime] NULL,
	[Activo] [bit] NULL,
	[Pass] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Libros] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [UltimoAcceso]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  StoredProcedure [dbo].[ABMLibros]    Script Date: 8/3/2022 16:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ABMLibros]
@ID					INTEGER			= NULL,
@ISBN				VARCHAR(100)	= NULL,
@Titulo				VARCHAR(100)	= NULL,
@Subtitulo			VARCHAR(1000)	= NULL,
@Idioma				VARCHAR(100)	= NULL,
@Descripcion		VARCHAR(MAX)	= NULL,
@Autor				VARCHAR(200)	= NULL,
@Tipo				VARCHAR(200)	= NULL,
@Editorial			VARCHAR(200)	= NULL,
@Coleccion			VARCHAR(200)	= NULL,
@Precio				DECIMAL(10,2)	= NULL,
@CantPaginas		INTEGER			= NULL,
@FechaPublicacion	DATE			= NULL,
@Activo				BIT				= NULL,
@Eliminar			BIT				= 0
AS
BEGIN
	DECLARE @Retorno AS INTEGER;
	SET @Retorno = 0;

	IF (@ID > 0 AND @Eliminar = 1)
	BEGIN
		UPDATE Libros
		SET Activo = 0
		WHERE ID = @ID

		SET @Retorno = 1;
	END
	ELSE 
	BEGIN
		IF (@ID > 0 )
		BEGIN
			UPDATE Libros
			SET	ISBN				= @ISBN,
				Titulo				= @Titulo,
				Subtitulo			= @Subtitulo,
				Idioma				= @Idioma,
				Descripcion			= @Descripcion,
				Autor				= @Autor,
				Tipo				= @Tipo,
				Editorial			= @Editorial,
				Coleccion			= @Coleccion,
				Precio				= @Precio,
				CantPaginas			= @CantPaginas,
				FechaPublicacion	= @FechaPublicacion,
				Activo				= @Activo
			WHERE ID = @ID;

			SET @Retorno = 1;
		END
		ELSE
		BEGIN
			INSERT INTO Libros(ISBN,Titulo,Subtitulo,Idioma,Descripcion,Autor,Tipo,Editorial,Coleccion,Precio,CantPaginas,FechaPublicacion,Activo)
			VALUES(@ISBN,@Titulo,@Subtitulo,@Idioma,@Descripcion,@Autor,@Tipo,@Editorial,@Coleccion,@Precio,@CantPaginas,@FechaPublicacion,@Activo)

			SET @Retorno = 1;
		END
	END

	RETURN @Retorno;
END

GO
/****** Object:  StoredProcedure [dbo].[ABMUsuarios]    Script Date: 8/3/2022 16:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ABMUsuarios]
@id				INTEGER = NULL,
@Usuario		VARCHAR(100) = NULL,
@Nombre			VARCHAR(100) = NULL,
@Nombre2		VARCHAR(100) = NULL,
@Apellido		VARCHAR(100) = NULL,
@Apellido2		VARCHAR(100) = NULL,
@Email			VARCHAR(100) = NULL,
@Telefono		VARCHAR(20) = NULL,
@Telefono2		VARCHAR(20) = NULL,
@Direccion		VARCHAR(1000) = NULL,
@UltimoAcceso	DATETIME = NULL,
@Activo			BIT = NULL,
@Eliminar		BIT = 0
AS
BEGIN
	DECLARE @Retorno AS INTEGER;
	SET @Retorno = 0;

	IF (@ID > 0 AND @Eliminar = 1)
	BEGIN
		UPDATE Usuarios
		SET Activo = 0
		WHERE ID = @ID
	END
	ELSE IF(@ID > 0 AND @Eliminar = 0)
	BEGIN
		UPDATE Usuarios
		SET	Nombre			= @Nombre,
			Nombre2			= @Nombre2,
			Apellido		= @Apellido,
			Apellido2		= @Apellido2,
			Email			= @Email,
			Telefono		= @Telefono,
			Telefono2		= @Telefono2,
			Direccion		= @Direccion,
			UltimoAcceso	= @UltimoAcceso,
			Usuario			= @usuario,
			Activo			= @Activo
		WHERE ID = @id;
	END
	ELSE
	BEGIN
		INSERT INTO Usuarios(Usuario, Nombre, Nombre2, Apellido, Apellido2, Email, Telefono, Telefono2, Direccion, UltimoAcceso, Activo)
		VALUES(@usuario, @Nombre, @Nombre2, @Apellido, @Apellido2, @Email, @Telefono, @Telefono2, @Direccion, @UltimoAcceso, @Activo)
	END

	RETURN @Retorno;
END

GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 8/3/2022 16:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Login]
@Usuario		VARCHAR(100),
@Password		VARCHAR(100)
AS
BEGIN
	SELECT 	ID,
			Usuario,
			Nombre,
			Nombre2,
			Apellido,
			Apellido2,
			Email,
			Telefono,
			Telefono2,
			Direccion,
			UltimoAcceso,
			Activo
	INTO #Tabla
	FROM Usuarios U
	WHERE (
		Usuario = @Usuario
		OR Email = @Usuario
		)
		AND U.Pass = @Password
		AND Activo = 1;


	IF EXISTS(
		SELECT *
		FROM #Tabla)
	BEGIN
		UPDATE Usuarios
		SET UltimoAcceso = GETDATE()
		WHERE Usuario = @Usuario;
	END

	SELECT *
	FROM #Tabla;

	DROP TABLE #Tabla;
END

GO
/****** Object:  StoredProcedure [dbo].[ObtenerLibros]    Script Date: 8/3/2022 16:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerLibros]
@ID				INTEGER = NULL,
@ISBN			VARCHAR(100) = NULL,
@Titulo			VARCHAR(100) = NULL,
@Autor			VARCHAR(100) = NULL,
@Descripcion	VARCHAR(100) = NULL,
@Editorial		VARCHAR(100) = NULL,
@Tipo			VARCHAR(100) = NULL,
@SoloActivos	BIT = 1
AS
BEGIN
	SELECT	ID,
			ISBN,
			Titulo,
			Subtitulo,
			Idioma,
			Descripcion,
			Autor,
			Tipo,
			Editorial,
			Coleccion,
			Precio,
			CantPaginas,
			FechaPublicacion,
			Activo
	FROM Libros
	WHERE (ID = @ID OR @ID IS NULL)
		AND (ISBN LIKE('%' + @ISBN + '%') OR @ISBN IS NULL) 
			AND (
				(Titulo LIKE('%' + @Titulo + '%') OR @Titulo IS NULL)
				AND (Autor LIKE('%' + @Autor + '%') OR @Autor IS NULL)
				AND (Descripcion LIKE('%' + @Descripcion + '%') OR @Descripcion IS NULL)
				AND (Editorial LIKE('%' + @Editorial + '%') OR @Editorial IS NULL)
				AND (Tipo LIKE('%' + @Tipo + '%') OR @Tipo IS NULL)
			)
		AND (Activo = @SoloActivos OR @SoloActivos = 0)
END

GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuarios]    Script Date: 8/3/2022 16:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerUsuarios]
@id				INTEGER = NULL,
@usuario		VARCHAR(100) = NULL,
@nombre			VARCHAR(100) = NULL,
@SoloActivos	BIT = 1
AS
BEGIN
	SELECT	ID,
			Usuario,
			Nombre,
			Nombre2,
			Apellido,
			Apellido2,
			Email,
			Telefono,
			Telefono2,
			Direccion,
			UltimoAcceso,
			Activo
	FROM Usuarios
	WHERE (ID = @id OR @id IS NULL)
		AND (
				(Usuario LIKE('%' + @usuario + '%') OR @usuario IS NULL)
				AND (Nombre LIKE('%' + @nombre + '%') OR @nombre IS NULL)
				AND (Nombre2 LIKE('%' + @nombre + '%') OR @nombre IS NULL)
				AND (Apellido LIKE('%' + @nombre + '%') OR @nombre IS NULL)
				AND (Apellido2 LIKE('%' + @nombre + '%') OR @nombre IS NULL)
			)
		AND (Activo = @SoloActivos OR @SoloActivos = 0)
END

GO
USE [master]
GO
ALTER DATABASE [Katherine] SET  READ_WRITE 
GO
