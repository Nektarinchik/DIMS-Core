CREATE PROCEDURE [dbo].[SetUserTaskAsSuccess]
	@UserId int,
	@TaskId int
AS
BEGIN
	UPDATE [dbo].[UserTask]
	SET [StateId] = (
		SELECT DISTINCT [StateId]
		FROM [dbo].[TaskState]
		WHERE [StateName] = 'Success'
	)
	WHERE   [UserId] = @UserId
		AND [TaskId] = @TaskId
END

