using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineBanking_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string lozinka = txtPassword.Text.Trim();

            if (Metode.KorisnikPostoji(email))
            {
                Session["KorisnikID"] = Metode.KorisnikLogin(email, lozinka);
                Response.Redirect("Home.aspx");
            }
            else
            {
                string script = "NalogNePostoji();";
                ScriptManager.RegisterStartupScript(this, GetType(), "NalogNePostojiScript", script, true);
            }
        }
    }
}