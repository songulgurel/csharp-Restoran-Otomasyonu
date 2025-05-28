namespace Proje
{
    partial class Giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_cikis = new System.Windows.Forms.Button();
            this.lbl_kullaniciBilgi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_kAdi = new System.Windows.Forms.Label();
            this.txt_kAdi = new System.Windows.Forms.TextBox();
            this.txt_Sifre = new System.Windows.Forms.TextBox();
            this.lbl_sifre = new System.Windows.Forms.Label();
            this.btn_giris = new System.Windows.Forms.Button();
            this.btn_kayıt = new System.Windows.Forms.Button();
            this.messageQueue1 = new System.Messaging.MessageQueue();
            this.btn_misafirGirisi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_cikis);
            this.panel1.Controls.Add(this.lbl_kullaniciBilgi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 223);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(161, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 157);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // btn_cikis
            // 
            this.btn_cikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btn_cikis.FlatAppearance.BorderSize = 0;
            this.btn_cikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_cikis.ForeColor = System.Drawing.Color.LavenderBlush;
            this.btn_cikis.Location = new System.Drawing.Point(415, 12);
            this.btn_cikis.Name = "btn_cikis";
            this.btn_cikis.Size = new System.Drawing.Size(73, 32);
            this.btn_cikis.TabIndex = 41;
            this.btn_cikis.Text = "Çıkış";
            this.btn_cikis.UseVisualStyleBackColor = false;
            this.btn_cikis.Click += new System.EventHandler(this.btn_cikis_Click);
            // 
            // lbl_kullaniciBilgi
            // 
            this.lbl_kullaniciBilgi.AutoSize = true;
            this.lbl_kullaniciBilgi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.lbl_kullaniciBilgi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kullaniciBilgi.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lbl_kullaniciBilgi.Location = new System.Drawing.Point(12, 200);
            this.lbl_kullaniciBilgi.Name = "lbl_kullaniciBilgi";
            this.lbl_kullaniciBilgi.Size = new System.Drawing.Size(265, 23);
            this.lbl_kullaniciBilgi.TabIndex = 7;
            this.lbl_kullaniciBilgi.Text = "Lütfen kullanıcı bilgilerinizi giriniz.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kullanıcı bilgilerinizi giriniz.";
            // 
            // lbl_kAdi
            // 
            this.lbl_kAdi.AutoSize = true;
            this.lbl_kAdi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kAdi.Location = new System.Drawing.Point(109, 297);
            this.lbl_kAdi.Name = "lbl_kAdi";
            this.lbl_kAdi.Size = new System.Drawing.Size(120, 28);
            this.lbl_kAdi.TabIndex = 1;
            this.lbl_kAdi.Text = "Kullanıcı Adı";
            // 
            // txt_kAdi
            // 
            this.txt_kAdi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_kAdi.Location = new System.Drawing.Point(113, 331);
            this.txt_kAdi.Name = "txt_kAdi";
            this.txt_kAdi.Size = new System.Drawing.Size(264, 31);
            this.txt_kAdi.TabIndex = 2;
            // 
            // txt_Sifre
            // 
            this.txt_Sifre.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Sifre.Location = new System.Drawing.Point(113, 415);
            this.txt_Sifre.Name = "txt_Sifre";
            this.txt_Sifre.Size = new System.Drawing.Size(264, 31);
            this.txt_Sifre.TabIndex = 4;
            this.txt_Sifre.UseSystemPasswordChar = true;
            // 
            // lbl_sifre
            // 
            this.lbl_sifre.AutoSize = true;
            this.lbl_sifre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_sifre.Location = new System.Drawing.Point(109, 381);
            this.lbl_sifre.Name = "lbl_sifre";
            this.lbl_sifre.Size = new System.Drawing.Size(51, 28);
            this.lbl_sifre.TabIndex = 3;
            this.lbl_sifre.Text = "Şifre";
            // 
            // btn_giris
            // 
            this.btn_giris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btn_giris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_giris.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_giris.ForeColor = System.Drawing.Color.LavenderBlush;
            this.btn_giris.Location = new System.Drawing.Point(172, 464);
            this.btn_giris.Name = "btn_giris";
            this.btn_giris.Size = new System.Drawing.Size(135, 40);
            this.btn_giris.TabIndex = 5;
            this.btn_giris.Text = "Giriş Yap";
            this.btn_giris.UseVisualStyleBackColor = false;
            this.btn_giris.Click += new System.EventHandler(this.btn_giris_Click);
            // 
            // btn_kayıt
            // 
            this.btn_kayıt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btn_kayıt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kayıt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kayıt.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_kayıt.Location = new System.Drawing.Point(276, 561);
            this.btn_kayıt.Name = "btn_kayıt";
            this.btn_kayıt.Size = new System.Drawing.Size(141, 32);
            this.btn_kayıt.TabIndex = 6;
            this.btn_kayıt.Text = "Kayıt Ol";
            this.btn_kayıt.UseVisualStyleBackColor = false;
            this.btn_kayıt.Click += new System.EventHandler(this.btn_kayıt_Click);
            // 
            // messageQueue1
            // 
            this.messageQueue1.DefaultPropertiesToSend.HashAlgorithm = System.Messaging.HashAlgorithm.Sha512;
            this.messageQueue1.MessageReadPropertyFilter.LookupId = true;
            this.messageQueue1.SynchronizingObject = this;
            // 
            // btn_misafirGirisi
            // 
            this.btn_misafirGirisi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btn_misafirGirisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_misafirGirisi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_misafirGirisi.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_misafirGirisi.Location = new System.Drawing.Point(276, 599);
            this.btn_misafirGirisi.Name = "btn_misafirGirisi";
            this.btn_misafirGirisi.Size = new System.Drawing.Size(141, 36);
            this.btn_misafirGirisi.TabIndex = 7;
            this.btn_misafirGirisi.Text = "Misafir Girişi";
            this.btn_misafirGirisi.UseVisualStyleBackColor = false;
            this.btn_misafirGirisi.Click += new System.EventHandler(this.btn_misafirGirisi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(91, 567);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Henüz bir hesabım yok";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(91, 609);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kayıt olmadan devam et";
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 700);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_misafirGirisi);
            this.Controls.Add(this.btn_kayıt);
            this.Controls.Add(this.btn_giris);
            this.Controls.Add(this.txt_Sifre);
            this.Controls.Add(this.lbl_sifre);
            this.Controls.Add(this.txt_kAdi);
            this.Controls.Add(this.lbl_kAdi);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_kAdi;
        private System.Windows.Forms.TextBox txt_kAdi;
        private System.Windows.Forms.TextBox txt_Sifre;
        private System.Windows.Forms.Label lbl_sifre;
        private System.Windows.Forms.Button btn_giris;
        private System.Windows.Forms.Button btn_kayıt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_kullaniciBilgi;
        private System.Messaging.MessageQueue messageQueue1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_misafirGirisi;
        private System.Windows.Forms.Button btn_cikis;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

