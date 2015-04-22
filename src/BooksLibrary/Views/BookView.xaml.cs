using System;
using Catel.Windows;
using BooksLibrary.ViewModels;

namespace BooksLibrary.Views
{
    public partial class BookView : DataWindow
    {
        public BookView() 
        {
            InitializeComponent();
        }

        public BookView(BookViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

    }
}
