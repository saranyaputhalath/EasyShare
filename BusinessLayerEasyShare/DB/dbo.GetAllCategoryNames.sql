USE [EasyShare]
GO

/****** Object: SqlProcedure [dbo].[GetAllCategoryNames] Script Date: 10/27/2018 3:18:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[GetAllCategoryNames];


GO
CREATE PROCEDURE [dbo].[GetAllCategoryNames]
AS
	SELECT * FROM [Category]
RETURN 0
