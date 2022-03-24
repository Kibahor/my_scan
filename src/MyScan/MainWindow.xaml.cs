using MahApps.Metro.Controls;
using Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using MenuItem = MyScan.ModelVue.MenuItem;

namespace MyScan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Navigation.NavigationServiceEx navigationServiceEx;
        private Manager Manager => (App.Current as App).Manager;

        public MainWindow()
        {

            InitializeComponent();

            //On abonne la méthode qui va lancer la sauvegarde des donnée à la fermeture de la fenêtre
            this.Closing += MainWindow_Closing;

            //On déclare et abonne les méthodes au événement de l'hamburger menu
            navigationServiceEx = new Navigation.NavigationServiceEx();
            navigationServiceEx.Navigated += this.NavigationServiceEx_OnNavigated;
            HamburgerMenuControl.Content = this.navigationServiceEx.Frame;

            // Navigue vers la page par défaut (l'accueil)
            Loaded += (sender, args) => this.navigationServiceEx.Navigate(new Uri("Vue/Accueil.xaml", UriKind.RelativeOrAbsolute));
            Loaded += MainWindow_Loaded_Restore_Theme;
        }

        private void MainWindow_Loaded_Restore_Theme(object sender, RoutedEventArgs e)
        {
            //Restaure les paramètres
            ThemeHelper.SetThemeColor(Manager.CurrentSetting.Theme);
            if (Manager.CurrentSetting.ModeNuit)
                ThemeHelper.ToogleThemeBase();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Sauvegarde JSON quand la fenêtre est en train de fermé
            Manager.Sauvegarder();
        }

        internal void Navigate(string PathVue, string title) //Simplifie la navigation depuis les autre classes
        {
            this.navigationServiceEx.Navigate(new Uri(PathVue, UriKind.RelativeOrAbsolute));
            this.Title = title;
        }
        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            if (e.InvokedItem is MenuItem menuItem && menuItem.IsNavigation)
            {
                this.navigationServiceEx.Navigate(menuItem.NavigationDestination);
                this.Title = menuItem.Label;
            }
        }

        private void NavigationServiceEx_OnNavigated(object sender, NavigationEventArgs e)
        {
            // sélectionne l'élément du menu
            this.HamburgerMenuControl.SelectedItem = this.HamburgerMenuControl
                                                         .Items
                                                         .OfType<MenuItem>()
                                                         .FirstOrDefault(x => x.NavigationDestination == e.Uri);
            this.HamburgerMenuControl.SelectedOptionsItem = this.HamburgerMenuControl
                                                                .OptionsItems
                                                                .OfType<MenuItem>()
                                                                .FirstOrDefault(x => x.NavigationDestination == e.Uri);

            this.GoBackButton.Visibility = this.navigationServiceEx.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void GoBack_OnClick(object sender, RoutedEventArgs e)
        {
            this.navigationServiceEx.GoBack();
        }

    }
}
