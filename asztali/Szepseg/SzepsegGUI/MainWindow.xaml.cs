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
using Szepseg_lib;

namespace SzepsegGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Datastore datas;
        public MainWindow()
        {
            InitializeComponent();
            datas = new(["alkalmazottak", "kezelesek", "szakmak", "vendegek"]);
            cb_szakma.ItemsSource = datas.SzakmakList._list;
        }
        private void cb_szakma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_alk.ItemsSource = datas.AlkalmazottakList._list.Where(x=>x.SzakmaId == (cb_szakma.SelectedItem as Szakma).SzakmaId);
            cb_alk.IsEnabled = true;
            l_alk.IsEnabled = true;
        }
        private void cb_alk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tb_tel.Text = (cb_alk.SelectedItem as Alkalmazott).Telefon;
        }
    }
}