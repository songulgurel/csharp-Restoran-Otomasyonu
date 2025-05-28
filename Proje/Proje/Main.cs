using System;
using System.Data;
using System.Data.SqlClient;

namespace Proje
{
    class Main
    {
        public static readonly string baglanti = "Data Source=DESKTOP-ETH28ML;Initial Catalog=proje;Integrated Security=True;";
        public static SqlConnection con = new SqlConnection(baglanti);

        public static bool KullaniciVarMi(string kullanici, string sifre)
        {
            string qry = "SELECT COUNT(*) FROM kullanicilar WHERE kAdi = @kullanici AND ksifre = @sifre";

            try
            {
                using (SqlConnection con = new SqlConnection(baglanti)) // bağlantıyı buraya al
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    cmd.Parameters.AddWithValue("@kullanici", kullanici);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Veritabanı hatası: " + ex.Message);
                return false;
            }
        }

    }
}
