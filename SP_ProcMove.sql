USE [LawDB]
GO

/****** Object:  StoredProcedure [dbo].[SP_ProcMove]    Script Date: 21/02/2016 10:04:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ProcMove]
	-- Add the parameters for the stored procedure here
	@Choice varchar(10),
	@SelectedParaID varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @Choice='ADD'
	Begin
		insert								
		into tblParaRight 
		values (@SelectedParaID);
	
		Delete from tblParaLeft where ParaID=@SelectedParaID;																						

	End

	Else If @Choice='REMOVE'
	Begin
	insert								
		into tblParaLeft 
		values
		(@SelectedParaID);
	
		Delete from tblParaRight where ParaID=@SelectedParaID;
	End

END

GO


