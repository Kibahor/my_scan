using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class Manager
    {
        /// <summary>
        /// Dictionnaire associant un Nom et un Scan
        /// </summary>
        public Dictionary<string, Scan> ScanDictionnary { get; private set; }

        /// <summary>
        /// Propriété qui enregistre le scan selectionné
        /// </summary>
        public Scan CurrentScan { get; set; }
        /// <summary>
        /// Propriété qui correspond au parametre actuel de l'application
        /// </summary>
        public Parametre CurrentSetting { get; set; }

        /// <summary>
        /// Constructeur de ManagerScan
        /// </summary>
        public Manager(string PathToScans)
        {
            CurrentSetting = Parametre.FileToSetting(); //Récupère les parametre enregistré
            if (CurrentSetting == null) //si il n'y en as pas
                CurrentSetting = new Parametre(); //On déclare un parametre avec les parametres par défaut
            ScanDictionnary = new Dictionary<string, Scan>(); //On instancie le dicionnaire
            if (!Charger(PathToScans)) //On charge les scans
                throw new ArgumentException("Le chemin n'est pas valide");
            
        }

        /// <summary>
        /// Charge tout les scans
        /// </summary>
        /// <param name="PathToScans"></param>
        /// <returns>
        /// Si le dossier existe renvoie true dans le cas contraire false
        /// </returns>
        private bool Charger(string PathToScans)
        {
            //Créé le dossier MyScan/Cover s'il n'existe pas
            if (!System.IO.Directory.Exists("./Cover"))
                Directory.CreateDirectory("./Cover");

            //Vérifie que le dossier donner existe
            if (!Directory.Exists(PathToScans)) return false;

            Scan TempScan = null;

            //Pour chaque Dossier de Scan
            foreach (string ScanFolder in File.GetTopDirectory(PathToScans)) 
            {
                //Le nom a partir du chemin
                string ScanFolderName = new DirectoryInfo(ScanFolder).Name;
                //Le nom du json
                string JsonName = ScanFolderName + ".json";

                //On regarde si le Dossier du Scan possède un JSON 
                foreach (string file in File.GetTopArborescence(ScanFolder))
                {
                    if (file.Contains(JsonName))
                    {
                        TempScan = Scan.FileToScan(file); //Convertit le json en San
                        break;
                    }
                }

                //Si le Scan n'est plus a null, cela veut dire qu'un JSON a été trouver
                if (TempScan != null)
                {
                    //Corrige les chemins au cas où ils seraient erroné dans le json
                    if (TempScan.URL != ScanFolder || !System.IO.File.Exists(TempScan.Cover))
                    {
                        TempScan.URL = Path.GetFullPath(ScanFolder);
                        TempScan.Cover = CoverToTempFolder(ScanFolder);
                    }
                    //Ajoute au dictionnaire
                    ScanDictionnary.Add(ScanFolderName, TempScan);
                    //On reinitialise pou rle prochain Scan
                    TempScan = null;
                }
                else
                {
                    //Le nombre de tomes est égale au nombre de dossier
                    int NbTome = File.GetTopDirectory(ScanFolder).Length;
                    //Ajoute le scan 
                    ScanDictionnary.Add(ScanFolderName, new Scan(ScanFolderName, NbTome, ScanFolder, CoverToTempFolder(ScanFolder))); 
                }
            }
            return true;
        }

        /// <summary>
        /// Copie la Cover (image) dans le dossier de l'application
        /// La fonction est là pour permettre la suppression de Scan sans exception de ressource utilisé lors de lasuppresion depuis l'application
        /// </summary>
        /// <param name="ScanFolder"></param>
        /// <returns>Retourne le chemin de la Cover (null si elle n'existe pas)</returns>
        private string? CoverToTempFolder(string ScanFolder)
        {
            string CoverPath = null;
            //Pour chaque fichier du dossier du Scan
            foreach (string file in File.GetTopArborescence(ScanFolder))
                //Si un fichier contient le mot "Cover" ou "cover"
                if (file.Contains("cover", StringComparison.OrdinalIgnoreCase))
                {
                    CoverPath = file;//On le met dans le variable
                    break;  //On casse la boucle
                }
            //Si il n'y a pas de cover
            if (CoverPath == null)
                return null;

            //Créé le nouveau chemin de l'image
            string NewCoverPath = Path.Combine("./Cover", Path.GetFileName(CoverPath).ToLower().Replace("cover", new DirectoryInfo(ScanFolder).Name));
            if (!System.IO.File.Exists(NewCoverPath)) //Vérifie que le fichier n'existe pas déjà
                System.IO.File.Copy(CoverPath, NewCoverPath); //On copies
            return Path.GetFullPath(NewCoverPath); //Retourne le nouveau chemin
        }

        /// <summary>
        /// Modifie le Scan actuel dans le Dictionnaire de Scan
        /// </summary>
        /// <param name="scan"></param>
        public bool Modifier(Scan scan)
        {
            bool Remove = ScanDictionnary.Remove(CurrentScan.Nom); //Supprime le scan
            ScanDictionnary.Add(scan.Nom, scan); //Ajoute le scan modifié
            CurrentScan = scan; //Met à jour le current scan
            return Remove; //Renvoie si le scan a été supprimé correctement du dictionnaires
        }

        /// <summary>
        /// Supprime le scan actuel et son dossier
        /// </summary>
        /// <param name="Titre"></param>
        /// <returns>
        /// Return false si le scan n'est pas trouvé ou si le dossier n'a pas pu être supprimer
        /// </returns>
        public bool Supprimer()
        {
            if (Directory.Exists(CurrentScan.URL))
            {
                Directory.Delete(CurrentScan.URL, true);
                //Supprime le Scan du dictionnaire et vérifie que le dossier a bien été supprimer correctement puis retourne le résulatat 
                return ScanDictionnary.Remove(CurrentScan.Nom) && !Directory.Exists(CurrentScan.URL);
            }
            return false;
        }

        /// <summary>
        /// Enregistre les Scan et les paramètre en JSON
        /// </summary>
        /// <returns>Retourne false si quelque chose c'est mal passé sinon true</returns>
        public bool Sauvegarder()
        {
            bool success = CurrentSetting.SettingsToFile(); //Parametre en JSON
            foreach (Scan scan in ScanDictionnary.Values) //Pour chaque Scan
            {
                if (!scan.ScanToFile()) //Si l'enregistrement échoue
                    success = false;
            }
            return success;
        }
    }
}
