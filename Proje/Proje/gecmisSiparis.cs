using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Proje
{
    public partial class gecmisSiparis : Form
    {
        private string kAdi;
        private string baglantiString = "Data Source=SONGUL;Initial Catalog=proje;Integrated Security=True;";

        public gecmisSiparis(string kullaniciAdi)
        {

            InitializeComponent();
            kAdi = kullaniciAdi;
        }
        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frmmenu = Application.OpenForms["menu"];
            if (frmmenu == null)
            {
                frmmenu = new menu(kAdi);
                frmmenu.Show();
            }
            else
            {
                frmmenu.Activate();
            }
        }
        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frm = Application.OpenForms["frmMain"];
            if (frm == null)
            {
                frm = new frmMain(kAdi);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }
        }
        private void btn_sepet_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frmsepet = Application.OpenForms["sepet"];
            if (frmsepet == null)
            {
                frmsepet = new sepet(kAdi);
                frmsepet.Show();
            }
            else
            {
                frmsepet.Activate();
            }
        }
        private void btn_hakkimizda_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frmHakkimizda = Application.OpenForms["hakkimizda"];
            if (frmHakkimizda == null)
            {
                frmHakkimizda = new hakkimizda(kAdi);
                frmHakkimizda.Show();
            }
            else
            {
                frmHakkimizda.Activate();
            }
        }

        private void SiparisleriListele()
        {
            listViewGecmis.Items.Clear(); //listwiew temizlenir

            //sqlde kullanıcı adına göre siparişler tablosundaki veriler çekiliyor
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
                {//veriler okunuyor listwiewda görüntüleniyor
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())//Listedeki ürün adı adeti toplam fiyat ve tarih bilgisi okunur.
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
        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            SiparisleriListele();
        }
        private void btn_bilgiGuncelle_Click(object sender, EventArgs e)
        {
            this.Close();
            if (kAdi.ToLower() == "misafir")
            {
                MessageBox.Show("Lütfen bilgilerinizi görmek/güncellemek için giriş yapınız.");
                Form frmgiris = Application.OpenForms["Giris"];
                if (frmgiris == null)
                {
                    frmgiris = new Giris();
                    frmgiris.Show();
                }
                else
                {
                    frmgiris.Show();
                }
                this.Close();
                return;
            }

            Form frmBilgiGuncelle = Application.OpenForms["bilgiGuncelle"];
            if (frmBilgiGuncelle == null)
            {
                frmBilgiGuncelle = new bilgiGuncelle(kAdi);
                frmBilgiGuncelle.Show();
            }
            else
            {
                frmBilgiGuncelle.Activate();
            }
        }

        private void btn_geriDon_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frm = Application.OpenForms["frmMain"];
            if (frm == null)
            {
                frm = new frmMain(kAdi);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void gecmisSiparis_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "Resimler\\logo2.png"; //logo picturebox'a yansıtılıt.
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            if (kAdi.ToLower() == "misafir")
            {
                MessageBox.Show("Geçmiş siparişleri görüntülemek için giriş yapmanız gerekiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Form frmgiris = Application.OpenForms["Giris"];
                if (frmgiris == null)
                {
                    frmgiris = new Giris();
                    frmgiris.Show();
                }
                else
                {
                    frmgiris.Activate();
                }
                this.Close();
                return;
            }
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
    }
    }
