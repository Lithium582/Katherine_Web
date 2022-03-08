USE Katherine;

GO

CREATE PROCEDURE ObtenerUsuarios
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

CREATE PROCEDURE ABMUsuarios
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

--EXEC ObtenerUsuarios @SoloActivos = 0;