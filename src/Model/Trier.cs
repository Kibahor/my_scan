using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Méthode de tri pour Dictionary<string, Scan>
    /// </summary>
    public abstract class Trier
    {
        /// <summary>
        /// Filtre la collection à partir d'un mot-clé
        /// </summary>
        /// <param name="CollectionScan"></param>
        /// <param name="Mot"></param>
        /// <returns></returns>
        public static IEnumerable<Scan> RechercheParNom(ObservableCollection<Scan> CollectionScan, string Mot)
        {
            return CollectionScan.Where(n => n.Nom.Contains(Mot, StringComparison.OrdinalIgnoreCase));
        }
        /// <summary>
        /// Trie la collection par Nom
        /// </summary>
        /// <param name="CollectionScan"></param>
        /// <param name="IsDesc"></param>
        /// <returns></returns>
        public static IEnumerable<Scan> TriParNom(ObservableCollection<Scan> CollectionScan, bool IsDesc)
        {
            if (IsDesc)
                return CollectionScan.OrderBy(n => n.Nom)
                                     .Reverse();
            else
                return CollectionScan.OrderBy(n => n.Nom);
        }
        /// <summary>
        /// Trie la collection par Auteur
        /// </summary>
        /// <param name="CollectionScan"></param>
        /// <param name="IsDesc"></param>
        /// <returns></returns>
        public static IEnumerable<Scan> TriParAuteur(ObservableCollection<Scan> CollectionScan, bool IsDesc)
        {
            if (IsDesc)
                return CollectionScan.OrderBy(n => n.Auteur)
                                     .Reverse();
            else
                return CollectionScan.OrderBy(n => n.Auteur);
        }
        /// <summary>
        /// Trie la collection par Genre
        /// </summary>
        /// <param name="CollectionScan"></param>
        /// <param name="IsDesc"></param>
        /// <returns></returns>
        public static IEnumerable<Scan> TriParGenre(ObservableCollection<Scan> CollectionScan, bool IsDesc)
        {
            if (IsDesc)
                return CollectionScan.OrderBy(n => n.Genre)
                                     .Reverse();
            else
                return CollectionScan.OrderBy(n => n.Genre);
        }
        /// <summary>
        /// Trie la collection par Classification
        /// </summary>
        /// <param name="CollectionScan"></param>
        /// <param name="IsDesc"></param>
        /// <returns></returns>
        public static IEnumerable<Scan> TriParClassification(ObservableCollection<Scan> CollectionScan, bool IsDesc)
        {
            if (IsDesc)
                return CollectionScan.OrderBy(n => n.Classification)
                                     .Reverse();
            else
                return CollectionScan.OrderBy(n => n.Classification);
        }
        /// <summary>
        /// Trie la collection par Note
        /// </summary>
        /// <param name="CollectionScan"></param>
        /// <param name="IsDesc"></param>
        /// <returns></returns>
        public static IEnumerable<Scan> TriParNote(ObservableCollection<Scan> CollectionScan, bool IsDesc)
        {
            if (IsDesc)
                return CollectionScan.OrderBy(n => n.Note)
                                     .Reverse();
            else
                return CollectionScan.OrderBy(n => n.Note);
        }
    }
}
