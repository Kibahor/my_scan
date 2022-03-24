using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ModelTest
{
    [TestClass]
    public class TestManager
    {
        [Fact]
        public void ModifierScan()
        {
            Manager manager = new Manager("./Scan");

            string Nom = "nom";
            string Description = "Une Description";
            string Auteur = "Un Auteur";
            string Genre = "un Genre";
            string Classification = "Une classification";
            string Status = "Un status";
            double NbTome = 10;
            double Note = 5;
            DateTime DateParution = new DateTime();
            string URL = "";

            Scan PartialScan = new Scan(Nom, NbTome, URL, null);
            Scan CompletScan = new Scan(Nom, Description, Auteur, Genre, Classification, Status, NbTome, Note, DateParution, URL, null);
            manager.CurrentScan = PartialScan;

            manager.ScanDictionnary.Add(PartialScan.Nom, PartialScan);
            Assert.IsTrue(manager.Modifier(CompletScan));

            Assert.IsNotNull(manager.CurrentScan);
            Assert.AreEqual(manager.CurrentScan, CompletScan);
            manager.ScanDictionnary.TryGetValue(CompletScan.Nom, out Scan ScanFromDictionary);
            Assert.AreEqual(ScanFromDictionary, CompletScan);
        }

        [Fact]
        public void SupprimerScan()
        {
            Manager manager = new Manager("./Scan");

            manager.ScanDictionnary.TryGetValue("Assassination Classroom",out Scan scan);
            manager.CurrentScan = scan;
            Assert.IsTrue(manager.Supprimer());
        }
    }
}