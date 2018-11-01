using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LocationWFPApp.Client;
using LocationWFPApp.User_Control_Client;

namespace LocationWFPApp
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class User_Control_Clients : UserControl
    {
        public User_Control_Clients()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTheDataGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadTheDataGrid();
        }

        private void LoadTheDataGrid()
        {
            Data_Grid_Client.ItemsSource = Outils.Outils.GetDataSet(@"SELECT * FROM Client C WHERE C.Nom & C.Prenom & C.Adresse LIKE '%" + Filter1_Txt.Text + "%' AND C.Nom & C.Prenom & C.Adresse LIKE '%" + Filter2_Txt.Text + "%'").AsDataView();
        }

        private void Data_Grid_Client_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Data_Grid_Client.CurrentItem != null)
            {
                User_Control_Ajout_Client user_Control_Clients = new User_Control_Ajout_Client(Convert.ToInt16((Data_Grid_Client.CurrentItem as DataRowView)["id"].ToString()));

                ((MainWindow)Application.Current.MainWindow).ContentGrid.Children.Clear();
                ((MainWindow)Application.Current.MainWindow).ContentGrid.Children.Add(user_Control_Clients);
            }
        }
    }
}
