﻿USE [master]
GO
/****** Object:  Database [FIAS_622]    Script Date: 01.07.2020 10:18:07 ******/
CREATE DATABASE [FIAS_622]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FIAS_622', FILENAME = N'V:\FIAS\FIAS_622.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FIAS_622_log', FILENAME = N'V:\FIAS\FIAS_622_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FIAS_622] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FIAS_622].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FIAS_622] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FIAS_622] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FIAS_622] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FIAS_622] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FIAS_622] SET ARITHABORT OFF 
GO
ALTER DATABASE [FIAS_622] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FIAS_622] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FIAS_622] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FIAS_622] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FIAS_622] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FIAS_622] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FIAS_622] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FIAS_622] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FIAS_622] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FIAS_622] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FIAS_622] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FIAS_622] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FIAS_622] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FIAS_622] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FIAS_622] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FIAS_622] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FIAS_622] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FIAS_622] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FIAS_622] SET  MULTI_USER 
GO
ALTER DATABASE [FIAS_622] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FIAS_622] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FIAS_622] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FIAS_622] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FIAS_622] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FIAS_622', N'ON'
GO
ALTER DATABASE [FIAS_622] SET QUERY_STORE = OFF
GO
USE [FIAS_622]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [FIAS_622]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01.07.2020 10:18:07 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACTSTAT]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTSTAT](
	[ACTSTATID] [smallint] NOT NULL,
	[NAME] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ACTSTAT] PRIMARY KEY CLUSTERED 
