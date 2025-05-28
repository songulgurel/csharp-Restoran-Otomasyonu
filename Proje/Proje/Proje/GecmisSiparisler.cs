using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proje
{
    public partial class GecmisSiparisler : Form
    {
        private string kAdi;
    

        private string baglantiString = "Server=DESKTOP-ETH28ML;Database=proje;Integrated Security=True;";

        public GecmisSiparisler(string kullaniciAdi)

        {
            InitializeComponent();
            kAdi = kullaniciAdi;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1200, 740); // 👈 Form boyutunu sabitle


        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu frmmenu = new menu(kAdi);
            frmmenu.Show();
        }
        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain(kAdi);
            frm.Show();
        }

        private void btn_sepet_Click(object sender, EventArgs e)
        {
            this.Hide();
            sepet frmsepet = new sepet(kAdi);
            frmsepet.Show();
        }

        private void btn_hakkimizda_Click(object sender, EventArgs e)
        {
            this.Hide();
            hakkimizda frm = new hakkimizda(kAdi);
            frm.Show();
        }

        private void GecmisSiparisler_Load(object sender, EventArgs e)
        {
                          // Sabit boyut

            // Liste görünümü ayarları
            listViewGecmis.View = View.Details;
            listViewGecmis.FullRowSelect = true;
            listViewGecmis.Columns.Clear();
            listViewGecmis.Columns.Add("Ürün Adı", 150);
            listViewGecmis.Columns.Add("Adet", 60);
            listViewGecmis.Columns.Add("Toplam Fiyat", 100);
            listViewGecmis.Columns.Add("Tarih", 120);

            dtpBitis.Value = DateTime.Now;
            dtpBaslangic.Value = DateTime.Now.AddMonths(-1);

            SiparisleriListele();
        }


        private void SiparisleriListele()
        {
            listViewGecmis.Items.Clear();

            string sorgu = @"
                SELECT urunAdi, Adet, ToplamFiyat, SiparisTarihi
                FROM GecmisSiparisler
                WHERE kullaniciAdi = @kAdi
                  AND SiparisTarihi BETWEEN @baslangic AND @bitis
                ORDER BY SiparisTarihi DESC";

            using (SqlConnection con = new SqlConnection(baglantiString))
            using (SqlCommand cmd = new SqlCommand(sorgu, con))
            {
                cmd.Parameters.AddWithValue("@kAdi", kAdi);
                cmd.Parameters.AddWithValue("@baslangic", dtpBaslangic.Value.Date);
                cmd.Parameters.AddWithValue("@bitis", dtpBitis.Value.Date.AddDays(1).AddSeconds(-1));

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["urunAdi"].ToString());
                        item.SubItems.Add(reader["Adet"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["ToplamFiyat"]).ToString("C2"));
                        item.SubItems.Add(Convert.ToDateTime(reader["SiparisTarihi"]).ToString("g"));

                        listViewGecmis.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

    

        private void btnListele_Click(object sender, EventArgs e)
        {
            string baglantiString = "Server=DESKTOP-ETH28ML;Database=proje;Integrated Security=True;";
            listViewGecmis.Items.Clear();

            using (SqlConnection con = new SqlConnection(baglantiString))
            {
                string sorgu = @"SELECT urunAdi, Adet, ToplamFiyat, SiparisTarihi 
                         FROM GecmisSiparisler 
                         WHERE kullaniciAdi = @kAdi AND 
                               SiparisTarihi BETWEEN @baslangic AND @bitis 
                         ORDER BY SiparisTarihi DESC";

                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@kAdi", kAdi); // Formun constructor'ından gelmeli
                cmd.Parameters.AddWithValue("@baslangic", dtpBaslangic.Value.Date);
                cmd.Parameters.AddWithValue("@bitis", dtpBitis.Value.Date.AddDays(1).AddTicks(-1)); // Gün sonuna kadar al

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["urunAdi"].ToString());
                        item.SubItems.Add(reader["Adet"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["ToplamFiyat"]).ToString("C2"));
                        item.SubItems.Add(Convert.ToDateTime(reader["SiparisTarihi"]).ToString("g"));
                        listViewGecmis.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
         private void btnGoruntule_Click(object sender, EventArgs e)
        {
            SiparisleriListele();
        }
        private void btn_bilgiGuncelle_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu frmmenu = new menu(kAdi);
            frmmenu.Show();
        }

        private void btn_geriDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu frmmenu = new menu(kAdi);
            frmmenu.Show();
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncarpi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_altSekme_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Formu alt sekmeye al
        }

        private void btn_buyut_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized; // Pencereyi büyüt
            }
            else
            {
                this.WindowState = FormWindowState.Normal; // Normal boyuta döndür
            }
        }

    }
}