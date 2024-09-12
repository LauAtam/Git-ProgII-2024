CREATE DATABASE DB_Facturacion;
GO

USE DB_Facturacion;
GO

CREATE TABLE Formas_pago (
    ID INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Articulos (
    ID INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Facturas (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    id_forma_pago INT,
    nombre_cliente NVARCHAR(100) NOT NULL,
    CONSTRAINT fk_facturas_id_forma_pago FOREIGN KEY (id_forma_pago) REFERENCES Formas_pago(ID)
);


CREATE TABLE Detalles_facturas (
    ID INT PRIMARY KEY IDENTITY(1,1),
	nro_detalle INT,
    ID_factura INT,
    id_articulo INT,
    cantidad INT NOT NULL,
    CONSTRAINT fk_detalles_facturas_id_factura FOREIGN KEY (ID_factura) REFERENCES Facturas(ID),
    CONSTRAINT fk_detalles_facturas_id_articulo FOREIGN KEY (id_articulo) REFERENCES Articulos(ID)
);
