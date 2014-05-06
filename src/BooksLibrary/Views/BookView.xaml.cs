using System;
using Catel.Windows;
using BooksLibrary.ViewModels;

namespace BooksLibrary.Views
{
    public partial class BookView : DataWindow
    {
        public BookView() //: base(DataWindowMode.Custom)
        {
            //AddCustomButton(new DataWindowButton("Отмена", () => DialogResult = false));
            //AddCustomButton(new DataWindowButton("Сохранить", () => DialogResult = true));

            InitializeComponent();
        }
        
        protected override Type GetViewModelType()
        {
            return typeof (BookViewModel);
        }
    }
}
