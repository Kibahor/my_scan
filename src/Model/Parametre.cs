using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Model
{
    public class Parametre
    {
        /// <summary>
        /// Pseudo
        /// </summary>
        public string Pseudo { get; set; }

        /// <summary>
        /// Prenom
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Nom
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// URL de l'avatar
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Etat du ModeNuit
        /// </summary>
        public bool ModeNuit { get; set; }
        /// <summary>
        /// Couleur du thème
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// Constructeur de la classe Mode Nuit et Theme par défaut
        /// </summary>
        public Parametre()
        {
            ModeNuit = false;
            Theme = "Blue";
            Pseudo = "Pseudo";
            Prenom = "Prenom";
            Nom = "Nom";
            Avatar = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Avatar.jpg");

        }
        [JsonConstructor]
        public Parametre(string pseudo, string nom, string prenom, string avatar, bool modenuit, string theme)
        {
            Pseudo = pseudo;
            Prenom = prenom;
            Nom = nom;
            ModeNuit = modenuit;
            Theme = theme;
            if (Avatar == null) 
                Avatar = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Avatar.jpg");
            else 
                Avatar = avatar;
        }

        /// <summary>
        /// Convertion JSON vers Parametre
        /// </summary>
        /// <returns>retourne parametre ou s'il n'existe pas null </returns>
        internal static Parametre? FileToSetting()
        {
            try //Explication exactement pareil que Scan
            {
                JsonSerializer serializer = new JsonSerializer();
                StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "settings.json"), true);
                return serializer.Deserialize<Parametre>(new JsonTextReader(sr));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        internal bool SettingsToFile()
        {
            var PathToJSON = Path.Combine(Directory.GetCurrentDirectory(), "settings.json");
            try //Explication exactement pareil que Scan
            {
                if (System.IO.File.Exists(PathToJSON))
                    System.IO.File.Delete(PathToJSON);
                JsonSerializer serializer = new JsonSerializer();
                StreamWriter sw = new StreamWriter(PathToJSON, true, Encoding.ASCII);
                serializer.Serialize(sw, this);
                sw.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Parametre parametre &&
                   Pseudo == parametre.Pseudo &&
                   Prenom == parametre.Prenom &&
                   Nom == parametre.Nom &&
                   Avatar == parametre.Avatar &&
                   ModeNuit == parametre.ModeNuit &&
                   Theme == parametre.Theme;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Pseudo, Prenom, Nom, Avatar, ModeNuit, Theme);
        }
    }
}
