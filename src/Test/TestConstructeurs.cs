using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ModelTest
{
    [TestClass]
    public class TestConstructeurs
    {
        [Fact]
        public void ConstructeurManager()
        {
            Manager manager = new Manager("./Scan");
            Assert.IsNotNull(manager);
            Assert.IsNotNull(manager.CurrentSetting);
            Assert.IsNotNull(manager.ScanDictionnary);
            Assert.IsNull(manager.CurrentScan);
        }
        [Fact]
        public void ConstructeurPartialScan()
        {
            string Nom = "nom";
            double NbTome = 10;
            string URL = "./Scan/Assassination Classroom/";

            Scan scan = new Scan(Nom, NbTome, URL, null);

            Assert.AreEqual(scan.Nom, Nom);
            Assert.AreEqual(scan.NbTome, NbTome);
            Assert.AreEqual(scan.URL, URL);

            Assert.IsTrue(scan.Cover.Contains("NoCover.png"));

            Assert.IsNull(scan.Description);
            Assert.IsNull(scan.Auteur);
            Assert.IsNull(scan.Genre);
            Assert.IsNull(scan.Classification);
            Assert.IsNull(scan.Status);
            Assert.IsNull(scan.Note);
            Assert.IsNull(scan.DateParution);

        }

        [Fact]
        public void ConstructeurCompleteScan()
        {
            string Nom = "nom";
            string Description = "Une Description";
            string Auteur = "Un Auteur";
            string Genre = "un Genre";
            string Classification = "Une classification";
            string Status = "Un status";
            double NbTome = 10;
            double Note = 5;
            DateTime DateParution = new DateTime();
            string URL = "./Scan/Assassination Classroom/";


            Scan scan = new Scan(Nom, Description, Auteur, Genre, Classification,
            Status, NbTome, Note, DateParution, URL, null);

            Assert.AreEqual(scan.Nom, Nom);
            Assert.AreEqual(scan.NbTome, NbTome);
            Assert.AreEqual(scan.URL, URL);
            Assert.IsTrue(scan.Cover.Contains("NoCover"));
            Assert.AreEqual(scan.Description, Description);
            Assert.AreEqual(scan.Auteur, Auteur);
            Assert.AreEqual(scan.Genre, Genre);
            Assert.AreEqual(scan.Classification, Classification);
            Assert.AreEqual(scan.Status, Status);
            Assert.AreEqual(scan.Note, Note);
            Assert.AreEqual(scan.DateParution, DateParution);

        }
        [Fact]
        public void ConstructeurPartialParametre()
        {
            Parametre param = new Parametre();

            Assert.AreEqual(param.Pseudo, "Pseudo");
            Assert.AreEqual(param.Nom, "Nom");
            Assert.AreEqual(param.Prenom, "Prenom");
            Assert.IsTrue(param.Avatar.Contains("Avatar.jpg"));
            Assert.AreEqual(param.ModeNuit, false);
            Assert.AreEqual(param.Theme, "Blue");

        }

        [Fact]
        public void ConstructeurCompleteParametre()
        {
            string Pseudo = "Kibahor";
            string Nom = "Blouin";
            string Prenom = "Lukas";
            string Avatar = null;
            bool Modenuit = true;
            string Theme = "blue";


            Parametre param = new Parametre(Pseudo, Nom, Prenom, Avatar, Modenuit, Theme);

            Assert.AreEqual(param.Pseudo, Pseudo);
            Assert.AreEqual(param.Nom, Nom);
            Assert.AreEqual(param.Prenom, Prenom);
            Assert.IsTrue(param.Avatar.Contains("Avatar.jpg"));
            Assert.AreEqual(param.ModeNuit, Modenuit);
            Assert.AreEqual(param.Theme, Theme);
        }
    }
}