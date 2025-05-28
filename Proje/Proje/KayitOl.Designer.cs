namespace Proje
{
    partial class KayitOl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.btn_misafirgirisi = new System.Windows.Forms.Button();
            this.btn_Kayit = new System.Windows.Forms.Button();
            this.txt_kSifre = new System.Windows.Forms.TextBox();
            this.lbl_kSifre = new System.Windows.Forms.Label();
            this.txt_kAdi = new System.Windows.Forms.TextBox();
            this.lbl_kAdi = new System.Windows.Forms.Label();
            this.txt_Soyad = new System.Windows.Forms.TextBox();
            this.lbl_Soyad = new System.Windows.Forms.Label();
            this.txt_Ad = new System.Windows.Forms.TextBox();
            this.lbl_Ad = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_cikis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.messageQueue1 = new System.Messaging.MessageQueue();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(66, 659);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Kayıt olmadan devam et";
            // 
            // btn_misafirgirisi
            // 
            this.btn_misafirgirisi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.btn_misafirgirisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_misafirgirisi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_misafirgirisi.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_misafirgirisi.Location = new System.Drawing.Point(251, 651);
            this.btn_misafirgirisi.Name = "btn_misafirgirisi";
            this.btn_misafirgirisi.Size = new System.Drawing.Size(141, 33);
            this.btn_misafirgirisi.TabIndex = 36;
            this.btn_misafirgirisi.Text = "Misafir Girişi";
            this.btn_misafirgirisi.UseVisualStyleBackColor = false;
            this.btn_misafirgirisi.Click += new System.EventHandler(this.btn_misafirgirisi_Click);
            // 
            // btn_Kayit
            // 
            this.btn_Kayit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btn_Kayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Kayit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Kayit.ForeColor = System.Drawing.Color.LavenderBlush;
            this.btn_Kayit.Location = new System.Drawing.Point(157, 593);
            this.btn_Kayit.Name = "btn_Kayit";
            this.btn_Kayit.Size = new System.Drawing.Size(112, 38);
            this.btn_Kayit.TabIndex = 35;
            this.btn_Kayit.Text = "Kayıt Ol";
            this.btn_Kayit.UseVisualStyleBackColor = false;
            this.btn_Kayit.Click += new System.EventHandler(this.btn_Kayit_Click);
            // 
            // txt_kSifre
            // 
            this.txt_kSifre.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_kSifre.Location = new System.Drawing.Point(81, 550);
            this.txt_kSifre.Name = "txt_kSifre";
            this.txt_kSifre.Size = new System.Drawing.Size(282, 31);
            this.txt_kSifre.TabIndex = 34;
            this.txt_kSifre.UseSystemPasswordChar = true;
            // 
            // lbl_kSifre
            // 
            this.lbl_kSifre.AutoSize = true;
            this.lbl_kSifre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kSifre.Location = new System.Drawing.Point(77, 511);
            this.lbl_kSifre.Name = "lbl_kSifre";
            this.lbl_kSifre.Size = new System.Drawing.Size(51, 28);
            this.lbl_kSifre.TabIndex = 33;
            this.lbl_kSifre.Text = "Şifre";
            // 
            // txt_kAdi
            // 
            this.txt_kAdi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_kAdi.Location = new System.Drawing.Point(81, 471);
            this.txt_kAdi.Name = "txt_kAdi";
            this.txt_kAdi.Size = new System.Drawing.Size(282, 31);
            this.txt_kAdi.TabIndex = 32;
            // 
            // lbl_kAdi
            // 
            this.lbl_kAdi.AutoSize = true;
            this.lbl_kAdi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kAdi.Location = new System.Drawing.Point(77, 439);
            this.lbl_kAdi.Name = "lbl_kAdi";
            this.lbl_kAdi.Size = new System.Drawing.Size(120, 28);
            this.lbl_kAdi.TabIndex = 31;
            this.lbl_kAdi.Text = "Kullanıcı Adı";
            // 
            // txt_Soyad
            // 
            this.txt_Soyad.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Soyad.Location = new System.Drawing.Point(81, 393);
            this.txt_Soyad.Name = "txt_Soyad";
            this.txt_Soyad.Size = new System.Drawing.Size(282, 31);
            this.txt_Soyad.TabIndex = 30;
            // 
            // lbl_Soyad
            // 
            this.lbl_Soyad.AutoSize = true;
            this.lbl_Soyad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Soyad.Location = new System.Drawing.Point(77, 357);
            this.lbl_Soyad.Name = "lbl_Soyad";
            this.lbl_Soyad.Size = new System.Drawing.Size(67, 28);
            this.lbl_Soyad.TabIndex = 29;
            this.lbl_Soyad.Text = "Soyad";
            // 
            // txt_Ad
            // 
            this.txt_Ad.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Ad.Location = new System.Drawing.Point(81, 314);
            this.txt_Ad.Name = "txt_Ad";
            this.txt_Ad.Size = new System.Drawing.Size(282, 31);
            this.txt_Ad.TabIndex = 28;
            // 
            // lbl_Ad
            // 
            this.lbl_Ad.AutoSize = true;
            this.lbl_Ad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Ad.Location = new System.Drawing.Point(77, 280);
            this.lbl_Ad.Name = "lbl_Ad";
            this.lbl_Ad.Size = new System.Drawing.Size(37, 28);
            this.lbl_Ad.TabIndex = 27;
            this.lbl_Ad.Text = "Ad";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_cikis);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 223);
            this.panel1.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(157, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 157);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // btn_cikis
            // 
            this.btn_cikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btn_cikis.FlatAppearance.BorderSize = 0;
            this.btn_cikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cikis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_cikis.ForeColor = System.Drawing.Color.LavenderBlush;
            this.btn_cikis.Location = new System.Drawing.Point(415, 3);
            this.btn_cikis.Name = "btn_cikis";
            this.btn_cikis.Size = new System.Drawing.Size(73, 38);
            this.btn_cikis.TabIndex = 42;
            this.btn_cikis.Text = "Çıkış";
            this.btn_cikis.UseVisualStyleBackColor = false;
            this.btn_cikis.Click += new System.EventHandler(this.btn_cikis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Kullanıcı bilgilerinizi giriniz.";
            // 
            // messageQueue1
            // 
            this.messageQueue1.DefaultPropertiesToSend.HashAlgorithm = System.Messaging.HashAlgorithm.Sha512;
            this.messageQueue1.MessageReadPropertyFilter.LookupId = true;
            this.messageQueue1.SynchronizingObject = this;
            // 
            // KayitOl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(500, 700);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_misafirgirisi);
            this.Controls.Add(this.btn_Kayit);
            this.Controls.Add(this.txt_kSifre);
            this.Controls.Add(this.lbl_kSifre);
            this.Controls.Add(this.txt_kAdi);
            this.Controls.Add(this.lbl_kAdi);
            this.Controls.Add(this.txt_Soyad);
            this.Controls.Add(this.lbl_Soyad);
            this.Controls.Add(this.txt_Ad);
            this.Controls.Add(this.lbl_Ad);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KayitOl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KayitOl";
            this.Load += new System.EventHandler(this.KayitOl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_misafirgirisi;
        private System.Windows.Forms.Button btn_Kayit;
        private System.Windows.Forms.TextBox txt_kSifre;
        private System.Windows.Forms.Label lbl_kSifre;
        private System.Windows.Forms.TextBox txt_kAdi;
        private System.Windows.Forms.Label lbl_kAdi;
        private System.Windows.Forms.TextBox txt_Soyad;
        private System.Windows.Forms.Label lbl_Soyad;
        private System.Windows.Forms.TextBox txt_Ad;
        private System.Windows.Forms.Label lbl_Ad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_cikis;
        private System.Windows.Forms.Label label1;
        private System.Messaging.MessageQueue messageQueue1;
    }
}