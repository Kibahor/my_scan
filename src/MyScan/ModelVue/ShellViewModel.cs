using MahApps.Metro.IconPacks;
using MyScan.Vue;
using System;
using System.Collections.ObjectModel;

namespace MyScan.ModelVue
{
    public class ShellViewModel
    {
        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppOptionsMenu = new ObservableCollection<MenuItem>();

        public ObservableCollection<MenuItem> Menu => AppMenu;

        public ObservableCollection<MenuItem> OptionsMenu => AppOptionsMenu;

        public ShellViewModel()
        {
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.HomeSolid },
                Label = "Accueil",
                NavigationType = typeof(Accueil),
                NavigationDestination = new Uri("Vue/Accueil.xaml", UriKind.RelativeOrAbsolute)
            });
            this.OptionsMenu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.LockSolid },
                Label = "Login (Inactif)",
                NavigationType = typeof(Login),
                NavigationDestination = new Uri("Vue/Login.xaml", UriKind.RelativeOrAbsolute)
            });
            this.OptionsMenu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CogsSolid },
                Label = "Paramètres",
                NavigationType = typeof(Parametre),
                NavigationDestination = new Uri("Vue/Parametre.xaml", UriKind.RelativeOrAbsolute)
            });
        }
    }
}