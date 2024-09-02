CREATE PROCEDURE [dbo].[SP_Student_Add]
	@first_name VARCHAR(50),
	@last_name VARCHAR(50),
	@birth_date DATETIME2,
	@section_id INT
AS
BEGIN
	INSERT INTO [dbo].[Student] (
								[FirstName],
								[LastName],
								[BirthDate],
								[SectionId],
								[YearResult])
		OUTPUT [inserted].[ID]
		VALUES (
				@first_name,
				@last_name,
				@birth_date,
				@section_id,
				0)
END