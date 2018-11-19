using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocationWFPApp.User_Control.Voiture
{
    /// <summary>
    /// Interaction logic for User_Control_Voiture.xaml
    /// </summary>
    public partial class User_Control_Voiture : UserControl
    {
        public User_Control_Voiture()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTheDataGrid();
            if (App.History == null)
            {
                App.History = new List<string>();
            }
            App.History.Add("Voitures");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadTheDataGrid();
        }

        private async void LoadTheDataGrid()
        {
            // TODO continue on the voiture shit!
            Data_Grid_Voiture.ItemsSource = (await Outils.Outils.GetDataSet(@"SELECT ID, Disponibilite, Num_Immatriculation, Num_WW, Date_Mise_En_Circulation, Marque, [Type], [Genre], Type_Carburant, Num_Chassis, Couleur, Prix_TTC, Kilometrage FROM Voiture C WHERE [C.Marque] & [C.Type] & [C.Genre] LIKE '%" + Filter1_Txt.Text + "%' AND [C.Marque] & [C.Type] & [C.Genre] LIKE '%" + Filter2_Txt.Text + "%'")).AsDataView();
            Data_Grid_Voiture.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void Data_Grid_Voiture_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
