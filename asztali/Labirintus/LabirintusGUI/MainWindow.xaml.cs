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

namespace LabirintusGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillLBs();
        }

        private void FillLBs()
        {
            for (int i = 0; i < 21; i++)
            {
                if (i >= 1 && 16 >= i)
                {
                    cb_ind.Items.Add(i);
                }
                if(i >= 5 && 20 >= i)
                {
                    cb_col.Items.Add(i);
                    cb_row.Items.Add(i);
                }
            }
            cb_ind.SelectedIndex = 2;
            cb_col.SelectedIndex = 7;
            cb_row.SelectedIndex = 7;
        }

        private void LabCreate(object sender, RoutedEventArgs e)
        {
            g_lab.Children.Clear();
            g_lab.ColumnDefinitions.Clear();
            g_lab.RowDefinitions.Clear();

            for(int i = 0;i < (int)cb_row.SelectedItem + 2;i++)
            {
                g_lab.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(15) });
            }
            for (int i = 0; i < (int)cb_col.SelectedItem + 2; i++)
            {
                g_lab.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(15) });
                CheckBox upcb = new CheckBox
                {
                    IsChecked = true,
                    IsEnabled = false,
                    Name = $"cb_0_{i}"
                };
                CheckBox downcb = new CheckBox
                {
                    IsChecked = true,
                    IsEnabled = false,
                    Name = $"cb_{(int)cb_col.SelectedItem + 1}_{i}"
                };
                Grid.SetColumn(upcb, i);
                Grid.SetRow(upcb, 0);
                g_lab.Children.Add(upcb);
                Grid.SetColumn(downcb, i);
                Grid.SetRow(downcb, (int)cb_col.SelectedItem + 1);
                g_lab.Children.Add(downcb);
            }


        }

        private void LabSave(object sender, RoutedEventArgs e)
        {

        }
    }
}