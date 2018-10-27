CREATE TABLE [dbo].[User] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [EmailId] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Group] (
    [Id]   INT            NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[UserGroupMapping] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [GroupId] INT NOT NULL,
    [UserId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

CREATE TABLE [dbo].[Category] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Activity] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CategoryId]  INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);

CREATE TABLE [dbo].[Transaction] (
    [Id]             INT          NOT NULL,
    [PayerUserId]    INT          NOT NULL,
    [ReceiverUserId] INT          NOT NULL,
    [Amount]         NUMERIC (18) NOT NULL,
    [GroupId]        INT          NOT NULL,
    [Date]           DATETIME     NOT NULL,
    [ActivityId]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PayerUserId]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([ReceiverUserId]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([Id]),
    FOREIGN KEY ([ActivityId]) REFERENCES [dbo].[Activity] ([Id])
);