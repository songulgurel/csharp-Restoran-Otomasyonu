using System;
using System.Windows.Forms;
using System.IO;

namespace Proje
{
    public partial class frmMain : Form
    {
        private string kAdi;

        // Eğer form parametresiz açılırsa admin varsayılır (debug için)
        public frmMain() : this("admin") { }

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

        private void btn_cikis_Click(object sender, EventArgs e) => Application.Exit();

        private void btn_cikis_Click_1(object sender, EventArgs e) => Application.Exit();

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
            this.Hide();
            menu frmmenu = new menu(kAdi); // ✅ Kullanıcı adı doğru geçiyor
            frmmenu.Show();
        }

        private void btn_sepet_Click(object sender, EventArgs e)
        {
            this.Hide();
            sepet frmsepet = new sepet(kAdi); // ✅ Kullanıcı adı doğru geçiyor
            frmsepet.Show();
        }

        private void btn_bilgiGuncelle_Click(object sender, EventArgs e)
        {
            if (kAdi.ToLower() == "misafir")
            {
                MessageBox.Show("Lütfen bilgilerinizi görmek/güncellemek için giriş yapınız.");
                this.Hide();
                Giris frmGiris = new Giris();
                frmGiris.Show();
                return;
            }

            this.Hide();
            bilgiGuncelle bilgiGuncelleform = new bilgiGuncelle(kAdi);
            bilgiGuncelleform.Show();
        }

        private void btn_hakkimizda_Click(object sender, EventArgs e)
        {
            this.Hide();
            hakkimizda hakkimizdaform = new hakkimizda(kAdi);
            hakkimizdaform.Show();
        }

        private void btn_gecmisSiparis_Click(object sender, EventArgs e)
        {
        
                this.Hide();  // önce mevcut formu gizle
                GecmisSiparisler gecmisSiparislerform = new GecmisSiparisler(kAdi);  // kullanıcı adı ile formu oluştur
                 gecmisSiparislerform  .Show();  // geçmiş siparişler formunu aç
            

        }
    }
}
