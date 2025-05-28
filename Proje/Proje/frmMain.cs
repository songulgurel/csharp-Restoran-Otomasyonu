    using System;
    using System.Windows.Forms;
    using System.IO;

    namespace Proje
    {
        public partial class frmMain : Form
        {
            private string kAdi;
            public frmMain(string kullaniciAdi)
            {
                InitializeComponent();
                kAdi = kullaniciAdi;
            }

            private void frmMain_Load(object sender, EventArgs e)
            {
                pictureBox1.ImageLocation = "Resimler\\logo.png";
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }

            private void btn_kapat_Click(object sender, EventArgs e) => Application.Exit();
            private void btn_altSekme_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
            private void btn_buyut_Click(object sender, EventArgs e)
            {
                this.WindowState = (this.WindowState == FormWindowState.Normal)
                    ? FormWindowState.Maximized
                    : FormWindowState.Normal;
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

            private void btn_sepet_Click(object sender, EventArgs e)
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
        private void btn_cikis_Click(object sender, EventArgs e) => Application.Exit();

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
    }
}
   
