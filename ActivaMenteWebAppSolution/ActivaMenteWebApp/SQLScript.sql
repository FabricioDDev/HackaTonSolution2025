/* ============================================
   CREAR BASE DE DATOS
   ============================================ */
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ActivaMenteDB')
BEGIN
    CREATE DATABASE ActivaMenteDB;
END
GO

/* Usar la base */
USE ActivaMenteDB;
GO

/* ============================================
   TABLA: Personas
   ============================================ */
CREATE TABLE Personas (
    idPersona INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    sexo VARCHAR(20),
    nacionalidad VARCHAR(50),
    fecha_nacimiento DATE,
    email VARCHAR(150) UNIQUE NOT NULL
);

/* ============================================
   TABLA: Usuario
   ============================================ */
CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    idPersona INT NOT NULL,
    nombre_usuario VARCHAR(100) UNIQUE NOT NULL,
    contraseña_hash VARCHAR(255) NOT NULL,
    avatar VARCHAR(150),
    fecha_registro DATETIME DEFAULT GETDATE(),
    puntos_totales INT DEFAULT 0,
    FOREIGN KEY (idPersona) REFERENCES Personas(idPersona)
);

/* ============================================
   TABLA: Juego
   ============================================ */
CREATE TABLE Juego (
    id_juego INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(300)
);

/* ============================================
   TABLA: Nivel
   ============================================ */
CREATE TABLE Nivel (
    id_nivel INT IDENTITY(1,1) PRIMARY KEY,
    id_juego INT NOT NULL,
    numero_nivel INT NOT NULL,
    dificultad VARCHAR(50),
    FOREIGN KEY (id_juego) REFERENCES Juego(id_juego)
);

/* ============================================
   TABLA: Pregunta
   ============================================ */
CREATE TABLE Pregunta (
    id_pregunta INT IDENTITY(1,1) PRIMARY KEY,
    id_juego INT NOT NULL,
    id_nivel INT NOT NULL,
    pregunta VARCHAR(300) NOT NULL,
    opcion1 VARCHAR(200) NOT NULL,
    opcion2 VARCHAR(200) NOT NULL,
    opcion3 VARCHAR(200) NOT NULL,
    opcion4 VARCHAR(200) NOT NULL,
    opcion_correcta INT NOT NULL,
    FOREIGN KEY (id_juego) REFERENCES Juego(id_juego),
    FOREIGN KEY (id_nivel) REFERENCES Nivel(id_nivel)
);

/* ============================================
   TABLA: ResultadoJuego
   ============================================ */
CREATE TABLE ResultadoJuego (
    id_resultado INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_juego INT NOT NULL,
    id_nivel INT NOT NULL,
    puntaje_obtenido INT NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_juego) REFERENCES Juego(id_juego),
    FOREIGN KEY (id_nivel) REFERENCES Nivel(id_nivel)
);
