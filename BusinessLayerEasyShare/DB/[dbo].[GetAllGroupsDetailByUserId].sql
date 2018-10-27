USE [EasyShare]
GO

/****** Object: SqlProcedure [dbo].[GetAllGroupsDetailByUserId] Script Date: 10/27/2018 4:38:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE [dbo].[GetAllGroupsDetailByUserId];


GO
CREATE PROCEDURE [dbo].[GetAllGroupsDetailByUserId]
	@userId int
AS
	SELECT G.Id GroupId, G.Name GroupName, T.Amount FROM [Group] G
	JOIN [UserGroupMapping] UGM ON UGM.GroupId = G.Id AND UGM.UserId = @userId
	JOIN [Transaction] T ON T.GroupId = G.Id
