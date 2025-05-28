using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje
{
    public partial class sepet : Form
    {
        private string kAdi;
        private string baglantiString = "Data Source=SONGUL;Initial Catalog=proje;Integrated Security=True;";

        public sepet(string kullaniciAdi)
        {
            InitializeComponent();
            kAdi = kullaniciAdi;
        }

        private void sepet_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "Resimler\\logo2.png"; //logo picturebox'a yansıtılıt.
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            sepetBilgileriniYukle();
            txtKartNo.MaxLength = 16;//kart numarası 16 karakter olmalı
            txtCVV.MaxLength = 3;//cvv 3 karakter olmalı

            // Ay ve yıl combobox’ları için örnek doldurma:
            cmAy.Items.AddRange(new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            for (int yil = DateTime.Now.Year; yil <= DateTime.Now.Year + 10; yil++)
            {
                cmYil.Items.Add(yil.ToString());
            }

            kartBilgiPaneli.Visible = false; // ilk başta gizli
        }

        private void sepetBilgileriniYukle()
        {
            //siparişler tablosundakş urun ad adet ve fiyat bilgisini seç kullanıcı adlarına göre ayırarak
            string sorgu = "SELECT urunAdi, Adet, ToplamFiyat FROM Siparisler WHERE kullaniciAdi = @kullaniciAdi";

            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            {
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciAdi", kAdi);

                try
                {
                    //ürünleri okuyup listView'de görüntüle
                    baglanti.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    listView1.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["urunAdi"].ToString());
                        item.SubItems.Add(reader["Adet"].ToString());
                        item.SubItems.Add(reader["ToplamFiyat"].ToString());
                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btn_kapat_Click(object sender, EventArgs e) => Application.Exit();

        private void btn_buyut_Click(object sender, EventArgs e) => WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;


        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frmMenu = Application.OpenForms["menu"];
            if (frmMenu == null)
            {
                frmMenu = new menu(kAdi);
                frmMenu.Show();
            }
            else
            {
                frmMenu.Activate();
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

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult onay = MessageBox.Show("Seçili ürün silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    string urunAdi = listView1.SelectedItems[0].SubItems[0].Text;

                    using (SqlConnection baglanti = new SqlConnection(baglantiString))
                    {
                        try
                        {
                            baglanti.Open();

                            string silSorgu = "DELETE TOP(1) FROM Siparisler WHERE kullaniciAdi = @kAdi AND urunAdi = @urunAdi";
                            SqlCommand silCmd = new SqlCommand(silSorgu, baglanti);
                            silCmd.Parameters.AddWithValue("@kAdi", kAdi);
                            silCmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                            int silinen = silCmd.ExecuteNonQuery();

                            if (silinen > 0)
                            {
                                MessageBox.Show("Ürün sepetten silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                sepetBilgileriniYukle();
                            }
                            else
                            {
                                MessageBox.Show("Silinecek ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)//sipariş tamamla butoonu
        {
            if (kAdi == "Misafir" || string.IsNullOrEmpty(kAdi))
            {
                MessageBox.Show("Lütfen giriş yapınız. Misafir olarak sipariş veremezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Hide();
                Giris frmGiris = new Giris();
                frmGiris.Show(); return;

            }

            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Sepetinizde ürün bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir ödeme yöntemi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string odemeYontemi = comboBox1.SelectedItem.ToString();

            // Kartla ödeme ise gerekli kontroller
            if (odemeYontemi == "Kartla Ödeme")//kartla ödeme ise kullanıcınan kart no, cvv ve geçerlilik tarihi alma
            {
                if (string.IsNullOrWhiteSpace(txtKartİsim.Text) ||
                    string.IsNullOrWhiteSpace(txtKartNo.Text) ||
                    cmAy.SelectedItem == null ||
                    cmYil.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtCVV.Text))
                {
                    MessageBox.Show("Lütfen kart sahibinin adı soyadı ve tüm bilgileri eksiksiz giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kart sahibi adı en az 2 kelime olsun
                string[] isimParcalari = txtKartİsim.Text.Trim().Split(' ');
                if (isimParcalari.Length < 2)
                {
                    MessageBox.Show("Kart sahibi adı ve soyadı olmak üzere en az iki kelime içermelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtKartNo.Text.Length != 16 || txtCVV.Text.Length != 3) //kart no 16 cvv de 3 olmadığı zaman bu id yapısı çalışır.
                {
                    MessageBox.Show("Kart numarası 16 haneli, CVV ise 3 haneli olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            string kullaniciAdres = "";

            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            {
                baglanti.Open();
                string adresSorgu = "SELECT Adres FROM Kullanicilar WHERE kAdi = @kAdi";
                SqlCommand cmd = new SqlCommand(adresSorgu, baglanti);
                cmd.Parameters.AddWithValue("@kAdi", kAdi);

                object sonuc = cmd.ExecuteScalar();
                if (sonuc != null)
                {
                    kullaniciAdres = sonuc.ToString();
                }
            }

            if (string.IsNullOrWhiteSpace(kullaniciAdres))
            {
                MessageBox.Show("Adres bilgisi boş. Lütfen profilinizden adresinizi güncelleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bilgiGuncelle frmBilgiGuncelle = new bilgiGuncelle(kAdi);
                frmBilgiGuncelle.Show();
                return;
            }
            using (SqlConnection con = new SqlConnection(baglantiString))
            {
                con.Open();

                // 1. Siparişleri oku
                string selectQuery = "SELECT * FROM Siparisler WHERE kullaniciAdi = @kAdi";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                selectCmd.Parameters.AddWithValue("@kAdi", kAdi);

                SqlDataReader reader = selectCmd.ExecuteReader();
                //siparişler bilgileri listede saklanır.
                List<(string urunAdi, int adet, decimal fiyat, decimal toplamFiyat, DateTime tarih)> siparisler = new List<(string, int, decimal, decimal, DateTime)>();

                while (reader.Read())
                {
                    siparisler.Add((
                        reader["urunAdi"].ToString(),
                        Convert.ToInt32(reader["Adet"]),
                        Convert.ToDecimal(reader["Fiyat"]),
                        Convert.ToDecimal(reader["ToplamFiyat"]),
                        Convert.ToDateTime(reader["SiparisTarihi"])
                    ));
                }
                reader.Close();

                //veriler sqlde kopyalanıyor
                string kopyalaSorgu = @"
                 INSERT INTO GecmisSiparisler (kullaniciAdi, urunAdi, Adet, Fiyat, ToplamFiyat, SiparisTarihi, OdemeYontemi)
                 SELECT kullaniciAdi, urunAdi, Adet, Fiyat, ToplamFiyat, SiparisTarihi, OdemeYontemi 
                 FROM Siparisler 
                 WHERE kullaniciAdi = @kAdi";
                //orijinal verileri sil
                string silSorgu = "DELETE FROM Siparisler WHERE kullaniciAdi = @kAdi";

                try
                {

                    SqlCommand guncelleCmd = new SqlCommand("UPDATE Siparisler SET OdemeYontemi = @odeme WHERE kullaniciAdi = @kAdi", con);
                    guncelleCmd.Parameters.AddWithValue("@odeme", odemeYontemi);
                    guncelleCmd.Parameters.AddWithValue("@kAdi", kAdi);
                    guncelleCmd.ExecuteNonQuery();

                    SqlCommand kopyalaCmd = new SqlCommand(kopyalaSorgu, con);
                    kopyalaCmd.Parameters.AddWithValue("@kAdi", kAdi);
                    kopyalaCmd.ExecuteNonQuery();

                    SqlCommand silCmd = new SqlCommand(silSorgu, con);
                    silCmd.Parameters.AddWithValue("@kAdi", kAdi);
                    silCmd.ExecuteNonQuery();

                    listView1.Items.Clear();
                    comboBox1.SelectedIndex = -1;
                    kartBilgiPaneli.Visible = false;

                    MessageBox.Show("Sipariş tamamlandı ve Geçmiş Siparişlerim'e taşındı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kartBilgiPaneli.Visible = comboBox1.SelectedItem?.ToString() == "Kartla Ödeme";
        }

        private void btn_altSekme_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void btn_gecmisSiparis_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    frmgiris.Show();
                }
                this.Close();
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

        private void tum_sil_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Sepetinizdeki tüm ürünleri silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                using (SqlConnection baglanti = new SqlConnection(baglantiString))
                {
                    try
                    {
                        baglanti.Open();

                        string silSorgu = "DELETE FROM Siparisler WHERE kullaniciAdi = @kAdi";
                        SqlCommand silCmd = new SqlCommand(silSorgu, baglanti);
                        silCmd.Parameters.AddWithValue("@kAdi", kAdi);
                        int silinen = silCmd.ExecuteNonQuery();

                        if (silinen > 0)
                        {
                            listView1.Items.Clear();
                            MessageBox.Show("Sepetinizdeki tüm ürünler silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Sepette silinecek ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}