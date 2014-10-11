CREATE TRIGGER [Trigger]
	ON [dbo].[Author]
	INSTEAD OF INSERT
	AS
	BEGIN
		SET NOCOUNT ON
		declare @Name_new NVARCHAR(MAX)
		declare @SecondName_new NVARCHAR(MAX)
		declare @LastName_new NVARCHAR(MAX)

		SET @Name_new = (Select Name From inserted)
		SET @SecondName_new = (Select SecondName From inserted)
		SET @LastName_new = (Select LastName From inserted)

		Set @Name_new = UPPER(LEFT(@Name_new,1))+LOWER(SUBSTRING(@Name_new,2,LEN(@Name_new)))
		Set @SecondName_new = UPPER(LEFT(@SecondName_new,1))+LOWER(SUBSTRING(@SecondName_new,2,LEN(@SecondName_new)))
		Set @LastName_new = UPPER(LEFT(@LastName_new,1))+LOWER(SUBSTRING(@LastName_new,2,LEN(@LastName_new)))

		PRINT(@Name_new)
		if @Name_new is not null and @SecondName_new is not null and @LastName_new is not null
		begin			
			insert into dbo.Author(Name, LastName, SecondName)
			values (@Name_new, @LastName_new, @SecondName_new)
		END
		else
		begin
			insert into dbo.Author(Name, LastName)
			values (@Name_new, @LastName_new)
		end
	END
