using Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MyScan.Vue
{
    /// <summary>
    /// Logique d'interaction pour Parametre.xaml
    /// </summary>
    public partial class Parametre : Page
    {
        private Manager Manager => (App.Current as App).Manager;
        public Parametre()
        {
            InitializeComponent();
            DataContext = Manager.CurrentSetting; //Pour faire correspondre les paramètre actuel à la page
        }
        /// <summary>
        /// Lorsque que le Toggle du mode nuit a changé d'état
        /// </summary>
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (ThemeHelper.IsDarkTheme() && ToggleModeNuit.IsOn) //Empêche de changer le mode nuit si le mode nuit est déja activé
                return;
            ThemeHelper.ToogleThemeBase();//Applique le mode nuit
            Manager.CurrentSetting.ModeNuit = ThemeHelper.IsDarkTheme(); //modifie les current settings dans manager
        }
        /// <summary>
        /// Lorsqu'une couleur est chosis
        /// </summary>
        private void Theme_Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = sender as Button; //Cast le sender en bouton
            ThemeHelper.SetThemeColor(ClickedButton.Name); //Récupère le nom du bouton qui correspond à la couleur du thème
            Manager.CurrentSetting.Theme = ClickedButton.Name; //modifie les current settings 
        }

        /// <summary>
        /// Quand on appuie su rmodifier le profile
        /// </summary>
        private void Profile_Button_Click(object sender, RoutedEventArgs e)
        {
            //Vérifie que les champs obligatoire sont rempli (Pseudo | Nom | Prénom)
            if(String.IsNullOrWhiteSpace(TextBox_Pseudo.Text) || String.IsNullOrWhiteSpace(TextBox_Nom.Text) || String.IsNullOrWhiteSpace(TextBox_Prenom.Text))
                ValueNotValide.Visibility = Visibility.Visible;
            else //Les champs sont valides
            {
                //Vérifie que le chemin de l'avatar existe
                if (!String.IsNullOrEmpty(TextBox_Avatar.Text))
                {
                    if (System.IO.File.Exists(TextBox_Avatar.Text))
                    {
                        Manager.CurrentSetting.Avatar = TextBox_Avatar.Text;
                        FileNotExist.Visibility = Visibility.Collapsed;
                    }
                    else
                        FileNotExist.Visibility = Visibility.Visible;
                }
                //Modifie les valeurs dans le manager
                Manager.CurrentSetting.Pseudo = TextBox_Pseudo.Text;
                Manager.CurrentSetting.Nom = TextBox_Nom.Text;
                Manager.CurrentSetting.Prenom = TextBox_Prenom.Text;
                //Enlève le message de champs obligatoire
                ValueNotValide.Visibility = Visibility.Collapsed;

                //Actualise la vue avec les nouvelles informations
                bool dark = ThemeHelper.IsDarkTheme();
                DataContext = null;
                ToggleModeNuit.IsOn = dark;
                DataContext = Manager.CurrentSetting;
            }
                
         }
    }
}
