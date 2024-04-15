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
            SqlConnection conn = Konekcija.Connect();
            string query = "select count(*) from Korisnik where email = @email";
            SqlCommand cmdProvera = new SqlCommand(query, conn);
            cmdProvera.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

            conn.Open();
            int count = Convert.ToInt32(cmdProvera.ExecuteScalar());
            if (count > 0)
            {
                string script = "ShowPopup();";
                ScriptManager.RegisterStartupScript(this, GetType(), "PopupScript", script, true);
            }
            else
            {
                SqlCommand cmdInsert = new SqlCommand("Korisnik_Insert", conn);
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.Parameters.Add("@Ime", SqlDbType.VarChar).Value = txtName.Text;
                cmdInsert.Parameters.Add("@Prezime", SqlDbType.VarChar).Value = txtSurname.Text;
                cmdInsert.Parameters.Add("@EMail", SqlDbType.VarChar).Value = txtEmail.Text;
                cmdInsert.Parameters.Add("@Sifra", SqlDbType.VarChar).Value = txtPassword.Text;
                cmdInsert.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}