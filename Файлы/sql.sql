USE ProjectData;

CREATE TABLE [dbo].[Employees] (
    [Id]         INT         IDENTITY (1, 1) NOT NULL,
    [LastName]   NVARCHAR (128) NULL,
    [FirstName]  NVARCHAR (128) NULL,
    [MiddleName] NVARCHAR (128) NULL,
    [Email]      NVARCHAR (128) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Projects] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (128) NULL,
    [CustomerName]     NVARCHAR (128) NULL,
    [ExecutingCompany] NVARCHAR (128) NULL,
    [StartDate]        DATETIME       NULL,
    [EndDate]          DATETIME       NULL,
    [Priority]         INT            DEFAULT ((0)) NOT NULL,
    [ProjectManagerId] INT           NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Projects_Employees] FOREIGN KEY ([ProjectManagerId]) REFERENCES [dbo].[Employees] ([Id]) ON DELETE SET NULL,
);

CREATE TABLE [dbo].[ProjectEmployees] (
    [ProjectId]  INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    CONSTRAINT [PK_ProjectEmployees] PRIMARY KEY CLUSTERED ([ProjectId] ASC, [EmployeeId] ASC),
    CONSTRAINT [FK_ProjectEmployeesProjects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProjectEmployeesEmployees] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[ProjectExecutors] (
    [ProjectId]  INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    CONSTRAINT [PK_ProjectExecutors] PRIMARY KEY CLUSTERED ([ProjectId] ASC, [EmployeeId] ASC),
    CONSTRAINT [FK_ProjectExecutorsProjects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Projects] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProjectExecutorsEmployees] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id]) ON DELETE CASCADE
);