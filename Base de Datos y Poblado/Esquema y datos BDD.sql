USE [master]
GO
/****** Object:  Database [Capacitaciones]    Script Date: 13-05-2024 4:21:47 ******/
CREATE DATABASE [Capacitaciones]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Capacitaciones', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Capacitaciones.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Capacitaciones_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Capacitaciones_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Capacitaciones] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Capacitaciones].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Capacitaciones] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Capacitaciones] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Capacitaciones] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Capacitaciones] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Capacitaciones] SET ARITHABORT OFF 
GO
ALTER DATABASE [Capacitaciones] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Capacitaciones] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Capacitaciones] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Capacitaciones] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Capacitaciones] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Capacitaciones] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Capacitaciones] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Capacitaciones] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Capacitaciones] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Capacitaciones] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Capacitaciones] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Capacitaciones] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Capacitaciones] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Capacitaciones] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Capacitaciones] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Capacitaciones] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Capacitaciones] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Capacitaciones] SET RECOVERY FULL 
GO
ALTER DATABASE [Capacitaciones] SET  MULTI_USER 
GO
ALTER DATABASE [Capacitaciones] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Capacitaciones] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Capacitaciones] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Capacitaciones] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Capacitaciones] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Capacitaciones] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Capacitaciones', N'ON'
GO
ALTER DATABASE [Capacitaciones] SET QUERY_STORE = ON
GO
ALTER DATABASE [Capacitaciones] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Capacitaciones]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13-05-2024 4:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 13-05-2024 4:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[RUN_Alumno] [int] NOT NULL,
	[DV_Alumno] [char](10) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[Genero] [char](1) NOT NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[RUN_Alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignacion_Cursos_Alu]    Script Date: 13-05-2024 4:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignacion_Cursos_Alu](
	[ID_Asignacion] [int] NOT NULL,
	[Codigo_Curso] [varchar](50) NOT NULL,
	[Codigo_Sala] [varchar](50) NOT NULL,
	[RUN_Alumno] [int] NOT NULL,
	[ID_Bimestre] [int] NOT NULL,
 CONSTRAINT [PK_Asignacion_Cursos_Alu] PRIMARY KEY CLUSTERED 
(
	[ID_Asignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignacion_Cursos_Pro]    Script Date: 13-05-2024 4:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignacion_Cursos_Pro](
	[ID_Asignacion] [int] NOT NULL,
	[Codigo_Curso] [varchar](50) NOT NULL,
	[RUN_Profesor] [int] NOT NULL,
	[ID_Bimestre] [int] NOT NULL,
 CONSTRAINT [PK_Asignacion_Cursos_Pro] PRIMARY KEY CLUSTERED 
(
	[ID_Asignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bimestre]    Script Date: 13-05-2024 4:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bimestre](
	[ID_Bimestre] [int] NOT NULL,
	[Anio] [int] NOT NULL,
	[Numero_Bimestre] [int] NOT NULL,
	[Fecha_Inicio] [date] NOT NULL,
	[Fecha_Fin] [date] NOT NULL,
 CONSTRAINT [PK_Bimestre] PRIMARY KEY CLUSTERED 
(
	[ID_Bimestre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 13-05-2024 4:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[Codigo_Curso] [varchar](50) NOT NULL,
	[Nombre_Curso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[Codigo_Curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notas]    Script Date: 13-05-2024 4:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notas](
	[ID_Nota] [int] NOT NULL,
	[RUN_Alumno] [int] NOT NULL,
	[Codigo_Curso] [varchar](50) NOT NULL,
	[ID_Bimestre] [int] NOT NULL,
	[Nota] [float] NOT NULL,
 CONSTRAINT [PK_Notas] PRIMARY KEY CLUSTERED 
(
	[ID_Nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 13-05-2024 4:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[RUN_Profesor] [int] NOT NULL,
	[DV_Profesor] [char](10) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[RUN_Profesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sala]    Script Date: 13-05-2024 4:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sala](
	[Codigo_Sala] [varchar](50) NOT NULL,
	[Capacidad_Maxima] [int] NOT NULL,
	[Caracteristicas_Especiales] [int] NOT NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[Codigo_Sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Alumno] ([RUN_Alumno], [DV_Alumno], [Nombre], [Apellido], [Fecha_Nacimiento], [Genero]) VALUES (11111111, N'1         ', N'EMANUEL', N'PEREZ', CAST(N'1998-05-20' AS Date), N'M')
INSERT [dbo].[Alumno] ([RUN_Alumno], [DV_Alumno], [Nombre], [Apellido], [Fecha_Nacimiento], [Genero]) VALUES (20813558, N'9         ', N'LUCIANO', N'FERNANDEZ', CAST(N'2001-11-13' AS Date), N'M')
INSERT [dbo].[Alumno] ([RUN_Alumno], [DV_Alumno], [Nombre], [Apellido], [Fecha_Nacimiento], [Genero]) VALUES (20813559, N'7         ', N'LUIS', N'FERNANDEZ', CAST(N'2001-11-13' AS Date), N'M')
INSERT [dbo].[Alumno] ([RUN_Alumno], [DV_Alumno], [Nombre], [Apellido], [Fecha_Nacimiento], [Genero]) VALUES (22222222, N'2         ', N'CECILIA', N'MONSERRAT', CAST(N'1998-05-20' AS Date), N'F')
INSERT [dbo].[Alumno] ([RUN_Alumno], [DV_Alumno], [Nombre], [Apellido], [Fecha_Nacimiento], [Genero]) VALUES (44444444, N'4         ', N'FERNANDA', N'LLANTEN', CAST(N'1997-08-01' AS Date), N'F')
GO
INSERT [dbo].[Asignacion_Cursos_Alu] ([ID_Asignacion], [Codigo_Curso], [Codigo_Sala], [RUN_Alumno], [ID_Bimestre]) VALUES (0, N'C121', N'A1', 20813558, 5)
INSERT [dbo].[Asignacion_Cursos_Alu] ([ID_Asignacion], [Codigo_Curso], [Codigo_Sala], [RUN_Alumno], [ID_Bimestre]) VALUES (1, N'C121', N'A1', 20813559, 1)
INSERT [dbo].[Asignacion_Cursos_Alu] ([ID_Asignacion], [Codigo_Curso], [Codigo_Sala], [RUN_Alumno], [ID_Bimestre]) VALUES (2, N'E122', N'A2', 11111111, 1)
INSERT [dbo].[Asignacion_Cursos_Alu] ([ID_Asignacion], [Codigo_Curso], [Codigo_Sala], [RUN_Alumno], [ID_Bimestre]) VALUES (3, N'U123', N'A3', 44444444, 2)
INSERT [dbo].[Asignacion_Cursos_Alu] ([ID_Asignacion], [Codigo_Curso], [Codigo_Sala], [RUN_Alumno], [ID_Bimestre]) VALUES (4, N'C121', N'A1', 22222222, 4)
GO
INSERT [dbo].[Asignacion_Cursos_Pro] ([ID_Asignacion], [Codigo_Curso], [RUN_Profesor], [ID_Bimestre]) VALUES (1, N'C121', 66666666, 4)
INSERT [dbo].[Asignacion_Cursos_Pro] ([ID_Asignacion], [Codigo_Curso], [RUN_Profesor], [ID_Bimestre]) VALUES (4, N'C121', 99999999, 2)
INSERT [dbo].[Asignacion_Cursos_Pro] ([ID_Asignacion], [Codigo_Curso], [RUN_Profesor], [ID_Bimestre]) VALUES (7, N'E122', 65444444, 3)
INSERT [dbo].[Asignacion_Cursos_Pro] ([ID_Asignacion], [Codigo_Curso], [RUN_Profesor], [ID_Bimestre]) VALUES (2, N'E122', 77777777, 1)
INSERT [dbo].[Asignacion_Cursos_Pro] ([ID_Asignacion], [Codigo_Curso], [RUN_Profesor], [ID_Bimestre]) VALUES (6, N'U123', 15202125, 4)
INSERT [dbo].[Asignacion_Cursos_Pro] ([ID_Asignacion], [Codigo_Curso], [RUN_Profesor], [ID_Bimestre]) VALUES (3, N'U123', 88888888, 1)
INSERT [dbo].[Asignacion_Cursos_Pro] ([ID_Asignacion], [Codigo_Curso], [RUN_Profesor], [ID_Bimestre]) VALUES (5, N'U123', 99999999, 5)
GO
INSERT [dbo].[Bimestre] ([ID_Bimestre], [Anio], [Numero_Bimestre], [Fecha_Inicio], [Fecha_Fin]) VALUES (1, 2011, 1, CAST(N'2011-03-01' AS Date), CAST(N'2011-05-15' AS Date))
INSERT [dbo].[Bimestre] ([ID_Bimestre], [Anio], [Numero_Bimestre], [Fecha_Inicio], [Fecha_Fin]) VALUES (2, 2012, 2, CAST(N'2012-06-01' AS Date), CAST(N'2012-08-15' AS Date))
INSERT [dbo].[Bimestre] ([ID_Bimestre], [Anio], [Numero_Bimestre], [Fecha_Inicio], [Fecha_Fin]) VALUES (3, 2013, 3, CAST(N'2013-09-01' AS Date), CAST(N'2013-11-15' AS Date))
INSERT [dbo].[Bimestre] ([ID_Bimestre], [Anio], [Numero_Bimestre], [Fecha_Inicio], [Fecha_Fin]) VALUES (4, 2014, 4, CAST(N'2014-06-01' AS Date), CAST(N'2014-08-15' AS Date))
INSERT [dbo].[Bimestre] ([ID_Bimestre], [Anio], [Numero_Bimestre], [Fecha_Inicio], [Fecha_Fin]) VALUES (5, 2011, 3, CAST(N'2011-09-01' AS Date), CAST(N'2011-11-15' AS Date))
INSERT [dbo].[Bimestre] ([ID_Bimestre], [Anio], [Numero_Bimestre], [Fecha_Inicio], [Fecha_Fin]) VALUES (6, 2011, 2, CAST(N'2011-06-01' AS Date), CAST(N'2011-08-15' AS Date))
INSERT [dbo].[Bimestre] ([ID_Bimestre], [Anio], [Numero_Bimestre], [Fecha_Inicio], [Fecha_Fin]) VALUES (7, 2011, 4, CAST(N'2011-09-01' AS Date), CAST(N'2012-01-15' AS Date))
GO
INSERT [dbo].[Curso] ([Codigo_Curso], [Nombre_Curso]) VALUES (N'C121', N'.NET')
INSERT [dbo].[Curso] ([Codigo_Curso], [Nombre_Curso]) VALUES (N'E122', N'EJB')
INSERT [dbo].[Curso] ([Codigo_Curso], [Nombre_Curso]) VALUES (N'U123', N'UML')
GO
INSERT [dbo].[Notas] ([ID_Nota], [RUN_Alumno], [Codigo_Curso], [ID_Bimestre], [Nota]) VALUES (1, 20813559, N'C121', 1, 6.5)
INSERT [dbo].[Notas] ([ID_Nota], [RUN_Alumno], [Codigo_Curso], [ID_Bimestre], [Nota]) VALUES (2, 44444444, N'U123', 2, 6.6)
INSERT [dbo].[Notas] ([ID_Nota], [RUN_Alumno], [Codigo_Curso], [ID_Bimestre], [Nota]) VALUES (3, 22222222, N'C121', 3, 7)
INSERT [dbo].[Notas] ([ID_Nota], [RUN_Alumno], [Codigo_Curso], [ID_Bimestre], [Nota]) VALUES (4, 20813558, N'U123', 4, 4.5)
INSERT [dbo].[Notas] ([ID_Nota], [RUN_Alumno], [Codigo_Curso], [ID_Bimestre], [Nota]) VALUES (5, 11111111, N'E122', 2, 4)
INSERT [dbo].[Notas] ([ID_Nota], [RUN_Alumno], [Codigo_Curso], [ID_Bimestre], [Nota]) VALUES (6, 11111111, N'U123', 5, 3.8)
GO
INSERT [dbo].[Profesor] ([RUN_Profesor], [DV_Profesor], [Nombre], [Apellido]) VALUES (15202125, N'K         ', N'ROSA', N'MARI')
INSERT [dbo].[Profesor] ([RUN_Profesor], [DV_Profesor], [Nombre], [Apellido]) VALUES (65444444, N'4         ', N'Guillermina', N'CASTRO')
INSERT [dbo].[Profesor] ([RUN_Profesor], [DV_Profesor], [Nombre], [Apellido]) VALUES (66666666, N'6         ', N'FELIPE', N'CACERES')
INSERT [dbo].[Profesor] ([RUN_Profesor], [DV_Profesor], [Nombre], [Apellido]) VALUES (77777777, N'7         ', N'CAROLINA', N'PEREZ')
INSERT [dbo].[Profesor] ([RUN_Profesor], [DV_Profesor], [Nombre], [Apellido]) VALUES (88888888, N'8         ', N'PAZ', N'GOMEZ')
INSERT [dbo].[Profesor] ([RUN_Profesor], [DV_Profesor], [Nombre], [Apellido]) VALUES (99999999, N'9         ', N'MANUEL', N'MILLAS')
GO
INSERT [dbo].[Sala] ([Codigo_Sala], [Capacidad_Maxima], [Caracteristicas_Especiales]) VALUES (N'A1', 20, 1)
INSERT [dbo].[Sala] ([Codigo_Sala], [Capacidad_Maxima], [Caracteristicas_Especiales]) VALUES (N'A2', 25, 0)
INSERT [dbo].[Sala] ([Codigo_Sala], [Capacidad_Maxima], [Caracteristicas_Especiales]) VALUES (N'A3', 25, 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Asignacion_Cursos_Pro_Bimestre]    Script Date: 13-05-2024 4:21:47 ******/
ALTER TABLE [dbo].[Asignacion_Cursos_Pro] ADD  CONSTRAINT [UQ_Asignacion_Cursos_Pro_Bimestre] UNIQUE NONCLUSTERED 
(
	[Codigo_Curso] ASC,
	[RUN_Profesor] ASC,
	[ID_Bimestre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uc_Notas]    Script Date: 13-05-2024 4:21:47 ******/
ALTER TABLE [dbo].[Notas] ADD  CONSTRAINT [uc_Notas] UNIQUE NONCLUSTERED 
(
	[RUN_Alumno] ASC,
	[Codigo_Curso] ASC,
	[ID_Bimestre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Alu]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Cursos_Alu_Alumno] FOREIGN KEY([RUN_Alumno])
REFERENCES [dbo].[Alumno] ([RUN_Alumno])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Alu] CHECK CONSTRAINT [FK_Asignacion_Cursos_Alu_Alumno]
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Alu]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Cursos_Alu_Bimestre] FOREIGN KEY([ID_Bimestre])
REFERENCES [dbo].[Bimestre] ([ID_Bimestre])
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Alu] CHECK CONSTRAINT [FK_Asignacion_Cursos_Alu_Bimestre]
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Alu]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Cursos_Alu_Curso] FOREIGN KEY([Codigo_Curso])
REFERENCES [dbo].[Curso] ([Codigo_Curso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Alu] CHECK CONSTRAINT [FK_Asignacion_Cursos_Alu_Curso]
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Alu]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Cursos_Alu_Sala] FOREIGN KEY([Codigo_Sala])
REFERENCES [dbo].[Sala] ([Codigo_Sala])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Alu] CHECK CONSTRAINT [FK_Asignacion_Cursos_Alu_Sala]
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Pro]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Cursos_Pro_Bimestre] FOREIGN KEY([ID_Bimestre])
REFERENCES [dbo].[Bimestre] ([ID_Bimestre])
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Pro] CHECK CONSTRAINT [FK_Asignacion_Cursos_Pro_Bimestre]
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Pro]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Cursos_Pro_Curso] FOREIGN KEY([Codigo_Curso])
REFERENCES [dbo].[Curso] ([Codigo_Curso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Pro] CHECK CONSTRAINT [FK_Asignacion_Cursos_Pro_Curso]
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Pro]  WITH CHECK ADD  CONSTRAINT [FK_Asignacion_Cursos_Pro_Profesor] FOREIGN KEY([RUN_Profesor])
REFERENCES [dbo].[Profesor] ([RUN_Profesor])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asignacion_Cursos_Pro] CHECK CONSTRAINT [FK_Asignacion_Cursos_Pro_Profesor]
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Alumno] FOREIGN KEY([RUN_Alumno])
REFERENCES [dbo].[Alumno] ([RUN_Alumno])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notas] CHECK CONSTRAINT [FK_Notas_Alumno]
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Bimestre] FOREIGN KEY([ID_Bimestre])
REFERENCES [dbo].[Bimestre] ([ID_Bimestre])
GO
ALTER TABLE [dbo].[Notas] CHECK CONSTRAINT [FK_Notas_Bimestre]
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Curso] FOREIGN KEY([Codigo_Curso])
REFERENCES [dbo].[Curso] ([Codigo_Curso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notas] CHECK CONSTRAINT [FK_Notas_Curso]
GO
ALTER TABLE [dbo].[Sala]  WITH CHECK ADD  CONSTRAINT [CHK_Caracteristicas_Especiales] CHECK  (([Caracteristicas_Especiales]=(1) OR [Caracteristicas_Especiales]=(0)))
GO
ALTER TABLE [dbo].[Sala] CHECK CONSTRAINT [CHK_Caracteristicas_Especiales]
GO
USE [master]
GO
ALTER DATABASE [Capacitaciones] SET  READ_WRITE 
GO
