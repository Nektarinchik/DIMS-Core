CREATE PROCEDURE [dbo].[DeleteTask]
    @TaskId INT
AS
BEGIN
    DELETE FROM [dbo].[Tasks] WHERE TaskId = @TaskId
END