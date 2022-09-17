# APICITYEVENTS 

# swagger

![ApiCityEvents](https://user-images.githubusercontent.com/48559533/190871773-95b3ba48-04c4-4dd0-b53b-2f6b31f921ff.jpg)

# Create tables - Database

CREATE TABLE CityEvent
(
	IdEvent BIGINT NOT NULL IDENTITY(1,1)
	,Title  VARCHAR(100) NOT NULL
	,[Description] VARCHAR(200)
	,DateHourEvent DATETIME NOT NULL
    ,[Local] VARCHAR(100) NOT NULL
    ,[Address] VARCHAR(200)
    ,Price DECIMAL(18,2)
    ,[Status] BIT NOT NULL

	CONSTRAINT PK_IdEvent PRIMARY KEY(IdEvent)
)

CREATE TABLE EventReservation
(
	IdReservation BIGINT NOT NULL IDENTITY(1,1)
	,IdEvent BIGINT NOT NULL
	,PersonName VARCHAR(100) NOT NULL
	,Quantity INTEGER NOT NULL
		
	CONSTRAINT PK_IdReservation PRIMARY KEY(IdReservation)
)


ALTER TABLE EventReservation
		ADD CONSTRAINT FK_IdEvent FOREIGN KEY (IdEvent) REFERENCES CityEvent (IdEvent);

CREATE TABLE Clientes
(
	Id BIGINT NOT NULL IDENTITY(1,1)
	,cpf VARCHAR(14) 
	,nome VARCHAR(255) NOT NULL
	,dataNascimento	DATETIME
    ,idade	INT
    ,permissao	VARCHAR(50) NOT NULL

	CONSTRAINT PK_Id PRIMARY KEY(Id)
)
