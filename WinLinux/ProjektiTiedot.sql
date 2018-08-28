CREATE TABLE [dbo].[ProjektiTiedot]
(
	[Projekti_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [ProjektiNimi] NCHAR(50) NULL, 
    [ProjektiAlkuPvm] NCHAR(50) NULL, 
    [ProjektiLoppuPvm] NCHAR(50) NULL
)
