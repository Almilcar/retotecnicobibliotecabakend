
IF EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME='BDPROYECTORETO')
	DROP DATABASE BDPROYECTORETO
	go

	CREATE DATABASE BDPROYECTORETO
	go

	USE BDPROYECTORETO
	go

-- Tabla: Libro
CREATE TABLE Libro (
    IdLibro INT PRIMARY KEY IDENTITY,
    Titulo NVARCHAR(200) NOT NULL,
    Categoria NVARCHAR(100),
    Editorial NVARCHAR(100),
    PrecioVenta DECIMAL(10, 2),
    Estado NVARCHAR(50)
);

-- Tabla: CopiaLibro
CREATE TABLE CopiaLibro (
    IdCopia INT PRIMARY KEY IDENTITY,
    CodigoBarras NVARCHAR(100) UNIQUE NOT NULL,
    IdLibro INT FOREIGN KEY REFERENCES Libro(IdLibro),
    UbicacionEstante NVARCHAR(100),
    EstadoCopia NVARCHAR(50)
);

-- Tabla: Cliente
CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY,
    NombreCompleto NVARCHAR(150),
    Documento NVARCHAR(20),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100),
    Direccion NVARCHAR(200),
    Ubigeo NVARCHAR(10),
	Departamento NVARCHAR(200),
	Provincia NVARCHAR(200),
	Distrito NVARCHAR(200),
	TipoDocumento NVARCHAR(10),
    EnListaNegra BIT DEFAULT 0
);

-- Tabla: Prestamo
CREATE TABLE Prestamo (
    IdPrestamo INT PRIMARY KEY IDENTITY,
    IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente),
    FechaSolicitud DATETIME DEFAULT GETDATE(),
    Estado NVARCHAR(50),
    MedioEntrega NVARCHAR(50),
    TotalLibros INT
);

-- Tabla: DetallePrestamo
CREATE TABLE DetallePrestamo (
    IdDetalle INT PRIMARY KEY IDENTITY,
    IdPrestamo INT FOREIGN KEY REFERENCES Prestamo(IdPrestamo),
    IdCopia INT FOREIGN KEY REFERENCES CopiaLibro(IdCopia),
    FechaEntrega DATETIME,
    FechaDevolucion DATETIME,
    Penalidad DECIMAL(10,2)
);

-- Tabla: Usuario
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY,
    Usuario NVARCHAR(100) UNIQUE NOT NULL,
    ContraseniaHash NVARCHAR(200),
    Rol NVARCHAR(50),
    Activo BIT DEFAULT 1
);

go
----------------------------------------
 INSERT INTO Cliente (NombreCompleto, Documento, Telefono, Email, Direccion)
VALUES ('Almilcar Chavez', '12345678', '901945152', 'almilcarchsz92@gmail.com', 'jr. Los tulipanes, Lima');

---------------------------------------
INSERT INTO Libro (Titulo, Categoria, Editorial, PrecioVenta, Estado)
VALUES 
('Cien años de soledad', 'Ficción', 'Editorial Sudamericana', 35.00, 'Disponible'),
('Don Quijote de la Mancha', 'Clásico', 'Editorial Planeta', 25.00, 'Disponible'),
('1984', 'Distopía', 'Editorial Seix Barral', 20.00, 'Disponible'),
('El código Da Vinci', 'Misterio', 'Editorial Planeta', 18.00, 'Disponible'),
('El Alquimista', 'Ficción', 'Editorial HarperCollins', 15.00, 'Disponible');

 
INSERT INTO CopiaLibro (CodigoBarras, IdLibro, UbicacionEstante, EstadoCopia)
VALUES ('1234567890123', 1, 'Estante 3 - Fila 5', 'Disponible');

 INSERT INTO CopiaLibro (CodigoBarras, IdLibro, UbicacionEstante, EstadoCopia)
VALUES ('1234567890987', 2, 'Estante 4 - Fila 6', 'Disponible');

--INSERT INTO Prestamo (IdCliente, Estado, MedioEntrega, TotalLibros)
--VALUES (1, 'Pendiente', 'Físico', 1);


--INSERT INTO DetallePrestamo (IdPrestamo, IdCopia, FechaEntrega)
--VALUES (1, 1, '2025-04-09');


--USE [BDPROYECTORETO]
--GO
--ALTER AUTHORIZATION ON DATABASE::[BDPROYECTORETO] TO [sa]
--GO

	 