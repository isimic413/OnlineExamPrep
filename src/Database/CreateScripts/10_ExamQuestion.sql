﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExamQuestion](
	[Id] [nvarchar](128) NOT NULL,
	[QuestionId] [nvarchar](128) NOT NULL,
	[ExamId] [nvarchar](128) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_ExamQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ExamQuestion_ExamId_Number] UNIQUE NONCLUSTERED 
(
	[ExamId] ASC,
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ExamQuestion_ExamId_QuestionId] UNIQUE NONCLUSTERED 
(
	[ExamId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ExamQuestion_ExamQuestion] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exam] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ExamQuestion] CHECK CONSTRAINT [FK_ExamQuestion_ExamQuestion]
GO

ALTER TABLE [dbo].[ExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ExamQuestion_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ExamQuestion] CHECK CONSTRAINT [FK_ExamQuestion_Question]
GO
