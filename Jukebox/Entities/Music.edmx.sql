
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2013 22:43:58
-- Generated from EDMX file: C:\Users\Julio Garcia\Desktop\Jukebox\Jukebox\Entities\Music.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [jukebox];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccountSong_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountSong] DROP CONSTRAINT [FK_AccountSong_Account];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountSong_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountSong] DROP CONSTRAINT [FK_AccountSong_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountPlaylist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Playlists] DROP CONSTRAINT [FK_AccountPlaylist];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_AccountRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_RoomAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomSong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Songs] DROP CONSTRAINT [FK_RoomSong];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Songs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Songs];
GO
IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[Playlists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Playlists];
GO
IF OBJECT_ID(N'[dbo].[AccountSong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountSong];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Songs'
CREATE TABLE [dbo].[Songs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Length] nvarchar(max)  NOT NULL,
    [FilePath] nvarchar(max)  NOT NULL,
    [Artist] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Album] nvarchar(max)  NOT NULL,
    [Room_Id] int  NULL
);
GO

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [LoginId] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [RoomId] int  NULL,
    [Room_Id] int  NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoomName] nvarchar(max)  NOT NULL,
    [RoomPassword] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Playlists'
CREATE TABLE [dbo].[Playlists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Account_LoginId] int  NOT NULL
);
GO

-- Creating table 'AccountSong'
CREATE TABLE [dbo].[AccountSong] (
    [Accounts_LoginId] int  NOT NULL,
    [Songs_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Songs'
ALTER TABLE [dbo].[Songs]
ADD CONSTRAINT [PK_Songs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([LoginId] ASC);
GO

-- Creating primary key on [Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Playlists'
ALTER TABLE [dbo].[Playlists]
ADD CONSTRAINT [PK_Playlists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Accounts_LoginId], [Songs_Id] in table 'AccountSong'
ALTER TABLE [dbo].[AccountSong]
ADD CONSTRAINT [PK_AccountSong]
    PRIMARY KEY CLUSTERED ([Accounts_LoginId], [Songs_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Accounts_LoginId] in table 'AccountSong'
ALTER TABLE [dbo].[AccountSong]
ADD CONSTRAINT [FK_AccountSong_Account]
    FOREIGN KEY ([Accounts_LoginId])
    REFERENCES [dbo].[Accounts]
        ([LoginId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Songs_Id] in table 'AccountSong'
ALTER TABLE [dbo].[AccountSong]
ADD CONSTRAINT [FK_AccountSong_Song]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[Songs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountSong_Song'
CREATE INDEX [IX_FK_AccountSong_Song]
ON [dbo].[AccountSong]
    ([Songs_Id]);
GO

-- Creating foreign key on [Account_LoginId] in table 'Playlists'
ALTER TABLE [dbo].[Playlists]
ADD CONSTRAINT [FK_AccountPlaylist]
    FOREIGN KEY ([Account_LoginId])
    REFERENCES [dbo].[Accounts]
        ([LoginId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountPlaylist'
CREATE INDEX [IX_FK_AccountPlaylist]
ON [dbo].[Playlists]
    ([Account_LoginId]);
GO

-- Creating foreign key on [Room_Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_AccountRoom]
    FOREIGN KEY ([Room_Id])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountRoom'
CREATE INDEX [IX_FK_AccountRoom]
ON [dbo].[Accounts]
    ([Room_Id]);
GO

-- Creating foreign key on [RoomId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_RoomAccount]
    FOREIGN KEY ([RoomId])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomAccount'
CREATE INDEX [IX_FK_RoomAccount]
ON [dbo].[Accounts]
    ([RoomId]);
GO

-- Creating foreign key on [Room_Id] in table 'Songs'
ALTER TABLE [dbo].[Songs]
ADD CONSTRAINT [FK_RoomSong]
    FOREIGN KEY ([Room_Id])
    REFERENCES [dbo].[Rooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomSong'
CREATE INDEX [IX_FK_RoomSong]
ON [dbo].[Songs]
    ([Room_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------