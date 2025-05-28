using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proje
{
    public partial class Giris : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ETH28ML;Initial Catalog=proje;Integrated Security=True;");
        public Giris()
        {
            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_kAdi.Text) || string.IsNullOrWhiteSpace(txt_Sifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT COUNT(*) FROM kullanicilar WHERE kAdi = @kAdi AND kSifre = @kSifre";

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-ETH28ML;Initial Catalog=proje;Integrated Security=True;"))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@kAdi", txt_kAdi.Text.Trim());
                    cmd.Parameters.AddWithValue("@kSifre", txt_Sifre.Text.Trim());

                    con.Open();
                    int kullaniciSayisi = (int)cmd.ExecuteScalar();

                    if (kullaniciSayisi > 0)
                    {
                        MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Giriş başarılıysa kullanıcı adını ana forma gönder
                        frmMain frm = new frmMain(txt_kAdi.Text.Trim());
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_misafirGirisi_Click(object sender, EventArgs e)
        {
            string kAdi = "misafir";
            this.Hide();
            frmMain frm = new frmMain("Misafir");
            frm.Show();
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "Resimler\\logo2.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btn_kayıt_Click(object sender, EventArgs e)
        {
            this.Hide();
            KayitOl frmKayit = new KayitOl();
            frmKayit.Show();
        }
    }
}
