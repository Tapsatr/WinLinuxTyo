CREATE TABLE [dbo].[ProjektiTehtavat]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Projekti_Id] INT NULL, 
    [Henkilo_Id] INT NULL, 
    [Tehtava_Id] INT NULL
	CONSTRAINT FK_ProjektiTehtavat_HenkiloId FOREIGN KEY (Henkilo_id)   
    REFERENCES HenkiloTiedot (Henkilo_Id),
	CONSTRAINT FK_ProjektiTehtavat_ProjektiId FOREIGN KEY (Projekti_Id)   
    REFERENCES ProjektiTiedot (Projekti_Id),
	CONSTRAINT FK_ProjektiTehtavat_TehtavaId FOREIGN KEY (Tehtava_Id)   
    REFERENCES Tehtavat (Tehtava_Id)

)
