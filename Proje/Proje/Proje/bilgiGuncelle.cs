using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Proje
{

    
    public partial class bilgiGuncelle : Form
    {
        public string baglantiString = @"Data Source=DESKTOP-ETH28ML;Initial Catalog=proje;Integrated Security=True;";

        private string kAdi;
        Image resim;

        public bilgiGuncelle(string kullaniciAdi)
        {
            InitializeComponent();
            kAdi = kullaniciAdi;
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btn_altSekme_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Formu alt sekmeye al
        }

        private void bilgiGuncelle_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "Resimler\\logo2.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            bilgileriYukle();
        }
        private void bilgileriYukle()
        {
            string sorgu = "SELECT * FROM kullanicilar WHERE kAdi = @kAdi";

            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            {
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kAdi", kAdi);

                try
                {
                    baglanti.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txt_kAd.Text = reader["kAdi"].ToString();
                        txt_ad.Text = reader["Ad"].ToString();
                        txt_soyad.Text = reader["Soyad"].ToString();
                        txt_tel.Text = reader["telNo"].ToString();
                        txt_adres.Text = reader["Adres"].ToString();

                        if (reader["pp"] != DBNull.Value)
                        {
                            byte[] resimBytes = (byte[])reader["pp"];
                            using (MemoryStream ms = new MemoryStream(resimBytes))
                            {
                                pictureBox2.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pictureBox2.ImageLocation = "Resimler\\profilePic.png";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bulunamadı.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {            

            if (!string.IsNullOrEmpty(txt_tel.Text))
            {
                string mevcutSifreQuery = "SELECT kSifre FROM kullanicilar WHERE kAdi = @kAdi";
                string mevcutSifre = "";

                using (SqlConnection baglanti = new SqlConnection(baglantiString))
                {
                    SqlCommand cmd = new SqlCommand(mevcutSifreQuery, baglanti);
                    cmd.Parameters.AddWithValue("@kAdi", kAdi);

                    try
                    {
                        baglanti.Open();
                        mevcutSifre = (string)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                        return;
                    }
                }

                if (txt_tel.Text == mevcutSifre)
                {
                    MessageBox.Show("Yeni şifre mevcut şifrenizle aynı olamaz. Lütfen farklı bir şifre girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txt_sifre.Text))
            {
                string mevcutSifreQuery = "SELECT kSifre FROM kullanicilar WHERE kAdi = @kAdi";
                string mevcutSifre = "";

                using (SqlConnection baglanti = new SqlConnection(baglantiString))
                {
                    SqlCommand cmd = new SqlCommand(mevcutSifreQuery, baglanti);
                    cmd.Parameters.AddWithValue("@kAdi", kAdi);

                    try
                    {
                        baglanti.Open();
                        mevcutSifre = (string)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                        return;
                    }
                }

                if (mevcutSifre != txt_sifre.Text)
                {
                    MessageBox.Show("Mevcut şifreniz hatalı! Lütfen doğru şifreyi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txt_kAd.Text != kAdi)
            {
                string kontrolQuery = "SELECT COUNT(*) FROM kullanicilar WHERE kAdi = @newKAdi";

                using (SqlConnection baglanti = new SqlConnection(baglantiString))
                {
                    SqlCommand kontrolCmd = new SqlCommand(kontrolQuery, baglanti);
                    kontrolCmd.Parameters.AddWithValue("@newKAdi", txt_kAd.Text);

                    try
                    {
                        baglanti.Open();
                        int mevcutKullanici = (int)kontrolCmd.ExecuteScalar();
                        if (mevcutKullanici > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten alınmış. Lütfen farklı bir kullanıcı adı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                        return;
                    }
                }
            }

            string kontrolTelQuery = "SELECT COUNT(*) FROM kullanicilar WHERE telNo = @telNo AND kAdi != @kAdi";
            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            {
                SqlCommand kontrolCmd = new SqlCommand(kontrolTelQuery, baglanti);
                kontrolCmd.Parameters.AddWithValue("@telNo", txt_tel.Text);
                kontrolCmd.Parameters.AddWithValue("@kAdi", kAdi);

                try
                {
                    baglanti.Open();
                    int mevcutKullanici = (int)kontrolCmd.ExecuteScalar();

                    if (mevcutKullanici > 0)
                    {
                        MessageBox.Show("Bu telefon numarasına ait bir kullanıcı mevcut! Lütfen başka bir telefon numarası girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txt_tel.Text) && txt_tel.Text.Length == 11)
            {
                if (txt_tel.Text[0] == '0')
                {
                    MessageBox.Show("Telefon numaranızı başında 0 olmadan giriniz.");
                    return;
                }
            }

            List<SqlParameter> parametreler = new List<SqlParameter>();
            string sorgu = "UPDATE kullanicilar SET ";
            bool guncellemeIhtiyaci = false;

            if (txt_kAd.Text != kAdi)
            {
                sorgu += "kAdi = @newKAdi, ";
                parametreler.Add(new SqlParameter("@newKAdi", txt_kAd.Text));
                guncellemeIhtiyaci = true;
            }

            if (!string.IsNullOrEmpty(txt_ad.Text))
            {
                sorgu += "Ad = @Ad, ";
                parametreler.Add(new SqlParameter("@Ad", txt_ad.Text));
                guncellemeIhtiyaci = true;
            }

            if (!string.IsNullOrEmpty(txt_soyad.Text))
            {
                sorgu += "Soyad = @Soyad, ";
                parametreler.Add(new SqlParameter("@Soyad", txt_soyad.Text));
                guncellemeIhtiyaci = true;
            }

            if (!string.IsNullOrEmpty(txt_sifre.Text) && !string.IsNullOrEmpty(txt_tel.Text))
            {
                sorgu += "kSifre = @kSifre, ";
                parametreler.Add(new SqlParameter("@kSifre", txt_tel.Text));
                guncellemeIhtiyaci = true;
            }

            if (!string.IsNullOrEmpty(txt_tel.Text))
            {
                sorgu += "telNo = @telNo, ";
                parametreler.Add(new SqlParameter("@telNo", txt_tel.Text));
                guncellemeIhtiyaci = true;
            }

            if (!string.IsNullOrEmpty(txt_adres.Text))
            {
                sorgu += "Adres = @Adres, ";
                parametreler.Add(new SqlParameter("@Adres", txt_adres.Text));
                guncellemeIhtiyaci = true;
            }

            if (!guncellemeIhtiyaci)
            {
                MessageBox.Show("Güncellenecek bir bilgi bulunamadı.");
                return;
            }

            sorgu = sorgu.TrimEnd(',', ' ');
            sorgu += " WHERE kAdi = @kAdi";
            parametreler.Add(new SqlParameter("@kAdi", kAdi));

            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            {
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddRange(parametreler.ToArray());

                try
                {
                    baglanti.Open();
                    int guncellenenSatirSayisi = cmd.ExecuteNonQuery();

                    if (guncellenenSatirSayisi > 0)
                    {
                        MessageBox.Show("Bilgiler başarıyla güncellendi.");
                        kAdi = txt_kAd.Text;
                        txt_sifre.Text = txt_tel.Text;
                        txt_tel.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız oldu.");
                    }
                    bilgileriYukle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        private void btn_ppEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resimler|*.png;*.jpg";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    resim = Image.FromFile(openFileDialog1.FileName);

                    //Resim otomatik döndürürülmesini engelleyen kod/boyut ne olursa olsun orijinal yüklenecek
                    if (resim.PropertyIdList.Contains(0x0112)) 
                    {
                        int dondurme = (int)resim.GetPropertyItem(0x0112).Value[0];
                        switch (dondurme)
                        {
                            case 1://resim orijinal gibiyse değişiklik yapna
                                break;
                            case 3:
                                resim.RotateFlip(RotateFlipType.Rotate180FlipNone); // 180 derece döndür
                                break;
                            case 6:
                                resim.RotateFlip(RotateFlipType.Rotate90FlipNone); // sağa döndür
                                break;
                            case 8:
                                resim.RotateFlip(RotateFlipType.Rotate270FlipNone); // sola döndür
                                break;
                            default:
                                break;
                        }
                    }

                    pictureBox2.Image = resim;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    byte[] resimBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        resim.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        resimBytes = ms.ToArray();
                    }

                    string query = "UPDATE kullanicilar SET pp = @pp WHERE kAdi = @kAdi";

                    using (SqlConnection connection = new SqlConnection(baglantiString))
                    {
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@pp", resimBytes);
                        cmd.Parameters.AddWithValue("@kAdi", kAdi);
                        try
                        {
                            connection.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Profil fotoğrafı başarıyla kaydedildi.");
                            }
                            else
                            {
                                MessageBox.Show("Profil fotoğrafı kaydedilemedi.");
                            }

                            bilgileriYukle();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim yükleme hatası: " + ex.Message);
                }
            }
        }
        private void btn_ppKaldir_Click(object sender, EventArgs e)
        {

            string query = "UPDATE kullanicilar SET pp = NULL WHERE kAdi = @kAdi";

            using (SqlConnection connection = new SqlConnection(baglantiString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@kAdi", kAdi);  

                try
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); 

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profil fotoğrafı kaldırıldı.");

                        pictureBox2.ImageLocation = "Resimler\\profilePic.png";
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("Profil fotoğrafı kaldırılmadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yapılan değişiklikler kaybolacak. Devam etmek istiyor musunuz?", "İptal Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bilgileriYukle();
            }
        }

        private void btn_geriDon_Click(object sender, EventArgs e)
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

        private void btn_hakkimizda_Click(object sender, EventArgs e)
        {
            this.Hide();
            hakkimizda hakkimizdaform = new hakkimizda(kAdi);
            hakkimizdaform.Show();
        }
        private void btn_gecmisSiparisler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GecmisSiparisler frm = new GecmisSiparisler(kAdi);
            frm.Show();
        }

    }
}
