select top 10 bc.BookID,
b.Name,
b.Pages,
b.Publishing
from BookCopy bc
INNER JOIN Book b
 on bc.BookID = b.ID 