
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/21/2013 18:12:35
-- Generated from EDMX file: C:\Users\Julio Garcia\Desktop\Jukebox\Jukebox\Entities\Music.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Jukebox];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsersSong_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersSong] DROP CONSTRAINT [FK_UsersSong_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersSong_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsersSong] DROP CONSTRAINT [FK_UsersSong_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_SongAlbum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Songs] DROP CONSTRAINT [FK_SongAlbum];
GO
IF OBJECT_ID(N'[dbo].[FK_SongGenre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Songs] DROP CONSTRAINT [FK_SongGenre];
GO
IF OBJECT_ID(N'[dbo].[FK_SongArtist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Songs] DROP CONSTRAINT [FK_SongArtist];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Songs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Songs];
GO
IF OBJECT_ID(N'[dbo].[Artists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Artists];
GO
IF OBJECT_ID(N'[dbo].[Albums]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Albums];
GO
IF OBJECT_ID(N'[dbo].[Genres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genres];
GO
IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[UsersSong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersSong];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Songs'
CREATE TABLE [dbo].[Songs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sTitle] nvarchar(max)  NOT NULL,
    [sLength] nvarchar(max)  NOT NULL,
    [sFilePath] nvarchar(max)  NOT NULL,
    [Album_Id] int  NOT NULL,
    [Genre_Id] int  NOT NULL,
    [Artist_Id] int  NOT NULL
);
GO

-- Creating table 'Artists'
CREATE TABLE [dbo].[Artists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Albums'
CREATE TABLE [dbo].[Albums] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sTitle] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Genres'
CREATE TABLE [dbo].[Genres] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [LoginId] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersSong'
CREATE TABLE [dbo].[UsersSong] (
    [Users_LoginId] int  NOT NULL,
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

-- Creating primary key on [Id] in table 'Artists'
ALTER TABLE [dbo].[Artists]
ADD CONSTRAINT [PK_Artists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [PK_Albums]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [PK_Genres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([LoginId] ASC);
GO

-- Creating primary key on [Users_LoginId], [Songs_Id] in table 'UsersSong'
ALTER TABLE [dbo].[UsersSong]
ADD CONSTRAINT [PK_UsersSong]
    PRIMARY KEY CLUSTERED ([Users_LoginId], [Songs_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Users_LoginId] in table 'UsersSong'
ALTER TABLE [dbo].[UsersSong]
ADD CONSTRAINT [FK_UsersSong_Users]
    FOREIGN KEY ([Users_LoginId])
    REFERENCES [dbo].[Accounts]
        ([LoginId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Songs_Id] in table 'UsersSong'
ALTER TABLE [dbo].[UsersSong]
ADD CONSTRAINT [FK_UsersSong_Song]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[Songs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersSong_Song'
CREATE INDEX [IX_FK_UsersSong_Song]
ON [dbo].[UsersSong]
    ([Songs_Id]);
GO

-- Creating foreign key on [Album_Id] in table 'Songs'
ALTER TABLE [dbo].[Songs]
ADD CONSTRAINT [FK_SongAlbum]
    FOREIGN KEY ([Album_Id])
    REFERENCES [dbo].[Albums]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SongAlbum'
CREATE INDEX [IX_FK_SongAlbum]
ON [dbo].[Songs]
    ([Album_Id]);
GO

-- Creating foreign key on [Genre_Id] in table 'Songs'
ALTER TABLE [dbo].[Songs]
ADD CONSTRAINT [FK_SongGenre]
    FOREIGN KEY ([Genre_Id])
    REFERENCES [dbo].[Genres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SongGenre'
CREATE INDEX [IX_FK_SongGenre]
ON [dbo].[Songs]
    ([Genre_Id]);
GO

-- Creating foreign key on [Artist_Id] in table 'Songs'
ALTER TABLE [dbo].[Songs]
ADD CONSTRAINT [FK_SongArtist]
    FOREIGN KEY ([Artist_Id])
    REFERENCES [dbo].[Artists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SongArtist'
CREATE INDEX [IX_FK_SongArtist]
ON [dbo].[Songs]
    ([Artist_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------