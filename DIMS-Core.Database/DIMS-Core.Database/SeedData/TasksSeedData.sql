INSERT INTO [dbo].[Tasks]
(
    [Name],
    [Description],
    [StartDate],
    [DeadlineDate]
)
VALUES (
    'Database basic',
    'Implement 2 tables: Tasks, UserProfiles'
    2022-01-01,
    2022-02-02
    ),
    (
    'Advanced database',
    'Add indexes to the created tables'
    2022-02-03,
    2022-03-03
    ),
    (
    'Implement repositories',
    'Implement 2 repositories for entities(Tasks, UserProfiles)'
    2022-03-04,
    2022-04-04
    ),
    (
    'Implement controllers',
    'Implement 2 controllers: TasksController, UserProfilesController'
    2022-04-05,
    2022-05-05
    );
