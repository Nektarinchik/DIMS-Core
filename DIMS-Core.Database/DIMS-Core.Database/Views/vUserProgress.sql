CREATE VIEW [dbo].[vUserProgress]
	AS
	SELECT  [dbo].[UserTask].[UserId]       AS UserId,
			[dbo].[UserTask].[TaskId]       AS TaskId,
			[dbo].[TaskTrack].[TaskTrackId] AS TaskTrackId,
			CONCAT(
				[dbo].[UserProfiles].[FirstName], 
				' ', 
				[dbo].[UserProfiles].[LastName]
			)                               AS UserName,
			[dbo].[Tasks].[Name]            AS TaskName,
			[dbo].[TaskTrack].[TrackNote]   AS TrackNote,
			[dbo].[TaskTrack].[TrackDate]   AS TrackDate
	FROM [dbo].[UserTask] 
		INNER JOIN [dbo].[TaskTrack]    ON [dbo].[TaskTrack].[UserTaskId] = [dbo].[UserTask].[UserTaskId]
		INNER JOIN [dbo].[UserProfiles] ON [dbo].[UserTask].[UserId] = [dbo].[UserProfiles].[UserId]
		INNER JOIN [dbo].[Tasks]        ON [dbo].[UserTask].[TaskId] = [dbo].[Tasks].[TaskId]