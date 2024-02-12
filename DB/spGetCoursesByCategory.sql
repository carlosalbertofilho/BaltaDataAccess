CREATE OR ALTER PROCEDURE [spGetCoursesByCategory]
    @CategoryID UNIQUEIDENTIFIER
AS 
    SELECT * FROM [Course] WHERE [CategoryId] = @CategoryID