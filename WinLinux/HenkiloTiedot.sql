CREATE TABLE [dbo].[HenkiloTiedot]
(
	[Henkilo_Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Nimi] NCHAR(25) NULL, 
    [Email] NCHAR(50) NULL, 
    [Puhelin] NCHAR(10) NULL
)

