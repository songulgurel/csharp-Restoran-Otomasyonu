using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proje
{
    public partial class sepet : Form
    {
        private string kAdi;
        private string baglantiString = "Server=DESKTOP-ETH28ML;Database=proje;Integrated Security=True;";

        public sepet(string kullaniciAdi)
        {
            InitializeComponent();
            kAdi = kullaniciAdi;
        }

        private void sepet_Load(object sender, EventArgs e)
        {
            sepetBilgileriniYukle();
            txtKartNo.MaxLength = 16;
            txtCVV.MaxLength = 3;

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
            string sorgu = "SELECT urunAdi, Adet, ToplamFiyat FROM Siparisler WHERE kullaniciAdi = @kullaniciAdi";

            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            {
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciAdi", kAdi);

                try
                {
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


        private void btn_kapat_Click(object sender, EventArgs e) =>Application.Exit();

        private void btn_buyut_Click(object sender, EventArgs e) => WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;

        private void btn_altSekme_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu frmMenu = new menu(kAdi);
            frmMenu.Show();
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
            hakkimizda frmhakkimizda = new hakkimizda(kAdi);
            frmhakkimizda.Show();
        }

        private void btn_bilgiGuncelle_Click(object sender, EventArgs e)
        {
            this.Hide();
            bilgiGuncelle frmbilgiGuncelle = new bilgiGuncelle(kAdi);
            frmbilgiGuncelle.Show();
        }

        private void btn_geriDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain(kAdi);
            frm.Show();
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult onay = MessageBox.Show("Seçili siparişi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (onay == DialogResult.Yes)
                {
                    string urunAdi = listView1.SelectedItems[0].SubItems[0].Text;

                    string sorgu = "DELETE FROM Siparisler WHERE kullaniciAdi = @kAdi AND urunAdi = @urunAdi";

                    using (SqlConnection baglanti = new SqlConnection(baglantiString))
                    {
                        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                        cmd.Parameters.AddWithValue("@kAdi", kAdi);
                        cmd.Parameters.AddWithValue("@urunAdi", urunAdi);

                        try
                        {
                            baglanti.Open();
                            int silinen = cmd.ExecuteNonQuery();

                            if (silinen > 0)
                            {
                                MessageBox.Show("Ürün sepetten silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                sepetBilgileriniYukle(); // listeyi güncelle
                            }
                            else
                            {
                                MessageBox.Show("Silme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
  
     private void button1_Click(object sender, EventArgs e)
        {
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

            // 🔐 Kartla ödeme ise gerekli kontroller
            if (odemeYontemi == "Kartla Ödeme")
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

                if (txtKartNo.Text.Length != 16 || txtCVV.Text.Length != 3)
                {
                    MessageBox.Show("Kart numarası 16 haneli, CVV ise 3 haneli olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (SqlConnection con = new SqlConnection(baglantiString))
            {
                con.Open();

                // 1. Siparişleri oku
                string selectQuery = "SELECT * FROM Siparisler WHERE kullaniciAdi = @kAdi";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                selectCmd.Parameters.AddWithValue("@kAdi", kAdi);

                SqlDataReader reader = selectCmd.ExecuteReader();
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

                string kopyalaSorgu = @"
    INSERT INTO GecmisSiparisler (kullaniciAdi, urunAdi, Adet, Fiyat, ToplamFiyat, SiparisTarihi, OdemeYontemi)
    SELECT kullaniciAdi, urunAdi, Adet, Fiyat, ToplamFiyat, SiparisTarihi, OdemeYontemi 
    FROM Siparisler 
    WHERE kullaniciAdi = @kAdi";

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


        private void lblCVV_Click(object sender, EventArgs e)
        {

        }


        private void btn_sepet_Click(object sender, EventArgs e)
        {
            // sepete eklenmiş ürün var mı kontrol et
            if (menu.secilenUrunler.Count == 0)
            {
                MessageBox.Show("Sepetinizde ürün bulunmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
        private void btn_gecmisSiparisler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GecmisSiparisler frm = new GecmisSiparisler(kAdi);
            frm.Show();
        }


    }
}
