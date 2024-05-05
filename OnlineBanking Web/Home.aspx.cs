using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking_Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaTransakcije.Items.Clear();
                listaTransakcije.Items.Add(new ListItem("Odaberi racun za depozit", "0"));

                Metode.PrikaziOdabirRacuna(listaTransakcije);

                decimal stanje = Metode.UkupnoStanje();
                stanjeValue.InnerText = stanje.ToString() + " rsd";
            }
        }

        protected void btnDepozit_Click(object sender, EventArgs e)
        {
            Metode.BankomatDepozit(listaTransakcije, txtTransakcijaSuma, this.Page);
            stanjeValue.InnerText = Metode.UkupnoStanje().ToString();
            Metode.KreirajTransakcijuBankomat(listaTransakcije, txtTransakcijaSuma, this.Page);
        }
    }
}