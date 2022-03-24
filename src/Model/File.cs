using System.IO;

namespace Model
{
    public abstract class File
    {
        /// <summary>
        /// Donne un array de string contenant tout les chemin des fichiers du dossier et sous-dossier du dossier donné en paramètre
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Retourne un string[] contenant les chemins, si le dossier n'existe pas renvoie null</returns>
        public static string[] GetFullArborescence(string path)
        {
            if (Directory.Exists(path))
                return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            else
                return null;
        }
        /// <summary>
        /// Donne un array contenant seulement les chemins des fichiers contenu dans le dossier sans les sous dossier 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Retourne un string[] contenant les chemins, si le dossier n'existe pas renvoie null</returns>
        public static string[] GetTopArborescence(string path)
        {
            if (Directory.Exists(path))
                return System.IO.Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
            else
                return null;
        }
        /// <summary>
        /// Donne un array des sous-dossiers du dossier donné en paramètre
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Retourne un string[] contenant les chemins, si le dossier n'existe pas renvoie null</returns>
        public static string[] GetTopDirectory(string path)
        {
            if (Directory.Exists(path))
                return Directory.GetDirectories(path, "*.*", SearchOption.TopDirectoryOnly);
            else
                return null;
        }
    }
}
