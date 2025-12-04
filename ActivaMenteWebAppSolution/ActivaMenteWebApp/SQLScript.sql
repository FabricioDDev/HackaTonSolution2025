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
    contrasenia VARCHAR(255) NOT NULL,
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
   TABLA: Categoria
   ============================================ */
CREATE TABLE Categoria (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(300)
);

/* ============================================
   TABLA: Pregunta
   ============================================ */
CREATE TABLE Pregunta (
    id_pregunta INT IDENTITY(1,1) PRIMARY KEY,
    id_juego INT NOT NULL,
    id_nivel INT NOT NULL,
    id_categoria INT NOT NULL,
    pregunta VARCHAR(300) NOT NULL,
    opcion1 VARCHAR(200) NOT NULL,
    opcion2 VARCHAR(200) NOT NULL,
    opcion3 VARCHAR(200) NOT NULL,
    opcion4 VARCHAR(200) NOT NULL,
    opcion_correcta INT NOT NULL,
    FOREIGN KEY (id_juego) REFERENCES Juego(id_juego),
    FOREIGN KEY (id_nivel) REFERENCES Nivel(id_nivel),
    FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria)
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

GO

/* ============================================
   INSERT: Personas
   ============================================ */
INSERT INTO Personas (nombre, apellido, sexo, nacionalidad, fecha_nacimiento, email)
VALUES
('Juan', 'Pérez', 'Masculino', 'Argentina', '2005-03-14', 'juan.perez@gmail.com'),
('María', 'Gómez', 'Femenino', 'Argentina', '2006-07-22', 'maria.gomez@gmail.com');



/* ============================================
   INSERT: Usuario
   ============================================ */
INSERT INTO Usuario (idPersona, nombre_usuario, contrasenia, avatar)
VALUES
(1, 'juan123', 'HASH001', 'avatar1.png'),
(2, 'mariaGG', 'HASH002', 'avatar2.png');



/* ============================================
   INSERT: Juego
   ============================================ */
INSERT INTO Juego (nombre, descripcion)
VALUES
('Cultura General', 'Preguntas básicas sobre historia, geografía y ciencia.'),
('Matemática Básica', 'Ejercicios simples para practicar números y operaciones.');



/* ============================================
   INSERT: Nivel
   ============================================ */
INSERT INTO Nivel (id_juego, numero_nivel, dificultad)
VALUES
(1, 1, 'Fácil'),
(1, 2, 'Intermedio'),
(2, 1, 'Fácil');



/* ============================================
   INSERT: Categoria
   ============================================ */
INSERT INTO Categoria (nombre, descripcion)
VALUES
('Geografía', 'Preguntas relacionadas con países, océanos, capitales, etc.'),
('Arte e Historia', 'Pintura, historia mundial, personajes históricos.'),
('Ciencia', 'Preguntas básicas de ciencias naturales.'),
('Matemática', 'Operaciones y preguntas numéricas simples.');



/* ============================================
   INSERT: Pregunta
   ============================================ */
INSERT INTO Pregunta (id_juego, id_nivel, id_categoria, pregunta, opcion1, opcion2, opcion3, opcion4, opcion_correcta)
VALUES
-- Cultura General - Nivel 1
(1, 1, 1, '¿Cuál es el océano más grande del mundo?', 'Atlántico', 'Pacífico', 'Índico', 'Ártico', 2),
(1, 1, 2, '¿Quién pintó La Mona Lisa?', 'Picasso', 'Van Gogh', 'Da Vinci', 'Miguel Ángel', 3),

-- Cultura General - Nivel 2
(1, 2, 2, '¿En qué año llegó el hombre a la Luna?', '1969', '1972', '1955', '1965', 1),

-- Matemática Básica - Nivel 1
(2, 3, 4, '¿Cuánto es 12 + 15?', '27', '22', '31', '25', 1),
(2, 3, 4, '¿Cuánto es 9 × 3?', '18', '27', '21', '24', 2);



/* ============================================
   INSERT: ResultadoJuego (simulación)
   ============================================ */
INSERT INTO ResultadoJuego (id_usuario, id_juego, id_nivel, puntaje_obtenido)
VALUES
(1, 1, 1, 80),
(1, 2, 3, 90),
(2, 1, 1, 70);