(
	[ACTSTATID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADDROBJ]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADDROBJ](
	[AOGUID] [uniqueidentifier] NOT NULL,
	[FORMALNAME] [nvarchar](120) NOT NULL,
	[REGIONCODE] [int] NOT NULL,
	[AUTOCODE] [int] NOT NULL,
	[AREACODE] [int] NOT NULL,
	[CITYCODE] [int] NOT NULL,
	[CTARCODE] [int] NOT NULL,
	[PLACECODE] [int] NOT NULL,
	[PLANCODE] [int] NOT NULL,
	[STREETCODE] [int] NULL,
	[EXTRCODE] [int] NOT NULL,
	[SEXTCODE] [int] NOT NULL,
	[OFFNAME] [nvarchar](120) NULL,
	[POSTALCODE] [int] NULL,
	[IFNSFL] [int] NULL,
	[TERRIFNSFL] [int] NULL,
	[IFNSUL] [int] NULL,
	[TERRIFNSUL] [int] NULL,
	[OKATO] [bigint] NULL,
	[OKTMO] [bigint] NULL,
	[UPDATEDATE] [date] NOT NULL,
	[SHORTNAMEID] [int] NOT NULL,
	[AOLEVEL] [bigint] NOT NULL,
	[PARENTGUID] [uniqueidentifier] NULL,
	[AOID] [uniqueidentifier] NOT NULL,
	[PREVID] [uniqueidentifier] NULL,
	[NEXTID] [uniqueidentifier] NULL,
	[CODE] [bigint] NULL,
	[PLAINCODE] [bigint] NULL,
	[ACTSTATUS] [bigint] NOT NULL,
	[CENTSTATUS] [bigint] NOT NULL,
	[OPERSTATUS] [bigint] NOT NULL,
	[CURRSTATUS] [bigint] NOT NULL,
	[STARTDATE] [date] NOT NULL,
	[ENDDATE] [date] NOT NULL,
	[NORMDOC] [uniqueidentifier] NULL,
	[LIVESTATUS] [tinyint] NOT NULL,
	[DIVTYPE] [int] NOT NULL,
 CONSTRAINT [PK_ADDROBJ] PRIMARY KEY CLUSTERED 
(
	[AOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CENTERST]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CENTERST](
	[NAME] [nvarchar](100) NOT NULL,
	[CENTERSTID] [smallint] NOT NULL,
 CONSTRAINT [PK_CENTERST] PRIMARY KEY CLUSTERED 
(
	[CENTERSTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CURENTST]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CURENTST](
	[CURENTSTID] [tinyint] NOT NULL,
	[NAME] [nvarchar](100) NULL,
 CONSTRAINT [PK_CURENTST] PRIMARY KEY CLUSTERED 
(
	[CURENTSTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTSTAT]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTSTAT](
	[ESTSTATID] [tinyint] NOT NULL,
	[NAME] [nvarchar](20) NOT NULL,
	[SHORTNAME] [nvarchar](20) NULL,
 CONSTRAINT [PK_ESTSTAT] PRIMARY KEY CLUSTERED 
(
	[ESTSTATID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FLATTYPE]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FLATTYPE](
	[FLTYPEID] [tinyint] NOT NULL,
	[NAME] [nvarchar](20) NOT NULL,
	[SHORTNAME] [nvarchar](20) NULL,
 CONSTRAINT [PK_FLATTYPE] PRIMARY KEY CLUSTERED 
(
	[FLTYPEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOUSE]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOUSE](
	[IFNSFL] [smallint] NULL,
	[TERRIFNSFL] [smallint] NULL,
	[IFNSUL] [smallint] NULL,
	[TERRIFNSUL] [smallint] NULL,
	[OKATO] [bigint] NULL,
	[OKTMO] [bigint] NULL,
	[UPDATEDATE] [date] NOT NULL,
	[ESTSTATUS] [smallint] NOT NULL,
	[STRUCNUM] [nvarchar](10) NULL,
	[STRSTATUS] [tinyint] NULL,
	[HOUSEID] [uniqueidentifier] NOT NULL,
	[HOUSEGUID] [uniqueidentifier] NOT NULL,
	[AOGUID] [uniqueidentifier] NOT NULL,
	[STARTDATE] [date] NOT NULL,
	[ENDDATE] [date] NOT NULL,
	[STATSTATUS] [bigint] NOT NULL,
	[NORMDOC] [uniqueidentifier] NULL,
	[COUNTER] [smallint] NOT NULL,
	[CADNUM] [nvarchar](100) NULL,
	[DIVTYPE] [tinyint] NOT NULL,
	[POSTALCODE] [int] NULL,
	[REGIONCODE] [tinyint] NULL,
	[HOUSENUM_IX] [int] NULL,
	[BUILDNUM_IX] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOUSE_BUILDNUM]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOUSE_BUILDNUM](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NULL,
 CONSTRAINT [PK_BLDNUM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOUSE_HOUSENUM]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOUSE_HOUSENUM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NULL,
 CONSTRAINT [PK_HOUSE_HOUSENUM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOUSEINT]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOUSEINT](
	[TERRIFNSUL] [nvarchar](4) NULL,
	[OKATO] [nvarchar](11) NULL,
	[OKTMO] [nvarchar](11) NULL,
	[UPDATEDATE] [date] NOT NULL,
	[INTSTART] [bigint] NOT NULL,
	[INTEND] [bigint] NOT NULL,
	[HOUSEINTID] [uniqueidentifier] NOT NULL,
	[INTGUID] [uniqueidentifier] NOT NULL,
	[AOGUID] [uniqueidentifier] NOT NULL,
	[STARTDATE] [date] NOT NULL,
	[ENDDATE] [date] NOT NULL,
	[INTSTATUS] [bigint] NOT NULL,
	[NORMDOC] [uniqueidentifier] NULL,
	[COUNTER] [bigint] NOT NULL,
	[IFNSUL] [nvarchar](4) NULL,
	[TERRIFNSFL] [nvarchar](4) NULL,
	[IFNSFL] [nvarchar](4) NULL,
	[POSTALCODE] [nvarchar](6) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HSTSTAT]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HSTSTAT](
	[HOUSESTID] [int] NOT NULL,
	[NAME] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_HSTSTAT] PRIMARY KEY CLUSTERED 
(
	[HOUSESTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INTVSTAT]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INTVSTAT](
	[INTVSTATID] [int] NOT NULL,
	[NAME] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_INTVSTAT] PRIMARY KEY CLUSTERED 
(
	[INTVSTATID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LANDMARK]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LANDMARK](
	[LOCATION] [nvarchar](500) NOT NULL,
	[POSTALCODE] [nvarchar](6) NULL,
	[IFNSFL] [nvarchar](4) NULL,
	[TERRIFNSFL] [nvarchar](4) NULL,
	[IFNSUL] [nvarchar](4) NULL,
	[TERRIFNSUL] [nvarchar](4) NULL,
	[OKATO] [nvarchar](11) NULL,
	[OKTMO] [nvarchar](11) NULL,
	[UPDATEDATE] [date] NOT NULL,
	[LANDID] [uniqueidentifier] NOT NULL,
	[LANDGUID] [uniqueidentifier] NOT NULL,
	[AOGUID] [uniqueidentifier] NOT NULL,
	[STARTDATE] [date] NOT NULL,
	[ENDDATE] [date] NOT NULL,
	[NORMDOC] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NDOCTYPE]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NDOCTYPE](
	[NDTYPEID] [smallint] NOT NULL,
	[NAME] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_NDOCTYPE] PRIMARY KEY CLUSTERED 
(
	[NDTYPEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NORMDOC]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NORMDOC](
	[NORMDOCID] [uniqueidentifier] NOT NULL,
	[DOCNAME] [nvarchar](max) NULL,
	[DOCDATE] [date] NULL,
	[DOCNUM] [nvarchar](20) NULL,
	[DOCTYPE] [smallint] NOT NULL,
	[DOCIMGID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_NORMDOC] PRIMARY KEY CLUSTERED 
(
	[NORMDOCID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OPERSTAT]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPERSTAT](
	[OPERSTATID] [tinyint] NOT NULL,
	[NAME] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_OPERSTAT] PRIMARY KEY CLUSTERED 
(
	[OPERSTATID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROOM]    Script Date: 01.07.2020 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROOM](
	[ROOMGUID] [uniqueidentifier] NOT NULL,
	[FLATNUMBER] [nvarchar](50) NOT NULL,
	[FLATTYPE] [int] NOT NULL,
	[ROOMNUMBER] [nvarchar](50) NULL,
	[ROOMTYPE] [int] NULL,
	[REGIONCODE] [int] NOT NULL,
	[POSTALCODE] [int] NULL,
	[UPDATEDATE] [date] NOT NULL,
	[HOUSEGUID] [uniqueidentifier] NOT NULL,
	[ROOMID] [uniqueidentifier] NOT NULL,
	[PREVID] [uniqueidentifier] NULL,
	[NEXTID] [uniqueidentifier] NULL,
	[STARTDATE] [date] NOT NULL,
	[ENDDATE] [date] NOT NULL,
	[LIVESTATUS] [tinyint] NOT NULL,
	[NORMDOC] [uniqueidentifier] NULL,
	[OPERSTATUS] [bigint] NOT NULL,
	[CADNUM] [nvarchar](100) NULL,
	[ROOMCADNUM] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROOMTYPE]    Script Date: 01.07.2020 10:18:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROOMTYPE](
	[SHORTNAME] [nvarchar](20) NULL,
	[RMTYPEID] [tinyint] NOT NULL,
	[NAME] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ROOMTYPE] PRIMARY KEY CLUSTERED 
(
	[RMTYPEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SOCRBASE]    Script Date: 01.07.2020 10:18:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOCRBASE](
	[LEVEL] [smallint] NOT NULL,
	[SCNAME] [nvarchar](10) NULL,
	[SOCRNAME] [nvarchar](50) NOT NULL,
	[KOD_T_ST] [smallint] NOT NULL,
 CONSTRAINT [PK_SOCRBASE] PRIMARY KEY CLUSTERED 
(
	[KOD_T_ST] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STEAD]    Script Date: 01.07.2020 10:18:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STEAD](
	[STEADGUID] [uniqueidentifier] NOT NULL,
	[NUMBER] [nvarchar](120) NULL,
	[REGIONCODE] [int] NOT NULL,
	[POSTALCODE] [int] NULL,
	[IFNSFL] [int] NULL,
	[TERRIFNSFL] [int] NULL,
	[IFNSUL] [int] NULL,
	[TERRIFNSUL] [int] NULL,
	[OKATO] [bigint] NULL,
	[OKTMO] [bigint] NULL,
	[UPDATEDATE] [date] NOT NULL,
	[PARENTGUID] [uniqueidentifier] NULL,
	[STEADID] [uniqueidentifier] NOT NULL,
	[PREVID] [uniqueidentifier] NULL,
	[NEXTID] [uniqueidentifier] NULL,
	[OPERSTATUS] [bigint] NOT NULL,
	[STARTDATE] [date] NOT NULL,
	[ENDDATE] [date] NOT NULL,
	[NORMDOC] [uniqueidentifier] NULL,
	[LIVESTATUS] [tinyint] NOT NULL,
	[CADNUM] [nvarchar](100) NULL,
	[DIVTYPE] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STRSTAT]    Script Date: 01.07.2020 10:18:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STRSTAT](
	[STRSTATID] [tinyint] NOT NULL,
	[NAME] [nvarchar](20) NOT NULL,
	[SHORTNAME] [nvarchar](20) NULL,
 CONSTRAINT [PK_STRSTAT] PRIMARY KEY CLUSTERED 
(
	[STRSTATID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [FIAS_622] SET  READ_WRITE 
GO