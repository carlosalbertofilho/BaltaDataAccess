CREATE DATABASE [Blog]
GO

USE [Blog]
GO

CREATE TABLE [User] (
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(200) NOT NULL,
    [PasswordHash] VARCHAR(255) NOT NULL,
    [Bio] TEXT,
    [Image] NVARCHAR(200),
    [Slug] NVARCHAR(80) NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_User_Email] UNIQUE ([Email]),
    CONSTRAINT [UQ_User_Slug] UNIQUE ([Slug])
)
GO

CREATE NONCLUSTERED INDEX [IX_User_Email] ON [User] ([Email])
CREATE NONCLUSTERED INDEX [IX_User_Slug] ON [User] ([Slug])

CREATE TABLE [Role](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [PK_Role] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Role_Slug] UNIQUE ([Slug])
)
GO
 
CREATE NONCLUSTERED INDEX [IX_Role_Slug] ON [Role] ([Slug])

CREATE TABLE [UserRole] (
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,

    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]),
    CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id])
)
GO

CREATE TABLE [Category] (
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] NVARCHAR(80) NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [PK_Category] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Category_Slug] UNIQUE ([Slug])
)
GO

CREATE NONCLUSTERED INDEX [IX_Category_Slug] ON [Category] ([Slug])

CREATE TABLE [Post] (
    [Id] INT NOT NULL IDENTITY(1,1),
    [Title] VARCHAR(160) NOT NULL,
    [Summary] VARCHAR(255) NOT NULL,
    [Slug] NVARCHAR(200) NOT NULL,
    [Body] TEXT NOT NULL,
    [Image] NVARCHAR(200),
    [CategoryId] INT NOT NULL,
    [AuthorId] INT NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),
    [LastUpdate] DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Post_Slug] UNIQUE ([Slug]),
    CONSTRAINT [FK_Post_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]),
    CONSTRAINT [FK_Post_Author] FOREIGN KEY ([AuthorId]) REFERENCES [User] ([Id])
)
GO

CREATE NONCLUSTERED INDEX [IX_Post_Slug] ON [Post] ([Slug])


CREATE TABLE [Tag](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [Slug] NVARCHAR(80) NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Tag_Slug] UNIQUE ([Slug])
)
GO
CREATE NONCLUSTERED INDEX [IX_Tag_Slug] ON [Tag] ([Slug])

CREATE TABLE [PostTag] (
    [PostId] INT NOT NULL,
    [TagId] INT NOT NULL,

    CONSTRAINT [PK_PostTag] PRIMARY KEY ([PostId], [TagId]),
    CONSTRAINT [FK_PostTag_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
    CONSTRAINT [FK_PostTag_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tag] ([Id])
)