USE [master]
GO
/****** Object:  Database [TuristickaAgencija]    Script Date: 11/29/2020 10:22:39 PM ******/
CREATE DATABASE [TuristickaAgencija]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TuristickaAgencija', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TuristickaAgencija.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TuristickaAgencija_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TuristickaAgencija_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TuristickaAgencija] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TuristickaAgencija].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TuristickaAgencija] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET ARITHABORT OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TuristickaAgencija] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TuristickaAgencija] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TuristickaAgencija] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TuristickaAgencija] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TuristickaAgencija] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TuristickaAgencija] SET  MULTI_USER 
GO
ALTER DATABASE [TuristickaAgencija] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TuristickaAgencija] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TuristickaAgencija] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TuristickaAgencija] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TuristickaAgencija]
GO
/****** Object:  Table [dbo].[tblBooking]    Script Date: 11/29/2020 10:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBooking](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[NumberOfPassengers] [int] NOT NULL,
	[HotelID] [int] NOT NULL,
	[ReservationDate] [smalldatetime] NOT NULL,
	[TransportID] [int] NOT NULL,
	[TotalPrice] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK_tblBooking] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 11/29/2020 10:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[NameSurname] [nvarchar](30) NOT NULL,
	[JMBG] [nvarchar](13) NOT NULL,
	[City] [nvarchar](20) NULL,
	[Adress] [nvarchar](20) NULL,
	[Contact] [nvarchar](15) NOT NULL,
	[CardNumber] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDestination]    Script Date: 11/29/2020 10:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDestination](
	[DestinationID] [int] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](20) NOT NULL,
	[City] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tblDestination] PRIMARY KEY CLUSTERED 
(
	[DestinationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblEmployee]    Script Date: 11/29/2020 10:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[OUID] [int] NOT NULL,
	[NameSurnameE] [nvarchar](40) NOT NULL,
	[IdentificationNumber] [nvarchar](13) NOT NULL,
	[City] [nvarchar](30) NULL,
	[Adress] [nvarchar](30) NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tblEmployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblHotel]    Script Date: 11/29/2020 10:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHotel](
	[HotelID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Adress] [nvarchar](30) NOT NULL,
	[RoomNumber] [int] NOT NULL,
	[Contact] [nvarchar](20) NOT NULL,
	[PricePerNight] [numeric](10, 2) NOT NULL,
	[DestinationID] [int] NOT NULL,
 CONSTRAINT [PK_tblHotel] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOrganisationUnit]    Script Date: 11/29/2020 10:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrganisationUnit](
	[OUID] [int] IDENTITY(1,1) NOT NULL,
	[NameOfUnit] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tblOrganisationUnit] PRIMARY KEY CLUSTERED 
(
	[OUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTicket]    Script Date: 11/29/2020 10:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTicket](
	[TicketID] [int] IDENTITY(1,1) NOT NULL,
	[Destination] [nvarchar](20) NOT NULL,
	[SeatNumber] [nvarchar](5) NOT NULL,
	[TicketPrice] [decimal](10, 0) NOT NULL,
	[Timetable] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_tblTicket] PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTransport]    Script Date: 11/29/2020 10:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransport](
	[TransportID] [int] IDENTITY(1,1) NOT NULL,
	[TicketID] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_tblTransport] PRIMARY KEY CLUSTERED 
(
	[TransportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTypeOfTransport]    Script Date: 11/29/2020 10:22:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTypeOfTransport](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tblTypeOfTransport] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblBooking]  WITH CHECK ADD  CONSTRAINT [FK_tblBooking_tblCustomer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tblCustomer] ([CustomerID])
GO
ALTER TABLE [dbo].[tblBooking] CHECK CONSTRAINT [FK_tblBooking_tblCustomer]
GO
ALTER TABLE [dbo].[tblBooking]  WITH CHECK ADD  CONSTRAINT [FK_tblBooking_tblEmployee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[tblEmployee] ([EmployeeID])
GO
ALTER TABLE [dbo].[tblBooking] CHECK CONSTRAINT [FK_tblBooking_tblEmployee]
GO
ALTER TABLE [dbo].[tblBooking]  WITH CHECK ADD  CONSTRAINT [FK_tblBooking_tblHotel] FOREIGN KEY([HotelID])
REFERENCES [dbo].[tblHotel] ([HotelID])
GO
ALTER TABLE [dbo].[tblBooking] CHECK CONSTRAINT [FK_tblBooking_tblHotel]
GO
ALTER TABLE [dbo].[tblBooking]  WITH CHECK ADD  CONSTRAINT [FK_tblBooking_tblTransport] FOREIGN KEY([TransportID])
REFERENCES [dbo].[tblTransport] ([TransportID])
GO
ALTER TABLE [dbo].[tblBooking] CHECK CONSTRAINT [FK_tblBooking_tblTransport]
GO
ALTER TABLE [dbo].[tblEmployee]  WITH CHECK ADD  CONSTRAINT [FK_tblEmployee_tblOrganisationUnit] FOREIGN KEY([OUID])
REFERENCES [dbo].[tblOrganisationUnit] ([OUID])
GO
ALTER TABLE [dbo].[tblEmployee] CHECK CONSTRAINT [FK_tblEmployee_tblOrganisationUnit]
GO
ALTER TABLE [dbo].[tblHotel]  WITH CHECK ADD  CONSTRAINT [FK_tblHotel_tblDestination] FOREIGN KEY([DestinationID])
REFERENCES [dbo].[tblDestination] ([DestinationID])
GO
ALTER TABLE [dbo].[tblHotel] CHECK CONSTRAINT [FK_tblHotel_tblDestination]
GO
ALTER TABLE [dbo].[tblTransport]  WITH CHECK ADD  CONSTRAINT [FK_tblTransport_tblTicket] FOREIGN KEY([TicketID])
REFERENCES [dbo].[tblTicket] ([TicketID])
GO
ALTER TABLE [dbo].[tblTransport] CHECK CONSTRAINT [FK_tblTransport_tblTicket]
GO
ALTER TABLE [dbo].[tblTransport]  WITH CHECK ADD  CONSTRAINT [FK_tblTransport_tblTypeOfTransport] FOREIGN KEY([TypeID])
REFERENCES [dbo].[tblTypeOfTransport] ([TypeID])
GO
ALTER TABLE [dbo].[tblTransport] CHECK CONSTRAINT [FK_tblTransport_tblTypeOfTransport]
GO
USE [master]
GO
ALTER DATABASE [TuristickaAgencija] SET  READ_WRITE 
GO
