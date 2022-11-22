CREATE TABLE [dbo].[Tasks]
(
    [TaskId]       INT             NOT NULL IDENTITY(1,1),
    [Name]         NVARCHAR(50)    NOT NULL,
    [Description]  NVARCHAR(250)   NOT NULL,
    [StartDate]    DATE            NULL,
    [DeadlineDate] DATE            NULL,

    CONSTRAINT PK_Tasks_TasksId PRIMARY KEY (TaskId)
)