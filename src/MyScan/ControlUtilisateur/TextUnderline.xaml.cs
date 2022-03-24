using System.Windows.Controls;

namespace MyScan.ControlUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour TextUnderline.xaml
    /// </summary>
    public partial class TextUnderline : UserControl
    {
        public TextUnderline()
        {
            InitializeComponent();
            DataContext = this;

        }
        public string Texte
        {
            get; set;

        }
        public int Taille
        {
            get; set;
        }

    }
}
