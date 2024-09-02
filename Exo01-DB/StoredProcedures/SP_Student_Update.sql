CREATE PROCEDURE [dbo].[SP_Student_Update]
	@year_result INT,
	@section_id INT,
	@id INT
AS
BEGIN
	UPDATE [dbo].[Student]
		SET [YearResult] = @year_result,
			[SectionId] = @section_id
		WHERE [ID] = @id
END
