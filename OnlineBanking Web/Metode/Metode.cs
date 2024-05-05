using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineBanking_Web
{
    public class Metode
    {
        public static bool KorisnikPostoji(string email, string sifra)
        {
            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Korisnik WHERE Email = @Email and Sifra = @Sifra";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Sifra", sifra);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public static void InsertKorisnik(string ime, string prezime, string email, string lozinka)
        {
            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Korisnik_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ime", ime);
                    cmd.Parameters.AddWithValue("@Prezime", prezime);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Sifra", lozinka);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static string KorisnikLogin(string email, string lozinka)
        {
            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();
                string query = "SELECT Id_Korisnik FROM Korisnik WHERE Email = @Email and Sifra = @Lozinka";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Lozinka", lozinka);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return null; 
                    }
                }
            }
        }
        public static decimal UkupnoStanje()
        {
            decimal ukupno = 0;
            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();
                string query = "SELECT SUM(Stanje) FROM Racun WHERE Id_Korisnik = @KorisnikID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@KorisnikID", Convert.ToInt16(HttpContext.Current.Session["KorisnikID"]));
                    object result = cmd.ExecuteScalar();
                    if (result == DBNull.Value)
                        ukupno = 0;
                    else
                        ukupno = Convert.ToDecimal(result);
                }
            }
            return ukupno;
        }
        public static string KorisnikImePrezime()
        {
            string Ime;
            string Prezime;
            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();
                string queryIme = "SELECT Ime FROM Korisnik WHERE Id_Korisnik = @KorisnikID";
                using (SqlCommand cmd = new SqlCommand(queryIme, conn))
                {
                    cmd.Parameters.AddWithValue("@KorisnikID", Convert.ToInt16(HttpContext.Current.Session["KorisnikID"]));
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                        Ime = "Ime";
                    else
                        Ime = result.ToString();
                }
                string queryPrezime = "SELECT Prezime FROM Korisnik WHERE Id_Korisnik = @KorisnikID";
                using (SqlCommand cmd = new SqlCommand(queryPrezime, conn))
                {
                    cmd.Parameters.AddWithValue("@KorisnikID", Convert.ToInt16(HttpContext.Current.Session["KorisnikID"]));
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                        Prezime = "Prezime";
                    else
                        Prezime = result.ToString();
                }
            }
            string ImePrezime = Ime + " " + Prezime;
            return ImePrezime;
        }
        public static void PrikaziOdabirRacuna(HtmlSelect comboBox)
        {
            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();
                string query = $"SELECT Broj_Racuna FROM Racun WHERE Id_Korisnik = @KorisnikID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@KorisnikID", Convert.ToInt16(HttpContext.Current.Session["KorisnikID"]));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox.Items.Add(new ListItem(reader.GetString(reader.GetOrdinal("Broj_Racuna")), reader.GetString(reader.GetOrdinal("Broj_Racuna"))));
                    }
                }
            }
        }
        public static void BankomatDepozit(HtmlSelect listaTransakcije, HtmlInputText transakcijaSuma, Page page)
        {
            string selectedValue = listaTransakcije.Value;
            if (selectedValue == "0")
            {
                string script = "NemasRacun();";
                ScriptManager.RegisterStartupScript(page, page.GetType(), "NemasRacunScript", script, true);
                return;
            }

            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();

                string brojRacuna = selectedValue;
                string updateQuery = $"UPDATE Racun SET Stanje = Stanje + @TransakcijaSuma WHERE Broj_Racuna = @BrojRacuna";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@TransakcijaSuma", Convert.ToDecimal(transakcijaSuma.Value));
                    updateCmd.Parameters.AddWithValue("@BrojRacuna", brojRacuna);
                    updateCmd.ExecuteNonQuery();
                }
            }
        }
        public static void KreirajTransakcijuBankomat(HtmlSelect listaTransakcije, HtmlInputText transakcijaSuma, Page page)
        {
            string brojPrimaoca = listaTransakcije.Value;
            decimal iznos = Convert.ToDecimal(transakcijaSuma.Value);
            if (brojPrimaoca == "0")
            {
                string script = "NemasRacun();";
                ScriptManager.RegisterStartupScript(page, page.GetType(), "NemasRacunScript", script, true);
                return;
            }

            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();
                using (SqlCommand cmdInsert = new SqlCommand("Transakcija_Insert", conn))
                {
                    cmdInsert.CommandType = CommandType.StoredProcedure;

                    cmdInsert.Parameters.AddWithValue("@Iznos", iznos);
                    cmdInsert.Parameters.AddWithValue("@broj_platioca", "0");
                    cmdInsert.Parameters.AddWithValue("@broj_primaoca", brojPrimaoca);
                    cmdInsert.Parameters.AddWithValue("@Id_Tip_Transakcije", 1);
                    cmdInsert.ExecuteNonQuery();
                }
            }
        }
        public static object IzvuciPodatak(string podatak)
        {
            SqlConnection conn = Konekcija.Connect();
            conn.Open();
            string query = $"SELECT {podatak} FROM Korisnik WHERE Id_Korisnik = @KorisnikID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@KorisnikID", Convert.ToInt16(HttpContext.Current.Session["KorisnikID"]));
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        }
        public static DataTable TransakcijeDtbl()
        {
            List<string> userAccounts = new List<string>();

            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();

                string queryRacun = "SELECT Broj_Racuna FROM Racun WHERE ID_Korisnik = @KorisnikID";
                using (SqlCommand cmd = new SqlCommand(queryRacun, conn))
                {
                    cmd.Parameters.AddWithValue("@KorisnikID", Convert.ToInt16(HttpContext.Current.Session["KorisnikID"]));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string brojRacuna = reader.GetString(0);
                            userAccounts.Add(brojRacuna);
                        }
                    }
                }

                DataTable dtbl = new DataTable();
                dtbl.Columns.Add("Iznos");
                dtbl.Columns.Add("Vreme");
                dtbl.Columns.Add("Broj_Racuna_Primaoca");
                dtbl.Columns.Add("Broj_Racuna_Platioca");

                foreach (string brojRacuna in userAccounts)
                {
                    string queryTabela = "SELECT Iznos, Vreme, Broj_Racuna_Primaoca, Broj_Racuna_Platioca FROM Transakcije WHERE Broj_Racuna_Primaoca = @BrojRacuna OR Broj_Racuna_Platioca = @BrojRacuna";
                    using (SqlCommand cmdTabela = new SqlCommand(queryTabela, conn))
                    {
                        cmdTabela.Parameters.AddWithValue("@BrojRacuna", brojRacuna);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdTabela))
                        {
                            DataTable tempTable = new DataTable();
                            adapter.Fill(tempTable);

                            foreach (DataRow row in tempTable.Rows)
                            {
                                dtbl.ImportRow(row);
                            }
                        }
                    }
                }

                return dtbl;
            }
        }
    }
}