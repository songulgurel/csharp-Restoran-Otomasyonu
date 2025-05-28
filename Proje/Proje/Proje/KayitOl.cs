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
    public partial class KayitOl: Form
    {
        private SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ETH28ML;Initial Catalog=proje;Integrated Security=True;");
        public KayitOl()
        {
            InitializeComponent();
        }

        private void btn_Kayit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_kAdi.Text) ||
                    string.IsNullOrWhiteSpace(txt_kSifre.Text) ||
                    string.IsNullOrWhiteSpace(txt_Ad.Text) ||
                    string.IsNullOrWhiteSpace(txt_Soyad.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları eksiksiz doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txt_kSifre.Text.Length > 10)
                {
                    MessageBox.Show("Şifreniz 10 karakterden fazla olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                baglanti.Open();
                string kontrolQuery = "SELECT COUNT(*) FROM kullanicilar WHERE kAdi = @kAdi";
                using (SqlCommand kontrolCmd = new SqlCommand(kontrolQuery, baglanti))
                {
                    kontrolCmd.Parameters.AddWithValue("@kAdi", txt_kAdi.Text);
                    int mevcutKullanici = (int)kontrolCmd.ExecuteScalar();

                    if (mevcutKullanici > 0)
                    {
                        MessageBox.Show("Bu kullanıcı adı zaten mevcut! Lütfen başka bir kullanıcı adı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string query = "INSERT INTO kullanicilar (kAdi, kSifre, Ad, Soyad) VALUES (@kAdi, @kSifre, @Ad, @Soyad)";
                using (SqlCommand cmd = new SqlCommand(query, baglanti))
                {
                    cmd.Parameters.AddWithValue("@kAdi", txt_kAdi.Text);
                    cmd.Parameters.AddWithValue("@kSifre", txt_kSifre.Text);
                    cmd.Parameters.AddWithValue("@Ad", txt_Ad.Text);
                    cmd.Parameters.AddWithValue("@Soyad", txt_Soyad.Text);

                    int sonuc = cmd.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla eklendi!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Giris frmgiris = new Giris();
                        frmgiris.Show();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt eklenirken hata oluştu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btn_misafirgirisi_Click(object sender, EventArgs e)
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

        private void KayitOl_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "Resimler\\logo2.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}

