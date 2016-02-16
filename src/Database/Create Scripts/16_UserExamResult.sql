SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserExamResult](
	[Id] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ExamId] [nvarchar](128) NOT NULL,
	[DurationInMinutes] [int] NOT NULL,
	[Points] [int] NOT NULL,
	[CorrectAnswers] [int] NOT NULL,
	[TimeTaken] [datetime] NOT NULL,
 CONSTRAINT [PK_UserExamResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserExamResult]  WITH CHECK ADD  CONSTRAINT [FK_UserExamResult_Exam] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exam] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[UserExamResult] CHECK CONSTRAINT [FK_UserExamResult_Exam]
GO

ALTER TABLE [dbo].[UserExamResult]  WITH CHECK ADD  CONSTRAINT [FK_UserExamResult_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[UserExamResult] CHECK CONSTRAINT [FK_UserExamResult_User]
GO
