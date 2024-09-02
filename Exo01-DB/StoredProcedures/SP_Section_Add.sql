CREATE PROCEDURE [dbo].[SP_Section_Add]
	@id INT,
	@section_name VARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[Section]
		VALUES (@id, @section_name)
END