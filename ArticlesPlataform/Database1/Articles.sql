CREATE TABLE [dbo].[Articles]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(80) NOT NULL, 
    [SubTitle] NVARCHAR(200) NOT NULL, 
    [ArticleBody] NVARCHAR(3500) NOT NULL, 
    [Authors] NVARCHAR(700) NOT NULL, 
    [Category] INT NOT NULL, 
    [DatePublished] DATETIME NOT NULL
)
