using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LottoGUI_BB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentGameType = 2;
        private int numbersToDraw = 6;
        private int maxNumber = 45;
        private int rows = 5;
        private int columns = 9;
        private Random r = new();

        private List<int> selectedNumbers = new List<int>();
        private List<int> drawnNumbers = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
            CreateGrid();
            rb_hatos.IsChecked = true;
        }

        private void GameType_Checked(object sender, RoutedEventArgs e)
        {
            if (rb_otos.IsChecked == true)
            {
                currentGameType = 1;
                numbersToDraw = 5;
                maxNumber = 90;
                rows = 9;
                columns = 10;
            }
            else if (rb_hatos.IsChecked == true)
            {
                currentGameType = 2;
                numbersToDraw = 6;
                maxNumber = 45;
                rows = 5;
                columns = 9;
            }
            else if (rb_skandinav.IsChecked == true)
            {
                currentGameType = 3;
                numbersToDraw = 7;
                maxNumber = 35;
                rows = 5;
                columns = 7;
            }

            selectedNumbers.Clear();
            drawnNumbers.Clear();
            btn_sorsolas.Foreground = Brushes.Gray;
            tb_kihuzott.Text = "";
            tb_talalatok.Text = "";
            sp_kihuzott.Visibility = Visibility.Hidden;
            sp_talalat.Visibility = Visibility.Hidden;
            CreateGrid();
        }

        private void SorsolasButton_Click(object sender, RoutedEventArgs e)
        {
            drawnNumbers.Clear();
            for (int i = 0; numbersToDraw > i;i++)
            {
                int rando = r.Next(1, maxNumber + 1);
                if (!drawnNumbers.Contains(rando))
                {
                    drawnNumbers.Add(rando);
                }
                else i--;
            }
            sp_kihuzott.Visibility = Visibility.Visible;
            sp_talalat.Visibility = Visibility.Visible;
            tb_kihuzott.Text = string.Join(", ", drawnNumbers);
            tb_talalatok.Text = drawnNumbers.Intersect(selectedNumbers).Count().ToString();
        }

        private void CreateGrid()
        {
            int numbersToPick = numbersToDraw;
            g_nums.Children.Clear();
            g_nums.ColumnDefinitions.Clear();
            g_nums.RowDefinitions.Clear();

            for (int i = 0; i < rows; i++)
            {
                g_nums.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25) });
            }
            for (int i = 0; i < columns; i++)
            {
                g_nums.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(25) });
            }
            for(int i = 0;i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Label label = new Label();
                    label.Content = i * columns + j + 1;
                    label.Background = Brushes.White;
                    label.MouseDown += (s, e) =>
                    {
                        Label label = s as Label;
                        if (label.Background == Brushes.White && numbersToPick > 0)
                        {
                            label.Background = Brushes.Green;
                            numbersToPick--;
                            selectedNumbers.Add(int.Parse(label.Content.ToString()!));
                            if(numbersToPick == 0)
                            {
                                btn_sorsolas.IsEnabled = true;
                                btn_sorsolas.Foreground = Brushes.Black;
                            }
                        }
                        else
                        {
                            if(label.Background == Brushes.Green)
                            {
                                numbersToPick++;
                                selectedNumbers.Remove(int.Parse(label.Content.ToString()!));
                            }
                            label.Background = Brushes.White;
                            if (numbersToPick != 0)
                            {
                                btn_sorsolas.IsEnabled = false;
                                btn_sorsolas.Foreground = Brushes.Gray;
                            }
                        }
                        tb_talalatok.Text = numbersToPick.ToString();
                    };
                    Grid.SetColumn(label, j);
                    Grid.SetRow(label, i);
                    g_nums.Children.Add(label);
                }
            }
        }
    }
}