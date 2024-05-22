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

--09 Change Primary Key
ALTER TABLE Users 
alter column Id int not null

--13

create database Movies
go
use Movies
go
create table Directors
(
Id int primary key identity,
DirectorName nvarchar(30) not null,
Notes nvarchar(200)
)
create table Genres
(
Id int primary key identity,
GenreName nvarchar(30) not null,
Notes nvarchar(200)
)
create table Categories
(
Id int primary key identity,
CategoryName nvarchar(30) not null,
Notes nvarchar(200)
)
create table Movies
(
Id int primary key identity,
Title nvarchar(50) not null,
DirectorId int not null,
CopyrightYear date,
[Length] float,
GenreId int not null,
CategoryId int not null,
Rating float not null,
Notes nvarchar(max),
constraint FK_Movies_Directors foreign key (DirectorId) references Directors(Id),
constraint FK_Movies_Genres foreign key (GenreId) references Genres(Id),
constraint FK_Movies_Category foreign key (CategoryId) references Categories(Id)
)

insert into Directors (DirectorName, Notes) values
('Ivan', null),
('Ivan1', null),
('Ivan2', null),
('Ivan3', null),
('Ivan4', null)
insert into Genres (GenreName, Notes) values
('komedy', null),
('horrer', null),
('action', null),
('drama', null),
('triller', null)

insert into Categories (CategoryName, Notes) values
('18+', null),
('16', null),
('14', null),
('family', null),
('12', null)

insert into Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId,Rating) values
('Doom', 1, '2010', 96, 1, 1, 3),
('LOR', 2, '2000', 220, 2, 1, 10),
('Blade',3 , '1996', 100, 3, 3, 10),
('FF6', 4,'2016', 120, 1, 4, 6),
('It', 5,'2020', 180, 4, 5, 1)
