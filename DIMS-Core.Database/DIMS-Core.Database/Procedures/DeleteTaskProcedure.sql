CREATE PROCEDURE [dbo].[DeleteTask_SP]
    @TaskId INT
AS
BEGIN
    DELETE FROM [dbo].[Tasks] WHERE TaskId = @TaskId
END