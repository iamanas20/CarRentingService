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
        DataTable dataTableClient;
        DataTable dataTablePermis;
        DataTable dataTablePiece;

        public User_Control_Ajout_Client()
        {
            InitializeComponent();
            if (App.History == null)
            {
                App.History = new List<string>();
            }
            App.History.Add("AjoutClient");
        }

        public async void Fill_For_Update(int id)
        {
            try
            {
                dataTableClient = new DataTable();
                dataTableClient = await Outils.Outils.GetDataSet("SELECT * FROM Client WHERE ID = " + id);
                dataTablePermis = await Outils.Outils.GetDataSet("SELECT * FROM Permis_De_Conduire WHERE Client = " + id);
                dataTablePiece = await Outils.Outils.GetDataSet("SELECT * FROM Pieces_ID WHERE Client = " + id);

                if (dataTableClient.Rows.Count != 0)
                {
                    TextBox_Nom.Text = dataTableClient.Rows[0]["Nom"].ToString();
                    TextBox_Prenom.Text = dataTableClient.Rows[0]["Prenom"].ToString();
                    DatePicker_Date_Naissance.Text = dataTableClient.Rows[0]["Date_Naissance"].ToString();
                    TextBox_Adresse.Text = dataTableClient.Rows[0]["Adresse"].ToString();
                    TextBox_Lieu_Naissance.Text = dataTableClient.Rows[0]["Lieu_Naissance"].ToString();
                    TextBox_Num_Mobile.Text = dataTableClient.Rows[0]["Num_Mobile"].ToString();
                    TextBox_Num_Telephone.Text = dataTableClient.Rows[0]["Num_Telephone"].ToString();
                    TextBox_Num_Fax.Text = dataTableClient.Rows[0]["Num_Fax"].ToString();
                    ComboBox_Type_Client.SelectedItem = dataTableClient.Rows[0]["Type_Client"].ToString();
                }

                if (dataTablePermis.Rows.Count != 0)
                {
                    TextBox_Numero_Permis_Conduire.Text = dataTablePermis.Rows[0]["Num"].ToString();
                    DatePicker_Permis_Conduire_Delivre_Le.Text = dataTablePermis.Rows[0]["Delivre_Le"].ToString();
                    TextBox_Permis_Conduire_Delivre_A.Text = dataTablePermis.Rows[0]["Delivre_A"].ToString();
                    DatePicker_Permis_Conduire_Valide_Le.Text = dataTablePermis.Rows[0]["Valide_Le"].ToString();
                }

                if (dataTablePiece.Rows.Count != 0)
                {
                    ComboBox_Type_Piece_Identite.Text = dataTablePiece.Rows[0]["Type"].ToString();
                    TextBox_Piece_ID_Numero.Text = dataTablePiece.Rows[0]["Num_Piece_ID"].ToString();
                    TextBox_Piece_ID_Nationalite.Text = dataTablePiece.Rows[0]["Nationalite"].ToString();
                    DatePicker_Delivre_Le_Piece_ID.Text = dataTablePiece.Rows[0]["Delivre_Le_Piece_ID"].ToString();
                    TextBox_Delivre_A_Piece_ID.Text = dataTablePiece.Rows[0]["Delivre_A_Piece_ID"].ToString();
                    DatePicker_Valide_Le_Piece_ID.Text = dataTablePiece.Rows[0]["Valide_Le_Piece_ID"].ToString();
                }
                _id = id;
                isUpdate = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

                MessageBox.Show("Successfully updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

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
        }
    }
}
