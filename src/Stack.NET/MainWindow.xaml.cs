using System.Windows.Input;
using Stack.NET.ViewModel;

namespace Stack.NET
{
    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private SceneViewModel ViewModel => (SceneViewModel) DataContext;

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ViewModel.Move(e.Delta / 250D);
        }
    }
}