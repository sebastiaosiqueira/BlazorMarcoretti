CREATE PROCEDURE [dbo].[INSERT_NewArticle]
	@Title NVARCHAR(80), 
	@SubTitle NVARCHAR(200), 
	@ArticleBody NVARCHAR(3500), 
	@Authors NVARCHAR(700), 
	@Category INT
AS
	INSERT INTO Articles (Id, Title, SubTitle, ArticleBody, Authors, Category, DatePublished)
	VALUES (NEWID(), @Title, @SubTitle, @ArticleBody, @Authors, @Category, SYSDATETIME())
RETURN 0
