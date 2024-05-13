using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking_Web
{
    public partial class Placanje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaPlacanje.Items.Clear();
                listaPlacanje.Items.Add(new ListItem("Odaberi racun za depozit", "0"));

                Metode.PrikaziOdabirRacuna(listaPlacanje);
            }
        }

        protected void btnPlati_ServerClick(object sender, EventArgs e)
        {
            // provera jel ima dovoljno para na racunu
            Metode.TransferNovca(listaPlacanje, primaocRacun, placanjeSuma, Page);
            Metode.KreirajTransakcijuRacun(listaPlacanje, primaocRacun, placanjeSuma, Page);
        }
    }
}