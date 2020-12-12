using System.Windows;

namespace _40402601
{
    /// <summary>
    /// Interaction logic for ChooseInput.xaml
    /// </summary>
    public partial class ChooseInput : Window
    {
        public ChooseInput()
        {
            InitializeComponent();
        }

        private void ReadInputBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
        }

        private void UserInputBtn_Click(object sender, RoutedEventArgs e)
        {
            UserInput win = new UserInput();
            Close();
            win.Show();
        }
    }
}
