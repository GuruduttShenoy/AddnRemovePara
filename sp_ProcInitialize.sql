USE [LawDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_ProcInitialize]    Script Date: 21/02/2016 10:02:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ProcInitialize] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Delete from tblParaLeft;

	
	Delete from tblParaRight;

	Insert into tblParaLeft
	SELECT ParaID from tblPara;
    -- Insert statements for procedure here
END

GO


