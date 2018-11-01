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
        bool isUpdate;
        int _id;
        DataTable dataTable;
        public User_Control_Ajout_Client(int id)
        {
            InitializeComponent();
            try
            {
                dataTable = new DataTable();
                dataTable = Outils.Outils.GetDataSet("SELECT * FROM (" +
                    "(Client INNER JOIN Permis_De_Conduire ON Client.ID = Permis_De_Conduire.Client )" +
                    "INNER JOIN Pieces_ID ON Client.ID = Pieces_ID.Client)" +
                    "WHERE Client.ID = " + id);
                TextBox_Nom.Text = dataTable.Rows[0]["Nom"].ToString();
                TextBox_Prenom.Text = dataTable.Rows[0]["Prenom"].ToString();
                DatePicker_Date_Naissance.Text = dataTable.Rows[0]["Date_Naissance"].ToString();
                TextBox_Adresse.Text = dataTable.Rows[0]["Adresse"].ToString();
                TextBox_Lieu_Naissance.Text = dataTable.Rows[0]["Lieu_Naissance"].ToString();
                TextBox_Num_Mobile.Text = dataTable.Rows[0]["Num_Mobile"].ToString();
                TextBox_Num_Telephone.Text = dataTable.Rows[0]["Num_Telephone"].ToString();
                TextBox_Num_Fax.Text = dataTable.Rows[0]["Num_Fax"].ToString();
                ComboBox_Type_Client.SelectedItem = dataTable.Rows[0]["Type_Client"].ToString();
                TextBox_Numero_Permis_Conduire.Text = dataTable.Rows[0]["Num"].ToString();
                DatePicker_Permis_Conduire_Delivre_Le.Text = dataTable.Rows[0]["Delivre_Le"].ToString();
                TextBox_Permis_Conduire_Delivre_A.Text = dataTable.Rows[0]["Delivre_A"].ToString();
                DatePicker_Permis_Conduire_Valide_Le.Text = dataTable.Rows[0]["Valide_Le"].ToString();
                ComboBox_Type_Piece_Identite.Text = dataTable.Rows[0]["Type"].ToString();
                TextBox_Piece_ID_Numero.Text = dataTable.Rows[0]["Num_Piece_ID"].ToString();
                TextBox_Piece_ID_Nationalite.Text = dataTable.Rows[0]["Nationalite"].ToString();
                DatePicker_Delivre_Le_Piece_ID.Text = dataTable.Rows[0]["Delivre_Le_Piece_ID"].ToString();
                TextBox_Delivre_A_Piece_ID.Text = dataTable.Rows[0]["Delivre_A_Piece_ID"].ToString();
                DatePicker_Valide_Le_Piece_ID.Text = dataTable.Rows[0]["Valide_Le_Piece_ID"].ToString();
                _id = id;
                isUpdate = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                         Outils.Outils._IsDate(DatePicker_Valide_Le_Piece_ID.Text)),
                    _id);
            if (isUpdate)
            {
                client.Update();

                User_Control_Clients user_Control_Clients = new User_Control_Clients();

                ((MainWindow)Application.Current.MainWindow).ContentGrid.Children.Clear();
                ((MainWindow)Application.Current.MainWindow).ContentGrid.Children.Add(user_Control_Clients);
            }
            else
            {
                client.Insert();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_Type_Client.SelectedIndex = 0;
            ComboBox_Type_Piece_Identite.SelectedIndex = 0;

            App.FirstTake = true;
        }
    }
}
