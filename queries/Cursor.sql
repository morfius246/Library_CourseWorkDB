CREATE PROCEDURE [dbo].[MyProcedure] AS

DECLARE @Name Nvarchar(max)
DECLARE @SecondName Nvarchar (Max)
DECLARE @LastName Nvarchar (Max)
/*Объявляем курсор*/
DECLARE @CURSOR CURSOR
/*Заполняем курсор*/
SET @CURSOR  = CURSOR SCROLL
FOR
SELECT  Name, SecondName, LastName
  FROM  View1 WHERE  1=1
/*Открываем курсор*/
OPEN @CURSOR
/*Выбираем первую строку*/
FETCH NEXT FROM @CURSOR INTO @Name, @SecondName, @LastName
/*Выполняем в цикле перебор строк*/
WHILE @@FETCH_STATUS = 0
BEGIN

        IF NOT EXISTS(SELECT Name FROM View2 WHERE SecondName=@SecondName)
        BEGIN
/*Вставляем параметры в третью таблицу если условие соблюдается*/
                INSERT INTO View3(Name, SecondName, LastName) VALUes(@Name , @SecondName, @LastName)
        END
/*Выбираем следующую строку*/
FETCH NEXT FROM @CURSOR INTO @Name, @SecondName, @LastName
END
CLOSE @CURSOR