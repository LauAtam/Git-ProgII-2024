USE [master]
GO
/****** Object:  Database [DB_Facturacion]    Script Date: 14/9/2024 03:59:40 ******/
CREATE DATABASE [DB_Facturacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Facturacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_Facturacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Facturacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_Facturacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_Facturacion] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Facturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Facturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Facturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Facturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Facturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Facturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Facturacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Facturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Facturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Facturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Facturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Facturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Facturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Facturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Facturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Facturacion] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Facturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Facturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Facturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Facturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Facturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Facturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Facturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Facturacion] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_Facturacion] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Facturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Facturacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Facturacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Facturacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Facturacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Facturacion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_Facturacion', N'ON'
GO
ALTER DATABASE [DB_Facturacion] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_Facturacion] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DB_Facturacion]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[precio_unitario] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_facturas]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_facturas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nro_detalle] [int] NOT NULL,
	[id_factura] [int] NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[id_forma_pago] [int] NULL,
	[nombre_cliente] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formas_pago]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formas_pago](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 
GO
INSERT [dbo].[Articulos] ([ID], [nombre], [precio_unitario]) VALUES (1, N'lapicera', CAST(200.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Articulos] ([ID], [nombre], [precio_unitario]) VALUES (2, N'goma', CAST(50.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Articulos] ([ID], [nombre], [precio_unitario]) VALUES (3, N'Pañuelitos descartables', CAST(500.50 AS Decimal(10, 2)))
GO
INSERT [dbo].[Articulos] ([ID], [nombre], [precio_unitario]) VALUES (4, N'Manteca de cacao', CAST(3600.00 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[Articulos] OFF
GO
SET IDENTITY_INSERT [dbo].[Detalles_facturas] ON 
GO
INSERT [dbo].[Detalles_facturas] ([id], [nro_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (1, 1, 1, 1, 3)
GO
INSERT [dbo].[Detalles_facturas] ([id], [nro_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (2, 2, 1, 2, 3)
GO
INSERT [dbo].[Detalles_facturas] ([id], [nro_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (3, 3, 1, 3, 5)
GO
INSERT [dbo].[Detalles_facturas] ([id], [nro_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (4, 1, 2, 3, 3)
GO
INSERT [dbo].[Detalles_facturas] ([id], [nro_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (5, 2, 2, 2, 3)
GO
INSERT [dbo].[Detalles_facturas] ([id], [nro_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (6, 3, 2, 1, 5)
GO
INSERT [dbo].[Detalles_facturas] ([id], [nro_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (7, 1, 3, 4, 3)
GO
INSERT [dbo].[Detalles_facturas] ([id], [nro_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (8, 2, 3, 2, 3)
GO
INSERT [dbo].[Detalles_facturas] ([id], [nro_detalle], [id_factura], [id_articulo], [cantidad]) VALUES (9, 3, 3, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Detalles_facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Facturas] ON 
GO
INSERT [dbo].[Facturas] ([ID], [Fecha], [id_forma_pago], [nombre_cliente]) VALUES (1, CAST(N'2024-09-03' AS Date), 1, N'Lautaro Atampiz')
GO
INSERT [dbo].[Facturas] ([ID], [Fecha], [id_forma_pago], [nombre_cliente]) VALUES (2, CAST(N'2024-09-03' AS Date), 2, N'Jose Dopazo')
GO
INSERT [dbo].[Facturas] ([ID], [Fecha], [id_forma_pago], [nombre_cliente]) VALUES (3, CAST(N'2024-09-03' AS Date), 3, N'Cerasulo Regina')
GO
SET IDENTITY_INSERT [dbo].[Facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Formas_pago] ON 
GO
INSERT [dbo].[Formas_pago] ([ID], [nombre]) VALUES (1, N'efectivo')
GO
INSERT [dbo].[Formas_pago] ([ID], [nombre]) VALUES (2, N'debito')
GO
INSERT [dbo].[Formas_pago] ([ID], [nombre]) VALUES (3, N'credito')
GO
SET IDENTITY_INSERT [dbo].[Formas_pago] OFF
GO
ALTER TABLE [dbo].[Detalles_facturas]  WITH CHECK ADD  CONSTRAINT [fk_detalles_facturas_id_articulo] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[Articulos] ([ID])
GO
ALTER TABLE [dbo].[Detalles_facturas] CHECK CONSTRAINT [fk_detalles_facturas_id_articulo]
GO
ALTER TABLE [dbo].[Detalles_facturas]  WITH CHECK ADD  CONSTRAINT [fk_detalles_facturas_id_factura] FOREIGN KEY([id_factura])
REFERENCES [dbo].[Facturas] ([ID])
GO
ALTER TABLE [dbo].[Detalles_facturas] CHECK CONSTRAINT [fk_detalles_facturas_id_factura]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [fk_facturas_id_forma_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[Formas_pago] ([ID])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [fk_facturas_id_forma_pago]
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTA_FACTURAS_Y_DETALLES]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_CONSULTA_FACTURAS_Y_DETALLES]
AS
BEGIN
select
	df.ID_factura 'ID Factura',
	f.Fecha 'Fecha',
	f.nombre_cliente 'Cliente',
	fp.nombre 'Forma de pago',
	df.nro_detalle 'Nro Detalle',
	a.nombre 'Articulo',
	df.cantidad 'Cantidad'
from Facturas f
join Detalles_facturas df on f.ID=df.ID_factura
join Formas_pago fp on f.id_forma_pago=fp.ID
join Articulos a on df.id_articulo=a.ID
order by f.ID, df.nro_detalle
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_ARTICULO]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ELIMINAR_ARTICULO]
@id int
as
begin
delete
from Articulos
where ID = @id
end
--select * from Articulos
--exec s
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_DETALLE_FACTURA]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ELIMINAR_DETALLE_FACTURA]
@id int
as
begin
delete
from Detalles_facturas
where id_factura = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_FACTURA]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ELIMINAR_FACTURA]
@id int
as
begin
delete
from Facturas
where ID = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_FORMA_PAGO]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ELIMINAR_FORMA_PAGO]
@id int
as
begin
delete
from Formas_pago
where ID = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_ARTICULO]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_GUARDAR_ARTICULO]
@id int,
@nombre varchar(100),
@precio decimal
as
begin
	if @id = 0
		begin
			insert into articulos(nombre, precio_unitario)
			values(@nombre, @precio)
		end
	else
		begin
			update Articulos
			set nombre = @nombre, precio_unitario = @precio
			where id=@id
		end
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_DETALLE_FACTURA]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_GUARDAR_DETALLE_FACTURA]
@id int,
@nro_detalle int,
@id_maestro int,
@id_articulo int,
@cantidad int
AS
	if @id = 0
		begin
			INSERT INTO Detalles_facturas(nro_detalle, id_factura, id_articulo, cantidad)
			VALUES (@nro_detalle, @id_maestro, @id_articulo, @cantidad)
		end
	else
		begin
			update Detalles_facturas
			set nro_detalle=@nro_detalle,id_factura=@id_maestro, id_articulo=@id_articulo, cantidad=@cantidad
			where id=@id
		END
GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_FACTURA]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_GUARDAR_FACTURA]
@id int,
@id_forma_pago int,
@nombre_cliente varchar(255),
@id_maestro int output

AS
begin
	if @id = 0
		begin
			INSERT INTO Facturas(Fecha, id_forma_pago, nombre_cliente)
			VALUES (getdate(), @id_forma_pago, @nombre_cliente)
			SET @id_maestro = SCOPE_IDENTITY()

		end
	else
		BEGIN
			update facturas
			set Fecha=getdate(), id_forma_pago=@id_forma_pago,nombre_cliente=@nombre_cliente
			where ID=@id
		END
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_FORMAS_PAGO]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_GUARDAR_FORMAS_PAGO]
@id int,
@nombre varchar
AS
BEGIN
	IF @id = 0
		begin
			INSERT INTO Formas_pago(nombre)
			VALUES (@nombre)
		end
	else
		begin
			update Formas_pago
			set nombre = @nombre
			where id = @id
		end
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_ARTICULOS]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_RECUPERAR_ARTICULOS]
as
begin
select Articulos.ID, articulos.nombre, Articulos.precio_unitario
from articulos
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_ARTICULOS_POR_ID]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_ARTICULOS_POR_ID]
	@id int
