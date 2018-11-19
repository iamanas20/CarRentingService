using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationWFPApp.User_Control.Client
{
    class Permis_De_Conduire
    {
        public Permis_De_Conduire()
        {
        }

        public Permis_De_Conduire(string num, string delivre_Le, string delivre_A, string valide_Le)
        {
            Num = num;
            Delivre_Le = delivre_Le;
            Delivre_A = delivre_A;
            Valide_Le = valide_Le;
        }

        public int ID { get; set; }
        public string Num { get; set; }
        public string Delivre_Le { get; set; }
        public string Delivre_A { get; set; }
        public string Valide_Le { get; set; }
        public int Client { get; set; }
    }

}
