using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ModelTest
{
    [TestClass]
    public class TrieTest
    {
        [Fact]
        public void RechercheParNom()
        {
            Manager manager = new Manager("./Scan");
            ObservableCollection<Scan> CollectionScan = new ObservableCollection<Scan>(manager.ScanDictionnary.Values);
            Assert.IsTrue(Enumerable.SequenceEqual(
                Trier.RechercheParNom(CollectionScan, "Hunter"),
                CollectionScan.Where(n => n.Nom.Contains("Hunter", StringComparison.OrdinalIgnoreCase))
            ));
        }

        [Fact]
        public void TrieParNom()
        {
            Manager manager = new Manager("./Scan");
            ObservableCollection<Scan> CollectionScan = new ObservableCollection<Scan>(manager.ScanDictionnary.Values);
            Assert.IsTrue(Enumerable.SequenceEqual(
                Trier.TriParNom(CollectionScan, false),
                CollectionScan.OrderBy(n => n.Nom)
            ));
        }

        [Fact]
        public void TrieParAuteur()
        {
            Manager manager = new Manager("./Scan");
            ObservableCollection<Scan> CollectionScan = new ObservableCollection<Scan>(manager.ScanDictionnary.Values);
            Assert.IsTrue(Enumerable.SequenceEqual(
                Trier.TriParAuteur(CollectionScan, false),
                CollectionScan.OrderBy(n => n.Auteur)
            ));
        }
        [Fact]
        public void TrieParGenre()
        {
            Manager manager = new Manager("./Scan");
            ObservableCollection<Scan> CollectionScan = new ObservableCollection<Scan>(manager.ScanDictionnary.Values);
            Assert.IsTrue(Enumerable.SequenceEqual(
                Trier.TriParGenre(CollectionScan, false),
                CollectionScan.OrderBy(n => n.Genre)
            ));
        }
        [Fact]
        public void TrieParClassification()
        {
            Manager manager = new Manager("./Scan");
            ObservableCollection<Scan> CollectionScan = new ObservableCollection<Scan>(manager.ScanDictionnary.Values);
            Assert.IsTrue(Enumerable.SequenceEqual(
                Trier.TriParClassification(CollectionScan, false),
                CollectionScan.OrderBy(n => n.Classification)
            ));
        }
        [Fact]
        public void TrieParNote()
        {
            Manager manager = new Manager("./Scan");
            ObservableCollection<Scan> CollectionScan = new ObservableCollection<Scan>(manager.ScanDictionnary.Values);
            Assert.IsTrue(Enumerable.SequenceEqual(
                Trier.TriParNote(CollectionScan, false),
                CollectionScan.OrderBy(n => n.Note)
            ));
        }
    }
}