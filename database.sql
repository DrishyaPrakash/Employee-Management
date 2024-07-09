ARS DATABASE

CREATE DATABASE ARSPracticeDb;

USE ARSPracticeDb

CREATE TABLE Departments
(
    DeptNo int primary key identity,
    DepartmentName Varchar(20)
);

INSERT INTO Departments(DepartmentName)
VALUES('IT'),
('NON-IT');


CREATE PROCEDURE spAllDepartment
As
BEGIN
     SELECT * FROM Departments
END

------------------------------------

CREATE TABLE Employees
(
    EmpId int primary key identity
    FirstName Varcha(20),
    LastName Varcha(20),
    DeptNo int,
    EmployeeType Varcha(20),
    DateOfJoining Date,
    CONSTRAINT FK_Dept FOREIGN KEY (DeptNo) REFERENCES Departments(DeptNo)

);


CREATE PROCEDURE spAddEmployee
    @FirstName Varcha(20),
    @LastName Varcha(20),
    @DeptNo int,
    @EmployeeType Varcha(20),
    @DateOfJoining Date
AS
BEGIN
      INSERT INTO (FirstName,LastName,DeptNo,EmployeeType,DateOfJoining)
      VALUES (@FirstName,@LastName,@DeptNo,@EmployeeType,@DateOfJoining);
END


CREATE PROCEDURE spAllEployees
As
BEGIN
     SELECT e.EmpId,e.FirstName,e.LastName,
     d.DepartmentName,e.EmployeeType,e.DateOfJoining
     FROM Employees e
     INNER JOIN Departments d
     ON e.DeptNo=d.DeptNo
END


CREATE PROCEDURE spEmployeeExistence
    @FirstName varchar(20),
    @LastName varchar(20),
    @Exist int OUTPUT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Employees
        WHERE FirstName = @FirstName AND LastName = @LastName
    )
    BEGIN
        SET @Exist = 1;
    END
    ELSE
    BEGIN
        SET @Exist = 0;
    END
END;


 


