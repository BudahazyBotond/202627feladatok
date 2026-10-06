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

namespace Wpf_proba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void gomb_Click(object sender, RoutedEventArgs e)
        {
            if(gomb.Background == Brushes.PaleVioletRed)
            {
                gomb.Background = Brushes.IndianRed;
            }
            else if(gomb.Background == Brushes.IndianRed)
            {
                gomb.Background = Brushes.PaleVioletRed;
            }
            listadoboz.Items.Clear();
            listadoboz.Items.Add("Gomb megnyomva");
            listadoboz.Items.Add("A gomb színe:" + gomb.Background);
            listadoboz.Items.Add(Application.Current.Windows.Count);
            listadoboz.Items.Add(Application.Current.MainWindow.Title);
            listadoboz.Items.Add(Application.Current.StartupUri);
            listadoboz.Items.Add(listadoboz.Items.Count);
            Application.Current.Properties["Allat"] = "Mókus";
            Application.Current.Properties["Nev"] = "BB";
            listadoboz.Items.Add(Application.Current.Properties.Count);
            foreach (var item in Application.Current.Properties)
            {
                listadoboz.Items.Add(item);
            }

            }
    }
}