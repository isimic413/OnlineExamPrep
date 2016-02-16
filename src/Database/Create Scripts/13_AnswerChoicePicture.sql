SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AnswerChoicePicture](
	[Id] [nvarchar](128) NOT NULL,
	[AnswerChoiceId] [nvarchar](128) NOT NULL,
	[Image] [image] NOT NULL,
 CONSTRAINT [PK_AnswerChoicePicture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[AnswerChoicePicture]  WITH CHECK ADD  CONSTRAINT [FK_AnswerChoicePicture_AnswerChoice] FOREIGN KEY([AnswerChoiceId])
REFERENCES [dbo].[AnswerChoice] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AnswerChoicePicture] CHECK CONSTRAINT [FK_AnswerChoicePicture_AnswerChoice]
GO
