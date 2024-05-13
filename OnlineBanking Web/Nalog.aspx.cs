using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking_Web
{
    public partial class Nalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imeNalog.InnerText = Metode.IzvuciPodatak("Ime").ToString();
            prezimeNalog.InnerText = Metode.IzvuciPodatak("Prezime").ToString();
            emailNalog.InnerText = Metode.IzvuciPodatak("Email").ToString();
            lozinkaNalog.Text = Metode.IzvuciPodatak("Sifra").ToString();
        }
    }
}