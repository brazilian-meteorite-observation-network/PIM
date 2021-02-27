
GO

CREATE TABLE [Observatory](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [Description] VARCHAR(255),
    [Location] VARCHAR(120)
)

CREATE TABLE [User]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(120),
    [Password] NVARCHAR(32) NOT NULL,
    [LastLogin] DATETIME,
    [Attempts] INTEGER NOT NULL,
    [ObservatoryId] INT NOT NULL,
    CONSTRAINT userobservatoryid_ObservatoryId_key FOREIGN KEY (ObservatoryId) REFERENCES [Observatory] (Id)
);

CREATE TABLE [DataTrajectoryCalculation ](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(80) NOT NULL,
    [FPLatitude] REAL NOT NULL,
    [InitialLongitude] REAL NOT NULL,
    [InitialHeight] REAL NOT NULL,
    [FLLatitude] REAL NOT NULL,
    [FinalLongitude] REAL NOT NULL,
    [FinalHeight] REAL NOT NULL,
    [TimeInterval] REAL NOT NULL,
    [MeteorDensity] REAL NOT NULL,
    [MeteorMass] REAL NOT NULL,
    [ObservatoryId] INT NOT NULL,
    [CreationDate] DATETIME NOT NULL,
    CONSTRAINT DataTrajectoryCalculation_ObservatoryId_key FOREIGN KEY (ObservatoryId) REFERENCES [Observatory] (Id)
)
GO