CREATE TABLE [dbo].[Incidents] (
    [IncidentID]       INT NOT NULL,
    [Date]             DATETIME       NOT NULL,
    [IncidentType]     NVARCHAR (MAX) NULL,
    [Department]       NVARCHAR (MAX) NULL,
    [Description]      NVARCHAR (MAX) NULL,
    [IncidentLocation] NVARCHAR (MAX) NULL,
    [ActionTaken]      NVARCHAR (MAX) NULL,
    [EmployeeID]       INT            NOT NULL,
    CONSTRAINT [PK_dbo.Incidents] PRIMARY KEY CLUSTERED ([IncidentID] ASC),
    CONSTRAINT [FK_dbo.Incidents_dbo.Employees_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeID]
    ON [dbo].[Incidents]([EmployeeID] ASC);

