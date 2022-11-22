CREATE VIEW [dbo].[Tasks]
AS
SELECT Tasks.TaskId,
       Tasks.Name,
       Tasks.Description,
       Tasks.StartDate,
       Tasks.DeadlineDate
FROM [Tasks]