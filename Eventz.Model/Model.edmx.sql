
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/20/2013 13:17:04
-- Generated from EDMX file: F:\Eventz\Platform\Events\Eventz.Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Events];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EventVenue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_EventVenue];
GO
IF OBJECT_ID(N'[dbo].[FK_EventCategory_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventCategory] DROP CONSTRAINT [FK_EventCategory_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_EventCategory_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventCategory] DROP CONSTRAINT [FK_EventCategory_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_Eventimage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Eventimage];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Venues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Venues];
GO
IF OBJECT_ID(N'[dbo].[UpdateLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UpdateLogs];
GO
IF OBJECT_ID(N'[dbo].[Storages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Storages];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[EventCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventCategory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(500)  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [EventUrl] nvarchar(2083)  NULL,
    [State] tinyint  NOT NULL,
    [AttendingCount] int  NULL,
    [VenueId] int  NULL,
    [VenueId1] int  NULL,
    [Version] tinyint  NOT NULL
);
GO

-- Creating table 'Venues'
CREATE TABLE [dbo].[Venues] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(256)  NULL,
    [Phone] nvarchar(20)  NULL,
    [Lon] float  NULL,
    [Lat] float  NULL,
    [Street] nvarchar(256)  NULL,
    [State] nvarchar(256)  NULL,
    [City] nvarchar(256)  NULL,
    [Country] nvarchar(256)  NULL,
    [Zip] nvarchar(256)  NULL
);
GO

-- Creating table 'UpdateLogs'
CREATE TABLE [dbo].[UpdateLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StorageType] tinyint  NOT NULL,
    [UpdateType] tinyint  NOT NULL,
    [Time] datetime  NOT NULL
);
GO

-- Creating table 'Storages'
CREATE TABLE [dbo].[Storages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StorageType] tinyint  NOT NULL,
    [LastUpdatedWeek] datetime  NOT NULL,
    [LastUpdatedClosest] datetime  NOT NULL,
    [LastUpdatedToday] datetime  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FilePath] nvarchar(max)  NOT NULL,
    [Type] tinyint  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [EventId] bigint  NOT NULL
);
GO

-- Creating table 'EventCategory'
CREATE TABLE [dbo].[EventCategory] (
    [Events_Id] bigint  NOT NULL,
    [Categories_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Venues'
ALTER TABLE [dbo].[Venues]
ADD CONSTRAINT [PK_Venues]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UpdateLogs'
ALTER TABLE [dbo].[UpdateLogs]
ADD CONSTRAINT [PK_UpdateLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Storages'
ALTER TABLE [dbo].[Storages]
ADD CONSTRAINT [PK_Storages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Events_Id], [Categories_Id] in table 'EventCategory'
ALTER TABLE [dbo].[EventCategory]
ADD CONSTRAINT [PK_EventCategory]
    PRIMARY KEY NONCLUSTERED ([Events_Id], [Categories_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [VenueId1] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_EventVenue]
    FOREIGN KEY ([VenueId1])
    REFERENCES [dbo].[Venues]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EventVenue'
CREATE INDEX [IX_FK_EventVenue]
ON [dbo].[Events]
    ([VenueId1]);
GO

-- Creating foreign key on [Events_Id] in table 'EventCategory'
ALTER TABLE [dbo].[EventCategory]
ADD CONSTRAINT [FK_EventCategory_Event]
    FOREIGN KEY ([Events_Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Categories_Id] in table 'EventCategory'
ALTER TABLE [dbo].[EventCategory]
ADD CONSTRAINT [FK_EventCategory_Category]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EventCategory_Category'
CREATE INDEX [IX_FK_EventCategory_Category]
ON [dbo].[EventCategory]
    ([Categories_Id]);
GO

-- Creating foreign key on [EventId] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_Eventimage]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Eventimage'
CREATE INDEX [IX_FK_Eventimage]
ON [dbo].[Images]
    ([EventId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------