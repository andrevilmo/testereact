
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
CREATE TABLE [User] (
    [id] int NOT NULL IDENTITY,
    [email] nvarchar(255) NOT NULL,
    [password] nvarchar(255) NOT NULL,
    [name] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([id])
);

CREATE INDEX [idx_user] ON [User] ([id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250521223121_InitialCreate', N'9.0.5');

COMMIT;
GO
