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
using Lovaglas_lib;

namespace LovaglasGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Datastore datas { get; init; }
        public MainWindow()
        {
            datas = new(["kepzes", "oktato", "orarend", "szint"]);
            //cb_kepzes.ItemsSource = datas.Kepzesek; ez valamiert azt mondja nincs object reference amikor van, beolvasas utan vannak benn adatok is
        }

        private void cb_kepzes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cb_oktato.IsEnabled = true;
            l_oktato.IsEnabled = true;
            cb_oktato.ItemsSource = datas.KepzesSzerint((cb_kepzes.SelectedValue as Kepzes).KepzesTipus);
        }

        private void cb_oktato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tb_tel.Text = (cb_oktato.SelectedValue as Oktato).Telefon;
            tb_email.Text = (cb_oktato.SelectedValue as Oktato).Email;
            tb_oradij.Text = (cb_oktato.SelectedValue as Oktato).Oradij.ToString();
        }
    }
}