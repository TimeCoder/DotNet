using System;
using WPFApplicationCatel.ViewModels;

namespace WPFApplicationCatel.Views
{
    using Catel.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : DataWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
            : base(DataWindowMode.Custom)
        {
            InitializeComponent();
        }

        protected override Type GetViewModelType()
        {
            return typeof (MainViewModel);
        }
    }
}
