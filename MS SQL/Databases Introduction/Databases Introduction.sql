USE Minions
GO

--07. Create Table People

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture BINARY(2),
Height DECIMAL(5,2),
[Weight] DECIMAL(5,2),
Gender CHAR(1) CHECK (Gender IN ('m', 'f')) NOT NULL,
Birthdate DATETIME2 NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
('Ivan', null, 167.00, 67.00, 'm', '1996-05-15 16:33:22.222222', 'driver'),
('Maria', null, 187.00, 57.00, 'f', '1999-05-15 16:33:22.222222', 'model'),
('Peter', null, 197.00, 107.00, 'f', '1989-05-15 16:33:22.222222', 'engineer'),
('Valq', null, 157.00, 47.00, 'm', '1986-05-15 16:33:22.222222', 'teacher'),
('Kolio', null, 207.00, 167.00, 'm', '1976-05-15 16:33:22.222222', 'drunker')

--08. Create Table Users

CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture BINARY(900),
LastLoginTime DATETIME2,
IsDeleted VARCHAR(5) CHECK(IsDeleted IN ('true', 'false'))

)

INSERT INTO Users (Username, [Password], ProfilePicture,LastLoginTime, IsDeleted)
VALUES
('Smith', 'pass', null, null, 'true'),
('Smit', 'pass1', null, null, 'true'),
('Smi', 'pass2', null, null, 'true'),
('Sm', 'pass', null, null, 'true'),
('S', 'pass4', null, null, 'true')