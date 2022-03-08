USE Katherine;

GO

ALTER PROCEDURE ObtenerLibros
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

ALTER PROCEDURE ABMLibros
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
	PRINT(@FechaPublicacion);

	IF (@ID > 0 AND @Eliminar = 1)
	BEGIN
		UPDATE Usuarios
		SET Activo = 0
		WHERE ID = @ID
	END
	ELSE IF(@ID > 0 AND @Eliminar = 0)
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
		WHERE ID = @id;
	END
	ELSE
	BEGIN
		INSERT INTO Libros(ISBN,Titulo,Subtitulo,Idioma,Descripcion,Autor,Tipo,Editorial,Coleccion,Precio,CantPaginas,FechaPublicacion,Activo)
		VALUES(@ISBN,@Titulo,@Subtitulo,@Idioma,@Descripcion,@Autor,@Tipo,@Editorial,@Coleccion,@Precio,@CantPaginas,@FechaPublicacion,@Activo)
	END

	RETURN @Retorno;
END

GO

DECLARE @Algo AS DATETIME;
SET @Algo = GETDATE();

EXEC ABMLibros
@ID = NULL,
@ISBN = '123',
@Titulo = 'La resurrección de D10S',
@Subtitulo = 'El Diegote en una nube',
@Idioma = 'E',
@Descripcion = 'Diegote y Boca en una comunión',
@Autor = 'WE',
@Tipo = 'Religión',
@Editorial = 'E',
@Coleccion = 'D10S',
@Precio = 140.5,
@CantPaginas = 150,
@FechaPublicacion = @Algo,
@Activo = 1

EXEC ObtenerLibros
--@ID = 2
@ISBN		= NULL
,@Titulo	= 'Pepa'
,@Autor		= NULL
,@Descripcion = NULL
,@Editorial	 = NULL
,@Tipo		 = NULL
,@SoloActivos = 1

