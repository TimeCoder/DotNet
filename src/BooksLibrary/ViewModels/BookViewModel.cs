using System.Collections.Generic;
using Catel.Data;
using Catel.MVVM;
using Seterlund.CodeGuard;
using BooksLibrary.Models;

namespace BooksLibrary.ViewModels
{
    public class BookViewModel : ViewModelBase
    {
        [Model]
        public Book BookObject
        {
            get { return GetValue<Book>(BookObjectProperty); }
            set { SetValue(BookObjectProperty, value); }
        }
        public static readonly PropertyData BookObjectProperty = RegisterProperty("BookObject", typeof(Book));


        [ViewModelToModel("BookObject", "Author")]
        public string BookAuthor
        {
            get { return GetValue<string>(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }
        public static readonly PropertyData AuthorProperty = RegisterProperty("BookAuthor", typeof(string));


        [ViewModelToModel("BookObject", "Title")]
        public string BookTitle
        {
            get { return GetValue<string>(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly PropertyData TitleProperty = RegisterProperty("BookTitle", typeof(string));

        
        public BookViewModel(Book book = null)
        {
            BookObject = book ?? new Book();
        }
    }
}
