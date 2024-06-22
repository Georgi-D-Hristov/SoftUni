--05. Online Store Database

CREATE TABLE ItemTypes
(
    ItemTypeID INT PRIMARY KEY,
    [Name] VARCHAR(30)
)
CREATE TABLE Items
(
    ItemID INT PRIMARY KEY,
    [Name] VARCHAR(30),
    ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)
CREATE TABLE Cities
(
    CityID INT PRIMARY KEY,
    [Name] VARCHAR(30)
)
CREATE TABLE Customers
(
    CustomerID  INT PRIMARY KEY,
    [Name] VARCHAR(30),
    Birthday DATETIME2,
    CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)
CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)
CREATE TABLE  OrderItems
(
    OrderID INT,
    ItemID INT,
    CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID),
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_OrderItems_Items FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)

--06. University Database

CREATE TABLE Subjects
(
    SubjectID INT PRIMARY KEY,
    SubjectName NVARCHAR(30)
)
CREATE TABLE Majors
(
    MajorID INT PRIMARY KEY,
    [Name] NVARCHAR(30)
)
CREATE  TABLE Students
(
    StudentID INT PRIMARY KEY,
    StudentNumber CHAR(8),
    StudentName VARCHAR(30),
    MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)
CREATE TABLE Payments
(
    PaymentID INT PRIMARY KEY,
    PaymentDate DATETIME2,
    PaymentAmount DECIMAL(8,2),
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)
CREATE TABLE Agenda
(
    StudentID INT,
    SubjectID INT,
    CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID),
    CONSTRAINT FK_Agenda_Students FOREIGN KEY (SubjectID) REFERENCES Students(StudentID),
    CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

--09. *Peaks in Rila
SELECT * FROM Mountains

SELECT 
CASE WHEN MountainId=17 THEN 'Rila'
END AS MountainRange, PeakName, Elevation
FROM Peaks
WHERE MountainId=17
ORDER BY Elevation DESC

SELECT MOU INTO Mountains
SELECT * FROM Peaks
WHERE MountainId=17