-- Si no existe la base de datos, se crea
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Examen1Progra6')
BEGIN
-- Se crea la base de datos
CREATE DATABASE Examen1Progra6
END
GO

-- Se usa la base de datos creada
USE Examen1Progra6
GO

-- Se crea la tabla Producto, donde se almacenará la información de los productos
CREATE TABLE Producto(
ProductoID INT PRIMARY KEY IDENTITY(1,1), 
Nombre VARCHAR(150) NOT NULL,
Descripcion VARCHAR(255) NOT NULL, 
Precio FLOAT NOT NULL CHECK(Precio > 0), 
CantidadStock INT NOT NULL CHECK(CantidadStock >= 0), 
Categoria NVARCHAR(150) NOT NULL,
FechaRegistro DATETIME DEFAULT GETDATE(),
RegistradoPor NVARCHAR(255) NOT NULL,
FechaModificacion DATETIME,
ModificadoPor NVARCHAR(255)
);

-- Se crea la tabla Errores, utilizada para guardar los errores que se presenten durante el uso
-- Funciona como una tabla de auditoría
GO
CREATE TABLE Errores
(
ErrorID INT IDENTITY(1,1) PRIMARY KEY,
Mensaje NVARCHAR(4000) NOT NULL,
Severidad INT NOT NULL,
Estatus INT NOT NULL,
FechaIngreso DATETIME DEFAULT GETDATE(),
ProcedimientoOrigen NVARCHAR(100) NOT NULL
);

-- Procedimiento almacenado para Crear un producto
GO
CREATE PROCEDURE spCrearProducto
(
@pNombre VARCHAR(150),
@pDescripcion VARCHAR(255), 
@pPrecio FLOAT, 
@pCantidadStock INT, 
@pCategoria NVARCHAR(150),
@pRegistradoPor NVARCHAR(255)
)
AS
BEGIN
BEGIN TRY
SET NOCOUNT ON;
-- Se realiza la inserción del nuevo producto
INSERT INTO Producto (Nombre, Descripcion, Precio, CantidadStock, Categoria, RegistradoPor)
VALUES (@pNombre, @pDescripcion, @pPrecio, @pCantidadStock, @pCategoria, @pRegistradoPor);        
-- Se selecciona el último ID generado
SELECT SCOPE_IDENTITY() AS IDIngresado
END TRY
 BEGIN CATCH
-- Se declaran variables para el manejo de errores
DECLARE @ERRORSEVERITY INT = ERROR_SEVERITY();
DECLARE @ERRORSTATE INT = ERROR_STATE();
DECLARE @ERRORMESSAGE NVARCHAR(255) = ERROR_MESSAGE();
-- Se registra el error en la tabla Errores
INSERT INTO Errores (Mensaje, Severidad, Estatus, ProcedimientoOrigen)
VALUES (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE, 'CREAR');        
-- Se genera el error para ser mostrado al usuario
RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
END CATCH;
END;

-- Procedimiento almacenado para actualizar un producto
GO
CREATE PROCEDURE spActualizarProducto
(
@pProductoID INT,
@pNombre VARCHAR(150),
@pDescripcion VARCHAR(255), 
@pPrecio FLOAT, 
@pCantidadStock INT, 
@pCategoria NVARCHAR(150),
@pModificadoPor NVARCHAR(255)
)
AS
BEGIN
BEGIN TRY
SET NOCOUNT ON;
-- Se actualizan los datos del producto con el ID indicado
UPDATE Producto
SET
Nombre = @pNombre,
Descripcion = @pDescripcion,
Precio = @pPrecio,
CantidadStock = @pCantidadStock,
Categoria = @pCategoria,
ModificadoPor = @pModificadoPor,
FechaModificacion = GETDATE()
WHERE ProductoID = @pProductoID;
-- Se devuelve la cantidad de registros modificados
SELECT @@ROWCOUNT AS IDModificado
END TRY
BEGIN CATCH
-- Se manejan los errores y se registran en la tabla Errores
DECLARE @ERRORSEVERITY INT = ERROR_SEVERITY();
DECLARE @ERRORSTATE INT = ERROR_STATE();
DECLARE @ERRORMESSAGE NVARCHAR(255) = ERROR_MESSAGE();
INSERT INTO Errores (Mensaje, Severidad, Estatus, ProcedimientoOrigen)
VALUES (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE, 'ACTUALIZAR');        
RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
END CATCH;
END;

-- Procedimiento almacenado para eliminar un producto
GO
CREATE PROCEDURE spEliminarProducto
(
@pProductoID INT
)
AS
BEGIN
BEGIN TRY
SET NOCOUNT ON;
-- Se elimina el producto correspondiente al ID indicado
DELETE Producto WHERE ProductoID = @pProductoID;        
-- Se devuelve la cantidad de registros eliminados
SELECT @@ROWCOUNT AS IDEliminado
END TRY
BEGIN CATCH
-- Se manejan los errores y se registran en la tabla Errores
DECLARE @ERRORSEVERITY INT = ERROR_SEVERITY();
DECLARE @ERRORSTATE INT = ERROR_STATE();
DECLARE @ERRORMESSAGE NVARCHAR(255) = ERROR_MESSAGE();
INSERT INTO Errores (Mensaje, Severidad, Estatus, ProcedimientoOrigen)
VALUES (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE, 'ELIMINAR');
RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
END CATCH;
END;

-- Procedimiento almacenado para Buscar un producto
GO
CREATE PROCEDURE spListarProducto
(
@pProductoID INT
)
AS
BEGIN
BEGIN TRY
-- Se selecciona la información del producto indicado
SELECT ProductoID, Nombre, Descripcion, Precio, CantidadStock, Categoria
FROM Producto
WHERE ProductoID = @pProductoID;
END TRY
BEGIN CATCH
-- Se manejan los errores y se registran en la tabla Errores
DECLARE @ERRORSEVERITY INT = ERROR_SEVERITY();
DECLARE @ERRORSTATE INT = ERROR_STATE();
DECLARE @ERRORMESSAGE NVARCHAR(255) = ERROR_MESSAGE();
INSERT INTO Errores (Mensaje, Severidad, Estatus, ProcedimientoOrigen)
VALUES (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE, 'LISTAR PRODUCTO');        
RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE);
END CATCH;
END;

-- Procedimiento almacenado para listar todos los productos
GO
CREATE PROCEDURE spListarProductos
AS
BEGIN
BEGIN TRY
-- Se listan todos los productos registrados en la base de datos
SELECT ProductoID, Nombre, Descripcion, Precio, CantidadStock, Categoria
FROM Producto;
END TRY
BEGIN CATCH
-- Se manejan los errores y se registran en la tabla Errores
DECLARE @ERRORSEVERITY INT = ERROR_SEVERITY();
DECLARE @ERRORSTATE INT = ERROR_STATE();
DECLARE @ERRORMESSAGE NVARCHAR(255) = ERROR_MESSAGE();
INSERT INTO Errores (Mensaje, Severidad, Estatus, ProcedimientoOrigen)
VALUES (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE, 'LISTAR PRODUCTOS');        
RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
END CATCH;
END;
