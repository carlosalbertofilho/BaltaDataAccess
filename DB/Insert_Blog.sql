USE[Blog]
GO

INSERT INTO [dbo].[User]
(
    [Name],[Email],[PasswordHash],[Bio],[Image],[Slug]
)
VALUES
    ('Carlos Albert Filho'
    ,'carlos@teste.com'
    ,'HASH'
    ,'Engenheiro de Software'
    ,'https://th.bing.com/th/id/OIP.XfN_dUTzgeHXLeHD9DK0uwAAAA?rs=1&pid=ImgDetMain'
    ,'carlos-alberto-filho')
,   ('Helena Martins'
    ,'helena.martins@teste.com'
    ,'HASH'
    ,'Trainee SQL'
    ,'https://th.bing.com/th/id/OIP.XfN_dUTzgeHXLeHD9DK0uwAAAA?rs=1&pid=ImgDetMain'
    ,'helena-martins')
,   ('João da Silva'
    ,'joao@teste.com'
    ,'HASH'
    ,'Junior SQL'
    ,'https://th.bing.com/th/id/OIP.XfN_dUTzgeHXLeHD9DK0uwAAAA?rs=1&pid=ImgDetMain'
    ,'joao-da-silva')
,   ('Maria da Silva'
    ,'maria@teste.com'
    ,'HASH'
    ,'Senior SQL'
    ,'https://th.bing.com/th/id/OIP.XfN_dUTzgeHXLeHD9DK0uwAAAA?rs=1&pid=ImgDetMain'
    ,'maria-da-silva');

SELECT * FROM [dbo].[User]
SELECT * FROM [Role]

INSERT INTO [Role]
([Name] ,[Slug])
VALUES
 ('admin' ,'admin')
,('suporte', 'suporte')

SELECT * FROM [Role]

INSERT INTO [Tag]
([Name],[Slug])
VALUES
    ('ASP.NET', 'aspnet')
,   ('Blazor IU', 'balzor')

SELECT * FROM [Tag]

INSERT INTO [UserRole]
VALUES
    (1, 1)
,   (1, 3)
,   (2, 3)
,   (3, 2)
,   (4, 3)
,   (5, 2)

SELECT * FROM [UserRole]

SELECT
    [User].*,
    [Role].*
FROM
    [User]
    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]