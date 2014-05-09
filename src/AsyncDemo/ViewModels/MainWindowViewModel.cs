using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Catel.Data;
using Catel.MVVM;
using Catel.MVVM.Services;

namespace AsyncDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IPleaseWaitService _pleaseWaitService;
        public override string Title { get { return "Async demo"; } }

        public MainWindowViewModel(IPleaseWaitService pleaseWaitService)
        {
            _pleaseWaitService = pleaseWaitService;
        }
                
        public int Sum
        {
            get { return GetValue<int>(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
        public static readonly PropertyData ResultProperty = RegisterProperty("Sum", typeof(int));


        private ICommand _calcWithBusyIndicatorCommand;
        public ICommand CalcWithBusyIndicatorCommand
        {
            get
            {
                return _calcWithBusyIndicatorCommand ?? (_calcWithBusyIndicatorCommand = new Command(
                    () =>
                    {
                        _pleaseWaitService.Show("Вычисление результата...");
                        Sum = longCalculation().Result;
                        _pleaseWaitService.Hide();
                    }));
            }
        }
        
        private ICommand _calcAsyncCommand;
        public ICommand CalcAsyncCommand
        {
            get
            {
                return _calcAsyncCommand ?? (_calcAsyncCommand = new Command(
                    async () =>
                    {
                        Sum = await longCalculation();
                    }));
            }
        }

        private ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                return _resetCommand ?? (_resetCommand = new Command( () => Sum = 0 ));
            }
        }

        private Task<int> longCalculation()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(4000);

                return 2 + 2;
            });
        }
    }
}
