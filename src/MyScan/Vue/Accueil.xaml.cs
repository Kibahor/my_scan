using Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace MyScan.Vue
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {
        //On récupére l'instance du Manager
        private Manager Manager => (App.Current as App).Manager;
        private ObservableCollection<Scan> Collection;

        public Accueil()
        {
            InitializeComponent();
            //Vérifie qu'il y a des scans, si non affiche le message
            if (Manager.ScanDictionnary.Count == 0)
            {
                NoScan.Visibility = Visibility.Visible;
                return;
            }

            //On convertit le dictionnaire en observables collection pour pouvoir détecté les changements
            Collection = new ObservableCollection<Scan>(Manager.ScanDictionnary.Values);
            //J'indique la collection à l'item control qui va générer les usercontrols
            ItemControl.ItemsSource = Collection;

            //J'abonne les méthodes au événements 
            Collection.CollectionChanged += CollectionHasChanged; //Actualise le nombre de fiche en cas de changement
            ComboBox_Ordre.SelectionChanged += ComboBox_SelectionChanged; //ComboBox (Croissant/Décroissant)
            ComboBox_Trier.SelectionChanged += ComboBox_SelectionChanged; //ComboBox (Nom/Genre...)
        }

        private void LoadData() => ItemControl.ItemsSource = Collection;

        private void Reset()
        {
            Collection = new ObservableCollection<Scan>(Manager.ScanDictionnary.Values);
            LoadData();
        }

        private void SearchBox_MakeSearch(object sender, RoutedEventArgs e)
        {
            if (Collection == null) return; //Si la collection est null il n'y a rien à faire

            if (String.IsNullOrWhiteSpace(SearchBox.Text)) //Si la textbox est vide on restore l'affichage de base
            {
                Reset();
                return;
            }

            Collection = new ObservableCollection<Scan>(Trier.RechercheParNom(Collection, SearchBox.Text));
            LoadData();
        }
        private void Tri(bool IsDesc)
        {
            switch (ComboBox_Trier.SelectedIndex) //Pour chaque index on applique le tri
            {
                case 0:
                    Collection = new ObservableCollection<Scan>(Trier.TriParNom(Collection, IsDesc));
                    break;
                case 1:
                    Collection = new ObservableCollection<Scan>(Trier.TriParAuteur(Collection, IsDesc));
                    break;
                case 2:
                    Collection = new ObservableCollection<Scan>(Trier.TriParGenre(Collection, IsDesc));
                    break;
                case 3:
                    Collection = new ObservableCollection<Scan>(Trier.TriParClassification(Collection, IsDesc));
                    break;
                case 4:
                    Collection = new ObservableCollection<Scan>(Trier.TriParNote(Collection, IsDesc));
                    break;
            }
        }
        private void ComboBox_SelectionChanged(object sender, System.EventArgs e)
        {
            Tri(ComboBox_Ordre.SelectedIndex != 0); //Si l'index est de 0 alors c'est croissant, dans le cas contraire c'est décroissant
            LoadData();
        }
        private void CollectionHasChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            LoadData(); //Quand la collection change les données s'actualise
        }

        private void SearchBox_FocusChange(object sender, RoutedEventArgs e)
        {
            //Permet de cacher l'icon de loupe et le watermaker "recherche"
            //quand on tape quelque chose dans la barre de recherche
            if (SearchBox_Icon.IsVisible)
            {
                SearchBox_Icon.Visibility = Visibility.Collapsed;
                SearchBox_Watermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                SearchBox_Icon.Visibility = Visibility.Visible;
                SearchBox_Watermark.Visibility = Visibility.Visible;
            }

        }
    }
}
