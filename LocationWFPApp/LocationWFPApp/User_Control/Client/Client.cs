using LocationWFPApp.User_Control.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LocationWFPApp.Models
{
    class Client
    {
        public Client()
        {
        }

        public Client(string nom,
            string prenom,
            string date_Naissance,
            string lieu_Naissance,
            string adresse,
            string num_Mobile,
            string num_Telephone,
            string num_Fax,
            string type,
            Permis_De_Conduire permis_De_Conduire,
            Pieces_ID pieces_ID)
        {
            try
            {
                Nom = nom;
                Prenom = prenom;
                Date_Naissance = date_Naissance;
                Lieu_Naissance = lieu_Naissance;
                Adresse = adresse;
                Num_Mobile = num_Mobile;
                Num_Telephone = num_Telephone;
                Num_Fax = num_Fax;
                Type = type;
                Permis_De_Conduire = permis_De_Conduire;
                Pieces_ID = pieces_ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Date_Naissance { get; set; }
        public string Lieu_Naissance { get; set; }
        public string Adresse { get; set; }
        public string Num_Mobile { get; set; }
        public string Num_Telephone { get; set; }
        public string Num_Fax { get; set; }
        public string Type { get; set; }
        public Permis_De_Conduire Permis_De_Conduire { get; set; }
        public Pieces_ID Pieces_ID { get; set; }

        public void Insert()
        {
            int id = Get_ID();
            Outils.Outils.Execute_Query("INSERT INTO Client (ID, Type_Client, Nom, Prenom, Date_Naissance, Lieu_Naissance, Adresse, Num_Mobile, Num_Telephone, Num_Fax) " +
                      "VALUES (" + id + "," +
                      "'" + Type + "'," +
                      "'" + Nom + "'," +
                      " '" + Prenom + "'," +
                      Outils.Outils._Date_Print(Date_Naissance) + "," +
                      " '" + Lieu_Naissance + "'," +
                      " '" + Adresse + "'," +
                      " '" + Num_Mobile + "'," +
                      " '" + Num_Telephone + "'," +
                      " '" + Num_Fax + "')");

            // insert the other stuff

            Outils.Outils.Execute_Query("INSERT INTO Pieces_ID (Num_Piece_ID, Type, Nationalite, Delivre_Le_Piece_ID, Delivre_A_Piece_ID, Valide_Le_Piece_ID, Client) " +
                      "VALUES ('" + Pieces_ID.Num + "'," +
                      "'" + Pieces_ID.Type + "'," +
                      "'" + Pieces_ID.Nationalite + "'," +
                      "'" + Outils.Outils._Date_Print(Pieces_ID.Delivre_Le) + "'," +
                      "'" + Pieces_ID.Delivre_A + "'," +
                      "'" + Outils.Outils._Date_Print(Pieces_ID.Valide_Le) + "'," +
                      id + ")");


            Outils.Outils.Execute_Query("INSERT INTO Permis_De_Conduire (Num, Delivre_Le, Delivre_A, Valide_Le, Client) " +
                      "VALUES ('" + Permis_De_Conduire.Num + "'," +
                      "'" + Outils.Outils._Date_Print(Permis_De_Conduire.Delivre_Le) + "'," +
                      " '" + Permis_De_Conduire.Delivre_A + "'," +
                      " '" + Outils.Outils._Date_Print(Permis_De_Conduire.Valide_Le) + "'," +
                      " '" + id + "')");
        }

        // create a function that gets the max of the ID in the clients db and increment it
        // think about when you have a null value of max(ID)

        private int Get_ID() => int.Parse(Outils.Outils.GetDataSet("SELECT IIF(ISNULL(MAX(ID)), 0, MAX(ID)) + 1 AS ID FROM Client").Rows[0]["ID"].ToString());

        public void Update(int id)
        {
            Outils.Outils.Execute_Query("Update Client SET" +
                " Type_Client = '" + Type + "'," +
                " Nom = '" + Nom + "'," +
                " Prenom = '" + Prenom + "'," +
                " Date_Naissance = " + Outils.Outils._Date_Print(Date_Naissance) + "," +
                " Lieu_Naissance = '" + Lieu_Naissance + "'," +
                " Adresse = '" + Adresse + "'," +
                " Num_Mobile = '" + Num_Mobile + "'," +
                " Num_Telephone = '" + Num_Telephone + "'," +
                " Num_Fax = '" + Num_Fax + "'" +
                " WHERE ID = " + id);

            Outils.Outils.Execute_Query("Update Permis_De_Conduire SET" +
                " Num = '" + Permis_De_Conduire.Num + "'," +
                " Delivre_Le = " + Outils.Outils._Date_Print(Permis_De_Conduire.Delivre_Le) + "," +
                " Delivre_A = '" + Permis_De_Conduire.Delivre_A + "'," +
                " Valide_Le = " + Outils.Outils._Date_Print(Permis_De_Conduire.Valide_Le) +
                " WHERE Client = " + id);

            Outils.Outils.Execute_Query("Update Pieces_ID SET" +
                " Num_Piece_ID = '" + Pieces_ID.Num + "'," +
                " Type = '" + Pieces_ID.Type + "'," +
                " Nationalite = '" + Pieces_ID.Nationalite + "'," +
                " Delivre_Le_Piece_ID = " + Outils.Outils._Date_Print(Pieces_ID.Delivre_Le) + "," +
                " Delivre_A_Piece_ID = '" + Pieces_ID.Delivre_A + "'," +
                " Valide_Le_Piece_ID = " + Outils.Outils._Date_Print(Pieces_ID.Valide_Le) +
                " WHERE Client = " + id);
        }
    }
}
