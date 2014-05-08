using System.Collections.ObjectModel;
using System.Threading;
using Catel.Data;
using Catel.MVVM.Services;
using Seterlund.CodeGuard;
using BooksLibrary.Models;

namespace BooksLibrary.ViewModels
{
    using Catel.MVVM;

    /// <summary>
    /// MainWindow view model.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly IMessageService _messageService;

        public MainViewModel(IUIVisualizerService uiVisualizerService, IPleaseWaitService pleaseWaitService, IMessageService messageService)
        {
            Guard.That(uiVisualizerService).IsNotNull();
            Guard.That(pleaseWaitService).IsNotNull();
            Guard.That(messageService).IsNotNull();

            _uiVisualizerService = uiVisualizerService;
            _pleaseWaitService = pleaseWaitService;
            _messageService = messageService;

            BooksCollection = new ObservableCollection<Book>
            {
		new Book {Title = "Автостопом по галактике", Author = "Дуглас Адамс"},
		new Book {Title = "Сто лет одиночества", Author = "Габриель Гарсиа Маркес"},
		new Book {Title = "Маленький принц", Author = "Антуан де Сент-Экзюпери"},
		new Book {Title = "1984", Author = "Джордж Оруэлл"},
		new Book {Title = "Над пропастью во ржи", Author = "Джером Дэвид Сэлинджер"},
            };
        }
        
        public override string Title { get { return "View model title"; } }

        
        public ObservableCollection<Book> BooksCollection
        {
            get { return GetValue<ObservableCollection<Book>>(BooksCollectionProperty); }
            set { SetValue(BooksCollectionProperty, value); }
        }
        public static readonly PropertyData BooksCollectionProperty = RegisterProperty("BooksCollection", typeof(ObservableCollection<Book>));


        public Book SelectedBook
        {
            get { return GetValue<Book>(SelectedBookProperty); }
            set { SetValue(SelectedBookProperty, value); }
        }
        public static readonly PropertyData SelectedBookProperty = RegisterProperty("SelectedBook", typeof(Book));

        
        private Command _addCommand;
        public Command AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new Command(
                    () =>
                    {
                        var viewModel = new BookViewModel(new Book());

                        _uiVisualizerService.ShowDialog(viewModel, (sender, e) =>
                        {
                            if (e.Result ?? false)
                            {
                                BooksCollection.Add(viewModel.BookObject);
                            }
                        });
                        
                    }));
            }
        }


        private Command _editCommand;
        public Command EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new Command(
                    () =>
                    {
                        var viewModel = new BookViewModel(SelectedBook);
                        _uiVisualizerService.ShowDialog(viewModel);
                    },
                    () => SelectedBook != null));
            }
        }


        private Command _removeCommand;
        public Command RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new Command(
                    () =>
                    {
                        if (_messageService.Show("Вы действительно хотите удалить объект?", "Внимание!",
                            MessageButton.YesNo, MessageImage.Warning) != MessageResult.Yes)
                        {
                            return;
                        }

                        _pleaseWaitService.Show("Удаление объекта...");

                        Thread.Sleep(2000);
                        BooksCollection.Remove(SelectedBook);

                        _pleaseWaitService.Hide();
                    },
                    () => SelectedBook != null));
            }
        }

        
    }
}
