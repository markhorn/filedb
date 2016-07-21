CREATE TABLE [dbo].[Files]
(
	[FileId] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Description] NCHAR(10) NULL, 
    [stream_id] UNIQUEIDENTIFIER NULL
)
