CREATE VIEW [dbo].[vUserTrack]
	AS
	SELECT  [dbo].[UserTask].[UserId]       AS UserId,
			[dbo].[UserTask].[TaskId]       AS TaskId,
			[dbo].[TaskTrack].[TaskTrackId] AS TaskTrackId,
			[dbo].[Tasks].[Name]            AS TaskName,
			[dbo].[TaskTrack].[TrackNote]   AS TrackNote,
			[dbo].[TaskTrack].[TrackDate]   AS TrackDate
	FROM [dbo].[UserTask]
		INNER JOIN [dbo].[TaskTrack] ON [dbo].[UserTask].[UserTaskId] = [dbo].[TaskTrack].[UserTaskId]
		INNER JOIN [dbo].[Tasks]     ON [dbo].[UserTask].[TaskId] = [dbo].[Tasks].[TaskId]
