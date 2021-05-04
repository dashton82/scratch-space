CREATE TABLE [dbo].[Person]
(
    [Id] uniqueidentifier,
    [Firstname] VARCHAR(500) NOT NULL,
    [Lastname] VARCHAR(500) NOT NULL,
    [DateOfBirth] DATETIME NOT NULL
)