CREATE TABLE [dbo].[User] (
    [UserId]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NULL,
    [Email]    NVARCHAR (100) NULL,
    [City]     NVARCHAR (100) NULL,
    [Mobile]   NVARCHAR (20)  NULL,
    [IsDelete] BIT            NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

