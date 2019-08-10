CREATE TABLE [dbo].[TblOwner] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Document]   NVARCHAR (20)  NOT NULL,
    [FirstName]  NVARCHAR (50)  NOT NULL,
    [LastName]   NVARCHAR (50)  NOT NULL,
    [FixedPhone] NVARCHAR (20)  NULL,
    [CellPhone]  NVARCHAR (20)  NULL,
    [Address]    NVARCHAR (100) NULL,
    CONSTRAINT [PK_TblOwner] PRIMARY KEY CLUSTERED ([Id] ASC)
);

