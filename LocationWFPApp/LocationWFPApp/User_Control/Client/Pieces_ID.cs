using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationWFPApp.User_Control.Client
{
    class Pieces_ID
    {
        public Pieces_ID()
        {
        }

        public Pieces_ID(string num, string type, string nationalite, string delivre_Le, string delivre_A, string valide_Le)
        {
            Num = num;
            Type = type;
            Nationalite = nationalite;
            Delivre_Le = delivre_Le;
            Delivre_A = delivre_A;
            Valide_Le = valide_Le;
        }

        public int ID { get; set; }
        public string Num { get; set; }
        public string Type { get; set; }
        public string Nationalite { get; set; }
        public string Delivre_Le { get; set; }
        public string Delivre_A { get; set; }
        public string Valide_Le { get; set; }
        public int Client { get; set; }

        public void Insert()
        {
            Outils.Outils.Execute_Query("INSERT INTO Client (Num, Type, Nationalite, Delivre_Le, Delivre_A, Valide_Le, Client) " +
                      "VALUES ('" + Num + "'," +
                      "VALUES ('" + Type + "'," +
                      "VALUES ('" + Nationalite + "'," +
                      "'" + Delivre_Le + "'," +
                      " '" + Delivre_A + "'," +
                      " '" + Valide_Le + "'," +
                      " '" + Client + "')");
        }

        public void Update()
        {
            Outils.Outils.Execute_Query("Update Client SET" +
                " Num = '" + Num + "'," +
                " Type = '" + Type + "'," +
                " Nationalite = '" + Nationalite + "'," +
                " Delivre_Le = '" + Delivre_Le + "'," +
                " Delivre_A = '" + Delivre_A + "'," +
                " Valide_Le = '" + Valide_Le + "'," +
                " Client = '" + Client + "'," +
                " WHERE ID = " + ID);
        }
    }
}
