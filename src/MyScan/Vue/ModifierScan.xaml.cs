using MahApps.Metro.Controls;
using Model;
using System;
using System.Windows;

namespace MyScan.Vue
{
    /// <summary>
    /// Logique d'interaction pour ModifierScan.xaml
    /// </summary>
    public partial class ModifierScan : MetroWindow
    {
        //On récupére l'instance du Manager
        private Manager Manager => (Application.Current as App).Manager;

        public ModifierScan()
        {
            InitializeComponent();
            DataContext = Manager.CurrentScan; //Pour préremplir les champs avec les informtions déjà disponible
            ComboBox_Status.SelectedIndex = ComboBox_Status.Items.IndexOf(Manager.CurrentScan.Status);  //Seul moyen que j'ai trouver pour sélectionner un item a partir d'un string

        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_Titre.Text)) // Vérifie que le titre n'est pas vide
            {
                TitleNotValide.Visibility = Visibility.Visible;
                return;
            }
            //Redéclare le scan avec toute les informations rempli par l'utilisateur
            Manager.Modifier(new Scan(TextBox_Titre.Text,
                                      TextBox_Description.Text,
                                      TextBox_Auteur.Text,
                                      TextBox_Genre.Text,
                                      TextBox_Classification.Text,
                                      ComboBox_Status.Text,
                                      Manager.CurrentScan.NbTome,
                                      TextBox_Note.Value,
                                      DatePicker_DateDeParution.SelectedDate,
                                      Manager.CurrentScan.URL,
                                      Manager.CurrentScan.Cover));
            this.Close(); //ferme la fenêtre
        }
        private void Esc_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //ferme la fenêtre si on appuis sur "Annuler"
        }
    }
}
