using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class hakkimizda: Form
    {
        private string kAdi;
        public hakkimizda(string kullaniciAdi)
        {
            InitializeComponent();
            kAdi = kullaniciAdi;
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_hakkimizda_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btn_kapat_Click(object sender, EventArgs e)
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

        private void hakkimizda_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "Resimler\\logo2.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;        
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


        private void btn_canliDestek_Click(object sender, EventArgs e)
        {

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

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain(kAdi);
            frm.Show();
        }
        private void btn_gecmisSiparisler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GecmisSiparisler frm = new GecmisSiparisler(kAdi);
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
