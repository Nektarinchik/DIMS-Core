CREATE VIEW [dbo].[vUserTask]
	AS
SELECT [UserProfiles].UserId,
		[Tasks].TaskId,
		[Tasks].Name,
		[Tasks].Description,
		[Tasks].StartDate,
		[Tasks].DeadlineDate,
		[TaskState].StateName
FROM [dbo].[UserTask] 
	INNER JOIN [dbo].[UserProfiles] ON [dbo].[UserTask].[UserId] = [dbo].[UserProfiles].[UserId]
	INNER JOIN [dbo].[Tasks]        ON [dbo].[UserTask].[TaskId] = [dbo].[Tasks].[TaskId]
	INNER JOIN [dbo].[TaskState]    ON [dbo].[UserTask].[StateId] = [dbo].[TaskState].[StateId]

