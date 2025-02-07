USE [master]
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'app')
BEGIN
    CREATE DATABASE [app]
END
GO

USE [app]

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250207082127_InitialCreate'
)
BEGIN
    CREATE TABLE [Puzzles] (
        [Id] int NOT NULL IDENTITY,
        [ShareId] nvarchar(8) NOT NULL,
        [Title] nvarchar(255) NOT NULL,
        [CreatedBy] nvarchar(255) NOT NULL,
        [CreatedOn] datetimeoffset NOT NULL,
        CONSTRAINT [PK_Puzzles] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250207082127_InitialCreate'
)
BEGIN
    CREATE TABLE [Groups] (
        [PuzzleId] int NOT NULL,
        [Difficulty] int NOT NULL,
        [Description] nvarchar(255) NOT NULL,
        [Member1] nvarchar(55) NOT NULL,
        [Member2] nvarchar(55) NOT NULL,
        [Member3] nvarchar(55) NOT NULL,
        [Member4] nvarchar(55) NOT NULL,
        CONSTRAINT [PK_Groups] PRIMARY KEY ([PuzzleId], [Difficulty]),
        CONSTRAINT [FK_Groups_Puzzles_PuzzleId] FOREIGN KEY ([PuzzleId]) REFERENCES [Puzzles] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250207082127_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedOn', N'ShareId', N'Title') AND [object_id] = OBJECT_ID(N'[Puzzles]'))
        SET IDENTITY_INSERT [Puzzles] ON;
    EXEC(N'INSERT INTO [Puzzles] ([Id], [CreatedBy], [CreatedOn], [ShareId], [Title])
    VALUES (1, N''avery'', ''2025-02-07T00:21:26.9746094-08:00'', N''test1234'', N''Example Puzzle'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedOn', N'ShareId', N'Title') AND [object_id] = OBJECT_ID(N'[Puzzles]'))
        SET IDENTITY_INSERT [Puzzles] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250207082127_InitialCreate'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Difficulty', N'PuzzleId', N'Description', N'Member1', N'Member2', N'Member3', N'Member4') AND [object_id] = OBJECT_ID(N'[Groups]'))
        SET IDENTITY_INSERT [Groups] ON;
    EXEC(N'INSERT INTO [Groups] ([Difficulty], [PuzzleId], [Description], [Member1], [Member2], [Member3], [Member4])
    VALUES (1, 1, N''Parts of a Bicycle Wheel'', N''Spoke'', N''Hub'', N''Rim'', N''Tire''),
    (2, 1, N''Types of Fabric'', N''Cotton'', N''Silk'', N''Wool'', N''Linen''),
    (3, 1, N''To Regard'', N''Deem'', N''Rate'', N''Judge'', N''Reckon''),
    (4, 1, N''Last words of David Lynch titles'', N''Peaks'', N''Empire'', N''Drive'', N''Velvet'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Difficulty', N'PuzzleId', N'Description', N'Member1', N'Member2', N'Member3', N'Member4') AND [object_id] = OBJECT_ID(N'[Groups]'))
        SET IDENTITY_INSERT [Groups] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250207082127_InitialCreate'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Puzzles_ShareId] ON [Puzzles] ([ShareId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250207082127_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250207082127_InitialCreate', N'9.0.1');
END;

COMMIT;
GO

