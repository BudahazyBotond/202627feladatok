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
using Erettsegi_lib;

namespace Erettsegi_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Erettsegik erettsegik;
        public MainWindow()
        {
            InitializeComponent();
            erettsegik = new("tanar.txt", "vizsgak.txt", "vizsgazo.txt");
            LoadComboBoxes();
        }

        public void LoadComboBoxes()
        {
            cb_diak.ItemsSource = erettsegik.vizsgazoLista.DistinctBy(x=>x.Nev).Select(x => x.Nev);
            cb_diak.SelectedIndex = -1;
        }
        private void cb_diak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_diak.SelectedItem != null)
            {
                string selectedDiak = cb_diak.SelectedItem.ToString()!;

                if (erettsegik.vizsgazoLista.Select(x => x.Nev).Contains(selectedDiak))
                {
                    List<Vizsgazo> vizsgazo = erettsegik.vizsgazoLista.Where(x => x.Nev == selectedDiak).ToList();
                    List<Vizsga> vizsgak = erettsegik.vizsgaLista.Where(x => x.VizsgazoId == vizsgazo.Select(x => x.Id).First()).ToList();
                    cb_tantargy.ItemsSource = vizsgak.Select(x=>x.Vizsgatargy);
                    cb_tantargy.SelectedIndex = -1;
                }
                else
                {
                    cb_tantargy.ItemsSource = null;
                }
                tb_adatok.Text = string.Empty;
            }
            else
            {
                cb_tantargy.ItemsSource = null;
                tb_adatok.Text = string.Empty;
            }
        }

        private void cb_tantargy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb_tantargy.SelectedItem != null)
            {
                string selectedDiak = cb_diak.SelectedItem.ToString()!;
                List<Vizsgazo> vizsgazo = erettsegik.vizsgazoLista.Where(x => x.Nev == selectedDiak).ToList();
                List<Vizsga> vizsgak = erettsegik.vizsgaLista.Where(x => x.VizsgazoId == vizsgazo.Select(x => x.Id).First()).ToList();
                string selectedTargy = cb_tantargy.SelectedItem.ToString()!;
                Vizsga vizsga = vizsgak.Where(x=>x.Vizsgatargy == selectedTargy).First();
                Tanar tanar = erettsegik.tanarLista.Where(x=>x.Id == vizsga.TanarId).First();
                tb_adatok.Text = tanar.Nev;
            }

        }

    }
}