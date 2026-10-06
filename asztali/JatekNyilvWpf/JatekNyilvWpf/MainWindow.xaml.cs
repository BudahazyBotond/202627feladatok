using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JatekNyilvWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Game> games = new List<Game>();

        public MainWindow()
        {
            InitializeComponent();
            GamesListBox.ItemsSource = games;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            GamesListBox.Visibility = Visibility.Hidden;
            AddButton.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;
            InputPanel.Visibility = Visibility.Visible;
            TitleTextBox.Clear();
            GenreTextBox.Clear();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text.Trim();
            string author = GenreTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
            {
                games.Add(new Game(title, author));
            }
            HideInputPanel();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            HideInputPanel();
        }

        private void HideInputPanel()
        {
            InputPanel.Visibility = Visibility.Hidden;
            GamesListBox.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Visible;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (GamesListBox.SelectedItem != null)
            {
                games.Remove((Game)GamesListBox.SelectedItem);
                GamesListBox.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem jelölt ki törlendő elemet.");
            }
        }
    }
}