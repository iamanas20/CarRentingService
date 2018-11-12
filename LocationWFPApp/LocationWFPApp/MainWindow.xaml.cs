using LocationWFPApp.User_Control_Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocationWFPApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hashtable User_Controls_HashSet;

        public MainWindow()
        {
            InitializeComponent();
            User_Controls_HashSet = new Hashtable();
            User_Controls_HashSet.Add("Client", new User_Control_Clients());
            User_Controls_HashSet.Add("Client_Ajout", new User_Control_Ajout_Client());

            App.History = new List<string>();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Outils.Outils.Connection(System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"Config\Config.xml");
        }

        private void Sous_Menu_Ajout_Client_Selected(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add((UserControl)User_Controls_HashSet["Client_Ajout"]);
            //Sous_Menu_Ajout_Client.IsSelected = false;
        }

        private void Sous_Menu_Clients_Selected(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add((UserControl)User_Controls_HashSet["Client"]);
            //Sous_Menu_Clients.IsSelected = false;
        }

        private void MyTabControl_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}