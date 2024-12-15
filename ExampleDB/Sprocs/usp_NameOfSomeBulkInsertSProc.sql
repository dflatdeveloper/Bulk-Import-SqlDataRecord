CREATE PROCEDURE [dbo].[usp_NameOfSomeBulkInsertSProc]
	@ExampleParam dbo.NameOfUDTableType_TT READONLY
AS
BEGIN
	INSERT INTO ExampleTable
	SELECT ID, NAME FROM @ExampleParam
END
