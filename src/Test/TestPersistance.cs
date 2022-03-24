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
    public class TestPersistance
    {
        [Fact]
        public void PersistanceFile()
        {
            try
            {
                Manager manager = new Manager("./Scan");
                string[] keys = null;
                manager.ScanDictionnary.Keys.CopyTo(keys, 0);
                manager.Sauvegarder();
                int i = 0;
                foreach (string file in Model.File.GetFullArborescence("./Scan"))
                {
                    foreach (string key in keys)
                    {
                        if (file.Contains(key))
                            i++;
                    }
                }
                Assert.IsTrue(i == manager.ScanDictionnary.Count, "Il manque des JSONs ou il ne porte pas le bon nom");
                Assert.IsTrue(System.IO.File.Exists("./settings.json"), "Les settings n'ont pas été enregistré");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        [Fact]
        public void PersistanceData()
        {
            Manager Manager1 = new Manager("./Scan");
            Manager1.Sauvegarder();
            Manager Manager2 = new Manager("./Scan");
            Assert.IsTrue(Enumerable.SequenceEqual(Manager1.ScanDictionnary, Manager2.ScanDictionnary), "Il y a une différence de contenu dans les scans après Serialization");
            Assert.AreEqual(Manager1.CurrentSetting, Manager2.CurrentSetting);
        }
    }
}