AS
begin
    SET NOCOUNT ON
	SELECT *
	FROM Articulos
	WHERE ID = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_DETALLES_FACTURAS]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RECUPERAR_DETALLES_FACTURAS]
as
begin
select *
from Detalles_facturas
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_DETALLES_FACTURAS_POR_ID]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_DETALLES_FACTURAS_POR_ID]
	@id int
AS
begin
    SET NOCOUNT ON
	SELECT *
	FROM Detalles_facturas
	WHERE ID = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_DETALLES_FACTURAS_POR_ID_FACTURA]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_RECUPERAR_DETALLES_FACTURAS_POR_ID_FACTURA]
	@id int
AS
begin
    SET NOCOUNT ON
	SELECT *
	FROM Detalles_facturas
	WHERE id_factura = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURAS]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RECUPERAR_FACTURAS]
as
begin
select *
from facturas
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURAS_POR_ID]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_FACTURAS_POR_ID]
	@id int
AS
begin
    SET NOCOUNT ON
	SELECT *
	FROM Facturas
	WHERE ID = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FORMAS_PAGO]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RECUPERAR_FORMAS_PAGO]
as
begin
select *
from Formas_pago
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FORMAS_PAGO_POR_ID]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_FORMAS_PAGO_POR_ID]
	@id int
AS
begin
    SET NOCOUNT ON
	SELECT *
	FROM Formas_pago
	WHERE ID = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_N_DETALLES_FACTURAS]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_RECUPERAR_N_DETALLES_FACTURAS]
@n int
as
begin
select TOP(@n) *
from Detalles_facturas
order by id_factura desc
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_N_FACTURAS]    Script Date: 14/9/2024 03:59:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RECUPERAR_N_FACTURAS]
@n int
as
begin
select TOP(@n) *
from facturas
order by ID
end
GO
USE [master]
GO
ALTER DATABASE [DB_Facturacion] SET  READ_WRITE 
GO
