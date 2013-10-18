
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/18/2013 10:23:55
-- Generated from EDMX file: C:\Users\Julio Garcia\Desktop\Jukebox\Jukebox\Entities\Music.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-Jukebox-20131008053551];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Songs'
CREATE TABLE [dbo].[Songs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sTitle] nvarchar(max)  NOT NULL,
    [sLength] nvarchar(max)  NOT NULL,
    [Genre_Id] int  NOT NULL
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
    [sTitle] nvarchar(max)  NOT NULL,
    [Artist_Id] int  NOT NULL
);
GO

-- Creating table 'Genres'
CREATE TABLE [dbo].[Genres] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sName] nvarchar(max)  NOT NULL,
    [Album_Id] int  NOT NULL,
    [Artist_Id] int  NOT NULL
);
GO

-- Creating table 'SongArtist'
CREATE TABLE [dbo].[SongArtist] (
    [Songs_Id] int  NOT NULL,
    [Artists_Id] int  NOT NULL
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

-- Creating primary key on [Songs_Id], [Artists_Id] in table 'SongArtist'
ALTER TABLE [dbo].[SongArtist]
ADD CONSTRAINT [PK_SongArtist]
    PRIMARY KEY CLUSTERED ([Songs_Id], [Artists_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [Album_Id] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [FK_AlbumGenre]
    FOREIGN KEY ([Album_Id])
    REFERENCES [dbo].[Albums]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AlbumGenre'
CREATE INDEX [IX_FK_AlbumGenre]
ON [dbo].[Genres]
    ([Album_Id]);
GO

-- Creating foreign key on [Artist_Id] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [FK_ArtistGenre]
    FOREIGN KEY ([Artist_Id])
    REFERENCES [dbo].[Artists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistGenre'
CREATE INDEX [IX_FK_ArtistGenre]
ON [dbo].[Genres]
    ([Artist_Id]);
GO

-- Creating foreign key on [Artist_Id] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [FK_ArtistAlbum]
    FOREIGN KEY ([Artist_Id])
    REFERENCES [dbo].[Artists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistAlbum'
CREATE INDEX [IX_FK_ArtistAlbum]
ON [dbo].[Albums]
    ([Artist_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------