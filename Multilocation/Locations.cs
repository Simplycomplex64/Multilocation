using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilocation
{
    class Locations
    {
        public int Location_id { get; set; }
        public DateTime Debut_location { get; set; }
        public DateTime Premier_paiement { get; set; }
        public string Montant_1er_Paiement { get; set; }
        public int Nbr_Paiement { get; set; }
        public string Vehicule_vise { get; set; }
        public int Client_vise { get; set; }
        public int Termes_Location { get; set; }
    }
}
