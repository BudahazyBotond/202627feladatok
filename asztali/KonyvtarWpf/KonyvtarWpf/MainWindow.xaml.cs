using System.Collections.ObjectModel;
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

namespace KonyvtarWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> books = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
            BooksListBox.ItemsSource = books;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            BooksListBox.Visibility = Visibility.Hidden;
            AddButton.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;
            InputPanel.Visibility = Visibility.Visible;
            TitleTextBox.Clear();
            AuthorTextBox.Clear();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text.Trim();
            string author = AuthorTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author))
            {
                books.Add(new Book(title, author));
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
            BooksListBox.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Visible;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListBox.SelectedItem != null)
            {
                books.Remove((Book)BooksListBox.SelectedItem);
                BooksListBox.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem jelölt ki törlendő elemet.");
            }
        }
    }
}