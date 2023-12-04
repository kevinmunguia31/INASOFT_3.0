DROP DATABASE IF EXISTS Prueba2;
CREATE DATABASE Prueba2;

USE Prueba2;

-- TABLA Tipos de Usuarios
CREATE TABLE `Tipo_Usuarios` (
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Nombre` VARCHAR(45) DEFAULT NULL,
	CONSTRAINT Tipos_Usuariospk PRIMARY KEY(id)
);

-- TABLA Usuarios
CREATE TABLE `Usuarios` (
  	`ID` INT NOT NULL AUTO_INCREMENT,
  	`Nombre` VARCHAR(70) NOT NULL,
  	`Usuario` VARCHAR(50) NOT NULL,
  	`Password` VARCHAR(80) DEFAULT NULL,
  	`ID_Tipo` INT NOT NULL,
	CONSTRAINT Usuariospk PRIMARY KEY(id),
	CONSTRAINT Usuariosfk FOREIGN KEY(ID_Tipo) REFERENCES Tipo_Usuarios(ID) ON UPDATE CASCADE ON DELETE CASCADE 
);

-- TABLA Clientes
CREATE TABLE `Clientes` (
  	`ID` INT NOT NULL AUTO_INCREMENT,
  	`Nombre` VARCHAR(70) NOT NULL,
	`Telefono` VARCHAR(10) DEFAULT NULL,
  	`Direccion` VARCHAR(100) DEFAULT NULL,
  	`Cedula` VARCHAR(20) DEFAULT NULL,
	CONSTRAINT Clientespk PRIMARY KEY(ID)
);

-- TABLA Entradas
CREATE TABLE `Tipos_Entradas` (
  	`ID` INT NOT NULL AUTO_INCREMENT,
  	`Tipos` VARCHAR(100) NOT NULL,
  	CONSTRAINT Tipos_Entradaspk PRIMARY KEY(ID)
);

-- TABLA Historial de transacciones
CREATE TABLE `HistorialTransacciones` (
  	`ID` INT NOT NULL AUTO_INCREMENT,
  	`Tipos` VARCHAR(100) NOT NULL,
	`Fecha` DATETIME NOT NULL,
	`Descripcioon` VARCHAR(300) NOT NULL,
  	CONSTRAINT HistorialTransaccionespk PRIMARY KEY(ID)
);


-- TABLA Tipo de pago
CREATE TABLE `Tipos_Pagos` (
  	`ID` INT NOT NULL AUTO_INCREMENT,
  	`Tipos` VARCHAR(100) NOT NULL,
  	CONSTRAINT Tipos_Pagospk PRIMARY KEY(ID)
);

-- TABLA Proveedores
CREATE TABLE `Proveedor` (
  	`ID` INT NOT NULL AUTO_INCREMENT,
  	`Nombre` VARCHAR(70) NOT NULL,
	`Telefono` VARCHAR(10) DEFAULT NULL,
	`Direccion` VARCHAR(100) DEFAULT NULL,
	`RUC` VARCHAR(20) DEFAULT NULL, 
	CONSTRAINT Proveedorpk PRIMARY KEY(ID)
);

-- TABLA Productos
CREATE TABLE `Productos` (
  	`ID` INT NOT NULL AUTO_INCREMENT,
  	`Codigo` VARCHAR(45) UNIQUE NOT NULL,
  	`Nombre` VARCHAR(300) NOT NULL,
	`Estado` ENUM('Activo', 'No activo') DEFAULT 'Activo',
  	`Existencias` DOUBLE NOT NULL,
	`Existencias_Minimas` DOUBLE NOT NULL,	
	`Precio_Compra` DOUBLE NOT NULL,
	`Precio_Venta` DOUBLE NOT NULL,
  	`Precio_Total` DOUBLE NOT NULL,
  	`Observacion` VARCHAR(200) DEFAULT NULL,
	`ID_Entrada` INT NOT NULL,
  	CONSTRAINT Productospk PRIMARY KEY(ID),
	CONSTRAINT Productosfk FOREIGN KEY(ID_Entrada) REFERENCES Tipos_Entradas(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Compras de porductos
CREATE TABLE `Compras`(
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Fecha` DATETIME NOT NULL,
	`Nombre_Vendedor` VARCHAR(200) NOT NULL,
	`Descripcion` VARCHAR(200) NOT NULL,
	`Estado` VARCHAR(50) NOT NULL,
	`Subtotal` DOUBLE DEFAULT NULL,
	`Descuento` DOUBLE NOT NULL,
	`IVA` DOUBLE NOT NULL,
	`Total_Final` DOUBLE DEFAULT NULL,
	`ID_Usuario` INT NOT NULL,
	`ID_Proveedor` INT NOT NULL,
	`ID_TiposPago` INT NOT NULL,
	CONSTRAINT Compraspk PRIMARY KEY(ID),
	CONSTRAINT Comprasfk1 FOREIGN KEY(ID_Usuario) REFERENCES Usuarios(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT Comprasfk2 FOREIGN KEY(ID_Proveedor) REFERENCES Proveedor(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT Comprasfk4 FOREIGN KEY(ID_TiposPago) REFERENCES Tipos_Pagos(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE `Detalle_Compra`(
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Cantidad` DOUBLE NOT NULL,
	`ID_Compra` INT NOT NULL,
	`ID_Producto` INT NOT NULL,
	CONSTRAINT Detalle_Comprapk PRIMARY KEY(ID),
	CONSTRAINT Detalle_Comprafk1 FOREIGN KEY(ID_Compra) REFERENCES Compras(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT Detalle_Comprafk2 FOREIGN KEY(ID_Producto) REFERENCES Productos(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Historico de los precio de productos
CREATE TABLE `Historial_Precio` (
  	`ID` INT NOT NULL AUTO_INCREMENT,
  	`Precio_Antiguo` DOUBLE NOT NULL,
  	`Precio_Nuevo` DOUBLE NOT NULL,
	`Descripcion` VARCHAR(300) NOT NULL,
	`Fecha_Cambio` DATETIME NOT NULL,
	`ID_Producto` INT NOT NULL,
  	CONSTRAINT Historico_PrecioProductospk PRIMARY KEY(ID),
	CONSTRAINT Historico_PrecioProductosfk FOREIGN KEY(ID_Producto) REFERENCES Productos(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Remisión de prodcutos
CREATE TABLE `Remisiones` (
  	`ID` INT NOT NULL AUTO_INCREMENT,
	`Descripcion` VARCHAR(100) NOT NULL,
	`Fecha` DATETIME NOT NULL,
	`ID_Usuario` INT NOT NULL,
	`Tipo_remision` VARCHAR(100) NOT NULL,
  	CONSTRAINT Remisionespk PRIMARY KEY(ID),
	CONSTRAINT Remisionesfk FOREIGN KEY(ID_Usuario) REFERENCES Usuarios(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Detalle remisión de prodcutos
CREATE TABLE `Detalle_Remision`(
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Cantidad` DOUBLE NOT NULL,
	`ID_Remision` INT NOT NULL,
	`ID_Producto` INT NOT NULL,
	CONSTRAINT Detalle_Remisionpk PRIMARY KEY(ID),
	CONSTRAINT Detalle_Remisionfk1 FOREIGN KEY(ID_Remision) REFERENCES Remisiones(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT Detalle_Remisionfk2 FOREIGN KEY(ID_Producto) REFERENCES Productos(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Facturas
CREATE TABLE `Facturas`(
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Codigo_Fac` INT,
	`Estado` VARCHAR(50) DEFAULT NULL,
	`Fecha` DATETIME NOT NULL,
	`Descuento` DOUBLE DEFAULT NULL,
	`Subtotal` DOUBLE DEFAULT NULL,
	`Total_Final` DOUBLE DEFAULT NULL,
	`Efectivo` DOUBLE DEFAULT NULL,
	`Devolucion` DOUBLE DEFAULT NULL,
	`Debe` DOUBLE DEFAULT NULL,
	`Tipo_Factura` VARCHAR(50) DEFAULT NULL,
	`Referencia` VARCHAR(300),
	`ID_Usuario` INT NOT NULL,
	`ID_Cliente` INT NOT NULL,
	`ID_TiposPago` INT NOT NULL,
	CONSTRAINT Facturaspk PRIMARY KEY(ID),
	CONSTRAINT Facturasfk1 FOREIGN KEY(ID_Usuario) REFERENCES Usuarios(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT Facturasfk2 FOREIGN KEY(ID_cliente) REFERENCES Clientes(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT Facturasfk3 FOREIGN KEY(ID_TiposPago) REFERENCES Tipos_Pagos(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Detalle de la facturas
CREATE TABLE `Detalle_Factura`(
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Cantidad` DOUBLE NOT NULL,
	`Descripcion` VARCHAR(200) NOT NULL,
	`ID_Factura` INT NOT NULL,
	`ID_Producto` INT NOT NULL,
	CONSTRAINT Detalle_Facturapk PRIMARY KEY(ID),
	CONSTRAINT Detalle_Facturafk1 FOREIGN KEY(ID_Factura) REFERENCES Facturas(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT Detalle_Facturafk2 FOREIGN KEY(ID_Producto) REFERENCES Productos(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE `Facturas_Anuladas`(
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Descripcion` VARCHAR(400) DEFAULT NULL,
	`ID_Factura` INT NOT NULL,
	CONSTRAINT Facturas_Anuladaspk PRIMARY KEY(ID),
	CONSTRAINT Facturas_Anuladasfk1 FOREIGN KEY(ID_Factura) REFERENCES Facturas(ID) ON UPDATE CASCADE ON DELETE CASCADE		
);

-- TABLA Devoluciones
CREATE TABLE `Devoluciones`(
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Fecha` DATETIME NOT NULL,
	`Descripcion` VARCHAR(200),
	`ID_Factura` INT NOT NULL,
	CONSTRAINT Devolucionespk PRIMARY KEY(ID),
	CONSTRAINT Devolucionesfk1 FOREIGN KEY(ID_Factura) REFERENCES Facturas(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Detalles de la devolución
CREATE TABLE `Detalle_Devolucion`(
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Cantidad` DOUBLE NOT NULL,
	`ID_Devolucion` INT NOT NULL,
	`ID_Producto` INT NOT NULL,
	CONSTRAINT Detalle_Devolucionpk PRIMARY KEY(ID),
	CONSTRAINT Detalle_Devolucionfk1 FOREIGN KEY(ID_Devolucion) REFERENCES Devoluciones(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT Detalle_Devolucionfk2 FOREIGN KEY(ID_Producto) REFERENCES Productos(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Crédito
CREATE TABLE `Credito` (
	`ID` INT NOT NULL AUTO_INCREMENT,
	`DiaDeCredito` DATE NOT NULL,
	`DiaDeVencimiento` DATE NOT NULL,
	`Cargo` DOUBLE DEFAULT NULL,
	`Estado` VARCHAR(10) DEFAULT NULL,
	`Descripcion` VARCHAR(400) DEFAULT NULL,
	`ID_Factura` INT NOT NULL,
	`ID_Cliente` INT NOT NULL,
	CONSTRAINT Creditopk PRIMARY KEY(ID),
	CONSTRAINT Creditofk1 FOREIGN KEY(ID_Factura) REFERENCES Facturas(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT Creditofk2 FOREIGN KEY(ID_Cliente) REFERENCES Clientes(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Abono
CREATE TABLE `Abono` (
	`ID` INT NOT NULL AUTO_INCREMENT,
	`Fecha` DATETIME NOT NULL,
	`Monto` DOUBLE NOT NULL,
	`Saldo_Anterior` DOUBLE DEFAULT NULL,
	`Saldo_Nuevo` DOUBLE DEFAULT NULL,
	`Descripcion` VARCHAR(400) DEFAULT NULL,
	`ID_Credito` INT NOT NULL,
	CONSTRAINT Abonopk PRIMARY KEY(ID),
	CONSTRAINT Abonofk FOREIGN KEY(ID_Credito) REFERENCES Credito(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLA Información general
CREATE TABLE `InfoGeneral` (
	`IDinfogeneral` INT NOT NULL AUTO_INCREMENT,
	`Nombre_negocio` VARCHAR(100) DEFAULT NULL,
	`Direccion_negocio` VARCHAR(100) DEFAULT NULL,
	`Num_ruc` VARCHAR(45) DEFAULT NULL,
	`Nombre_admin` VARCHAR(45) DEFAULT NULL,
	`Telefono` VARCHAR(20) DEFAULT NULL,
	PRIMARY KEY (`IDinfogeneral`)
);

-- TABLA Logs
CREATE TABLE `Logs` (
	`IDlogs` INT NOT NULL AUTO_INCREMENT,
    `Fecha` DATETIME,
	`Descripcion` VARCHAR(200) DEFAULT NULL,
	PRIMARY KEY (`IDlogs`)
);

-- TABLA de Servicios
CREATE TABLE Servicios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    NombreServicio VARCHAR(255) NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME,
    Precio DECIMAL(10, 2) NOT NULL,
    Notas TEXT
);



-- ---------------------------------------------------------------- Insertar datos iniciales ----------------------------------------------------------------

-- Insertar Tipos de usuarios
INSERT INTO Tipo_Usuarios VALUES(NULL, 'Administrador');
INSERT INTO Tipo_Usuarios VALUES(NULL, 'Empleado');

-- Insertar Usuarios
INSERT INTO Usuarios VALUES (NULL,'Administrador','admin','05fe7461c607c33229772d402505601016a7d0ea',1);

-- Insertar Cliente generico 
INSERT INTO Clientes VALUES (NULL, 'Cliente generico', NULL, NULL, NULL);

-- Insetar Entradas
INSERT INTO Tipos_Entradas VALUES (NULL, 'Compra de productos');
INSERT INTO Tipos_Entradas VALUES (NULL, 'Remision de entrada');

-- Insetar Tipos de pagos
INSERT INTO Tipos_Pagos VALUES (NULL, 'Dolares');
INSERT INTO Tipos_Pagos VALUES (NULL, 'Cordobas');
INSERT INTO Tipos_Pagos VALUES (NULL, 'Transferencia');
INSERT INTO Tipos_Pagos VALUES (NULL, 'Cheque');

-- ---------------------------------------------------------------- Procedimientos de Usuarios ----------------------------------------------------------------

-- Al borrar un usuario pasar sus facturas al Administrador
DELIMITER //

CREATE PROCEDURE EliminarUsuario(_ID INT) 
BEGIN
    -- Actualizar las facturas relacionadas al usuario que se eliminará
    UPDATE Facturas SET ID_Usuario = 1 WHERE ID_Usuario = _ID;

    -- Eliminar al usuario
    DELETE FROM Usuarios WHERE ID = _ID;
END //

DELIMITER ;

-- ---------------------------------------------------------------- Procedimientos de Cliente ----------------------------------------------------------------

-- Al borrar un cliente pasar sus facturas al Administrador
DELIMITER //

CREATE PROCEDURE Eliminarcliente(_ID INT) 
BEGIN
    -- Actualizar las facturas relacionadas al usuario que se eliminará
    UPDATE Facturas SET ID_Cliente = 1 WHERE ID_Cliente = _ID;

    -- Eliminar al usuario
    DELETE FROM Clientes WHERE ID = _ID;
END //

DELIMITER ;

-- ---------------------------------------------------------------- Procedimientos de Productos ----------------------------------------------------------------

-- Insertar Producto
DELIMITER //
CREATE PROCEDURE Insertar_Producto(
    _Codigo VARCHAR(45),
    _Nombre VARCHAR(300),
    _Existencias DOUBLE,
    _Existencias_Min DOUBLE,
    _Precio_Compra DOUBLE,
    _Precio_Venta DOUBLE,
    _Observacion VARCHAR(200),
    _ID_Entrada INT
)
BEGIN
    DECLARE Total DOUBLE;
    DECLARE Aux_IDProducto INT;
    DECLARE Aux_Estado VARCHAR(30);

    -- Ajustar el tamaño de la columna _Nombre según sea necesario
    IF _Existencias = 0 THEN
        SET Aux_Estado = 'No Activo';
    ELSE
        SET Aux_Estado = 'Activo';
    END IF;

    -- Ajustar la precisión del tipo de dato
    SET Total = ROUND(_Precio_Compra * _Existencias, 2);

    -- Insertar datos en la tabla Productos
    INSERT INTO Productos (Codigo, Nombre, Estado, Existencias, Existencias_Minimas, Precio_Compra, Precio_Venta, Precio_Total, Observacion, ID_Entrada)
    VALUES(_Codigo, _Nombre, Aux_Estado, _Existencias, _Existencias_Min , _Precio_Compra, _Precio_Venta, Total, _Observacion, _ID_Entrada);

END //
DELIMITER ;


-- Actualizar Producto
DELIMITER //
CREATE PROCEDURE Actualizar_Producto(
    IN _ID_Producto INT,
    IN _Nombre_Producto VARCHAR(300),
    IN _Estado VARCHAR(50),
    IN _Existencias DOUBLE,
    IN _Existencias_Min DOUBLE,
    IN _Precio_Compra DOUBLE,
    IN _Precio_Venta DOUBLE,
    IN _Observacion VARCHAR(200)
)
BEGIN
    DECLARE Total DOUBLE;
    DECLARE Aux_PrecioCompra DOUBLE;
    DECLARE Aux_Existencias DOUBLE;

    -- Obtener el precio de compra actual del producto
    SELECT Precio_Compra INTO Aux_PrecioCompra FROM Productos WHERE ID = _ID_Producto;

    -- Verificar si el nuevo precio de compra es diferente al precio anterior
    IF Aux_PrecioCompra != _Precio_Compra THEN
        -- Insertar un registro en el historial de precios
        INSERT INTO Historial_Precio (ID_Producto, Precio_Antiguo, Precio_Nuevo, Descripcion, Fecha_Cambio) VALUES (_ID_Producto, Aux_PrecioCompra, _Precio_Compra, CONCAT('Se ha cambiado el precio del producto'), NOW());
    END IF;

    -- Actualizar los detalles del producto
    UPDATE Productos 
    SET 
        Estado = _Estado, 
        Nombre = _Nombre_Producto,
		Existencias = Existencias + _Existencias,
        Existencias_Minimas = _Existencias_Min, 
        Precio_Compra = _Precio_Compra, 
        Precio_Venta = _Precio_Venta, 
        Observacion = _Observacion 
    WHERE ID = _ID_Producto;

	SELECT Existencias INTO Aux_Existencias FROM Productos WHERE ID = _ID_Producto;
    -- Calcular el nuevo valor para Precio_Total
    SET Total = ROUND(_Precio_Compra * Aux_Existencias, 2);

    -- Actualizar el Precio_Total y Existencias
    UPDATE Productos SET 
        Precio_Total = Total -- Cambiado aquí
    WHERE ID = _ID_Producto;
    
END //
DELIMITER ;


-- Verficar si existe el codigo en la base de datos
DELIMITER //
	CREATE PROCEDURE EvaluacionCodigo( _Codigo VARCHAR(45)) 
	BEGIN
		DECLARE datoExistente INT;
		DECLARE Aux_Cod VARCHAR(45);

		-- Verificar si el dato existe en la tabla
		SELECT COUNT(*) INTO datoExistente FROM Productos WHERE Codigo = _Codigo;

		-- Comprobar el resultado
		IF datoExistente = 0 THEN
			SELECT 'No existe' AS mensaje; 
		ELSE 
			SELECT 'Existe' AS mensaje; 
		END IF;
	END //
DELIMITER ;

-- ------------------------------------------------------------ Procedimientos de remisión de productos------------------------------------------------------------

-- Insertar Remisión
DELIMITER //
CREATE PROCEDURE Realizar_Remision(
    IN _Descripcion VARCHAR(200),
    IN _Tipo_Remision VARCHAR(200),
	IN _ID_Usuario INT
)
BEGIN
    -- Insertar en la tabla Remisiones
    INSERT INTO Remisiones (Descripcion, Fecha, ID_Usuario, Tipo_Remision) VALUES (_Descripcion, NOW(), _ID_Usuario, _Tipo_Remision);
END //
DELIMITER ;


-- Realizar remisiones de entrada de productos
DELIMITER //
CREATE PROCEDURE Detalle_RemisionEntrada(
    IN _ID_Producto INT,
    IN _Codigo_Producto VARCHAR(45),
    IN _Nombre_Producto VARCHAR(100),
    IN _Cantidad DOUBLE,
    IN _Existencias_Min DOUBLE,
    IN _Precio_Compra DOUBLE,
    IN _Precio_Venta DOUBLE,
    IN _Observacion VARCHAR(200),
    IN _ID_Remision INT
)
BEGIN
    DECLARE Aux_IDProducto INT;

    -- Verificar si el dato ya existe en la tabla Productos
    SELECT ID INTO Aux_IDProducto FROM Productos WHERE ID = _ID_Producto;

    -- Comprobar el resultado
    IF Aux_IDProducto != 0 THEN
        CALL Actualizar_Producto(_ID_Producto, _Nombre_Producto, 'Activo', _Cantidad, _Existencias_Min, _Precio_Compra, _Precio_Venta, _Observacion);
    ELSE
        CALL Insertar_Producto(_Codigo_Producto, _Nombre_Producto, _Cantidad, _Existencias_Min, _Precio_Compra, _Precio_Venta, _Observacion, 2);
        -- Obtener el ID del último producto insertado
       SET Aux_IDProducto = LAST_INSERT_ID();
    END IF;

    -- Insertar en la tabla Detalle_Remisiones
    INSERT INTO Detalle_Remision (Cantidad, ID_Remision, ID_Producto)
    VALUES (_Cantidad, _ID_Remision, Aux_IDProducto);
    
    INSERT INTO HistorialTransacciones VALUES (NULL, 'Remision de entrada', NOW(), CONCAT('Se ha hecho una transacción de entrada de productos mediante una remisión de entrada de ', _Cantidad, ' ', _Nombre_Producto));
END //
DELIMITER ;


-- Realizar remisiones de salidas de productos
DELIMITER //
CREATE PROCEDURE Detalle_RemisionSalida(
    IN _ID_Producto INT,
    IN _Nombre_Producto VARCHAR(100),
    IN _Cantidad DOUBLE,
    IN _ID_Remision INT
)
BEGIN
		DECLARE productoExistencias INT;
		DECLARE Aux_ID_DetalleFactura INT;
 
		-- Iniciar una transacción
		START TRANSACTION;

		-- Obtener existencias actuales del producto
		SELECT Existencias INTO productoExistencias FROM Productos WHERE ID = _ID_Producto;

		-- Verificar si hay suficientes existencias para la venta
		IF productoExistencias >= _Cantidad THEN
			-- Registrar la venta en Detalle_Factura
			
			INSERT INTO Detalle_Remision (Cantidad, ID_Remision, ID_Producto) VALUES (_Cantidad, _ID_Remision, _ID_Producto);

			INSERT INTO HistorialTransacciones VALUES (NULL, 'Remision de salida', NOW(), CONCAT('Se ha hecho una transacción de salida de productos mediante una remisión de salida de ', _Cantidad, ' ', _Nombre_Producto));
			
			-- Actualizar existencias y precio total
			UPDATE Productos SET Existencias = Existencias - _Cantidad WHERE ID = _ID_Producto;
			UPDATE Productos SET Precio_Total =  (Precio_Compra * Existencias) WHERE ID = _ID_Producto;

			-- Verificar si las existencias se han agotado
			IF (productoExistencias - _Cantidad) = 0 THEN
				UPDATE Productos SET Estado = 'No activo' WHERE ID = _ID_Producto;
			END IF;

			-- Confirmar la transacción
			COMMIT;
		ELSE
			-- Si no hay suficientes existencias, revertir la transacción
			ROLLBACK;
			SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'No hay suficientes existencias para esta venta.';
		END IF;
	END //
DELIMITER ;


-- ------------------------------------------------------------ Procedimientos de compras de productos------------------------------------------------------------

-- Realizar nueva compra
DELIMITER //
CREATE PROCEDURE Realizar_Compra(
    IN _Nombre_Vendedor VARCHAR(200),
    IN _Subtotal DOUBLE,
    IN _Descuento DOUBLE,
    IN _IVA DOUBLE,
    IN _Descripcion VARCHAR(200),
    IN _Estado VARCHAR(50),
    IN _ID_Usuario INT,
    IN _ID_Proveedor INT,
    IN _ID_TipoPagos INT
)
BEGIN
    DECLARE SubtotalConIVA DOUBLE;
    DECLARE Total DOUBLE;

    -- Calcular el Subtotal con IVA si el IVA es mayor que 0
    IF _IVA > 0 THEN
        SET SubtotalConIVA = _Subtotal + (_Subtotal * (_IVA / 100));
    ELSE
        SET SubtotalConIVA = _Subtotal;
    END IF;

    -- Calcular el Total con Descuento si el Descuento es mayor que 0
    IF _Descuento > 0 THEN
        SET Total = SubtotalConIVA - (SubtotalConIVA * (_Descuento / 100));
    ELSE
        SET Total = SubtotalConIVA;
    END IF;

    -- Insertar la compra en la tabla Compras
    INSERT INTO Compras (Fecha, Nombre_Vendedor, Descripcion, Estado, Subtotal,  Descuento, IVA, Total_Final, ID_Usuario, ID_Proveedor, ID_TiposPago) VALUES (NOW(), _Nombre_Vendedor,  _Descripcion, _Estado, _Subtotal,  _Descuento,  _IVA, Total, _ID_Usuario, _ID_Proveedor, _ID_TipoPagos);
END //
DELIMITER ;


-- Actualizar el proveedor de los productos de remisión
DELIMITER //
CREATE PROCEDURE CambiarProveedorProducto(
    IN _ID_Producto INT,
	IN _Cantidad DOUBLE,
	IN _ID_Proveedor INT,
	IN _ID_Compra INT
)
BEGIN
	DECLARE Aux_NombreProducto VARCHAR(200);
	DECLARE Aux_NombreProveedor VARCHAR(200);

    SELECT Nombre INTO Aux_NombreProducto FROM Productos WHERE ID = _ID_Producto;
    SELECT Nombre INTO Aux_NombreProveedor FROM Proveedor WHERE ID = _ID_Proveedor;
	
	UPDATE Productos SET ID_Entrada = 1 WHERE ID = _ID_Producto;
	
    INSERT INTO Detalle_Compra (Cantidad, ID_Compra, ID_Producto) VALUES (_Cantidad, _ID_Compra, _ID_Producto);
	INSERT INTO HistorialTransacciones VALUES (NULL, 'Cambio a proveedor', NOW(), CONCAT('Se ha hecho un cambio al proveedor ', Aux_NombreProveedor, ' de ', _Cantidad, '  ', Aux_NombreProducto));
END //
DELIMITER ;


-- Comprar detalle compra e insertar productos
DELIMITER //
CREATE PROCEDURE Productos_Comprados(
    IN _ID_Producto INT,
    IN _Codigo_Producto VARCHAR(45),
    IN _Nombre_Producto VARCHAR(100),
    IN _Cantidad DOUBLE,
    IN _Existencias_Min DOUBLE,
    IN _Precio_Compra DOUBLE,
    IN _Precio_Venta DOUBLE,
    IN _Observacion VARCHAR(200),
	IN _ID_Compra INT
)
BEGIN
    DECLARE Aux_IDProducto INT;

    -- Verificar si el producto ya existe en la tabla Productos
    SELECT ID INTO Aux_IDProducto FROM Productos WHERE ID = _ID_Producto;

    -- Comprobar el resultado
    IF Aux_IDProducto IS NOT NULL THEN
        -- Si el producto existe, actualizarlo
		CALL Actualizar_Producto(_ID_Producto, _Nombre_Producto, 'Activo', _Cantidad, _Existencias_Min, _Precio_Compra, _Precio_Venta, _Observacion);
    ELSE
        -- Si el producto no existe, insertarlo
        CALL Insertar_Producto(_Codigo_Producto, _Nombre_Producto, _Cantidad, _Existencias_Min, _Precio_Compra, _Precio_Venta, _Observacion, 1);
        -- Obtener el ID del producto recién insertado
        SET Aux_IDProducto = LAST_INSERT_ID();
    END IF;

    -- Insertar en la tabla Detalle_Compra
    INSERT INTO Detalle_Compra (Cantidad, ID_Compra, ID_Producto) VALUES (_Cantidad, _ID_Compra, Aux_IDProducto);
	INSERT INTO HistorialTransacciones VALUES (NULL, 'Remision de entrada', NOW(), CONCAT('Se ha hecho una transacción de entrada de productos de mendiante una compra de ', _Cantidad, '  ', _Nombre_Producto));
END //
DELIMITER ;


-- Mostrar el último ID de una compra realizada
DELIMITER //
	CREATE PROCEDURE Mostrar_IDCompra()
	BEGIN
		DECLARE Aux_ID INT;
		SET Aux_ID = CONVERT((SELECT ID FROM Compras ORDER BY ID DESC LIMIT 1), UNSIGNED INT);
		IF (SELECT Aux_ID ) IS NULL THEN 
			SELECT 0;
		ELSE
			SELECT Aux_ID;
		END IF;
	END//
DELIMITER ;


-- ---------------------------------------------------------------- Procedimientos de facturación ----------------------------------------------------------------

-- Trigger para controlar la secuencia del codigo factura
DELIMITER //
	CREATE TRIGGER tr_actualizar_Cod BEFORE INSERT ON Facturas
	FOR EACH ROW
	BEGIN
  		DECLARE max_secuencia INT;
  		SET max_secuencia = (SELECT MAX(Codigo_Fac) FROM Facturas);

		IF max_secuencia IS NULL THEN
			SET NEW.Codigo_Fac = 1;
  		ELSE
    			SET NEW.Codigo_Fac = max_secuencia + 1;
  		END IF;
	END//
DELIMITER ;

-- Facturación al contado Final 
DELIMITER //
CREATE PROCEDURE Facturacion_Final(
    IN _Estado VARCHAR(50),
    IN _Descuento DOUBLE,
    IN _Subtotal DOUBLE,
    IN _Efectivo DOUBLE,
    IN _Debe DOUBLE,
    IN _TipoFactura VARCHAR(50), 
	IN _Referencia VARCHAR(300),
	IN _Fecha DATETIME, 
    IN _ID_Usuario INT,
    IN _ID_Cliente INT,
    IN _ID_TipoPagos INT
)
BEGIN
    DECLARE Total DOUBLE;
    DECLARE Vuelto DOUBLE;

    IF (_TipoFactura = 'Al contado') THEN
        IF (_Descuento = 0.00) THEN
                SET Total = _Subtotal;
         ELSE
             SET Total = _Subtotal - _Descuento;
         END IF;
        SET Vuelto = _Efectivo - Total;
    ELSE
        SET Total = _Subtotal;        
        SET Vuelto = 0.00;
    END IF;
        
    INSERT INTO Facturas (Estado, Fecha, Descuento, Subtotal, Total_Final, Efectivo, Devolucion, Debe, Tipo_Factura, Referencia, ID_Usuario, ID_Cliente, ID_TiposPago) VALUES(_Estado, _Fecha, _Descuento, _Subtotal, Total, _Efectivo, Vuelto, _Debe, _TipoFactura, _Referencia, _ID_Usuario, _ID_Cliente, _ID_TipoPagos);
END //
DELIMITER ;

-- Facturación de los prodcutos con el ID de la factura
DELIMITER //
CREATE PROCEDURE Facturar_Productos(
    IN _Cantidad DOUBLE,
	IN _Descripcion VARCHAR(200),
    IN _ID_Factura INT,
    IN _ID_Producto INT
)
BEGIN
    DECLARE productoExistencias DOUBLE;
    DECLARE Aux_ID_DetalleFactura INT;
	DECLARE Aux_NombreProducto VARCHAR(100);
 
    -- Iniciar una transacción
    START TRANSACTION;

    -- Obtener existencias actuales del producto
    SELECT Existencias INTO productoExistencias FROM Productos WHERE ID = _ID_Producto;
	SELECT Nombre INTO Aux_NombreProducto FROM Productos WHERE ID = _ID_Producto;

    -- Verificar si hay suficientes existencias para la venta
    IF productoExistencias >= _Cantidad THEN
        -- Registrar la venta en Detalle_Factura
        INSERT INTO Detalle_Factura (Cantidad, Descripcion, ID_Factura, ID_Producto) VALUES (_Cantidad, _Descripcion, _ID_Factura, _ID_Producto);
		SET Aux_ID_DetalleFactura = LAST_INSERT_ID();
		
        -- Actualizar existencias y precio total
        UPDATE Productos SET Existencias = (Existencias - _Cantidad) WHERE ID = _ID_Producto;
		UPDATE Productos SET Precio_Total =  (Precio_Compra * Existencias) WHERE ID = _ID_Producto;
		
        -- Verificar si las existencias se han agotado
        IF (productoExistencias - _Cantidad) = 0 THEN
            UPDATE Productos SET Estado = 'No activo' WHERE ID = _ID_Producto;
        END IF;
	
		INSERT INTO HistorialTransacciones VALUES (NULL, 'Facturacion', NOW(), CONCAT('Se ha hecho una transacción de salida de productos de mendiante una facturacion de ', _Cantidad, '  ', Aux_NombreProducto));
			
        -- Confirmar la transacción
        COMMIT;
    ELSE
        -- Si no hay suficientes existencias, revertir la transacción
        ROLLBACK;
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'No hay suficientes existencias para esta venta.';
    END IF;
END //
DELIMITER ;

-- Mostrar el código de la última factura realizada
DELIMITER //
	CREATE PROCEDURE Mostrar_Cod()
	BEGIN
		DECLARE Aux_Cod INT;
		SET Aux_Cod = CONVERT((SELECT Codigo_Fac FROM Facturas ORDER BY Codigo_Fac DESC LIMIT 1), UNSIGNED INT);
		IF (SELECT Aux_Cod) IS NULL THEN 
			SELECT CONCAT('FAC-', LPAD(1, 2, '0'));
		ELSE
			SELECT CONCAT('FAC-', LPAD((Aux_Cod + 1), 2, '0'));
		END IF;
	END//
DELIMITER ;

-- Mostrar el último ID de una factura realizada
DELIMITER //
	CREATE PROCEDURE Mostrar_ID()
	BEGIN
		DECLARE Aux_ID INT;
		SET Aux_ID = CONVERT((SELECT ID FROM Facturas ORDER BY ID DESC LIMIT 1), UNSIGNED INT);
		IF (SELECT Aux_ID ) IS NULL THEN 
			SELECT 0;
		ELSE
			SELECT Aux_ID;
		END IF;
	END//
DELIMITER ;

-- Anular una factura
DELIMITER //
CREATE PROCEDURE Anular_Factura(
    IN _Cantidad DOUBLE,
    IN _ID_Producto INT,
    IN _ID_Factura INT
)
	BEGIN
		DECLARE Total_Prod DOUBLE;
		DECLARE Aux_Precio DOUBLE;

		-- Iniciar una transacción
		START TRANSACTION;
		SELECT Precio_Compra INTO Aux_Precio FROM Productos WHERE ID = _ID_Producto;

		-- Calcular el Total_Producto
		SET Total_Prod =  Aux_Precio * _Cantidad;

		-- Actualizar Cantidad y Total en Detalle_Factura
		UPDATE Detalle_Factura SET Cantidad = Cantidad - _Cantidad WHERE ID_Factura = _ID_Factura AND ID_Producto = _ID_Producto;
		
		-- Confirmar la transacción
		COMMIT;
	END //
DELIMITER ;

-- Actualizar factura anulada
DELIMITER //
	CREATE PROCEDURE Actualizar_FacturaAnulada(_Desc VARCHAR(200), _ID_Factura INT)
	BEGIN
		UPDATE Facturas SET 
			Estado = 'Anulada', 
			Descuento = 0.00, 
			Subtotal = 0.00, 
			Total_Final = 0.00,
			Efectivo = 0.00,
			Debe = 0.00,
			Devolucion = 0.00,
			Tipo_Factura = '--' WHERE ID = _ID_Factura;

			INSERT INTO Facturas_Anuladas VALUES(NULL, _Desc, _ID_Factura);

			IF (SELECT ID FROM Credito WHERE ID_Factura = _ID_Factura) IS NOT NULL THEN
				DELETE FROM Credito WHERE ID_Factura = _ID_Factura;
			END IF;

			DELETE FROM Detalle_Factura WHERE ID_Factura = _ID_Factura;
	END//
DELIMITER ;


-- ---------------------------------------------------------------- Procedimientos de devoluciones ----------------------------------------------------------------

-- Agregar una devolución
DELIMITER //
CREATE PROCEDURE Agregar_Devolucion(_Desc VARCHAR(200), _ID_Factura INT)
BEGIN
    -- Verificar si la factura con _ID_Factura existe
    IF (SELECT COUNT(*) FROM Facturas WHERE ID = _ID_Factura) > 0 THEN
        INSERT INTO Devoluciones VALUES(NULL, NOW(), _Desc, _ID_Factura);
    ELSE
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La factura especificada no existe.';
    END IF;
END //
DELIMITER ;

-- Devolución de los prodcutos con el ID de la factura 
DELIMITER //
	CREATE PROCEDURE Devolver_Productos(
		IN _Cantidad DOUBLE,
		IN _ID_Devolucion INT,
		IN _ID_Producto INT,
		IN _ID_Factura INT
	)
	BEGIN
		DECLARE Total_Prod DOUBLE;
		DECLARE Aux_Precio DOUBLE;
		DECLARE Aux_ID_Devolucion INT;
		DECLARE Aux_NombreProducto VARCHAR(200);

		-- Verificar si existe la devolución con el ID proporcionado
		SELECT ID INTO Aux_ID_Devolucion FROM Devoluciones WHERE ID = _ID_Devolucion;

		-- Verificar si hay una relación válida con la devolución y la factura
		IF Aux_ID_Devolucion IS NOT NULL AND (SELECT COUNT(*) FROM Detalle_Factura WHERE ID_Factura = _ID_Factura AND ID_Producto = _ID_Producto) > 0 THEN
			-- Iniciar una transacción
			START TRANSACTION;

			-- Obtener el precio de compra del producto
			SELECT Precio_Compra INTO Aux_Precio FROM Productos WHERE ID = _ID_Producto;
			SELECT Nombre INTO Aux_NombreProducto FROM Productos WHERE ID = _ID_Producto;

			-- Calcular el Total_Producto
			SET Total_Prod = Aux_Precio * _Cantidad;

			-- Insertar en Detalle_Devolucion
			INSERT INTO Detalle_Devolucion (Cantidad, ID_Devolucion, ID_Producto) VALUES (_Cantidad, _ID_Devolucion, _ID_Producto);

			-- Actualizar existencias, precio total y estado en Productos
			UPDATE Productos
			SET Existencias = Existencias + _Cantidad, Precio_Total = Precio_Total + Total_Prod, Estado = 'Activo'
			WHERE ID = _ID_Producto;

			-- Actualizar Detalle_Factura
			UPDATE Detalle_Factura SET Cantidad = Cantidad - _Cantidad WHERE ID_Producto = _ID_Producto AND ID_Factura = _ID_Factura;
			
			INSERT INTO HistorialTransacciones VALUES (NULL, 'Devolucion', NOW(), CONCAT('Se ha hecho una transacción de entrada de productos de mendiante una devolución de ', _Cantidad, '  ', Aux_NombreProducto));

			-- Confirmar la transacción
			COMMIT;
		ELSE
			-- Si no hay una devolución válida relacionada o la factura no existe
			ROLLBACK;
			SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'No hay relación válida con esa devolución o la factura no existe.';
		END IF;
	END //
DELIMITER ;

-- Actualizar los campos de la factura final
DELIMITER //
CREATE PROCEDURE Actualizar_facturacion(_ID_Devolucion INT, _ID_Factura INT)
BEGIN
    DECLARE Aux_Total DOUBLE;

    -- Verificar si la devolución está relacionada con la factura _ID_Factura
    SELECT SUM(a.Precio_Venta * b.Cantidad) INTO Aux_Total
    FROM Productos a
    INNER JOIN Detalle_Devolucion b ON a.ID = b.ID_Producto
    INNER JOIN Devoluciones c ON b.ID_Devolucion = c.ID
    WHERE c.ID = _ID_Devolucion AND c.ID_Factura = _ID_Factura;

    IF Aux_Total IS NOT NULL THEN
        -- Actualizar los valores en la factura
        UPDATE Facturas
        SET
            Subtotal = Subtotal - Aux_Total,
            Total_Final = Total_Final - Aux_Total
        WHERE ID = _ID_Factura;

        -- Calcular la Devolución y actualizar la Devolución en la factura
        UPDATE Facturas
        SET Devolucion =  Efectivo - Total_Final
        WHERE ID = _ID_Factura;
    ELSE
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La devolución no está relacionada con la factura especificada.';
    END IF;
END //
DELIMITER ;

-- Verificar si se realizó una devolución en una factura 
DELIMITER //
CREATE PROCEDURE Verificar_Devolucion(_ID_Factura INT)
BEGIN
    DECLARE Aux INT;

    -- Verificar si existe una devolución para la factura especificada
    SELECT COUNT(*) INTO Aux FROM Devoluciones WHERE ID_Factura = _ID_Factura;

    -- Devolver 1 si hay una devolución, 0 si no la hay
    SELECT IF(Aux > 0, 1, 0) AS Resultado;
END //
DELIMITER ;

-- ---------------------------------------------------------------- Procedimientos de Créditos y abonos ---------------------------------------------------------------

-- Agregar crédito
DELIMITER //
	CREATE PROCEDURE Agregar_Credito(
		IN _DiaDeInicio DATE,
		IN _DiaDeVencimiento DATE,
		IN _Cargo DOUBLE,
		IN _Estado VARCHAR(50),
		IN _Desc VARCHAR(400),
		IN _ID_Factura INT,
		IN _ID_Cliente INT,
		IN _ID_TipoPagos INT
	)
	BEGIN
		-- Actualizar el tipo de pago en la factura
		UPDATE Facturas SET ID_TiposPago = _ID_TipoPagos WHERE ID = _ID_Factura;

		-- Insertar información de crédito
		INSERT INTO Credito (DiaDeCredito, DiaDeVencimiento, Cargo, Estado, Descripcion, ID_Factura, ID_Cliente)
		VALUES (_DiaDeInicio, _DiaDeVencimiento, _Cargo, _Estado, _Desc, _ID_Factura, _ID_Cliente);
		
		-- Comprobar si se ha insertado correctamente el crédito
		IF (SELECT ROW_COUNT()) > 0 THEN
			SELECT 'Crédito agregado con éxito.';
		ELSE
			SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'Error al agregar el crédito.';
		END IF;
	END //
DELIMITER ;


-- Realizar Abono
DELIMITER //
	CREATE PROCEDURE Realziar_Abono(
		IN _Monto DOUBLE,
		IN _Saldo_ante DOUBLE,
		IN _Saldo_nuevo DOUBLE,
		IN _Desc VARCHAR(100),
		IN _ID_Credito INT,
		IN _ID_Factura INT
	)
	BEGIN
		-- Insertar el registro de abono
		INSERT INTO Abono (Fecha, Monto, Saldo_Anterior, Saldo_Nuevo, Descripcion, ID_Credito)  VALUES (NOW(), _Monto, _Saldo_ante, _Saldo_nuevo, _Desc, _ID_Credito);

		-- Actualizar el saldo y efectivo en la factura
		UPDATE Facturas SET Debe = Debe - _Monto, Efectivo = Efectivo + _Monto WHERE ID = _ID_Factura;
		
		-- Comprobar si se ha insertado correctamente el abono
		IF (SELECT ROW_COUNT()) > 0 THEN
			SELECT 'Abono realizado con éxito.';
		ELSE
			SIGNAL SQLSTATE '45000'
			SET MESSAGE_TEXT = 'Error al realizar el abono.';
		END IF;
	END //
DELIMITER ;

-- Cuando el saldo sea 0.00 actualizar a "Cancelado" la factura al crédito
DELIMITER //
	CREATE PROCEDURE Actualizar_FacturaCredito(
		IN _ID_Credito INT, 
		IN _ID_Factura INT
	)
	BEGIN
		DECLARE Aux_Saldo_nuevo INT;
		
		-- Obtener el saldo nuevo más reciente del crédito
		SELECT Saldo_Nuevo INTO Aux_Saldo_nuevo
		FROM Abono 
		WHERE ID_Credito = _ID_Credito 
		ORDER BY ID DESC 
		LIMIT 1;
		
		IF Aux_Saldo_nuevo = 0 THEN
			-- Si el saldo nuevo es 0, marcar la factura y el crédito como "Cancelado"
			UPDATE Facturas SET Estado = 'Cancelado' WHERE ID = _ID_Factura;
			UPDATE Credito SET Estado = 'Cancelado' WHERE ID = _ID_Credito;
			SELECT 1 AS Resultado;
		ELSE
			SELECT 2 AS Resultado;
		END IF;
	END //
DELIMITER ;

-- ------------------------------------------------------------ Consultas realcionado a los productos --------------------------------------------------------------

-- Mostrar todos los productos
CREATE VIEW Mostrar_Producto AS SELECT 
    a.ID, 
    a.Codigo,
    a.Nombre AS 'Producto', 
    a.Estado AS 'Estado', 
    a.Existencias, 
    CONCAT('C$ ', FORMAT(a.Precio_Compra, 2)) AS 'Precio de compra', 
    CONCAT('C$ ', FORMAT(a.Precio_Venta, 2)) AS 'Precio de venta', 
    CONCAT('C$ ', FORMAT(a.Precio_Total, 2)) AS 'Precio total', 
    a.Observacion AS 'Observaciones',
	e.Tipos, 
    CASE WHEN (e.ID) = 1 THEN d.Nombre ELSE e.Tipos END AS 'Tipo de entrada' 
FROM Productos a 
LEFT JOIN Detalle_Compra b ON a.ID = b.ID_Producto 
LEFT JOIN Compras c ON c.ID = b.ID_Compra
LEFT JOIN Proveedor d ON c.ID_Proveedor = d.ID  
INNER JOIN Tipos_Entradas e ON a.ID_Entrada = e.ID 
GROUP BY 
    a.ID, 
    a.Codigo,
    a.Nombre,
    a.Estado,
    a.Existencias, 
    a.Existencias_Minimas,
    CONCAT('C$ ', FORMAT(a.Precio_Compra, 2)),
    CONCAT('C$ ', FORMAT(a.Precio_Venta, 2)),
    CONCAT('C$ ', FORMAT(a.Precio_Total, 2)),
    a.Observacion,
	e.Tipos,
    CASE WHEN (e.ID) = 1 THEN d.Nombre ELSE e.Tipos END
ORDER BY a.ID;

-- Cargar los productos conforme al Proveedor
SELECT 
	a.ID, a.Nombre 
FROM Productos a 
LEFT JOIN Detalle_Compra b ON a.ID = b.ID_Producto 
LEFT  JOIN Compras c ON c.ID = b.ID_Compra
LEFT  JOIN Proveedor d ON c.ID_Proveedor = d.ID WHERE d.ID = 1;

-- Total de capital invertido en productos
SELECT CASE WHEN ROUND(SUM(precio_total), 2) IS NULL THEN '0' ELSE CONCAT('C$ ', FORMAT(ROUND(SUM(precio_total), 2), 2)) END AS 'Precio Total' FROM Productos;


-- Cantidad total de los productos
SELECT CASE WHEN COUNT(*) IS NULL THEN '0' ELSE COUNT(*)  END 'Cantidad de productos' FROM productos;

-- Buscar producto por su nombre o por codigo
SELECT * FROM Mostrar_Producto WHERE Producto LIKE '%%' OR Codigo LIKE '%01%';

-- Buscar productos por su nombre o por codigo, dependiendo del Proveedor
SELECT 
    a.ID, a.Nombre 
FROM Productos a 
LEFT JOIN Detalle_Compra b ON a.ID = b.ID_Producto 
LEFT JOIN Compras c ON c.ID = b.ID_Compra
LEFT JOIN Proveedor d ON c.ID_Proveedor = d.ID 
WHERE d.ID = 1 AND (a.Nombre LIKE '% %' OR a.Codigo LIKE '% %');

-- ------------------------------------------------------------ Consultas realcionado a las compras --------------------------------------------------------------

--  Mostrar todas las compras realizadas
SELECT * FROM Compras;

-- Mostrar todas las compras con datos especificos
CREATE VIEW Mostrar_Compras AS
SELECT
    a.ID,
    a.Estado,
    a.Fecha,
    a.Descripcion AS 'Referencia',
    e.Tipos AS 'Tipo de pago',
    COUNT(b.ID) AS 'Cant. Productos Comprados',
    CONCAT('C$ ', FORMAT(a.Subtotal, 2)) AS 'Subtotal',
    CONCAT(a.Descuento, ' %') AS 'Descuento',
    CONCAT(a.IVA, ' %') AS 'IVA',
    CONCAT('C$ ', FORMAT(a.Total_Final, 2)) AS 'Total',
    d.Nombre 'Usuario',
    a.Nombre_Vendedor AS 'Nombre del vendedor',
    c.Nombre 
FROM Compras a 
INNER JOIN Detalle_Compra b ON a.ID = b.ID_Compra 
INNER JOIN Proveedor c ON a.ID_Proveedor = c.ID 
INNER JOIN Usuarios d ON a.ID_Usuario = d.ID 
INNER JOIN Tipos_Pagos e ON a.ID_TiposPago = e.ID 
WHERE a.Nombre_Vendedor != '--'
GROUP BY a.ID
ORDER BY a.ID; 

-- Filtros para la tabla Compras
DELIMITER //
CREATE PROCEDURE FiltrarCompras(
    IN opcion INT,
    IN estadoCompra VARCHAR(100),
    IN idProveedor INT
)
BEGIN
    IF opcion = 1 THEN
        -- Filtrar por Proveedor
        SELECT
            a.ID,
            a.Estado,
            a.Fecha,
            a.Descripcion AS 'Referencia',
            e.Tipos AS 'Tipo de pago',
            COUNT(b.ID) AS 'Cant. Productos Comprados',
            CONCAT('C$ ', FORMAT(a.Subtotal, 2)) AS 'Subtotal',
            CONCAT(a.Descuento, ' %') AS 'Descuento',
            CONCAT(a.IVA, ' %') AS 'IVA',
            CONCAT('C$ ', FORMAT(a.Total_Final, 2)) AS 'Total',
            d.Nombre 'Usuario',
            a.Nombre_Vendedor AS 'Nombre del vendedor',
            c.Nombre
        FROM Compras a
        INNER JOIN Detalle_Compra b ON a.ID = b.ID_Compra
        INNER JOIN Proveedor c ON a.ID_Proveedor = c.ID
        INNER JOIN Usuarios d ON a.ID_Usuario = d.ID
        INNER JOIN Tipos_Pagos e ON a.ID_TiposPago = e.ID
        WHERE c.ID = idProveedor AND a.Nombre_Vendedor != '--'
        GROUP BY a.ID
        ORDER BY a.ID;
        
    ELSEIF opcion = 2 THEN
        -- Filtrar por Estado
        SELECT
            a.ID,
            a.Estado,
            a.Fecha,
            a.Descripcion AS 'Referencia',
            e.Tipos AS 'Tipo de pago',
            COUNT(b.ID) AS 'Cant. Productos Comprados',
            CONCAT('C$ ', FORMAT(a.Subtotal, 2)) AS 'Subtotal',
            CONCAT(a.Descuento, ' %') AS 'Descuento',
            CONCAT(a.IVA, ' %') AS 'IVA',
            CONCAT('C$ ', FORMAT(a.Total_Final, 2)) AS 'Total',
            d.Nombre 'Usuario',
            a.Nombre_Vendedor AS 'Nombre del vendedor',
            c.Nombre
        FROM Compras a
        INNER JOIN Detalle_Compra b ON a.ID = b.ID_Compra
        INNER JOIN Proveedor c ON a.ID_Proveedor = c.ID
        INNER JOIN Usuarios d ON a.ID_Usuario = d.ID
        INNER JOIN Tipos_Pagos e ON a.ID_TiposPago = e.ID
        WHERE a.Estado = estadoCompra AND a.Nombre_Vendedor != '--'
        GROUP BY a.ID
        ORDER BY a.ID;
        
    ELSE
        -- Opción no válida
        SELECT 'Opción no válida' AS Resultado;
    END IF;
END //
DELIMITER ;


SELECT
    b.ID AS 'ID',
    c.Codigo AS 'Codigo',
    c.Nombre AS 'Nombre producto',
    c.Precio_Venta AS 'Precio de venta',
    c.Precio_Compra AS 'Precio de compra',
    b.Cantidad AS 'Cant. Productos'
FROM Compras a 
INNER JOIN Detalle_Compra b ON a.ID = b.ID_Compra
INNER JOIN Productos c ON b.ID_Producto = c.ID
WHERE a.ID = 1
ORDER BY b.ID;

-- ------------------------------------------------------------ Consultas realcionada a las remisiones --------------------------------------------------------------

-- Mostrar todas las compras con datos especificos
CREATE VIEW Mostrar_Remisiones AS
SELECT
    a.ID,
    a.Fecha,
    a.Descripcion AS 'Descripcion',
    COUNT(b.ID) AS 'Cant. Productos',
	a.Tipo_Remision AS 'Tipo de remisión',
	c.Nombre AS 'Nombre del empleado'
FROM Remisiones a 
INNER JOIN Detalle_Remision b ON a.ID = b.ID_Remision
INNER JOIN UsuarioS c ON a.ID_Usuario = c.ID
GROUP BY a.ID
ORDER BY a.ID;

-- SELECT * FROM Mostrar_Remisiones WHERE DATE_FORMAT(Fecha, '%Y/%m/%d') BETWEEN '2022/08/23' AND '2022/08/23';

-- Procedures de Filtro
DELIMITER //
CREATE PROCEDURE Filtro_Remisiones(IN OP INT)
BEGIN
    IF OP = 1 THEN
        -- Consulta de Remisiones de Entrada
        SELECT
            a.ID,
            a.Fecha,
            a.Descripcion AS 'Descripcion',
            COUNT(b.ID) AS 'Cant. Productos',
            a.Tipo_Remision AS 'Tipo de remisión',
            c.Nombre AS 'Nombre del empleado'
        FROM Remisiones a 
        INNER JOIN Detalle_Remision b ON a.ID = b.ID_Remision
        INNER JOIN Usuarios c ON a.ID_Usuario = c.ID
        WHERE a.Tipo_Remision = 'Remisión de Entrada'
        GROUP BY a.ID
        ORDER BY a.ID;
    ELSEIF OP = 2 THEN
        -- Consulta de Remisiones de Salida
        SELECT
            a.ID,
            a.Fecha,
            a.Descripcion AS 'Descripcion',
            COUNT(b.ID) AS 'Cant. Productos',
            a.Tipo_Remision AS 'Tipo de remisión',
            c.Nombre AS 'Nombre del empleado'
        FROM Remisiones a 
        INNER JOIN Detalle_Remision b ON a.ID = b.ID_Remision
        INNER JOIN Usuarios c ON a.ID_Usuario = c.ID
        WHERE a.Tipo_Remision = 'Remisión de Salida'
        GROUP BY a.ID
        ORDER BY a.ID;
    ELSE
        -- Opción no válida
        SELECT 'Opción no válida' AS 'Resultado';
    END IF;
END//
DELIMITER ;


SELECT
    b.ID AS 'ID',
    c.Codigo AS 'Codigo',
    c.Nombre AS 'Nombre producto',
    c.Precio_Venta AS 'Precio de venta',
    c.Precio_Compra AS 'Precio de compra',
    b.Cantidad AS 'Cant. Productos',
    a.Tipo_Remision AS 'Tipo de remisión'
FROM Remisiones a 
INNER JOIN Detalle_Remision b ON a.ID = b.ID_Remision
INNER JOIN Productos c ON b.ID_Producto = c.ID
WHERE a.ID = 2
ORDER BY b.ID;

-- ---------------------------------------------------------------- Consultas realcionado al Home -----------------------------------------------------------------

-- Sumar los ingresos obtenidos de una determinada fecha
SELECT CASE WHEN SUM(Total_Final - Debe) IS NULL THEN '0' ELSE SUM(Total_Final - Debe) END AS 'Total ingresado por fecha' FROM Facturas WHERE DATE_FORMAT(fecha, '%Y/%m/%d') = '2023/08/18';

-- Mostrar cantidad de facturas realizar en un día determinado
SELECT COUNT(ID) AS 'Cant. Fact' FROM Facturas WHERE DATE_FORMAT(Fecha, '%Y/%m/%d') = '2022/08/23';

-- Mostrar cantidad de facturas anuladas
-- SELECT COUNT(a.ID) AS 'Cantidad de Facturas Anuladas del Día' FROM Facturas_Anuladas a INNER JOIN Facturas b ON a.ID_Factura = b.ID WHERE DATE(b.Fecha) = CURDATE();

-- Mostrar el Total de todas las facturas
SELECT CASE WHEN SUM(Total_Final - Debe) IS NULL THEN '0.00' ELSE SUM(Total_Final - Debe) END AS 'Total ingresado por fecha' FROM Facturas;

-- Mostrar cantidad de facturas realizar en el día
SELECT COUNT(ID) AS 'Fact. de Hoy' FROM Facturas WHERE DATE_FORMAT(Fecha, '%Y/%m/%d') = DATE_FORMAT(NOW(), '%Y/%m/%d');

-- Total de capital de ventas en el día agrupado por hora
SELECT 
    DATE_FORMAT(Fecha, '%H:00') AS Hora,
    FORMAT(SUM(Total_Final - Debe), 2) AS 'Ganancias'
FROM Facturas
WHERE Fecha >= CURDATE() AND Fecha < CURDATE() + INTERVAL 1 DAY
GROUP BY Hora
ORDER BY Hora;

-- Productos más vendidos en el día
SELECT 
    c.Nombre AS 'Producto', 
    SUM(a.Cantidad) AS 'Cant. Vendida' 
FROM Detalle_Factura a
INNER JOIN Facturas b ON a.ID_Factura = b.ID
INNER JOIN Productos c ON a.ID_Producto = c.ID
WHERE a.Cantidad > 0 AND DATE(b.Fecha) = CURDATE()
GROUP BY c.Nombre  
ORDER BY SUM(a.Cantidad) DESC LIMIT 5;

-- Cuanto se ha ganado en los últimos 7 días
SELECT DATE_FORMAT(Fecha, '%Y-%m-%d'), SUM(Total_Final - Debe) FROM Facturas WHERE DATE_FORMAT(Fecha, '%Y-%m-%d') BETWEEN CURDATE() - INTERVAL 7 DAY AND CURDATE() GROUP BY DATE_FORMAT(Fecha, '%Y-%m-%d');



SELECT DATE_FORMAT(Fecha, '%H:00') AS Hora, 
       CASE 
           WHEN ROUND(SUM(Total_Final - Debe), 2) IS NULL THEN 0.00 
           ELSE FORMAT(ROUND(SUM(Total_Final - Debe), 2), 2) 
       END AS 'Ganancias' 
FROM Facturas 
WHERE Fecha >= CURDATE() AND Fecha < CURDATE() + INTERVAL 1 DAY 
GROUP BY Hora 
ORDER BY Hora;
-- --------------------------------------------------------------- Consultas realcionado a la factura -----------------------------------------------------------------

-- Mostrar facturación con campos especificos
CREATE VIEW Mostrar_Factura AS SELECT
    a.ID AS 'ID',
    CONCAT('FAC-', LPAD(a.Codigo_Fac, 5, '0')) AS 'Codigo',
    a.Estado,
    a.Fecha,
    c.Nombre AS 'Cliente',
    COALESCE(COUNT(b.ID), 0) AS 'Cant. Productos',
    e.Tipos AS 'Tipo de pago',
    CONCAT('C$ ', FORMAT(a.Subtotal, 2)) AS 'Subtotal',
    CONCAT('C$ ', FORMAT(a.Descuento, 2)) AS 'Descuento',
    CONCAT('C$ ', FORMAT(a.Total_Final, 2)) AS 'Total Final',
    CONCAT('C$ ', FORMAT(a.Efectivo, 2)) AS 'Efectivo',
    CONCAT('C$ ', FORMAT(a.Devolucion, 2)) AS 'Devolucion',
    CONCAT('C$ ', FORMAT(a.Debe, 2)) AS 'Debe',
    d.Nombre AS 'Nombre empleado'
FROM Facturas a
INNER JOIN Clientes c ON a.ID_Cliente = c.ID
INNER JOIN Usuarios d ON a.ID_Usuario = d.ID
INNER JOIN Tipos_Pagos e ON a.ID_TiposPago = e.ID
LEFT JOIN Detalle_Factura b ON a.ID = b.ID_Factura
WHERE DATE(a.Fecha) = CURDATE()
GROUP BY a.ID
ORDER BY a.ID;

-- Mostrar todas las facturas sin excepciones
CREATE VIEW Mostrar_TodasFactura AS  SELECT
    a.ID AS 'ID',
    CONCAT('FAC-', LPAD(a.Codigo_Fac, 5, '0')) AS 'Codigo',
    a.Estado,
    a.Fecha,
    c.Nombre AS 'Cliente',
    COALESCE(COUNT(b.ID), 0) AS 'Cant. Productos',
    e.Tipos AS 'Tipo de pago',
    CONCAT('C$ ', FORMAT(a.Subtotal, 2)) AS 'Subtotal',
    CONCAT('C$ ', FORMAT(a.Descuento, 2)) AS 'Descuento',
    CONCAT('C$ ', FORMAT(a.Total_Final, 2)) AS 'Total Final',
    CONCAT('C$ ', FORMAT(a.Efectivo, 2)) AS 'Efectivo',
    CONCAT('C$ ', FORMAT(a.Devolucion, 2)) AS 'Devolucion',
    CONCAT('C$ ', FORMAT(a.Debe, 2)) AS 'Debe',
    d.Nombre AS 'Nombre empleado'
FROM Facturas a
INNER JOIN Clientes c ON a.ID_Cliente = c.ID
INNER JOIN Usuarios d ON a.ID_Usuario = d.ID
INNER JOIN Tipos_Pagos e ON a.ID_TiposPago = e.ID
LEFT JOIN Detalle_Factura b ON a.ID = b.ID_Factura
GROUP BY a.ID
ORDER BY a.ID;

-- Filtros de las facturas
DELIMITER //
CREATE PROCEDURE SeleccionarProcedimiento(
IN opcion INT,
    IN FechaInicio DATE,
    IN FechaFinal DATE,
    IN _NombreCliente VARCHAR(100)
)
BEGIN
    IF opcion = 1 THEN
        -- Mostrar facturación con campos específicos (Rango entre fechas)
	SELECT
            a.ID AS 'ID',
            CONCAT('FAC-', LPAD(a.Codigo_Fac, 5, '0')) AS 'Codigo',
            a.Estado,
            a.Fecha,
            c.Nombre AS 'Cliente',
	    COALESCE(COUNT(b.ID), 0) AS 'Cant. Productos',
            e.Tipos AS 'Tipo de pago',
            CONCAT('C$ ', FORMAT(a.Subtotal, 2)) AS 'Subtotal',
            CONCAT('C$ ', FORMAT(a.Descuento, 2)) AS 'Descuento',
            CONCAT('C$ ', FORMAT(a.Total_Final, 2)) AS 'Total Final',
            CONCAT('C$ ', FORMAT(a.Efectivo, 2)) AS 'Efectivo',
            CONCAT('C$ ', FORMAT(a.Devolucion, 2)) AS 'Devolucion',
            CONCAT('C$ ', FORMAT(a.Debe, 2)) AS 'Debe',
            d.Nombre AS 'Nombre empleado'
        FROM Facturas a
        INNER JOIN Detalle_Factura b ON a.ID = b.ID_Factura
        INNER JOIN Clientes c ON a.ID_Cliente = c.ID
        INNER JOIN Usuarios d ON a.ID_Usuario = d.ID
        INNER JOIN Tipos_Pagos e ON a.ID_TiposPago = e.ID
        WHERE DATE_FORMAT(a.Fecha, '%Y/%m/%d') BETWEEN FechaInicio AND FechaFinal
        GROUP BY a.ID
        ORDER BY a.ID;
    ELSEIF opcion = 2 THEN
        -- Buscar facturas por nombres de cliente
	SELECT
		a.ID AS 'ID',
		CONCAT('FAC-', LPAD(a.Codigo_Fac, 5, '0')) AS 'Codigo',
		a.Estado,
		a.Fecha,
		c.Nombre AS 'Cliente',
		COALESCE(COUNT(b.ID), 0) AS 'Cant. Productos',
		e.Tipos AS 'Tipo de pago',
		CONCAT('C$ ', FORMAT(a.Subtotal, 2)) AS 'Subtotal',
		CONCAT('C$ ', FORMAT(a.Descuento, 2)) AS 'Descuento',
		CONCAT('C$ ', FORMAT(a.Total_Final, 2)) AS 'Total Final',
		CONCAT('C$ ', FORMAT(a.Efectivo, 2)) AS 'Efectivo',
		CONCAT('C$ ', FORMAT(a.Devolucion, 2)) AS 'Devolucion',
		CONCAT('C$ ', FORMAT(a.Debe, 2)) AS 'Debe',
		d.Nombre AS 'Nombre empleado'
	FROM Facturas a
	INNER JOIN Detalle_Factura b ON a.ID = b.ID_Factura
	INNER JOIN Clientes c ON a.ID_Cliente = c.ID
	INNER JOIN Usuarios d ON a.ID_Usuario = d.ID
	INNER JOIN Tipos_Pagos e ON a.ID_TiposPago = e.ID
	WHERE c.Nombre LIKE CONCAT('%', _NombreCliente, '%')
	GROUP BY a.ID
	ORDER BY a.ID;
    ELSE
        -- Opción no válida
        SELECT 'Opción no válida' AS Resultado;
    END IF;
END //
DELIMITER ;

-- Mostrar facturación con campos especificos (Pidiento un mes de referencia)
SELECT * FROM Mostrar_Factura WHERE MONTH(fecha) = 8 GROUP BY ID;

-- Total de facturas canceladas
SELECT CASE WHEN SUM(Total_Final) IS NULL THEN '0' ELSE SUM(Total_Final) END 'Total'  FROM Facturas WHERE Estado = 'Cancelado';
	
-- Total de facturas pendientes
SELECT CASE WHEN SUM(Efectivo) IS NULL THEN '0' ELSE SUM(Efectivo) END 'Total'   FROM Facturas WHERE Estado = 'Pendiente';

-- Mostrar detalles de la factura
SELECT 
	c.Codigo AS 'Codigo', 
	c.Nombre AS 'Nombre', 
	c.Precio_Venta, 
	b.Cantidad,
	(c.Precio_Venta * b.Cantidad) AS 'Total'
FROM Facturas a 
INNER JOIN Detalle_Factura b ON b.ID_Factura = a.ID 
INNER JOIN Productos c ON c.ID = b.ID_Producto WHERE a.ID = 1;


-- ----------------------------------------------------------- Consultas realcionado a las devoluciones -------------------------------------------------------------

-- Mostrar las devoluciones realizadas 
CREATE VIEW Mostrar_Devoluciones AS SELECT
    MAX(a.ID), 
    CONCAT('FAC-', LPAD(d.Codigo_Fac, 5, '0')) AS 'Cod. Factura',
    COUNT(a.ID) AS 'Cant. Devoluciones',
    CONCAT('C$ ', FORMAT(SUM(c.Precio_Venta * b.Cantidad), 2)) AS 'Total Devoluciones',
    MAX(a.Fecha) AS 'Fecha de última Devolución',
    MAX(d.Estado) AS 'Estado',
    MAX(a.Descripcion) AS 'Descripción',
    MAX(e.Nombre) AS 'Cliente',
    MAX(f.Nombre) AS 'Trabajador'
FROM Devoluciones a
INNER JOIN Detalle_Devolucion b ON a.ID = b.ID_Devolucion
INNER JOIN Productos c ON c.ID = b.ID_Producto
INNER JOIN Facturas d ON a.ID_Factura = d.ID
INNER JOIN Clientes e ON d.ID_Cliente = e.ID
INNER JOIN Usuarios f ON d.ID_Usuario = f.ID
GROUP BY d.Codigo_Fac
ORDER BY 'Cod. Factura' ASC;		

-- Filtros para la tabla devoluciones
DELIMITER //
CREATE PROCEDURE ObtenerDevoluciones(
    IN opcion INT,
    IN Fec_Inicio DATETIME,
    IN Fec_Final DATETIME,
    IN _Nombre_Cliente VARCHAR(100),
    IN _Estado VARCHAR(100)
)
BEGIN
    IF opcion = 1 THEN
        -- Mostrar las devoluciones (Rango entre fechas)
         SELECT
    		MAX(a.ID), 
    		CONCAT('FAC-', LPAD(d.Codigo_Fac, 5, '0')) AS 'Cod. Factura',
	    	COUNT(a.ID) AS 'Cant. Devoluciones',
   		CONCAT('C$ ', FORMAT(SUM(c.Precio_Venta * b.Cantidad), 2)) AS 'Total Devoluciones',
  		MAX(a.Fecha) AS 'Fecha de última Devolución',
		MAX(d.Estado) AS 'Estado',
	 	MAX(a.Descripcion) AS 'Descripción',
    		MAX(e.Nombre) AS 'Cliente',
	    	MAX(f.Nombre) AS 'Trabajador'
	FROM Devoluciones a
	INNER JOIN Detalle_Devolucion b ON a.ID = b.ID_Devolucion
	INNER JOIN Productos c ON c.ID = b.ID_Producto
	INNER JOIN Facturas d ON a.ID_Factura = d.ID
	INNER JOIN Clientes e ON d.ID_Cliente = e.ID
	INNER JOIN Usuarios f ON d.ID_Usuario = f.ID
        WHERE DATE_FORMAT(a.Fecha, '%Y/%m/%d') BETWEEN Fec_Inicio AND Fec_Final
        GROUP BY d.Codigo_Fac
	ORDER BY 'Cod. Factura' ASC;
    ELSEIF opcion = 2 THEN
        -- Buscar devolución por nombres de cliente
        SELECT
    		MAX(a.ID), 
    		CONCAT('FAC-', LPAD(d.Codigo_Fac, 5, '0')) AS 'Cod. Factura',
	    	COUNT(a.ID) AS 'Cant. Devoluciones',
   		CONCAT('C$ ', FORMAT(SUM(c.Precio_Venta * b.Cantidad), 2)) AS 'Total Devoluciones',
  		MAX(a.Fecha) AS 'Fecha de última Devolución',
		MAX(d.Estado) AS 'Estado',
	 	MAX(a.Descripcion) AS 'Descripción',
    		MAX(e.Nombre) AS 'Cliente',
	    	MAX(f.Nombre) AS 'Trabajador'
	FROM Devoluciones a
	INNER JOIN Detalle_Devolucion b ON a.ID = b.ID_Devolucion
	INNER JOIN Productos c ON c.ID = b.ID_Producto
	INNER JOIN Facturas d ON a.ID_Factura = d.ID
	INNER JOIN Clientes e ON d.ID_Cliente = e.ID
	INNER JOIN Usuarios f ON d.ID_Usuario = f.ID
        WHERE e.Nombre LIKE CONCAT('%', _Nombre_Cliente, '%')
        GROUP BY d.Codigo_Fac
	ORDER BY 'Cod. Factura' ASC;
    ELSEIF opcion = 3 THEN
        -- Buscar devolución por estado de factura
         SELECT
    		MAX(a.ID), 
    		CONCAT('FAC-', LPAD(d.Codigo_Fac, 5, '0')) AS 'Cod. Factura',
	    	COUNT(a.ID) AS 'Cant. Devoluciones',
   		CONCAT('C$ ', FORMAT(SUM(c.Precio_Venta * b.Cantidad), 2)) AS 'Total Devoluciones',
  		MAX(a.Fecha) AS 'Fecha de última Devolución',
		MAX(d.Estado) AS 'Estado',
	 	MAX(a.Descripcion) AS 'Descripción',
    		MAX(e.Nombre) AS 'Cliente',
	    	MAX(f.Nombre) AS 'Trabajador'
	FROM Devoluciones a
	INNER JOIN Detalle_Devolucion b ON a.ID = b.ID_Devolucion
	INNER JOIN Productos c ON c.ID = b.ID_Producto
	INNER JOIN Facturas d ON a.ID_Factura = d.ID
	INNER JOIN Clientes e ON d.ID_Cliente = e.ID
	INNER JOIN Usuarios f ON d.ID_Usuario = f.ID
        WHERE d.Estado = _Estado
        GROUP BY d.Codigo_Fac
	ORDER BY 'Cod. Factura' ASC;
    ELSE
        -- Opción no válida
        SELECT 'Opción no válida' AS Resultado;
    END IF;
END //
DELIMITER ;

-- Mostrar detalle de la devolución
SELECT 
	c.ID,
	c.Codigo AS 'Codigo', 
	c.Nombre AS 'Nombre', 
	c.Precio_Venta, 
	b.Cantidad,   
	(c.Precio_Venta * b.Cantidad) AS 'Total'
FROM Devoluciones a
INNER JOIN Detalle_Devolucion b ON a.ID = b.ID_Devolucion
INNER JOIN Productos c ON c.ID = b.ID_Producto 
WHERE a.ID = 1;

-- ----------------------------------------------------------- Consultas realcionado al crédito y abono -------------------------------------------------------------

-- Mostrar los creditos realizados
CREATE VIEW Mostrar_Creditos AS SELECT
    a.ID,
    CONCAT('FAC-', LPAD(c.Codigo_Fac, 5, '0')) AS 'Cod. Factura',
    d.Nombre AS 'Cliente',
    a.Estado,
    a.DiaDeCredito AS 'Inicio del credito',
    a.DiaDeVencimiento AS 'Fin del credito',
    CASE WHEN (DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento)) < 0 THEN '0' ELSE DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento) END AS 'Dias vencidos',
    CONCAT('C$ ', FORMAT(a.Cargo, 2)) AS 'Cargo',
    CONCAT('C$ ', FORMAT(c.Debe, 2)) AS 'Pendiente',
    CONCAT('C$ ', FORMAT(SUM(e.Monto), 2)) AS 'Total de monto',
    c.ID AS 'ID Factura'
FROM Credito a
INNER JOIN Facturas c ON a.ID_Factura = c.ID
INNER JOIN Clientes d ON c.ID_Cliente = d.ID
INNER JOIN Abono e ON a.ID = e.ID_Credito
GROUP BY a.ID ORDER BY a.ID ASC;

-- Mostrar estado de cuenta
CREATE VIEW Mostrar_EstadoCredito AS SELECT e.ID, e.Fecha, e.Descripcion AS 'Concepto', CONCAT('C$ ', FORMAT(e.Saldo_Anterior, 2)) AS 'Saldo anterior', CONCAT('C$ ', FORMAT(a.Cargo, 2)) AS 'Cargo', CONCAT('C$ ', FORMAT(e.Monto, 2)) AS 'Abono', CONCAT('C$ ', FORMAT(e.Saldo_Nuevo, 2)) AS 'Saldo nuevo', e.ID_Credito FROM Credito a INNER JOIN Facturas c ON a.ID_Factura = c.ID INNER JOIN Clientes d ON c.ID_Cliente = d.ID INNER JOIN Abono e ON a.ID = e.ID_Credito GROUP BY e.ID ORDER BY e.ID ASC;

-- Filtro para la tabla creditos
DELIMITER //
CREATE PROCEDURE ObtenerFacturasCredito(
    IN opcion INT,
    IN Fec_Inicio DATETIME,
    IN Fec_Final DATETIME,
    IN _Nombre_Cliente VARCHAR(100),
    IN _Estado VARCHAR(100),
    IN _DiasVencidos INT
)
BEGIN
    IF opcion = 1 THEN
        -- Mostrar las facturas al crédito (Rango entre fechas)
        SELECT
            a.ID,
            CONCAT('FAC-', LPAD(c.Codigo_Fac, 5, '0')) AS 'Cod. Factura',
            d.Nombre AS 'Cliente',
            a.Estado,
            a.DiaDeCredito AS 'Inicio del credito',
            a.DiaDeVencimiento AS 'Fin del credito',
    	    CASE WHEN (DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento)) < 0 THEN '0' ELSE DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento) END AS 'Dias vencidos',
            CONCAT('C$ ', FORMAT(a.Cargo, 2)) AS 'Cargo',
            CONCAT('C$ ', FORMAT(c.Debe, 2)) AS 'Pendiente',
            CONCAT('C$ ', FORMAT(SUM(e.Monto), 2)) AS 'Total de monto',
            c.ID AS 'ID Factura'
        FROM Credito a
        INNER JOIN Facturas c ON a.ID_Factura = c.ID
        INNER JOIN Clientes d ON c.ID_Cliente = d.ID
        INNER JOIN Abono e ON a.ID = e.ID_Credito
        WHERE DATE_FORMAT(a.DiaDeCredito, '%Y/%m/%d') BETWEEN Fec_Inicio AND Fec_Final
        GROUP BY a.ID
        ORDER BY a.ID;
    ELSEIF opcion = 2 THEN
        -- Buscar facturas al crédito por nombres de cliente
        SELECT
            a.ID,
            CONCAT('FAC-', LPAD(c.Codigo_Fac, 5, '0')) AS 'Cod. Factura',
            d.Nombre AS 'Cliente',
            a.Estado,
            a.DiaDeCredito AS 'Inicio del credito',
            a.DiaDeVencimiento AS 'Fin del credito',
            CASE WHEN (DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento)) < 0 THEN '0' ELSE DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento) END AS 'Dias vencidos',
            CONCAT('C$ ', FORMAT(a.Cargo, 2)) AS 'Cargo',
            CONCAT('C$ ', FORMAT(c.Debe, 2)) AS 'Pendiente',
            CONCAT('C$ ', FORMAT(SUM(e.Monto), 2)) AS 'Total de monto',
            c.ID AS 'ID Factura'
        FROM Credito a
        INNER JOIN Facturas c ON a.ID_Factura = c.ID
        INNER JOIN Clientes d ON c.ID_Cliente = d.ID
        LEFT JOIN Abono e ON a.ID = e.ID_Credito
        WHERE d.Nombre LIKE CONCAT('%', _Nombre_Cliente, '%')
        GROUP BY a.ID
        ORDER BY a.ID;
    ELSEIF opcion = 3 THEN
        -- Buscar facturas al crédito por estado de factura
        SELECT
            a.ID,
            CONCAT('FAC-', LPAD(c.Codigo_Fac, 5, '0')) AS 'Cod. Factura',
            d.Nombre AS 'Cliente',
            a.Estado,
            a.DiaDeCredito AS 'Inicio del credito',
            a.DiaDeVencimiento AS 'Fin del credito',
            CASE WHEN (DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento)) < 0 THEN '0' ELSE DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento) END AS 'Dias vencidos',
            CONCAT('C$ ', FORMAT(a.Cargo, 2)) AS 'Cargo',
            CONCAT('C$ ', FORMAT(c.Debe, 2)) AS 'Pendiente',
            CONCAT('C$ ', FORMAT(SUM(e.Monto), 2)) AS 'Total de monto',
            c.ID AS 'ID Factura'
        FROM Credito a
        INNER JOIN Facturas c ON a.ID_Factura = c.ID
        INNER JOIN Clientes d ON c.ID_Cliente = d.ID
        LEFT JOIN Abono e ON a.ID = e.ID_Credito
        WHERE c.Estado = _Estado
        GROUP BY a.ID
        ORDER BY a.ID;
    ELSEIF opcion = 4 THEN
           -- Buscar facturas al crédito por días vencidos
        SELECT
            a.ID,
            CONCAT('FAC-', LPAD(c.Codigo_Fac, 5, '0')) AS 'Cod. Factura',
            d.Nombre AS 'Cliente',
            a.Estado,
            a.DiaDeCredito AS 'Inicio del credito',
            a.DiaDeVencimiento AS 'Fin del credito',
    	    CASE WHEN (DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento)) < 0 THEN '0' ELSE DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento) END AS 'Dias vencidos',
            CONCAT('C$ ', FORMAT(a.Cargo, 2)) AS 'Cargo',
            CONCAT('C$ ', FORMAT(c.Debe, 2)) AS 'Pendiente',
            CONCAT('C$ ', FORMAT(SUM(e.Monto), 2)) AS 'Total de monto',
            c.ID AS 'ID Factura'
        FROM Credito a
        INNER JOIN Facturas c ON a.ID_Factura = c.ID
        INNER JOIN Clientes d ON c.ID_Cliente = d.ID
        INNER JOIN Abono e ON a.ID = e.ID_Credito
        WHERE (_DiasVencidos = 1 AND DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento) > 0)
           OR (_DiasVencidos = 2 AND DATEDIFF(CURRENT_DATE(), a.DiaDeVencimiento) <= 0)
        GROUP BY a.ID
        ORDER BY a.ID;
    ELSE
        -- Opción no válida
        SELECT 'Opción no válida' AS Resultado;
    END IF;
END //
DELIMITER ;


-- ----------------------------------------------------------- Reportes y Graficos de Ganancias -------------------------------------------------------------

-- Ganancias por mes, ultimos 15 días, ultimos 7 días y el dia de hoy
DELIMITER //
CREATE PROCEDURE ConsultarIngresos(IN opcion INT)
BEGIN
    IF opcion = 1 THEN
        -- Ingresos brutos por mes
        SELECT
			CONCAT(YEAR(Fecha), '-', LPAD(WEEK(Fecha, 3), 2, '0')) AS 'Año-Semana',
			FORMAT(SUM(Total_Final - Debe), 2) AS 'Ingresos Brutos'
		FROM Facturas
		WHERE Fecha >= DATE_SUB(CURRENT_DATE, INTERVAL 12 MONTH)
		GROUP BY CONCAT(YEAR(Fecha), '-', LPAD(WEEK(Fecha, 3), 2, '0'))
		ORDER BY CONCAT(YEAR(Fecha), '-', LPAD(WEEK(Fecha, 3), 2, '0'));
        
    ELSEIF opcion = 2 THEN
        -- Ingresos brutos en los últimos 15 días
			SELECT
				DATE_FORMAT(Fecha, '%d-%m-%Y') AS Dia,
				FORMAT(SUM(Total_Final - Debe), 2) AS 'Ingresos Brutos'
			FROM Facturas
			WHERE Fecha >= DATE_SUB(CURDATE(), INTERVAL 15 DAY)
			GROUP BY Dia
			ORDER BY Dia;
        
    ELSEIF opcion = 3 THEN
        -- Ingresos brutos en los últimos 7 días
		SELECT
			DATE_FORMAT(Fecha, '%d-%m-%Y') AS Dia,
			FORMAT(SUM(Total_Final - Debe), 2) AS 'Ingresos Brutos'
		FROM Facturas
		WHERE Fecha >= DATE_SUB(CURRENT_DATE, INTERVAL 7 DAY)
			GROUP BY Dia
			ORDER BY Dia;
        
    ELSEIF opcion = 4 THEN
        -- Ingresos brutos en la fecha de hoy
        SELECT 
			DATE_FORMAT(Fecha, '%H:00') AS Hora, 
			FORMAT(SUM(Total_Final - Debe), 2) AS 'Ingresos Brutos'
		FROM Facturas
		WHERE Fecha >= CURDATE()
		GROUP BY Hora
		ORDER BY Hora;
		
    ELSE
        SELECT 'Opción no válida';
    END IF;
END //
DELIMITER ;

-- Ganancias de los últimos 6 días
SELECT
    CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3), '-', LPAD(DAY(Fecha), 2, '0')) AS 'Año-Mes-Día',
    FORMAT(SUM(Total_Final - Debe), 2) AS 'Total vendido'
FROM Facturas
WHERE DATE(Fecha) BETWEEN CURDATE() - INTERVAL 6 DAY AND CURDATE()
GROUP BY CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3), '-', LPAD(DAY(Fecha), 2, '0'))
ORDER BY CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3), '-', LPAD(DAY(Fecha), 2, '0'));

-- Cantidad de ventas en los últimos 7 días
SELECT 
	CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3), '-', LPAD(DAY(Fecha), 2, '0')) AS 'Año-Mes-Día',
    COUNT(ID) AS 'Cantidad de Facturas realizadas'
FROM Facturas
WHERE DATE(Fecha) BETWEEN CURDATE() - INTERVAL 6 DAY AND CURDATE()
GROUP BY CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3), '-', LPAD(DAY(Fecha), 2, '0'))
ORDER BY CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3), '-', LPAD(DAY(Fecha), 2, '0'));

-- Total de ganancias por mes
SELECT
    CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3)) AS 'Año-Mes',
    SUM(Total_Final - Debe) AS 'Total vendido'
FROM Facturas
GROUP BY CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3))
ORDER BY CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3));

-- Cantidad pendiente de las facturas al crédito
SELECT CASE WHEN SUM(Debe) IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT(SUM(Debe), 2)) END 'Total' 
FROM Facturas;

-- Facturas realizadas
SELECT CASE WHEN COUNT(ID)  IS NULL THEN '0' ELSE COUNT(ID) END 'Cantidad'
FROM Facturas; 

-- Total de ganancias 
SELECT CASE WHEN SUM(Debe) IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT(SUM(Total_Final - Debe), 2)) END 'Total' 
FROM Facturas;

-- Total de facturas pendientes
SELECT CASE WHEN COUNT(ID)  IS NULL THEN '0' ELSE COUNT(ID) END 'Cantidad'
FROM Facturas WHERE Estado = 'Pendiente';

-- --------------------------------------------------------- Reportes y Graficos de productos más y menos vendidos ----------------------------------------------------------

-- Ganancias por mes, ultimos 15 días, ultimos 7 días y el dia de hoy
DELIMITER //
CREATE PROCEDURE ConsultarProductosMasVendidos(IN opcion INT)
BEGIN
    IF opcion = 1 THEN
        -- Ingresos brutos por mes
		SELECT
			a.Nombre,
			SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
		FROM Productos a
		INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
		INNER JOIN Facturas c ON c.ID = b.ID_Factura
        WHERE Fecha >= DATE_SUB(CURRENT_DATE, INTERVAL 12 MONTH)
		GROUP BY a.Nombre
		ORDER BY SUM(b.Cantidad) DESC LIMIT 10;

    ELSEIF opcion = 2 THEN
        -- Ingresos brutos en los últimos 15 días
		SELECT
			a.Nombre,
			SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
		FROM Productos a
		INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
		INNER JOIN Facturas c ON c.ID = b.ID_Factura
		WHERE Fecha >= DATE_SUB(CURRENT_DATE, INTERVAL 15 DAY)
		GROUP BY a.Nombre
		ORDER BY SUM(b.Cantidad) DESC LIMIT 10;
        
    ELSEIF opcion = 3 THEN
        -- Ingresos brutos en los últimos 7 días
		SELECT
			a.Nombre,
			SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
		FROM Productos a
		INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
		INNER JOIN Facturas c ON c.ID = b.ID_Factura
        WHERE Fecha >= DATE_SUB(CURRENT_DATE, INTERVAL 7 DAY)
		GROUP BY a.Nombre
		ORDER BY SUM(b.Cantidad) DESC LIMIT 10;

    ELSEIF opcion = 4 THEN
        -- Ingresos brutos en la fecha de hoy
        SELECT
			a.Nombre,
			SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
		FROM Productos a
		INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
		INNER JOIN Facturas c ON c.ID = b.ID_Factura
        		WHERE Fecha >= CURDATE()
		GROUP BY Nombre
		ORDER BY SUM(b.Cantidad) DESC LIMIT 10;

    ELSE
        SELECT 'Opción no válida';
    END IF;
END //
DELIMITER ;

-- Ganancias por mes, ultimos 15 días, ultimos 7 días y el dia de hoy
DELIMITER //
CREATE PROCEDURE ConsultarProductosMenosVendidos(IN opcion INT)
BEGIN
    IF opcion = 1 THEN
        -- Ingresos brutos por mes
		SELECT
			a.Nombre,
			SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
		FROM Productos a
		INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
		INNER JOIN Facturas c ON c.ID = b.ID_Factura
        WHERE Fecha >= DATE_SUB(CURRENT_DATE, INTERVAL 12 MONTH)
		GROUP BY a.Nombre
		ORDER BY SUM(b.Cantidad) ASC LIMIT 10;

    ELSEIF opcion = 2 THEN
        -- Ingresos brutos en los últimos 15 días
		SELECT
			a.Nombre,
			SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
		FROM Productos a
		INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
		INNER JOIN Facturas c ON c.ID = b.ID_Factura
		WHERE Fecha >= DATE_SUB(CURRENT_DATE, INTERVAL 15 DAY)
		GROUP BY a.Nombre
		ORDER BY SUM(b.Cantidad) ASC LIMIT 10;
        
    ELSEIF opcion = 3 THEN
        -- Ingresos brutos en los últimos 7 días
		SELECT
			a.Nombre,
			SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
		FROM Productos a
		INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
		INNER JOIN Facturas c ON c.ID = b.ID_Factura
        WHERE Fecha >= DATE_SUB(CURRENT_DATE, INTERVAL 7 DAY)
		GROUP BY a.Nombre
		ORDER BY SUM(b.Cantidad) ASC LIMIT 10;

    ELSEIF opcion = 4 THEN
        -- Ingresos brutos en la fecha de hoy
        SELECT
			a.Nombre,
			SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
		FROM Productos a
		INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
		INNER JOIN Facturas c ON c.ID = b.ID_Factura
        		WHERE Fecha >= CURDATE()
		GROUP BY Nombre
		ORDER BY SUM(b.Cantidad) ASC LIMIT 10;

    ELSE
        SELECT 'Opción no válida';
    END IF;
END //
DELIMITER ;


-- --------------------------------------------------------- Reportes y Graficos de kardex del inventario ----------------------------------------------------------

-- Los productos que han aumentado su precio de compra
SELECT 
    a.Nombre,
    DATE_FORMAT(b.Fecha_Cambio, '%d %b, %Y') AS 'Fecha del cambio',
	CASE WHEN  b.Precio_Antiguo IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT(b.Precio_Antiguo, 2)) END 'Precio Antiguo',
	CASE WHEN   b.Precio_Nuevo IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT( b.Precio_Nuevo, 2)) END 'Precio Nuevo'   
FROM Productos a 
INNER JOIN Historial_Precio b ON a.ID = b.ID_Producto;

-- Productos activos y productos inactivos
CREATE VIEW ProductosActivosNoActivos AS SELECT 
    'Activo' AS 'Estado',
    Nombre AS 'Producto', 
    Existencias AS 'Existencias Actuales'
FROM Productos
WHERE Estado = 'Activo' 
UNION ALL
SELECT 
    'No activo' AS 'Estado',
    Nombre AS 'Producto', 
    Existencias AS 'Existencias Actuales'
FROM Productos
WHERE Estado = 'No activo' 
ORDER BY Estado, `Existencias Actuales` DESC;

-- Productos con Bajo Inventario
SELECT 
	Nombre, 
	Existencias
FROM Productos
WHERE Existencias < 10;

-- Producto que no se han vendido
SELECT
    p.Nombre AS 'Producto',
    p.Existencias AS 'Existencias Actuales'
FROM Productos p
LEFT JOIN Detalle_Factura df ON p.ID = df.ID_Producto
WHERE df.ID_Producto IS NULL;


-- UN SOLO DATO

-- Mostrar el producto más caro del inventario y cuantas veces se ha vendido
SELECT
    a.Nombre AS 'Producto',
	CASE WHEN   a.Precio_Venta IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT(a.Precio_Venta, 2))  END 'Precio más alto',
    SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
FROM Productos a
INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
INNER JOIN Facturas c ON c.ID = b.ID_Factura
WHERE a.Precio_Venta = (SELECT MAX(Precio_Venta) FROM Productos)
GROUP BY a.Nombre, a.Precio_Venta;

-- Proveedor más habitual
SELECT
    p.Nombre AS 'Proveedor',
    SUM(dc.Cantidad) AS 'Cantidad de Productos Comprados'
FROM Compras c
INNER JOIN Detalle_Compra dc ON c.ID = dc.ID_Compra
INNER JOIN Proveedor p ON c.ID_Proveedor = p.ID
GROUP BY p.Nombre
ORDER BY SUM(dc.Cantidad) DESC;

-- Producto más vendido
SELECT
	a.Nombre,
	SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
FROM Productos a
INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
INNER JOIN Facturas c ON c.ID = b.ID_Factura
GROUP BY a.Nombre
ORDER BY SUM(b.Cantidad) DESC LIMIT 1;

-- Producto menos vendido
SELECT
	a.Nombre,
	SUM(b.Cantidad) AS 'Cantidad de productos vendidos'
FROM Productos a
INNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto
INNER JOIN Facturas c ON c.ID = b.ID_Factura
GROUP BY a.Nombre
ORDER BY SUM(b.Cantidad) ASC LIMIT 1;

-- --------------------------------------------------------- Reportes y Graficos de entradas y salidas ----------------------------------------------------------

-- Listar productos de compras por entrada
SELECT 
	    DATE_FORMAT(Fecha, '%d %b, %Y') AS 'Fecha de Entrada', 
	Nombre AS 'Nombre del Producto', 
	Cantidad AS 'Cantidad de Entrada'
FROM Detalle_Compra
JOIN Compras ON Detalle_Compra.ID_Compra = Compras.ID
JOIN Productos ON Detalle_Compra.ID_Producto = Productos.ID
WHERE Fecha BETWEEN '2023-09-01' AND '2023-10-31'
ORDER BY Fecha;

-- Listar productos en remesa por entrada
SELECT 
	p.Nombre AS 'Producto', 
    DATE_FORMAT(r.Fecha, '%d %b, %Y') AS 'Fecha de Remision', 
	SUM(dr.Cantidad) AS 'Cant. en Remison'
FROM Remisiones r
INNER JOIN Detalle_Remision dr ON r.ID = dr.ID_Remision
INNER JOIN Productos p ON dr.ID_Producto = p.ID
GROUP BY p.Nombre, DATE_FORMAT(r.Fecha, '%d %b, %Y')
HAVING SUM(dr.Cantidad) != 0;

-- Listar productos vendidos en un rango de fechas
SELECT 
	df.ID_Producto, 
	p.Nombre AS 'Producto', 
	SUM(df.Cantidad) AS 'Cantidad Vendida'
FROM Detalle_Factura df
INNER JOIN Facturas f ON df.ID_Factura = f.ID
INNER JOIN Productos p ON df.ID_Producto = p.ID
WHERE f.Fecha BETWEEN '2023-01-01' AND '2023-12-31'
GROUP BY df.ID_Producto
ORDER BY df.ID_Producto;

-- Listar todas las compras de un producto específico
SELECT c.ID AS 'ID Compra', c.Fecha, c.Nombre_Vendedor, df.Cantidad, p.Nombre AS 'Producto'
FROM Compras c
INNER JOIN Detalle_Compra df ON c.ID = df.ID_Compra
INNER JOIN Productos p ON df.ID_Producto = p.ID
WHERE p.ID = 2;

-- Listar productos con existencias mínimas
SELECT ID, Nombre, Existencias
FROM Productos
WHERE Existencias <= Existencias_Minimas;

-- UN SOLO Resultado

-- Calcular la cantidad total de productos vendidos
SELECT SUM(Cantidad) AS 'Total de Productos Vendidos'
FROM Detalle_Factura;

-- Calcular el valor total del inventario
SELECT SUM(Existencias * Precio_Compra) AS 'Valor Total del Inventario'
FROM Productos
WHERE Estado = 'Activo';


-- Calcular el valor total de ventas en un período específico:
SELECT SUM(Total_Final - Debe) AS 'Total de Ventas'
FROM Facturas
WHERE Fecha BETWEEN '2023-01-01' AND '2023-12-31';

DELIMITER //

CREATE PROCEDURE ObtenerMovimientosProductos(IN opcion INT)
BEGIN
    DECLARE fechaInicio DATE;
    
    IF opcion = 1 THEN
        SET fechaInicio = DATE_SUB(CURRENT_DATE, INTERVAL 12 MONTH);
    ELSEIF opcion = 2 THEN
        SET fechaInicio = DATE_SUB(CURRENT_DATE, INTERVAL 15 DAY);
    ELSEIF opcion = 3 THEN
        SET fechaInicio = DATE_SUB(CURRENT_DATE, INTERVAL 7 DAY);
    ELSEIF opcion = 4 THEN
        SET fechaInicio = CURDATE();
    ELSE
        SELECT 'Opción no válida';
    END IF;

    SELECT 
        'Entrada' AS 'Tipo', 
        DATE_FORMAT(c.Fecha, '%d %b, %Y') AS 'Fecha',
        p.Nombre AS 'Producto', 
        SUM(dc.Cantidad) AS 'Cantidad'
    FROM Compras c
    INNER JOIN Detalle_Compra dc ON c.ID = dc.ID_Compra
    INNER JOIN Productos p ON dc.ID_Producto = p.ID
    WHERE c.Fecha >= fechaInicio
    GROUP BY 'Entrada', DATE_FORMAT(c.Fecha, '%d %b, %Y'), p.Nombre

    UNION 

    SELECT 
        'Entrada' AS 'Tipo', 
        DATE_FORMAT(r.Fecha, '%d %b, %Y') AS 'Fecha',
        p.Nombre AS 'Producto', 
        SUM(dr.Cantidad) AS 'Cantidad'
    FROM Remisiones r
	INNER JOIN Detalle_Remision dr ON r.ID = dr.ID_Remision
	INNER JOIN Productos p ON dr.ID_Producto = p.ID
    WHERE r.Fecha >= fechaInicio
    GROUP BY 'Entrada', DATE_FORMAT(r.Fecha, '%d %b, %Y'), p.Nombre
    HAVING SUM(dr.Cantidad) != 0

    UNION

    SELECT 
        'Salida' AS 'Tipo', 
        DATE_FORMAT(f.Fecha, '%d %b, %Y') AS 'Fecha',
        p.Nombre AS 'Producto', 
        SUM(df.Cantidad) AS 'Cantidad'
    FROM Facturas f
    INNER JOIN Detalle_Factura df ON f.ID = df.ID_Factura
    INNER JOIN Productos p ON df.ID_Producto = p.ID
    WHERE f.Fecha >= fechaInicio
    GROUP BY 'Salida', DATE_FORMAT(f.Fecha, '%d %b, %Y'), p.Nombre
    ORDER BY DATE_FORMAT(Fecha, '%d %b, %Y');
    
END //
DELIMITER ;


