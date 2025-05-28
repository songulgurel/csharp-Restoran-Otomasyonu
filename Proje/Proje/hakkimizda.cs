using System;
using System.Windows.Forms;

namespace Proje
{
    public partial class hakkimizda : Form
    {
        private string kAdi;
        public hakkimizda(string kullaniciAdi)
        {
            InitializeComponent();
            kAdi = kullaniciAdi;
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit(); //uygulamadan çıkılır.
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            Application.Exit(); //uygulamadan çıkılır.
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

        private void hakkimizda_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "Resimler\\logo2.png"; //bu forma girildiğinde resimler klasöründeki logoyu picturebox'ta göster

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;   //size'ını da ayarla.      
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

        private void btn_canliDestek_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://us05web.zoom.us/j/83231531596?pwd=terMiR0lUEfb0aveHBmTHtNK7xywWB.1");
        }

        private void btn_geriDon_Click(object sender, EventArgs e) //geridon butonu main formunu açar.
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

        private void btn_sepet_Click(object sender, EventArgs e) //sepet butonu sepet formnunu açar
        {
            this.Close();
            Form frmSepet = Application.OpenForms["sepet"];
            if (frmSepet == null)
            {
                frmSepet = new sepet(kAdi);
                frmSepet.Show();
            }
            else
            {
                frmSepet.Activate();
            }
        }


        private void btn_anasayfa_Click(object sender, EventArgs e) //anasayfa butonu ana sayfa formunu açar
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
    }
}

