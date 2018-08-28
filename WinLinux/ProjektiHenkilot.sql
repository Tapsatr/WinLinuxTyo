CREATE TABLE [dbo].[ProjektiHenkilot]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Henkilo_Id] INT NULL, 
    [Projekti_Id] INT NULL
	CONSTRAINT FK_ProjektiHenkilot_HenkiloID FOREIGN KEY (Henkilo_id)   
    REFERENCES HenkiloTiedot (Henkilo_Id),
	CONSTRAINT FK_ProjektiHenkilot_Projekti_Id FOREIGN KEY (Projekti_Id)   
    REFERENCES ProjektiTiedot (Projekti_Id)
)
