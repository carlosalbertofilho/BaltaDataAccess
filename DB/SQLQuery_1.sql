SELECT TOP (1000) [Id]
      ,[Name]
      ,[Email]
      ,[Document]
      ,[Phone]
      ,[Birthdate]
      ,[CreateDate]
  FROM [balta].[dbo].[Student]

  SELECT TOP (100) [Id]
      ,[Tag]
      ,[Title]
      ,[Summary]
      ,[Url]
      ,[Level]
      ,[DurationInMinutes]
      ,[CreateDate]
      ,[LastUpdateDate]
      ,[Active]
      ,[Free]
      ,[Featured]
      ,[AuthorId]
      ,[CategoryId]
      ,[Tags]
  FROM [balta].[dbo].[Course]

  SELECT TOP (1000) [CourseId]
      ,[StudentId]
      ,[Progress]
      ,[Favorite]
      ,[StartDate]
      ,[LastUpdateDate]
  FROM [balta].[dbo].[StudentCourse]


INSERT INTO [Student]
    (Id, Name, Email, Document, Phone, Birthdate, CreateDate)
VALUES
    ('5d8cf24e-e717-9a02-2443-01b300000000',
    'Carlos Filho',
    'carlos.filho@hupe.br',
    27825485471,
    21221323254,
    null,
    GETDATE())

INSERT INTO [StudentCourse]
    (CourseId, StudentId, Progress, Favorite, StartDate, LastUpdateDate)
VALUES 
    (
        '5d1b6506-c980-8031-5957-26df00000000',
        '5d8cf24e-e717-9a02-2443-01b300000000',
        0,
        1,
        GETDATE(),
        GETDATE()
    )

INSERT INTO [Student]
    (Id, Name, Email, Document, Phone, Birthdate, CreateDate)
VALUES
    ('893b03bd-aaf4-4184-a3d5-b06a93e99e90',
    'Ruan Minto',
    'ruan.minto@hupe.br',
    12346789231,
    21093423431,
    null,
    GETDATE())
    

INSERT INTO [StudentCourse]
    (CourseId, StudentId, Progress, Favorite, StartDate, LastUpdateDate)
VALUES 
    (
        '5baed79d-e717-9a35-8dc2-1a3500000000',
        '893b03bd-aaf4-4184-a3d5-b06a93e99e90',
        0,
        1,
        GETDATE(),
        GETDATE()
    )
