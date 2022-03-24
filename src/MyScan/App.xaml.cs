using Model;
using System.Windows;

namespace MyScan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Déclare le manager pour pouvoir accéder à l'instance depuis les autres classes
        public Manager Manager { get; private set; } 

        public App()
        {
            Manager = new Manager("./Scan");
        }
    }
}
