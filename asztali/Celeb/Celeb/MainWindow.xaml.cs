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
using System.IO;
using Celeb_lib;

namespace Celeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ember> emberek = new();
        void Feltoltes()
        {
            foreach (var item in File.ReadAllLines("hires.txt").Skip(1))
            {
                emberek.Add(new Ember(item));
            }
        }
        void Nemzetisegek()
        {
            var nemzetisegek = emberek.Select(x => x.Nemzetiseg).Distinct().Order();
            cB_nemzetiseg.ItemsSource = nemzetisegek;
            cB_nemzetiseg.SelectedIndex = 0;
        }

        public MainWindow()
        {
            InitializeComponent();
            Feltoltes();
            Nemzetisegek();
        }

        void VisszaAllitas()
        {
            tb_nev.Text = String.Empty;
            cB_foglalkozas.SelectedIndex = 0;
            ch_vilaghiru.IsChecked = false;
            rB_Ferfi.IsChecked = true;
            rB_No.IsChecked = false;
            cB_nemzetiseg.SelectedIndex = 0;
        }

        private void btn_Rogzit_Click(object sender, RoutedEventArgs e)
        {
            if (tb_nev.Text == String.Empty)
            {
                MessageBox.Show("Adja meg a híres ember nevét!", "Hiba!");
                return;
            }
            string urlapAdat = $"{tb_nev.Text};{cB_foglalkozas.Text};{cB_nemzetiseg.Text};{(ch_vilaghiru.IsChecked == true ? "igen" : "nem")};{(rB_Ferfi.IsChecked == true ? "férfi" : "nő")}";
            File.AppendAllText("hires.txt", urlapAdat + Encoding.UTF8);
            VisszaAllitas();
        }

        private void btn_Megsem_Click(object sender, RoutedEventArgs e)
        {
            VisszaAllitas();
        }
    }
}