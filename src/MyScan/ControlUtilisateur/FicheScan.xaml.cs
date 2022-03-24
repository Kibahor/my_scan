using Model;
using System.Windows;
using System.Windows.Controls;

namespace MyScan.ControlUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour FicheScan.xaml
    /// </summary>
    public partial class FicheScan : UserControl
    {
        private Manager Manager => (App.Current as App).Manager;
        private Scan CurrentScan;

        public FicheScan()
        {
            InitializeComponent();
            //Lorsque le datacontext change on modifie le currentscan 
            DataContextChanged += new DependencyPropertyChangedEventHandler(FicheScan_DataContextChanged);
        }
        private void FicheScan_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CurrentScan = DataContext as Scan;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.CurrentScan = CurrentScan;
            DataContextChanged -= FicheScan_DataContextChanged; //Je me désabonne de l'event
            ((MainWindow)System.Windows.Application.Current.MainWindow).Navigate("Vue/Description.xaml", "Description");
        }
    }
}
