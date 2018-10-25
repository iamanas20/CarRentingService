using LocationWFPApp.Models;
using System;
using System.Collections.Generic;
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
using LocationWFPApp.Models;
using LocationWFPApp.User_Control.Client;
using System.Data;

namespace LocationWFPApp.User_Control_Client
{
    /// <summary>
    /// Interaction logic for User_Control_Ajout_Client.xaml
    /// </summary>.
    /// 
    public partial class User_Control_Ajout_Client : UserControl
    {
        DataTable dataTable;
        public User_Control_Ajout_Client(int id)
        {
            dataTable = new DataTable();
            dataTable = Outils.Outils.GetDataSet("SELECT * FROM Client INNER JOIN Permis_De_Conduire ON ");
        }

        public User_Control_Ajout_Client()
        {
            InitializeComponent();
        }

        private void Button_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            Models.Client client = new Models.Client(TextBox_Nom.Text,
                TextBox_Prenom.Text,
                Outils.Outils._IsDate(DatePicker_Date_Naissance.Text),
                TextBox_Lieu_Naissance.Text,
                TextBox_Adresse.Text,
                TextBox_Num_Mobile.Text,
                TextBox_Num_Telephone.Text,
                TextBox_Num_Fax.Text,
                ComboBox_Type_Client.SelectedValue.ToString(),
                new Permis_De_Conduire(TextBox_Numero_Permis_Conduire.Text,
                     Outils.Outils._IsDate(DatePicker_Permis_Conduire_Delivre_Le.Text), 
                    TextBox_Permis_Conduire_Delivre_A.Text,
                     Outils.Outils._IsDate(DatePicker_Permis_Conduire_Valide_Le.Text)),
                new Pieces_ID(TextBox_Piece_ID_Numero.Text, 
                    ComboBox_Type_Piece_Identite.SelectedValue.ToString(), 
                    TextBox_Piece_ID_Nationalite.Text,
                     Outils.Outils._IsDate(DatePicker_Permis_Conduire_Valide_Le.Text), 
                    TextBox_Delivre_A_Piece_ID.Text,
                     Outils.Outils._IsDate(DatePicker_Valide_Le_Piece_ID.Text)));

            client.Insert();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_Type_Client.SelectedIndex = 0;
            ComboBox_Type_Piece_Identite.SelectedIndex = 0;
        }
    }
}
