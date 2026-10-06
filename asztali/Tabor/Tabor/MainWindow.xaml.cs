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
using Tabor_lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace Tabor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<NyelvAdat> Lista = new List<NyelvAdat>();
        public MainWindow()
        {
            InitializeComponent();
            NyelvOlvas();
            Alaphelyzet();
        }

        public void SzintKivalasztva()
        {
            if (szint_cb.SelectedItem == null || nyelv_cb.CommandBindings == null) return;
            string kivalasztottSzint = (szint_cb.SelectedItem as System.Windows.Controls.ComboBoxItem)!.Content.ToString()!;
            var szuro = Lista.Where(x => x.Szint.Equals(kivalasztottSzint)).Select(x => x.Nyelv).Distinct().OrderBy(x=>x).ToList();
            nyelv_cb.ItemsSource = szuro;
            if (szuro.Any())
            {
                nyelv_cb.SelectedIndex = 0;
            }
        }

        public void NyelvOlvas()
        {
            string[] f = File.ReadAllLines("nyelv.csv");
            foreach (string s in f) {
                string[] sor = s.Split(";");
                Lista.Add(new NyelvAdat(sor[0], sor[1]));
            }
        }

        public void Alaphelyzet()
        {
            szint_cb.SelectedIndex = 0;
            nev_tb.Clear();
            fiu_rb.IsChecked = true;
            lany_rb.IsChecked = false;
            bentlakasos_chb.IsChecked = false;
            SzintKivalasztva();
        }

        private void SzintValtozas(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            SzintKivalasztva(); //ez valamiert ugy tunik hogy nem mukodik, de mas megoldast nem talaltam sehol
        }

        private void Rogzit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nev_tb.Text))
            {
                MessageBox.Show("Adja meg a jelentkező nevét!", "Hiba");
                return;
            }

            try
            {
                string szint = (szint_cb.SelectedItem as System.Windows.Controls.ComboBoxItem)!.Content.ToString()!;
                string nyelv = nyelv_cb.SelectedItem?.ToString() ?? "";
                string nev = nev_tb.Text.Trim();
                string nem = fiu_rb.IsChecked == true ? "fiú" : "lány";
                string bentlakasos = bentlakasos_chb.IsChecked == true ? "igen" : "nem";

                string ujSor = $"{nev};{szint};{nyelv};{bentlakasos};{nem}";
                string fajlUtvonal = "jelentkezok.txt";

                if (File.Exists(fajlUtvonal))
                {
                    File.AppendAllText(fajlUtvonal, ujSor + "\n");
                }
                else
                {
                    File.WriteAllText(fajlUtvonal, ujSor + "\n");
                }

                Alaphelyzet();
                MessageBox.Show("Sikeres rögzítés!", "Információ");
            }
            catch
            {
                MessageBox.Show("Hiba a rögzítés során!", "Hiba");
            }
        }



        private void Megsem_Click(object sender, RoutedEventArgs e)
        {
            Alaphelyzet();
        }
    }
}