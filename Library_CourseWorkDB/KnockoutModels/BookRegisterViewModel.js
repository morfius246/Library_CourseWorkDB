var bookRegisterViewModel;

function Book(id, name, editionYear, publishing, pages, udcId) {
    var self = this;

    self.ID = ko.observable(id);
    self.Name = ko.observable(name);
    self.EditionYear = ko.observable(editionYear);
    self.Publishing = ko.observable(publishing);
    self.Pages = ko.observable(pages);
    self.UDCID = ko.observable(udcId);

    self.createBook = function () {
        var dataObject = ko.toJSON(this);

        $.ajax({
            url: '/api/BookApi',
            type: 'post',
            data: dataObject,
            contentType: 'application/json',
            success: function (data) {
                bookRegisterViewModel.bookListViewModel.books.push(new Book(data.ID, data.Name, data.EditionYear, data.Publishing, data.Pages, data.UDCID));

                self.ID(null);
                self.Name('');
                self.EditionYear(null);
                self.Publishing('');
                self.Pages(null);
                self.UDCID(null);
            }
        });
    };
}

function BookList() {
    var self = this;
    self.books = ko.observableArray([]);


    self.getBooks = function() {
        self.books.removeAll();

        $.getJSON('/api/BookApi/', function(data) {
            $.each(data, function (key, value) {
                self.books.push(new Book(value.ID, value.Name, value.EditionYear, value.Publishing, value.Pages, value.UDCID));
            });
        });
    };

    self.removeBook = function(book) {
        $.ajax({
            url: '/api/BookApi/' + book.ID(),
            type: 'delete',
            contentType: 'application/json',
            success: function() {
                self.books.remove(book);
            }
        });
    };
};


bookRegisterViewModel = { createBookViewModel: new Book(), bookListViewModel: new BookList };

$(document).ready(function () {
    ko.applyBindings(bookRegisterViewModel);


    bookRegisterViewModel.bookListViewModel.getBooks();
});
