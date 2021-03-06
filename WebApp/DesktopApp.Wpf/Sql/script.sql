USE [master]
GO
/****** Object:  Database [sebicu]    Script Date: 1/4/2019 7:53:18 PM ******/
CREATE DATABASE [sebicu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sebicu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\sebicu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'sebicu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\sebicu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [sebicu] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sebicu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sebicu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sebicu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sebicu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sebicu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sebicu] SET ARITHABORT OFF 
GO
ALTER DATABASE [sebicu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sebicu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sebicu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sebicu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sebicu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sebicu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sebicu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sebicu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sebicu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sebicu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sebicu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sebicu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sebicu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sebicu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sebicu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sebicu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sebicu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sebicu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sebicu] SET  MULTI_USER 
GO
ALTER DATABASE [sebicu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sebicu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sebicu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sebicu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sebicu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [sebicu] SET QUERY_STORE = OFF
GO
USE [sebicu]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 1/4/2019 7:53:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[categ_id] [float] NOT NULL,
	[tip] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[categ_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 1/4/2019 7:53:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[ingred_id] [float] NOT NULL,
	[ingredient] [varchar](255) NOT NULL,
 CONSTRAINT [PK__Ingredie__54320D999CACB6B3] PRIMARY KEY CLUSTERED 
(
	[ingred_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reteta]    Script Date: 1/4/2019 7:53:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reteta](
	[reteta_id] [float] NOT NULL,
	[nume] [varchar](255) NULL,
	[descriere] [varchar](255) NULL,
	[categ_id] [float] NULL,
	[vegetariana] [varchar](1) NULL,
	[timp_preparare] [float] NULL,
	[portii] [int] NULL,
	[sursa] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[reteta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Set_ingrediente]    Script Date: 1/4/2019 7:53:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Set_ingrediente](
	[reteta_id] [float] NOT NULL,
	[ingred_id] [float] NOT NULL,
	[cantitate] [float] NULL,
	[um] [varchar](5) NULL,
	[comentarii] [varchar](255) NULL,
 CONSTRAINT [PK__Set_ingr__7A2941CCE371F6EC] PRIMARY KEY CLUSTERED 
(
	[reteta_id] ASC,
	[ingred_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Categorie] ([categ_id], [tip]) VALUES (1, N'Aperitive')
INSERT [dbo].[Categorie] ([categ_id], [tip]) VALUES (2, N'Salate')
INSERT [dbo].[Categorie] ([categ_id], [tip]) VALUES (3, N'Desert')
INSERT [dbo].[Categorie] ([categ_id], [tip]) VALUES (4, N'Cu carne')
INSERT [dbo].[Categorie] ([categ_id], [tip]) VALUES (5, N'Ciorba')
INSERT [dbo].[Categorie] ([categ_id], [tip]) VALUES (6, N'Supa')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (1, N'bucati de vita')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (2, N'ulei')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (3, N'usturoi')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (4, N'cartofi')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (5, N'Lapte')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (6, N'morcovi')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (7, N'miel')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (8, N'ciuperci')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (9, N'piept de pui')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (10, N'pesmet')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (12, N'parmezan')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (13, N'carne')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (15, N'salata')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (16, N'ardei')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (18, N'zahar')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (19, N'avocado')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (20, N'mure')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (23, N'ciocolata')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (25, N'foietaj')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (26, N'merisoare')
INSERT [dbo].[Ingredient] ([ingred_id], [ingredient]) VALUES (27, N'crosata')
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (1, N'Vita', N'La cuptor', 4, N'N', 54, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (2, N'Tocanita', N'La cuptor', 4, N'N', 12, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (3, N'Miel in sos', N'La cuptor', 4, N'N', 14, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (4, N'Frigarui la gratar', N'La cuptor', 4, N'N', 33, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (5, N'Pissaladiere', N'La cuptor', 1, N'N', 31, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (6, N'Pita la gratar', N'La gratar', 1, N'N', 76, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (7, N'Degete de pui', N'La cuptor', 1, N'N', 45, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (8, N'Salata de ardei copti', N'La plita', 2, N'D', 30, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (9, N'Morcovi marinati', N'La rece', 2, N'D', 30, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (10, N'Salata de avocado', N'La rece', 2, N'D', 34, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (11, N'Crostata cu sos de merisoare', N'La rece/plita', 3, N'D', 87, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (12, N'Prajitura cu mure si mousse de iaurt', N'La rece', 3, N'D', 30, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (13, N'Brownie cu ciocolata', N'Cuptor', 3, N'D', 54, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (14, N'Cremes Carpati', N'La rece/plita', 3, N'D', 30, 4, NULL)
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (15, N'Ciorba de varza', N'La oala', 5, N'D', 28, 3, N'asdf')
INSERT [dbo].[Reteta] ([reteta_id], [nume], [descriere], [categ_id], [vegetariana], [timp_preparare], [portii], [sursa]) VALUES (16, N'Ciorba de lacrimioara', N'La oala', 5, N'D', 29, 6, N'asdf')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (1, 1, 400, N'gr', N'bucati de vita')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (1, 2, 100, N'ml', N'ulei')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (1, 3, 400, N'gr', N'usturoi')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (2, 1, 400, N'gr', NULL)
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (2, 4, 1000, N'gr', N'cartofi')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (2, 5, 500, N'ml', N'lapte')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (2, 6, 300, N'gr', N'morcovi')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (3, 7, 400, N'gr', N'miel')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (3, 8, 10, N'gr', NULL)
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (4, 9, 600, N'gr', N'piept de pui')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (4, 10, 300, N'gr', N'pesmet')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (4, 12, 100, N'gr', N'parmezan')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (4, 28, 300, N'gr', NULL)
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (6, 13, 400, N'gr', N'carne')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (6, 15, 400, N'gr', N'salata')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (6, 29, 300, N'gr', NULL)
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (8, 16, 400, N'gr', N'ardei')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (8, 17, 10, N'gr', NULL)
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (10, 19, 400, N'gr', N'avocado')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (11, 26, 400, N'gr', N'merisoare')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (11, 27, 400, N'gr', N'crosata')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (12, 20, 400, N'gr', N'mure')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (13, 23, 500, N'gr', N'ciocolata')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (14, 18, 400, N'gr', N'zahar')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (14, 25, 200, N'gr', N'foietaj')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (15, 3, 500, N'gr', N'usturoi in ciorba')
INSERT [dbo].[Set_ingrediente] ([reteta_id], [ingred_id], [cantitate], [um], [comentarii]) VALUES (16, 3, 12500, N'gr', N'asta e max de usturoi')
ALTER TABLE [dbo].[Reteta]  WITH CHECK ADD FOREIGN KEY([categ_id])
REFERENCES [dbo].[Categorie] ([categ_id])
GO
ALTER TABLE [dbo].[Set_ingrediente]  WITH CHECK ADD  CONSTRAINT [FK__Set_ingre__retet__412EB0B6] FOREIGN KEY([reteta_id])
REFERENCES [dbo].[Reteta] ([reteta_id])
GO
ALTER TABLE [dbo].[Set_ingrediente] CHECK CONSTRAINT [FK__Set_ingre__retet__412EB0B6]
GO
USE [master]
GO
ALTER DATABASE [sebicu] SET  READ_WRITE 
GO
