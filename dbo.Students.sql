CREATE TABLE [dbo].[Students] (
    [StudentId]               NVARCHAR (450) NOT NULL,
    [Pin]                     NVARCHAR (MAX) NOT NULL,
    [Name]                    NVARCHAR (MAX) NOT NULL,
    [College]                 NVARCHAR (MAX) NOT NULL,
    [Department]              NVARCHAR (MAX) NOT NULL,
    [CreditHours]             INT            NOT NULL,
    [Semester]                INT            NOT NULL,
    [IsRegistrationAvailable] BIT            NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([StudentId] ASC)
);

