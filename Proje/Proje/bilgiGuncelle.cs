using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Proje
{
    public partial class bilgiGuncelle : Form
    {
        //sql bağlantısı yazılır.
        private string kAdi;
        Image resim; //pp için image global değişkeni tanoımlanır ve Media kütüphanesi yazılır.
        private string baglantiString = "Data Source=SONGUL;Initial Catalog=proje;Integrated Security=True;";

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
            pictureBox1.ImageLocation = "Resimler\\logo2.png"; //logo picturebox'a yansıtılıt.
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            bilgileriYukle(); //billgileri yükle fonk çalışır.
        }
        private void bilgileriYukle()
        {
            string sorgu = "SELECT * FROM kullanicilar WHERE kAdi = @kAdi";//kullanıcılar tablosunda kullanıcı adı bilgisi alınır.
            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            {
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kAdi", kAdi);
                try
                {
                    baglanti.Open(); //bağlantı çalıştırılır.
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) //bilgiler okunur
                    {
                        txt_kAd.Text = reader["kAdi"].ToString();//textboxlara ilgili bilgiler yazdırılır.
                        txt_ad.Text = reader["Ad"].ToString();
                        txt_soyad.Text = reader["Soyad"].ToString();
                        txt_tel.Text = reader["telNo"].ToString();
                        txt_adres.Text = reader["Adres"].ToString();

                        if (reader["pp"] != DBNull.Value) //pp sütunundaki fotoğraf pictureBox'a aktarılır.
                        {
                            byte[] resimBytes = (byte[])reader["pp"];
                            using (MemoryStream ms = new MemoryStream(resimBytes))
                            {
                                pictureBox2.Image = Image.FromStream(ms);
                            }
                        }
                        else //boşsa varsayılan fotoğraf görüntülenir
                        {
                            pictureBox2.ImageLocation = "Resimler\\profilePic.png";
                        }
                    }
                    else//bilgiler okunamazsa bu mesaj görüntülenir.
                    {
                        MessageBox.Show("Kullanıcı bulunamadı.");
                    }

                    reader.Close(); //okuyucu kapatılır.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            //Mevcut şifre girilmeden yeni şifre tanımlanmasın
            if (string.IsNullOrWhiteSpace(txt_sifre.Text) && !string.IsNullOrWhiteSpace(txt_yeniSİfre.Text))
            {
                MessageBox.Show("Mevcut şifrenizi girmeden şifrenizi güncelleyemezsiniz. Lütfen mevcut şifrenizi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(txt_sifre.Text)) //şifre alanın boş olup olmadığı kontrol edilir boşsa 
            {
                string mevcutSifreQuery = "SELECT kSifre FROM kullanicilar WHERE kAdi = @kAdi"; //kullanıcıa adına gçmre şifre verisi çekilir.
                string mevcutSifre = "";

                using (SqlConnection baglanti = new SqlConnection(baglantiString))
                {
                    SqlCommand cmd = new SqlCommand(mevcutSifreQuery, baglanti);
                    cmd.Parameters.AddWithValue("@kAdi", kAdi);
                    try
                    {
                        baglanti.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            mevcutSifre = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                        return;
                    }
                }
                if (txt_yeniSİfre.Text.Length <6)
                {
                    MessageBox.Show("Yeni şifreniz 6 karakterden az olamaz! Lütfen farklı bir şifre girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //yeni şifre mevcut şifre ile aynıysa bu mesaj görüntülenir
                if (txt_yeniSİfre.Text == mevcutSifre)
                {
                    MessageBox.Show("Yeni şifre mevcut şifrenizle aynı olamaz. Lütfen farklı bir şifre girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //mevcut şifreye girilen şifre doğru mu? değilse bu hata mesajı verilir.
                if (txt_sifre.Text != mevcutSifre)
                {
                    MessageBox.Show("Mevcut şifreniz hatalı! Lütfen doğru şifreyi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //kullanıcı adı güncellendiğinde zaten sqlde böyle bir kullanıcı adı varsa hata ver.
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

            //telno güncellendiğinde zaten sqlde böyle bir telno  varsa hata ver.
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

            // Telefon numarası 10 haneli mi ve başında 0 var mı varsa bu hata mesajını göster.
            if (!string.IsNullOrEmpty(txt_tel.Text))
            {
                if (txt_tel.Text.Length != 10 || txt_tel.Text.StartsWith("0"))
                {
                    MessageBox.Show("Telefon numaranızı başında 0 olmadan ve 10 haneli olarak giriniz.");
                    return;
                }
            }

            List<SqlParameter> parametreler = new List<SqlParameter>();
            string sorgu = "UPDATE kullanicilar SET ";
            bool guncellemeIhtiyaci = false;

            if (txt_kAd.Text != kAdi) //eğer kullanıcı acı güncellendiyse
            {
                sorgu += "kAdi = @newKAdi, ";
                parametreler.Add(new SqlParameter("@newKAdi", txt_kAd.Text)); //güncelle
                guncellemeIhtiyaci = true;
            }

            if (!string.IsNullOrEmpty(txt_ad.Text))
            {
                sorgu += "Ad = @Ad, ";//eğer ad değiştiyse
                parametreler.Add(new SqlParameter("@Ad", txt_ad.Text)); //ad kısmını güncelle 
                guncellemeIhtiyaci = true;
            }

            if (!string.IsNullOrEmpty(txt_soyad.Text))//eğer soyad değiştiyse
            {
                sorgu += "Soyad = @Soyad, ";
                parametreler.Add(new SqlParameter("@Soyad", txt_soyad.Text)); //soyad kısmını güncelle
                guncellemeIhtiyaci = true;
            }

            if (!string.IsNullOrEmpty(txt_yeniSİfre.Text)) //eğer yeni şifre değiştiyse
            {
                sorgu += "kSifre = @kSifre, ";
                parametreler.Add(new SqlParameter("@kSifre", txt_yeniSİfre.Text));//şifreyi güncelle
                guncellemeIhtiyaci = true;
                txt_sifre.Clear();
                txt_yeniSİfre.Clear();
            }

            if (!string.IsNullOrEmpty(txt_tel.Text)) //eğer tel değiştiyse
            {
                sorgu += "telNo = @telNo, ";
                parametreler.Add(new SqlParameter("@telNo", txt_tel.Text));//tel güncelle
                guncellemeIhtiyaci = true;
            }

            if (!string.IsNullOrEmpty(txt_adres.Text))//eğer adres değiştiyse
            {
                sorgu += "Adres = @Adres, ";
                parametreler.Add(new SqlParameter("@Adres", txt_adres.Text)); //adresi güncelle
                guncellemeIhtiyaci = true;
            }

            if (!guncellemeIhtiyaci)//eğer güncelleme yapulnadıysa
            {
                MessageBox.Show("Güncellenecek bir bilgi bulunamadı."); //bunu  yazdır.
                return;
            }

            // sonundaki virgülü kaldır
            sorgu = sorgu.TrimEnd(',', ' ');

            // Hangi kullanıcının bilgileri güncellenecekse where ile sorguluyoruz.
            sorgu += " WHERE kAdi = @kAdi";
            parametreler.Add(new SqlParameter("@kAdi", kAdi));

            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            {
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddRange(parametreler.ToArray());

                try
                {
                    baglanti.Open();
                    int sonuc = cmd.ExecuteNonQuery();
                    if (sonuc > 0)//eğer güncelleme olduysa bu mesajı ver
                    {
                        MessageBox.Show("Bilgiler başarıyla güncellendi.");
                    }
                    else//olmadıysa bu mesajı ver
                    {
                        MessageBox.Show("Güncelleme başarısız oldu. Kullanıcı bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        private void btn_ppEkle_Click(object sender, EventArgs e) 
        {
            openFileDialog1.Filter = "Resimler|*.png;*.jpg;*.jpeg"; 
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                    resim = Image.FromFile(openFileDialog1.FileName);

                    //Resmin otomatik döndürülmemesisini sağlar
                    foreach (var id in resim.PropertyIdList)
                    {
                        if (id == 0x0112) // Orientation bilgisi
                        {
                            int yon = resim.GetPropertyItem(id).Value[0];
                            if (yon == 3)
                                resim.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            else if (yon == 6)
                                resim.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            else if (yon == 8)
                                resim.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                    }

                    pictureBox2.Image = resim;
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                    byte[] resimBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        resim.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        resimBytes = ms.ToArray();
                    }

                    string query = "UPDATE kullanicilar SET pp = @pp WHERE kAdi = @kAdi"; //kullanıcı adına göre pp hatırla

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
        }
        private void btn_ppKaldir_Click(object sender, EventArgs e) //pp kaldır tuşu
        {
            string query = "UPDATE kullanicilar SET pp = NULL WHERE kAdi = @kAdi"; //pp sütununu güncelle sorgusu
            using (SqlConnection connection = new SqlConnection(baglantiString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@kAdi", kAdi);

                try
                {
                    connection.Open();
                    int guncellenenSatir = cmd.ExecuteNonQuery();

                    if (guncellenenSatir > 0)//kaldırılırsa bu mesaj
                    {
                        MessageBox.Show("Profil fotoğrafı kaldırıldı.");

                        pictureBox2.ImageLocation = "Resimler\\profilePic.png";//varsayılan fotoğraf görüntülenir.
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("Profil fotoğrafı kaldırılmadı.");//kaldırılamazsa bu mesaj veriir.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btn_iptal_Click(object sender, EventArgs e) //iptal edilirse bu mesaj görüntülenir
        {
            DialogResult result = MessageBox.Show("Yapılan değişiklikler kaybolacak. Devam etmek istiyor musunuz?", "İptal Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bilgileriYukle();//bilgileri yükleme metodu çalıştırılır.
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
        private void btn_gecmisSiparisler_Click(object sender, EventArgs e)
        {
            this.Close();
            if (kAdi.ToLower() == "misafir")
            {
                MessageBox.Show("Geçmiş siparişleri görüntülemek için giriş yapmanız gerekiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Hide();
                Giris frm = new Giris();
                frm.Show();
                return;
            }

            Form frmGecmis = Application.OpenForms["gecmisSiparis"];
            if (frmGecmis == null)
            {
                frmGecmis = new gecmisSiparis(kAdi);
                frmGecmis.Show();
            }
            else
            {
                frmGecmis.Activate();
            }
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

