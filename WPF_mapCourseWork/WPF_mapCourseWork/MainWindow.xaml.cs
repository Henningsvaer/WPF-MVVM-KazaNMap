using System.Windows;

namespace WPF_mapCourseWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        #region MenuAnimation

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.ColumnDefinitions[0].Width = new GridLength(250);

            MenuMiniStackPanel.Visibility = Visibility.Hidden;
            MenuStackPanel.Visibility = Visibility.Visible;

        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.ColumnDefinitions[0].Width = new GridLength(35);

            MenuStackPanel.Visibility = Visibility.Hidden;
            MenuMiniStackPanel.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
