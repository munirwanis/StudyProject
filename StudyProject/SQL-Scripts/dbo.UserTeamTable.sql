CREATE TABLE [dbo].[UserTeamTable]
(
	[UserTeamId] INT NOT NULL PRIMARY KEY, 
    [Login] VARCHAR(30) NOT NULL, 
    [FullName] VARCHAR(100) NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [IsEnabled] BIT NOT NULL, 
    [Password] VARCHAR(10) NOT NULL, 
    [GroupTeamId] INT NOT NULL, 
    CONSTRAINT [FK_UserTeamTable_GroupTeamTable] FOREIGN KEY ([GroupTeamId]) REFERENCES [dbo].[GroupTeamTable]([GroupTeamId])
)
