using System.Windows;
using Szepseg_lib;

namespace SzepsegWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataStore datas = new(["alkalmazottak", "kezelesek", "szakmak", "vendegek"]);
            cb_alkalmazott.Items.Clear();
            cb_szakma.Items.Clear();
            tb_tel.Clear();
            cb_alkalmazott.IsEnabled = false;
            l_alkalmazott.IsEnabled = false;
            cb_alkalmazott.ItemsSource = datas.szakmak.SzakmakList;
        }
    }
}