CREATE PROCEDURE [dbo].[SetUserTaskAsFail]
	@UserId int,
	@TaskId int
AS
BEGIN
	UPDATE [dbo].[UserTask]
	SET [StateId] = (
		SELECT DISTINCT [StateId]
		FROM [dbo].[TaskState]
		WHERE [StateName] = 'Fail'
	)
	WHERE   [UserId] = @UserId
		AND [TaskId] = @TaskId
END
