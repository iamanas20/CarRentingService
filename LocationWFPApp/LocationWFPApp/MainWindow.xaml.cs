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
        bool wantUser = true;
        Hashtable User_Controls_HashSet;
        
        public MainWindow()
        {
            InitializeComponent();
            User_Controls_HashSet = new Hashtable();
            User_Controls_HashSet.Add("Client", new User_Control_Clients());
            User_Controls_HashSet.Add("Client_Ajout", new User_Control_Ajout_Client());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Outils.Outils.Connection(System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"Config\Config.xml");
        }
        
        private void Sous_Menu_Ajout_Client_Selected(object sender, RoutedEventArgs e)
        {
            wantUser = false;
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add((UserControl)User_Controls_HashSet["Client_Ajout"]);
        }

        // bug:  When you select the client TabItem in the TabControl, it goes nominal,
        //       but when we want to select the AjoutClient it thinks that we are selecting
        //       the Client TabItem so when the event above rises, the event below rises as well
        //       so I made a small bool test but now when we are at AjoutClient we can't go back 
        //       to Client, idk why? this is one hell of a bug, I will fix it!

        private void MyTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (User_Controls_HashSet.ContainsKey((MyTabControl.SelectedItem as TabItem).Tag.ToString()) && wantUser && App.FirstTake)
            {
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add((UserControl)User_Controls_HashSet[(MyTabControl.SelectedItem as TabItem).Tag.ToString()]);
                App.FirstTake = false;
            }
            wantUser = true;
        }


        private void MyTabControl_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}