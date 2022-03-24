using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Model
{
    public class Scan
    {
        /// <summary>
        /// Nom du Scan
        /// </summary>
        public string Nom { get; private set; }

        /// <summary>
        /// Description du Scan
        /// </summary>
        public string? Description { get; private set; }

        /// <summary>
        /// Auteur du Scan
        /// </summary>
        public string? Auteur { get; private set; }

        /// <summary>
        /// Genre du Scan
        /// </summary>
        public string? Genre { get; private set; }

        /// <summary>
        /// Genre du Scan
        /// </summary>
        public string? Classification { get; private set; }

        /// <summary>
        /// Status du scan (en cours, fini)
        /// </summary>
        public string? Status { get; private set; }

        /// <summary>
        /// Nombre de Tome
        /// </summary>
        public double NbTome { get; private set; }

        /// <summary>
        /// Note sur 5
        /// </summary>
        public double? Note { get; private set; }

        /// <summary>
        /// Date de parution du premier Tome
        /// </summary>
        public DateTime? DateParution { get; private set; }

        /// <summary>
        /// Chemin menant au dossier du Scan
        /// </summary>
        public string URL { get; internal set; }
        /// <summary>
        /// Chemin menant à la couverture du Scan
        /// </summary>
        public string Cover { get; internal set; }

        /// <summary>
        /// Constructeur d'un Scan ayant des infos partielles
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="nbTome"></param>
        /// <param name="url"></param>
        /// <param name="cover"></param>
        public Scan(string nom, double nbTome, string url, string? cover)
        {
            //Scan avec des informations locales
            Nom = nom;
            NbTome = nbTome;
            URL = url;
            if (cover == null)
                Cover = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "NoCover.png");
            else
                Cover = cover;
        }

        /// <summary>
        /// Constructeur de Scan
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="description"></param>
        /// <param name="auteur"></param>
        /// <param name="genre"></param>
        /// <param name="classification"></param>
        /// <param name="status"></param>
        /// <param name="nbTome"></param>
        /// <param name="note"></param>
        /// <param name="dateParution"></param>
        /// <param name="url"></param>
        /// /// <param name="cover"></param>
        [JsonConstructor]
        public Scan(string nom, string? description, string? auteur, string? genre, string? classification,
            string? status, double nbTome, double? note, DateTime? dateParution, string url, string? cover) : this(nom, nbTome, url, cover)
        {
            //Scan qui possède toute les informations
            Description = description;
            Auteur = auteur;
            Genre = genre;
            Classification = classification;
            Status = status;
            Note = note;
            DateParution = dateParution;
        }
        /// <summary>
        /// Convertion JSON vers Scan
        /// </summary>
        /// <param name="PathToJSON"></param>
        /// <returns>Le Scan ou null en cas d'erreur</returns>
        internal static Scan? FileToScan(string PathToJSON)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer(); //Déclare le serializer
                StreamReader sr = new StreamReader(PathToJSON, true); //Déclare un flux pour lire un fichier
                return serializer.Deserialize<Scan>(new JsonTextReader(sr)); //Le serializer récupére le contenu du JSON et le convertit en Scan à l'aide du constructeur balisé
            }
            catch (Exception e)//En cas d'erreur
            {
                System.Diagnostics.Debug.WriteLine(e); //Affiche l'erreur dans la console en mode debug
                return null; //Retourne un scan null
            }
        }
        /// <summary>
        /// Conversion Scan vers JSON
        /// </summary>
        /// <returns>True si le fichier a été créé sinon false</returns>
        internal bool ScanToFile()
        {
            var PathToJSON =Path.Combine(URL,new DirectoryInfo(URL).Name+".json"); //Créé le chemin du JSON
            try
            {
                if (System.IO.File.Exists(PathToJSON)) //Si le fichier existe déjà
                    System.IO.File.Delete(PathToJSON); //On le supprime
                JsonSerializer serializer = new JsonSerializer(); //Déclare le serializer
                StreamWriter sw = new StreamWriter(PathToJSON, true, Encoding.UTF32); //Déclare le strema pour écrire dans un fichier
                serializer.Serialize(sw, this); //Le serializer le convertit en json et l'inscrit dans le fichier 
                sw.Close();//Ferme le flux
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return Nom;
        }

        public override bool Equals(object obj)
        {
            //Est égale seulement s'il:
            return obj == this ||   //Possède la même adresse mémoire
                   obj is Scan scan &&  //est un scan et...
                   URL == scan.URL;     //Possède la même URL (Une URL étant unique)
        }

        public override int GetHashCode()
        {
            //Le hash code est représenté par le nom, l'url et le nombre de tomes
            HashCode hash = new HashCode();
            hash.Add(Nom);
            hash.Add(NbTome);
            hash.Add(URL);
            return hash.ToHashCode();
        }
    }
}
