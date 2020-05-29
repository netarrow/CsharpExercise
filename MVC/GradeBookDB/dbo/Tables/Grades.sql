CREATE TABLE [dbo].[Grades] (
    [Id]        INT            NOT NULL,
    [Rate]      FLOAT (53)     NOT NULL,
    [Subject]   NVARCHAR (MAX) NOT NULL,
    [StudentId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Grades_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id])
);

