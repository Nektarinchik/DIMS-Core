CREATE VIEW [dbo].[vDirections]
    AS
    SELECT Directions.DirectionId,
           Directions.Name,
           Directions.Description
    FROM [Directions]
