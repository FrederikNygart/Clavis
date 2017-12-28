
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/28/2017 13:38:03
-- Generated from EDMX file: D:\Projects\Clavis\Clavis\ClavisModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ClavisDb];
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

-- Creating table 'Locks'
CREATE TABLE [dbo].[Locks] (
    [LockId] uniqueidentifier  NOT NULL,
    [IsOpen] bit  NOT NULL
);
GO

-- Creating table 'LockGroups'
CREATE TABLE [dbo].[LockGroups] (
    [LockGroupId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LockOwners'
CREATE TABLE [dbo].[LockOwners] (
    [LockOwnerId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'LockUsers'
CREATE TABLE [dbo].[LockUsers] (
    [LockUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'LockGroupLock'
CREATE TABLE [dbo].[LockGroupLock] (
    [LockGroups_LockGroupId] uniqueidentifier  NOT NULL,
    [Locks_LockId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'LockGroupLockGroup'
CREATE TABLE [dbo].[LockGroupLockGroup] (
    [Children_LockGroupId] uniqueidentifier  NOT NULL,
    [Parents_LockGroupId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'LockOwnerLockGroup'
CREATE TABLE [dbo].[LockOwnerLockGroup] (
    [LockOwners_LockOwnerId] uniqueidentifier  NOT NULL,
    [LockGroups_LockGroupId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'LockUserLockGroup'
CREATE TABLE [dbo].[LockUserLockGroup] (
    [LockUsers_LockUserId] uniqueidentifier  NOT NULL,
    [LockGroups_LockGroupId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LockId] in table 'Locks'
ALTER TABLE [dbo].[Locks]
ADD CONSTRAINT [PK_Locks]
    PRIMARY KEY CLUSTERED ([LockId] ASC);
GO

-- Creating primary key on [LockGroupId] in table 'LockGroups'
ALTER TABLE [dbo].[LockGroups]
ADD CONSTRAINT [PK_LockGroups]
    PRIMARY KEY CLUSTERED ([LockGroupId] ASC);
GO

-- Creating primary key on [LockOwnerId] in table 'LockOwners'
ALTER TABLE [dbo].[LockOwners]
ADD CONSTRAINT [PK_LockOwners]
    PRIMARY KEY CLUSTERED ([LockOwnerId] ASC);
GO

-- Creating primary key on [LockUserId] in table 'LockUsers'
ALTER TABLE [dbo].[LockUsers]
ADD CONSTRAINT [PK_LockUsers]
    PRIMARY KEY CLUSTERED ([LockUserId] ASC);
GO

-- Creating primary key on [LockGroups_LockGroupId], [Locks_LockId] in table 'LockGroupLock'
ALTER TABLE [dbo].[LockGroupLock]
ADD CONSTRAINT [PK_LockGroupLock]
    PRIMARY KEY CLUSTERED ([LockGroups_LockGroupId], [Locks_LockId] ASC);
GO

-- Creating primary key on [Children_LockGroupId], [Parents_LockGroupId] in table 'LockGroupLockGroup'
ALTER TABLE [dbo].[LockGroupLockGroup]
ADD CONSTRAINT [PK_LockGroupLockGroup]
    PRIMARY KEY CLUSTERED ([Children_LockGroupId], [Parents_LockGroupId] ASC);
GO

-- Creating primary key on [LockOwners_LockOwnerId], [LockGroups_LockGroupId] in table 'LockOwnerLockGroup'
ALTER TABLE [dbo].[LockOwnerLockGroup]
ADD CONSTRAINT [PK_LockOwnerLockGroup]
    PRIMARY KEY CLUSTERED ([LockOwners_LockOwnerId], [LockGroups_LockGroupId] ASC);
GO

-- Creating primary key on [LockUsers_LockUserId], [LockGroups_LockGroupId] in table 'LockUserLockGroup'
ALTER TABLE [dbo].[LockUserLockGroup]
ADD CONSTRAINT [PK_LockUserLockGroup]
    PRIMARY KEY CLUSTERED ([LockUsers_LockUserId], [LockGroups_LockGroupId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LockGroups_LockGroupId] in table 'LockGroupLock'
ALTER TABLE [dbo].[LockGroupLock]
ADD CONSTRAINT [FK_LockGroupLock_LockGroup]
    FOREIGN KEY ([LockGroups_LockGroupId])
    REFERENCES [dbo].[LockGroups]
        ([LockGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Locks_LockId] in table 'LockGroupLock'
ALTER TABLE [dbo].[LockGroupLock]
ADD CONSTRAINT [FK_LockGroupLock_Lock]
    FOREIGN KEY ([Locks_LockId])
    REFERENCES [dbo].[Locks]
        ([LockId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LockGroupLock_Lock'
CREATE INDEX [IX_FK_LockGroupLock_Lock]
ON [dbo].[LockGroupLock]
    ([Locks_LockId]);
GO

-- Creating foreign key on [Children_LockGroupId] in table 'LockGroupLockGroup'
ALTER TABLE [dbo].[LockGroupLockGroup]
ADD CONSTRAINT [FK_LockGroupLockGroup_LockGroup]
    FOREIGN KEY ([Children_LockGroupId])
    REFERENCES [dbo].[LockGroups]
        ([LockGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Parents_LockGroupId] in table 'LockGroupLockGroup'
ALTER TABLE [dbo].[LockGroupLockGroup]
ADD CONSTRAINT [FK_LockGroupLockGroup_LockGroup1]
    FOREIGN KEY ([Parents_LockGroupId])
    REFERENCES [dbo].[LockGroups]
        ([LockGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LockGroupLockGroup_LockGroup1'
CREATE INDEX [IX_FK_LockGroupLockGroup_LockGroup1]
ON [dbo].[LockGroupLockGroup]
    ([Parents_LockGroupId]);
GO

-- Creating foreign key on [LockOwners_LockOwnerId] in table 'LockOwnerLockGroup'
ALTER TABLE [dbo].[LockOwnerLockGroup]
ADD CONSTRAINT [FK_LockOwnerLockGroup_LockOwner]
    FOREIGN KEY ([LockOwners_LockOwnerId])
    REFERENCES [dbo].[LockOwners]
        ([LockOwnerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LockGroups_LockGroupId] in table 'LockOwnerLockGroup'
ALTER TABLE [dbo].[LockOwnerLockGroup]
ADD CONSTRAINT [FK_LockOwnerLockGroup_LockGroup]
    FOREIGN KEY ([LockGroups_LockGroupId])
    REFERENCES [dbo].[LockGroups]
        ([LockGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LockOwnerLockGroup_LockGroup'
CREATE INDEX [IX_FK_LockOwnerLockGroup_LockGroup]
ON [dbo].[LockOwnerLockGroup]
    ([LockGroups_LockGroupId]);
GO

-- Creating foreign key on [LockUsers_LockUserId] in table 'LockUserLockGroup'
ALTER TABLE [dbo].[LockUserLockGroup]
ADD CONSTRAINT [FK_LockUserLockGroup_LockUser]
    FOREIGN KEY ([LockUsers_LockUserId])
    REFERENCES [dbo].[LockUsers]
        ([LockUserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LockGroups_LockGroupId] in table 'LockUserLockGroup'
ALTER TABLE [dbo].[LockUserLockGroup]
ADD CONSTRAINT [FK_LockUserLockGroup_LockGroup]
    FOREIGN KEY ([LockGroups_LockGroupId])
    REFERENCES [dbo].[LockGroups]
        ([LockGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LockUserLockGroup_LockGroup'
CREATE INDEX [IX_FK_LockUserLockGroup_LockGroup]
ON [dbo].[LockUserLockGroup]
    ([LockGroups_LockGroupId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------