CREATE PROCEDURE [dbo].[SP_Student_Delete]
	@id INT
AS
BEGIN
	DELETE FROM [dbo].[Student]
		WHERE [ID] = @id
END
