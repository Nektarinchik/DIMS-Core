CREATE VIEW [dbo].[vTasks]
	AS
    SELECT Tasks.TaskId,
           Tasks.Name,
           Tasks.Description,
           Tasks.StartDate,
           Tasks.DeadlineDate
    FROM [Tasks]
