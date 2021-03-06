USE [master]
GO
/****** Object:  Database [kanbandb]    Script Date: 3/19/2020 4:31:25 PM ******/
CREATE DATABASE [kanbandb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kanbandb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\kanbandb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kanbandb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\kanbandb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kanbandb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kanbandb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kanbandb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kanbandb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kanbandb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kanbandb] SET ARITHABORT OFF 
GO
ALTER DATABASE [kanbandb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kanbandb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kanbandb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kanbandb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kanbandb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kanbandb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kanbandb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kanbandb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kanbandb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kanbandb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kanbandb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kanbandb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kanbandb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kanbandb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kanbandb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kanbandb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kanbandb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kanbandb] SET RECOVERY FULL 
GO
ALTER DATABASE [kanbandb] SET  MULTI_USER 
GO
ALTER DATABASE [kanbandb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kanbandb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kanbandb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kanbandb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kanbandb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'kanbandb', N'ON'
GO
ALTER DATABASE [kanbandb] SET QUERY_STORE = OFF
GO
USE [kanbandb]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/19/2020 4:31:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 3/19/2020 4:31:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OwnerId] [int] NULL,
	[StartDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[TaskStatuts] [nvarchar](50) NULL,
	[Priority] [int] NULL,
	[Completion] [int] NULL,
	[AssignedEmployeeId] [int] NULL,
	[IndexTask] [float] NULL,
	[ListId] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskList]    Script Date: 3/19/2020 4:31:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaskListToDo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (1, N'John')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (2, N'San')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (3, N'Vu')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (4, N'Nhan')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (5, N'Duy')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (6, N'Cuong')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (7, N'Tinh')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (8, N'Thinh')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (9, N'Luu')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (10, N'Cong')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (11, N'Trong')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (12, N'Truong')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (13, N'Ki')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (14, N'Khang')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (15, N'Chien')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (16, N'Nhat')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (17, N'Dinh')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (18, N'Thang')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (19, N'Loi')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (20, N'Huyen')
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (1, N'Create Report on Customer Feedback', 1, CAST(N'2016-05-06T00:00:00.000' AS DateTime), NULL, N'Backlog', 2, 50, 2, 1, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (3, N'Refund Request Template', 2, CAST(N'2016-05-06T00:00:00.000' AS DateTime), CAST(N'2016-05-10T00:00:00.000' AS DateTime), N'Backlog', 2, 50, 4, 3.25, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (4, N'Overtime Approval Guidelines', 2, CAST(N'2016-05-06T00:00:00.000' AS DateTime), CAST(N'2016-05-10T00:00:00.000' AS DateTime), N'Backlog', 2, 50, 12, 2.25, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (5, N'Refund Request Template', 1, CAST(N'2016-05-06T00:00:00.000' AS DateTime), NULL, N'Backlog', 2, 50, 2, 0.75, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (6, N'Overtime Approval Guidelines', 2, CAST(N'2016-05-06T00:00:00.000' AS DateTime), CAST(N'2016-05-10T00:00:00.000' AS DateTime), N'Backlog', 2, 50, 7, 1.25, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (7, N'Submit Overtime Request Forms', 2, CAST(N'2016-05-06T00:00:00.000' AS DateTime), CAST(N'2016-05-10T00:00:00.000' AS DateTime), N'Backlog', 2, 50, 8, 1.09375, 2)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (10, N'anh dynhasdnhandja', 1, CAST(N'2020-03-18T16:59:59.353' AS DateTime), CAST(N'2020-03-28T09:59:00.000' AS DateTime), NULL, NULL, NULL, 2, 2.75, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (12, N'Submit Customer Follow Up Plan Feedback', 1, CAST(N'2020-03-18T17:51:12.273' AS DateTime), NULL, N'Backlog', 2, 50, 2, 0.125, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (15, N'new', 1, CAST(N'2020-03-19T09:20:27.610' AS DateTime), NULL, NULL, NULL, NULL, 2, 3.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (16, N'vnew new', 1, CAST(N'2020-03-19T09:23:31.620' AS DateTime), CAST(N'2020-03-28T02:22:00.000' AS DateTime), NULL, NULL, NULL, 2, 0.1875, 1)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (17, N'qwewqeqweqweqwe', 1, CAST(N'2020-03-19T09:24:54.667' AS DateTime), NULL, NULL, NULL, NULL, 2, 4.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (18, N'a123123123', 1, CAST(N'2020-03-19T09:26:53.837' AS DateTime), CAST(N'2020-03-28T02:26:00.000' AS DateTime), NULL, NULL, NULL, 2, 5.5, 3)
INSERT [dbo].[Task] ([Id], [Name], [OwnerId], [StartDate], [DueDate], [TaskStatuts], [Priority], [Completion], [AssignedEmployeeId], [IndexTask], [ListId]) VALUES (21, N'hahakjghsdkj ', 1, CAST(N'2020-03-19T16:11:02.207' AS DateTime), CAST(N'2020-03-28T09:10:00.000' AS DateTime), NULL, NULL, NULL, 2, 0.375, 1)
SET IDENTITY_INSERT [dbo].[Task] OFF
SET IDENTITY_INSERT [dbo].[TaskList] ON 

INSERT [dbo].[TaskList] ([Id], [Name]) VALUES (1, N'Backlog')
INSERT [dbo].[TaskList] ([Id], [Name]) VALUES (2, N'Resolved')
INSERT [dbo].[TaskList] ([Id], [Name]) VALUES (3, N'Closed')
SET IDENTITY_INSERT [dbo].[TaskList] OFF
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Employee] FOREIGN KEY([AssignedEmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Employee]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Owner] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Owner]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_TaskList] FOREIGN KEY([ListId])
REFERENCES [dbo].[TaskList] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_TaskList]
GO
USE [master]
GO
ALTER DATABASE [kanbandb] SET  READ_WRITE 
GO
