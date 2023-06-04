
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/24/2023 15:42:34
-- Generated from EDMX file: C:\Users\311-5(student)\Downloads\RoabotnProject66553-master\RoabotnProject66553-master\Roabotn\Model\RabothProjectModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RabotnProject];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AdminLogin_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdminLogin] DROP CONSTRAINT [FK_AdminLogin_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Worker_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Worker] DROP CONSTRAINT [FK_Worker_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_Worker_Tasks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Worker] DROP CONSTRAINT [FK_Worker_Tasks];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdminLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminLogin];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO
IF OBJECT_ID(N'[dbo].[Worker]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Worker];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdminLogin'
CREATE TABLE [dbo].[AdminLogin] (
    [IdAdmin] int IDENTITY(1,1) NOT NULL,
    [login] varchar(16)  NULL,
    [password] varchar(16)  NULL,
    [firstname] nvarchar(30)  NULL,
    [lastname] nvarchar(50)  NULL,
    [surname] nvarchar(50)  NULL,
    [IdStatus] int  NOT NULL
);
GO

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [IdDepartment] int IDENTITY(1,1) NOT NULL,
    [NameDepartment] nvarchar(50)  NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [IdStatus] int IDENTITY(1,1) NOT NULL,
    [NameStatus] nvarchar(50)  NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [IdTasks] int IDENTITY(1,1) NOT NULL,
    [TaskName] nvarchar(50)  NULL,
    [Description] nvarchar(50)  NULL,
    [StartTime] datetime  NULL,
    [EndTime] datetime  NULL,
    [Status] nvarchar(50)  NULL
);
GO

-- Creating table 'Worker'
CREATE TABLE [dbo].[Worker] (
    [IdWorker] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(50)  NULL,
    [lastname] nvarchar(50)  NULL,
    [surname] nvarchar(50)  NULL,
    [number] nvarchar(12)  NULL,
    [email] nvarchar(50)  NULL,
    [birthday] datetime  NULL,
    [INN] int  NULL,
    [Snils] int  NULL,
    [Adress] nvarchar(50)  NULL,
    [PasportSeries] int  NULL,
    [PasportNumber] int  NULL,
    [IdDepartment] int  NULL,
    [IdTasks] int  NULL,
    [Image] varchar(50)  NULL,
    [Specialnost] nvarchar(50)  NULL,
    [CompletedTasks] int  NULL,
    [ForthcomingTasks] int  NULL,
    [FailedTasks] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAdmin] in table 'AdminLogin'
ALTER TABLE [dbo].[AdminLogin]
ADD CONSTRAINT [PK_AdminLogin]
    PRIMARY KEY CLUSTERED ([IdAdmin] ASC);
GO

-- Creating primary key on [IdDepartment] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([IdDepartment] ASC);
GO

-- Creating primary key on [IdStatus] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([IdStatus] ASC);
GO

-- Creating primary key on [IdTasks] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([IdTasks] ASC);
GO

-- Creating primary key on [IdWorker] in table 'Worker'
ALTER TABLE [dbo].[Worker]
ADD CONSTRAINT [PK_Worker]
    PRIMARY KEY CLUSTERED ([IdWorker] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdStatus] in table 'AdminLogin'
ALTER TABLE [dbo].[AdminLogin]
ADD CONSTRAINT [FK_AdminLogin_Status]
    FOREIGN KEY ([IdStatus])
    REFERENCES [dbo].[Status]
        ([IdStatus])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminLogin_Status'
CREATE INDEX [IX_FK_AdminLogin_Status]
ON [dbo].[AdminLogin]
    ([IdStatus]);
GO

-- Creating foreign key on [IdDepartment] in table 'Worker'
ALTER TABLE [dbo].[Worker]
ADD CONSTRAINT [FK_Worker_Department]
    FOREIGN KEY ([IdDepartment])
    REFERENCES [dbo].[Department]
        ([IdDepartment])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Worker_Department'
CREATE INDEX [IX_FK_Worker_Department]
ON [dbo].[Worker]
    ([IdDepartment]);
GO

-- Creating foreign key on [IdTasks] in table 'Worker'
ALTER TABLE [dbo].[Worker]
ADD CONSTRAINT [FK_Worker_Tasks]
    FOREIGN KEY ([IdTasks])
    REFERENCES [dbo].[Tasks]
        ([IdTasks])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Worker_Tasks'
CREATE INDEX [IX_FK_Worker_Tasks]
ON [dbo].[Worker]
    ([IdTasks]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------