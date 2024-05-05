using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking_Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string ime = txtName.Text.Trim();
            string prezime = txtSurname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string lozinka = txtPassword.Text.Trim();

            if (Metode.KorisnikPostoji(email, lozinka))
            {
                string script = "NalogPostoji();";
                ScriptManager.RegisterStartupScript(this, GetType(), "NalogPostojiScript", script, true);
            }
            else
            {
                Metode.InsertKorisnik(ime, prezime, email, lozinka);
                string script = "UspesnaRegistracija();";
                ScriptManager.RegisterStartupScript(this, GetType(), "UspesnaRegistracijaScript", script, true);
            }
        }
    }
}