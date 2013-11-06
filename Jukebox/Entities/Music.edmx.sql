
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2013 19:56:48
-- Generated from EDMX file: C:\Users\Christina\Desktop\Jukebox\Jukebox\Entities\Music.edmx
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

IF OBJECT_ID(N'[dbo].[FK_AccountSong_Account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountSong] DROP CONSTRAINT [FK_AccountSong_Account];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountSong_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountSong] DROP CONSTRAINT [FK_AccountSong_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_SongArtist_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongArtist] DROP CONSTRAINT [FK_SongArtist_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_SongArtist_Artist]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongArtist] DROP CONSTRAINT [FK_SongArtist_Artist];
GO
IF OBJECT_ID(N'[dbo].[FK_SongGenre_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongGenre] DROP CONSTRAINT [FK_SongGenre_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_SongGenre_Genre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongGenre] DROP CONSTRAINT [FK_SongGenre_Genre];
GO
IF OBJECT_ID(N'[dbo].[FK_SongAlbum_Song]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongAlbum] DROP CONSTRAINT [FK_SongAlbum_Song];
GO
IF OBJECT_ID(N'[dbo].[FK_SongAlbum_Album]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongAlbum] DROP CONSTRAINT [FK_SongAlbum_Album];
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
IF OBJECT_ID(N'[dbo].[AccountSong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountSong];
GO
IF OBJECT_ID(N'[dbo].[SongArtist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongArtist];
GO
IF OBJECT_ID(N'[dbo].[SongGenre]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongGenre];
GO
IF OBJECT_ID(N'[dbo].[SongAlbum]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongAlbum];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Songs'
CREATE TABLE [dbo].[Songs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sTitle] nvarchar(max)  NOT NULL,
    [sLength] nvarchar(max)  NOT NULL,
    [sFilePath] nvarchar(max)  NOT NULL
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
    [Username] nvarchar(max)  NOT NULL,
    [Room_Id] int  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'AccountSong'
CREATE TABLE [dbo].[AccountSong] (
    [Accounts_LoginId] int  NOT NULL,
    [Songs_Id] int  NOT NULL
);
GO

-- Creating table 'SongArtist'
CREATE TABLE [dbo].[SongArtist] (
    [Songs_Id] int  NOT NULL,
    [Artists_Id] int  NOT NULL
);
GO

-- Creating table 'SongGenre'
CREATE TABLE [dbo].[SongGenre] (
    [Songs_Id] int  NOT NULL,
    [Genres_Id] int  NOT NULL
);
GO

-- Creating table 'SongAlbum'
CREATE TABLE [dbo].[SongAlbum] (
    [Songs_Id] int  NOT NULL,
    [Albums_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Accounts_LoginId], [Songs_Id] in table 'AccountSong'
ALTER TABLE [dbo].[AccountSong]
ADD CONSTRAINT [PK_AccountSong]
    PRIMARY KEY NONCLUSTERED ([Accounts_LoginId], [Songs_Id] ASC);
GO

-- Creating primary key on [Songs_Id], [Artists_Id] in table 'SongArtist'
ALTER TABLE [dbo].[SongArtist]
ADD CONSTRAINT [PK_SongArtist]
    PRIMARY KEY NONCLUSTERED ([Songs_Id], [Artists_Id] ASC);
GO

-- Creating primary key on [Songs_Id], [Genres_Id] in table 'SongGenre'
ALTER TABLE [dbo].[SongGenre]
ADD CONSTRAINT [PK_SongGenre]
    PRIMARY KEY NONCLUSTERED ([Songs_Id], [Genres_Id] ASC);
GO

-- Creating primary key on [Songs_Id], [Albums_Id] in table 'SongAlbum'
ALTER TABLE [dbo].[SongAlbum]
ADD CONSTRAINT [PK_SongAlbum]
    PRIMARY KEY NONCLUSTERED ([Songs_Id], [Albums_Id] ASC);
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

-- Creating foreign key on [Songs_Id] in table 'SongArtist'
ALTER TABLE [dbo].[SongArtist]
ADD CONSTRAINT [FK_SongArtist_Song]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[Songs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Artists_Id] in table 'SongArtist'
ALTER TABLE [dbo].[SongArtist]
ADD CONSTRAINT [FK_SongArtist_Artist]
    FOREIGN KEY ([Artists_Id])
    REFERENCES [dbo].[Artists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SongArtist_Artist'
CREATE INDEX [IX_FK_SongArtist_Artist]
ON [dbo].[SongArtist]
    ([Artists_Id]);
GO

-- Creating foreign key on [Songs_Id] in table 'SongGenre'
ALTER TABLE [dbo].[SongGenre]
ADD CONSTRAINT [FK_SongGenre_Song]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[Songs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Genres_Id] in table 'SongGenre'
ALTER TABLE [dbo].[SongGenre]
ADD CONSTRAINT [FK_SongGenre_Genre]
    FOREIGN KEY ([Genres_Id])
    REFERENCES [dbo].[Genres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SongGenre_Genre'
CREATE INDEX [IX_FK_SongGenre_Genre]
ON [dbo].[SongGenre]
    ([Genres_Id]);
GO

-- Creating foreign key on [Songs_Id] in table 'SongAlbum'
ALTER TABLE [dbo].[SongAlbum]
ADD CONSTRAINT [FK_SongAlbum_Song]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[Songs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Albums_Id] in table 'SongAlbum'
ALTER TABLE [dbo].[SongAlbum]
ADD CONSTRAINT [FK_SongAlbum_Album]
    FOREIGN KEY ([Albums_Id])
    REFERENCES [dbo].[Albums]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SongAlbum_Album'
CREATE INDEX [IX_FK_SongAlbum_Album]
ON [dbo].[SongAlbum]
    ([Albums_Id]);
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------