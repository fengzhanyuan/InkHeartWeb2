
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/06/2017 12:12:21
-- Generated from EDMX file: E:\InkHeartWeb\InkHeart.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InkHeartWeb_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Book]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Book];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Book'
CREATE TABLE [dbo].[Book] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [BookName] nvarchar(20)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [body] varchar(max)  NOT NULL,
    [Author] nvarchar(20)  NOT NULL,
    [Price] decimal(19,4)  NOT NULL,
    [Type] nvarchar(50)  NOT NULL,
    [Character] nvarchar(50)  NOT NULL,
    [Grade] int  NOT NULL,
    [Focus_count] int  NOT NULL,
    [Comment_count] int  NOT NULL,
    [Word_count] bigint  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [GroupId] int  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [ImageCover] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [Age] int  NOT NULL,
    [LogName] nvarchar(20)  NOT NULL,
    [LogTime] datetime  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [PhoneNumber] nvarchar(20)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Birthday] datetime  NULL,
    [State] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Book'
ALTER TABLE [dbo].[Book]
ADD CONSTRAINT [PK_Book]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------