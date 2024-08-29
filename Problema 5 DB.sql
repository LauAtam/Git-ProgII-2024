-- Crear la base de datos
CREATE DATABASE Facturas_v2;
GO

-- Usar la base de datos recién creada
USE Facturas_v2;
GO

-- Crear la tabla Formas_pago
CREATE TABLE Formas_pago (
    ID INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria autoincremental
    nombre NVARCHAR(100) NOT NULL
);

-- Crear la tabla Articulos
CREATE TABLE Articulos (
    ID INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria autoincremental
    nombre NVARCHAR(100) NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL
);

-- Crear la tabla Facturas
CREATE TABLE Facturas (
    ID INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria autoincremental
    Fecha DATE NOT NULL,
    id_forma_pago INT,  -- Clave foránea que referencia a Formas_pago
    nombre_cliente NVARCHAR(100) NOT NULL,
    CONSTRAINT fk_facturas_id_forma_pago FOREIGN KEY (id_forma_pago) REFERENCES Formas_pago(ID) -- FK con identificador
);

-- Crear la tabla Detalles_facturas
CREATE TABLE Detalles_facturas (
    ID INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria autoincremental
    ID_factura INT,  -- Clave foránea que referencia a Facturas
    id_articulo INT,  -- Clave foránea que referencia a Articulos
    cantidad INT NOT NULL,
    CONSTRAINT fk_detalles_facturas_id_factura FOREIGN KEY (ID_factura) REFERENCES Facturas(ID), -- FK con identificador
    CONSTRAINT fk_detalles_facturas_id_articulo FOREIGN KEY (id_articulo) REFERENCES Articulos(ID) -- FK con identificador
);
