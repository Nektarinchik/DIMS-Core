CREATE PROCEDURE [dbo].[DeleteUser]
	@UserId INT
AS
BEGIN
	DELETE [dbo].[UserProfiles] 
	WHERE UserId = @UserId;
END