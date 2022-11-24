CREATE VIEW [dbo].[vUserTask]
	AS
SELECT  [UserTask].UserId,
		[Tasks].TaskId,
		[Tasks].Name,
		[Tasks].Description,
		[Tasks].StartDate,
		[Tasks].DeadlineDate,
		[TaskState].StateName
FROM [dbo].[Tasks] 
	INNER JOIN [dbo].[UserTask]  ON [dbo].[UserTask].[TaskId] = [dbo].[Tasks].[TaskId]
	INNER JOIN [dbo].[TaskState] ON [dbo].[UserTask].[StateId] = [dbo].[TaskState].[StateId]

