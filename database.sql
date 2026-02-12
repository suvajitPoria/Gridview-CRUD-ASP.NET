use dbStudent
CREATE TABLE tblStudent
(
	StudentId INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	Email VARCHAR(100),
	Course VARCHAR(50),
	Age int,
	CreatedAt DATE DEFAULT GETDATE()
)

CREATE PROC spCreateStudent 
	@Name VARCHAR(100),
	@Email VARCHAR(100),
	@Course VARCHAR(50),
	@Age int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblStudent
	(
		NAME,
		Email,
		Course,
		Age
	)
	VALUES
	(
		@Name, @Email, @Course, @Age
	)
	SELECT 'Student added successfully' AS Message;
END

CREATE PROC spReadStudent
AS
BEGIN
	SELECT * FROM tblStudent;
END

ALTER PROC spUpdateStudent
	@StudentId int,
	@Name VARCHAR(100),
	@Email VARCHAR(100),
	@Course VARCHAR(50),
	@Age int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE tblStudent
	SET Name = @Name, Email = @Email, Course = @Course, Age = @Age
	Where StudentId = @StudentId;

	SELECT  'Student Data Updated successfully' AS Message
END

CREATE PROC spDeleteStudent
	@StudentId int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM tblStudent
	Where StudentId = @StudentId;

	SELECT  'Student Data Deleted successfully' AS Message
END