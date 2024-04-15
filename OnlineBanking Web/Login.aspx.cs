using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Konekcija.Connect();
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT Id_Korisnik FROM Korisnik WHERE Email = @Email and Sifra = @Password", conn))
            {
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Session["KorisnikID"] = result.ToString();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    string script = "NoAccount();";
                    ScriptManager.RegisterStartupScript(this, GetType(), "NoAccScript", script, true);
                }
            }
        }
    }
}