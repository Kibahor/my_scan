using Model;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

namespace MyScan.Vue
{
    /// <summary>
    /// Logique d'interaction pour Description.xaml
    /// </summary>
    public partial class Description : Page
    {
        //On récupére l'instance du Manager
        private Manager Manager => (App.Current as App).Manager; 

        public Description()
        {
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// Charge les donnée dans la vue
        /// </summary>
        private void LoadData()
        {
            //Comme le titre est un usercontrol,c'est le moyen le pllus efficace que j'ai trouvé
            ScanTitle.Texte = Manager.CurrentScan.Nom; 
            //Convertit la date de parution en string sous la forme mm/MM/YYYY
            DateParution.Text = Manager.CurrentScan.DateParution?.ToShortDateString();
            //Force l'actualisation des données
            DataContext = null; 
            DataContext = Manager.CurrentScan;
        }

        /// <summary>
        /// Action lors de l'appuie du bouton de suppression
        /// </summary>
        private async void DelButton_Click(object sender, RoutedEventArgs e)
        {
            //Récupére l'instance de la fenêtre principal
            var metroWindow = (Application.Current.MainWindow as MetroWindow);
            //Déclare les paramètres du dialogs
            var dialogSettings = new MetroDialogSettings
            {
                AffirmativeButtonText = "Annuler",
                NegativeButtonText = "Supprimer",
                OwnerCanCloseWithDialog = true,
                ColorScheme = metroWindow.MetroDialogOptions.ColorScheme,
            };

            //J'envoie le Dialogs et j'attend la réponse de l'utilisateur
            MessageDialogResult reponse = await metroWindow.ShowMessageAsync(($"Voulez-vous vraiment supprimer {Manager.CurrentScan.Nom} ?"), "Cette action va supprimer le scan de l'accueil et le dossier de façon définitive", MessageDialogStyle.AffirmativeAndNegative, dialogSettings);
            if (reponse == MessageDialogResult.Negative) //Negative = bouton "Supprimer"
            {
                if (Manager.Supprimer()) //Je supprime le scan et si la valeur retourné est positive
                {
                    //J'affiche le message de confirmation
                    DelText.Visibility = Visibility.Visible;
                    //Je rends les boutons inactif 
                    EditButton.IsEnabled = false;
                    DelButton.IsEnabled = false;
                    PlayButton.IsEnabled = false;
                }
                else
                    //J'affiche le message d'échec de la suppression
                    FailDelText.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Quand on veut modifier un Scan
        /// </summary>
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ModifierScan(); //J'ouvre une fenêtre externe
            window.Closed += NewWindowClose; //J'abonne l'événement pour que quand la fenêtre externe est fermé, la description se mette à jour
            window.ShowDialog(); //ouvre la fenêtre
        }

        public void NewWindowClose(object sender, System.EventArgs e)
        {
            LoadData();

        }



    }
}
