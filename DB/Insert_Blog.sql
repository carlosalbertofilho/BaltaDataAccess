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

INSERT INTO [Role]
([Name] ,[Slug])
VALUES
 ('admin' ,'admin')
,('suporte', 'suporte')

SELECT * FROM [Role]

