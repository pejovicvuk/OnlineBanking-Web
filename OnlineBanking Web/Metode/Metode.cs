using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineBanking_Web
{
    public class Metode
    {
        public static bool KorisnikPostoji(string email)
        {
            using (SqlConnection conn = Konekcija.Connect())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Korisnik WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
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
                    conn.Close();
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
    }
}