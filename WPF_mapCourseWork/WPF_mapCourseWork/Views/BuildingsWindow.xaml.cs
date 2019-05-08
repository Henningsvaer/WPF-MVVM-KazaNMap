using System.Windows;

namespace WPF_mapCourseWork
{
    /// <summary>
    /// Логика взаимодействия для BuildingsWindow.xaml
    /// </summary>
    public partial class BuildingsWindow : Window
    {
        public AnyBuilding AnyBuilding { get; set; }

        public BuildingsWindow(AnyBuilding ab)
        {
            InitializeComponent();
            AnyBuilding = ab;
            this.DataContext = AnyBuilding;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
