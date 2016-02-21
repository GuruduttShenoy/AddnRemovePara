USE [LawDB]
GO

/****** Object:  Table [dbo].[tblPara]    Script Date: 21/02/2016 10:06:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblPara](
	[ParaID] [nchar](10) NOT NULL,
	[ParaText] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


