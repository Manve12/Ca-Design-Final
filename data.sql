USE [master]
GO
/****** Object:  Database [StoreGraphRenderer]    Script Date: 07/11/2018 08:56:44 ******/
CREATE DATABASE [StoreGraphRenderer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreGraphRenderer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StoreGraphRenderer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StoreGraphRenderer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StoreGraphRenderer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StoreGraphRenderer] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreGraphRenderer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreGraphRenderer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreGraphRenderer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreGraphRenderer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StoreGraphRenderer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreGraphRenderer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET RECOVERY FULL 
GO
ALTER DATABASE [StoreGraphRenderer] SET  MULTI_USER 
GO
ALTER DATABASE [StoreGraphRenderer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreGraphRenderer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreGraphRenderer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreGraphRenderer] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StoreGraphRenderer] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StoreGraphRenderer', N'ON'
GO
ALTER DATABASE [StoreGraphRenderer] SET QUERY_STORE = OFF
GO
USE [StoreGraphRenderer]
GO
/****** Object:  Table [dbo].[SampleData]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SampleData](
	[StoreID] [varchar](50) NULL,
	[TotalSalesWeeks13] [varchar](50) NULL,
	[TotalVolumeWeeks13] [varchar](50) NULL,
	[AverageProfitWeeks13] [varchar](50) NULL,
	[WeekCounter13] [varchar](50) NULL,
	[TotalSalesWeeks52] [varchar](50) NULL,
	[TotalVolumeWeeks52] [varchar](50) NULL,
	[AverageProfitWeeks52] [varchar](50) NULL,
	[WeekCounter52] [varchar](50) NULL,
	[Bay] [varchar](50) NULL,
	[FloorName] [varchar](50) NULL,
	[ClusterGroupID] [varchar](50) NULL,
	[ClusterID] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_BayGetProfits]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_BayGetProfits]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT,
@Bay INT
AS
SELECT AverageProfitWeeks13,AverageProfitWeeks52 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND Bay = @Bay AND ClusterID = @ClusterID
GO
/****** Object:  StoredProcedure [dbo].[sp_BayGetSales]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_BayGetSales]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT,
@Bay INT
AS
SELECT TotalSalesWeeks13,TotalSalesWeeks52 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND Bay = @Bay AND ClusterID = @ClusterID
GO
/****** Object:  StoredProcedure [dbo].[sp_BayGetVolume]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_BayGetVolume]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT,
@Bay INT
AS
SELECT TotalVolumeWeeks13,TotalVolumeWeeks52 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND Bay = @Bay AND ClusterID = @ClusterID
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAverageProfit]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAverageProfit]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT
AS
SELECT AverageProfitWeeks13, WeekCounter13, AverageProfitWeeks52, WeekCounter52 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND ClusterID = @ClusterID
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAverageProfitPerBay]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAverageProfitPerBay]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT
AS
SELECT AverageProfitWeeks13, Bay, AverageProfitWeeks52 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND ClusterID = @ClusterID
ORDER BY CONVERT(int,Bay) ASC
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBay]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetBay]
@StoreID INT,
@ClusterID INT,
@FloorName NVARCHAR(50)
AS
SELECT DISTINCT Bay FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND ClusterID = @ClusterID ORDER BY Bay ASC
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRegionLocationSize]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetRegionLocationSize]
	@SelectedRegion INT = NULL,
	@SelectedLocation INT = NULL,
	@SelectedSize INT = NULL
AS
	
	SELECT * FROM SampleData
	WHERE 
		ClusterID = @SelectedRegion
	UNION 
	SELECT * FROM SampleData
	WHERE 
		ClusterID = @SelectedLocation
	UNION
	SELECT * FROM SampleData
	WHERE 
		ClusterID = @SelectedSize
	
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStoreFloors]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetStoreFloors]
@StoreID NVARCHAR(50)
AS
SELECT DISTINCT FloorName FROM SampleData WHERE StoreID = @StoreID ORDER BY FloorName
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStoreIDs]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetStoreIDs]

AS
SELECT DISTINCT StoreID FROM SampleData ORDER BY StoreID
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalSales]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetTotalSales]
@StoreID INT,
@ClusterID INT,
@FloorName NVARCHAR(50)
AS

SELECT DISTINCT TotalSalesWeeks13, WeekCounter13,TotalSalesWeeks52, WeekCounter52 FROM SampleData WHERE StoreID = @StoreID AND ClusterID = @ClusterID AND FloorName = @FloorName
ORDER BY WeekCounter13
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalSalesPerBay]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTotalSalesPerBay]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT
AS
SELECT TotalSalesWeeks13, Bay, TotalSalesWeeks52 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND ClusterID = @ClusterID
ORDER BY CONVERT(INT,Bay) ASC
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalSalesProfitPerBay]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTotalSalesProfitPerBay]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT,
@Bay INT
AS
SELECT TotalSalesWeeks13, AverageProfitWeeks13 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND ClusterID = @ClusterID AND Bay = @Bay
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalSalesVolumeProfitPerBay]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTotalSalesVolumeProfitPerBay]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT,
@Bay INT
AS
SELECT TotalSalesWeeks13, TotalVolumeWeeks13, AverageProfitWeeks13 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND ClusterID = @ClusterID AND Bay = @Bay
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalVolume]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetTotalVolume]
@StoreID INT,
@ClusterID INT,
@FloorName NVARCHAR(50)
AS

SELECT DISTINCT TotalVolumeWeeks13, WeekCounter13,TotalVolumeWeeks52, WeekCounter52 FROM SampleData WHERE StoreID = @StoreID AND ClusterID = @ClusterID AND FloorName = @FloorName
ORDER BY WeekCounter13
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalVolumePerBay]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTotalVolumePerBay]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT
AS
SELECT TotalVolumeWeeks13, Bay, TotalVolumeWeeks52 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND ClusterID = @ClusterID
ORDER BY CONVERT(INT, Bay) ASC
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalVolumeProfitPerBay]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTotalVolumeProfitPerBay]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT,
@Bay INT
AS
SELECT TotalVolumeWeeks13, AverageProfitWeeks13 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND ClusterID = @ClusterID AND Bay = @Bay
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTotalVolumeSalesPerBay]    Script Date: 07/11/2018 08:56:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTotalVolumeSalesPerBay]
@StoreID INT,
@FloorName NVARCHAR(50),
@ClusterID INT,
@Bay INT
AS
SELECT TotalSalesWeeks13, TotalVolumeWeeks13 FROM SampleData WHERE StoreID = @StoreID AND FloorName = @FloorName AND ClusterID = @ClusterID AND Bay = @Bay
GO
USE [master]
GO
ALTER DATABASE [StoreGraphRenderer] SET  READ_WRITE 
GO
