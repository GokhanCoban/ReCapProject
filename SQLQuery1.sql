CREATE TABLE [dbo].[Users] (
    [Id]        INT           NOT NULL PRIMARY KEY IDENTITY(1,1),
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    [Email]     NVARCHAR (50) NOT NULL,
    [Password]  NVARCHAR (50) NOT NULL
);