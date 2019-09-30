CREATE TABLE [dbo].Comments
(
	[Id] INT NOT NULL, 
    [AuthorId] INT NULL, 
    [PostId] INT NULL, 
    CONSTRAINT [FK_Comments_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors]([Id]), 
    CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES Posts(Id) ,
	CONSTRAINT [PK_Comments] PRIMARY KEY(Id)
)
