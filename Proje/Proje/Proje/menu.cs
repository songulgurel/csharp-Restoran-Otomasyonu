using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Proje
{
    
    public partial class menu : Form
    {
        private string kAdi;
       
        string baglantiString = "Server=DESKTOP-ETH28ML;Database=proje;Integrated Security=True;";
        private decimal toplamTutar = 0;
        public static Dictionary<string, int> secilenUrunler = new Dictionary<string, int>();
        public menu(string kullaniciAdi)
        {
            InitializeComponent();
            kAdi = kullaniciAdi;

        }

        private void menu_Load(object sender, EventArgs e)
        {
            yiyecekleriYukle();
            butonlariBagla();
        }

        private void butonlariBagla()
        {
            var buttonsAndNumericUpDowns = new (Button btnArtir, Button btnAzalt, NumericUpDown numUpDown)[]
            {
             (btn_arttır, btn_azalt, numericUpDown), (btn_arttır1, btn_azalt1, numericUpDown1),(btn_arttır2, btn_azalt2, numericUpDown2),
             (btn_arttır3, btn_azalt3, numericUpDown3), (btn_arttır4, btn_azalt4, numericUpDown4),(btn_arttır5, btn_azalt5, numericUpDown5),
             (btn_arttır6, btn_azalt6, numericUpDown6),(btn_arttır7, btn_azalt7, numericUpDown7),(btn_arttır8, btn_azalt8, numericUpDown8),
             (btn_arttır9, btn_azalt9, numericUpDown9),(btn_arttır10, btn_azalt10, numericUpDown10),(btn_arttır11, btn_azalt11, numericUpDown11),
             (btn_arttır12, btn_azalt12, numericUpDown12), (btn_arttır13, btn_azalt13, numericUpDown13),
             (btn_arttır14, btn_azalt14, numericUpDown14), (btn_arttır15, btn_azalt15, numericUpDown15),

             (btn_arttır16, btn_azalt16, numericUpDown16),(btn_arttır17, btn_azalt17, numericUpDown17), (btn_arttır18, btn_azalt18, numericUpDown18),
             (btn_arttır19, btn_azalt19, numericUpDown19), (btn_arttır20, btn_azalt20, numericUpDown20), (btn_arttır21, btn_azalt21, numericUpDown21),
             (btn_arttır22, btn_azalt22, numericUpDown22), (btn_arttır23, btn_azalt23, numericUpDown23), (btn_arttır24, btn_azalt24, numericUpDown24),
             (btn_arttır25, btn_azalt15, numericUpDown25), (btn_arttır26, btn_azalt26, numericUpDown26),(btn_arttır27, btn_azalt27, numericUpDown27),
             (btn_arttır28, btn_azalt28, numericUpDown28), (btn_arttır29, btn_azalt29, numericUpDown29),
             (btn_arttır30, btn_azalt30, numericUpDown30),(btn_arttır31, btn_azalt31, numericUpDown31),

             (btn_arttır32, btn_azalt32, numericUpDown32),(btn_arttır33, btn_azalt33, numericUpDown33),(btn_arttır34, btn_azalt34, numericUpDown34),
             (btn_arttır35, btn_azalt35, numericUpDown35), (btn_arttır36, btn_azalt36, numericUpDown36),(btn_arttır37, btn_azalt37, numericUpDown37),
             (btn_arttır38, btn_azalt38, numericUpDown38), (btn_arttır39, btn_azalt39, numericUpDown39),(btn_arttır40, btn_azalt40, numericUpDown40),
             (btn_arttır41, btn_azalt41, numericUpDown41), (btn_arttır42, btn_azalt42, numericUpDown42), (btn_arttır43, btn_azalt43, numericUpDown43),
             (btn_arttır44, btn_azalt44, numericUpDown44), (btn_arttır45, btn_azalt45, numericUpDown45),
             (btn_arttır46, btn_azalt46, numericUpDown46),(btn_arttır47, btn_azalt47, numericUpDown47),

             (btn_arttır48, btn_azalt48, numericUpDown48), (btn_arttır49, btn_azalt49, numericUpDown49), (btn_arttır50, btn_azalt50, numericUpDown50),
             (btn_arttır51, btn_azalt51, numericUpDown51), (btn_arttır52, btn_azalt52, numericUpDown52), (btn_arttır53, btn_azalt53, numericUpDown53),
             (btn_arttır54, btn_azalt54, numericUpDown54),(btn_arttır55, btn_azalt55, numericUpDown55),(btn_arttır56, btn_azalt56, numericUpDown56),
             (btn_arttır57, btn_azalt57, numericUpDown57),(btn_arttır58, btn_azalt58, numericUpDown58), (btn_arttır59, btn_azalt59, numericUpDown59),
             (btn_arttır60, btn_azalt60, numericUpDown60),(btn_arttır61, btn_azalt61, numericUpDown61),
             (btn_arttır62, btn_azalt62, numericUpDown62),(btn_arttır63, btn_azalt63, numericUpDown63),
            };

            foreach (var (btnArtir, btnAzalt, numUpDown) in buttonsAndNumericUpDowns)
            {
                btnArtir.Tag = numUpDown;
                btnAzalt.Tag = numUpDown;

                btnArtir.Click += btnArtirAzalt_Click;
                btnAzalt.Click += btnArtirAzalt_Click;
            }
        }
        private void btnArtirAzalt_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is NumericUpDown)
            {
                NumericUpDown numUpDown = (NumericUpDown)btn.Tag;

                if (btn.Text == "+" && numUpDown.Value < numUpDown.Maximum)
                {
                    numUpDown.Value += 1;
                }
                else if (btn.Text == "-" && numUpDown.Value > numUpDown.Minimum)
                {
                    numUpDown.Value -= 1;
                }
            }
        }
        private void yiyecekleriYukle()
        {
            string sorgu = "SELECT YiyecekAdı, Resim, Fiyat FROM Yemekler";

            using (SqlConnection baglanti = new SqlConnection(baglantiString))
            using (SqlCommand cmd = new SqlCommand(sorgu, baglanti))
            {
                try
                {
                    baglanti.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<string, (Label, PictureBox, TextBox)> yemekler = new()
                        {
                            //Kahvaltılar
                            { "Kahvaltı Tabağı", (lbl_kahvaltitabagi, re_KahvaltiT, txt_kT) },{ "Serpme Kahvaltı", (lbl_serpme, re_SerpmeKahvalti, txt_sK) },
                            { "Sahanda Yumurta", (lbl_sahanda, re_SahandaY, txt_sY) },{ "Sucuklu Yumurta", (lbl_sucuklu, reSucukluY, txt_sucY) },
                            { "Pankek Tabağı", (lbl_pankek, re_PankekT, txt_Pankek) },{ "Pişi Tabağı", (lbl_pisi, re_PisiT, txt_pisi) },
                            { "Menemen", (lbl_menemen, re_Menemen, txt_Menemen) }, { "Omlet", (lbl_omlet, re_Omlet, txt_Omlet) },
                            //Çorbalar
                            { "Mercimek Çorbası", (lbl_mercimek, re_MercimekC, txt_mercimek) }, { "Domates Çorbası", (lbl_domates, re_DomatesC, txt_domates) },
                            { "Tavuk Suyu Çorbası", (lbl_tavuk, re_TavukSuyuC, txt_tavuk) }, { "Kelle Paça Çorbası", (lbl_kelle, re_KellePacaC, txt_kelle) },
                            { "Beyran", (lbl_beyran, re_Beyran, txt_beyran) }, { "Mantar Çorbası", (lbl_mantar, re_MantarC, txt_mantar) },
                            { "Yayla Çorbası", (lbl_yayla, re_YaylaC, txt_yayla) },{ "İşkembe Çorbası", (lbl_iskembe, re_Iskembe, txt_iskembe) },
                             //Ara Sıcak
                            { "Kuru Patlıcan Dolması", (lbl_patlicanDolmasi, re_PatlicanD,txt_patlicanD) }, { "Kızartma İçli Köfte", (lbl_kIcliKofte, re_KızartmaİcliK,txt_kİcliKofte) },
                            { "Haşlama İçli Köfte", (lbl_hIcliKofte, re_HaslamaIcliK,txt_hİcliKofte) },{ "Patates Köftesi", (lbl_patatesK, re_PatatesK,txt_patatesK) },
                            { "Mücver", (lbl_mucver, re_Mucver,txt_mucver) },{ "Sigara Böreği", (lbl_sigaraB, re_SigaraB,txt_sigaraB) },
                            { "Paçanga Böreği", (lbl_pacangaB, re_PacangaB,txt_pacangaB) },{ "Fındık Lahmacun", (lbl_findikL, re_FindikLahmacun,txt_findikL) },
                            //Mezeler
                            { "Acılı Ezme", (lbl_aE, re_AciliEzme,txt_aE) }, { "Cacık", (lbl_c, re_Cacik,txt_c) },
                            { "Girit Ezmesi", (lbl_gE, re_GiritEzmesi,txt_gE) }, { "Humus", (lbl_hu, re_Humus,txt_hu) },
                            { "Haydari", (lbl_ha, re_Haydari,txt_ha) },{ "Zeytin Piyazı", (lbl_zP, re_ZeytinPiyazi,txt_zP) },
                            { "Patlıcan Salatası", (lbl_pS, re_PatlicanSalatasi,txt_pS) }, { "Çiğ Köfte", (lbl_cK, re_CigKofte,txt_cK) },
                            //Salatalar
                            { "Mevsim Salata", (lbl_m, re_MevsimS,txt_m) }, { "Nurdağı Salata", (lbl_n, re_NurdagiS,txt_n) },
                            { "Çoban Salata", (lbl_co, re_CobanS,txt_co) }, { "Yeşil Salata", (lbl_y, re_YesilS,txt_y) },
                            { "Gavurdağı Salata", (lbl_g, re_GavurdagS,txt_g) },{ "Kaşık Salata", (lbl_k, re_KasikS,txt_k) },
                            { "Sezar Salata", (lbl_s, re_SezarS,txt_s) },{ "Rus Salatası", (lbl_r, re_RusS,txt_r) },
                            //Kebaplar
                            { "Adana Kebap", (lbl_aK, re_AdanaKebap, txt_aK) }, { "Urfa Kebap", (lbl_uK, re_UrfaKebap, txt_uK) },
                            { "Kuzu Şiş", (lbl_kS, re_KuzuSis, txt_kS) }, { "Çöp Şiş", (lbl_cS, re_CopSis, txt_cS) },
                            { "Patlıcan Kebabı", (lbl_pK, re_PatlicanKebabi, txt_pK) }, { "Tavuk Şiş", (lbl_tS, re_TavukSis, txt_tS) },
                            { "Tavuk Kanat", (lbl_tK, re_TavukKanat, txt_tK) },{ "Sac Tava", (lbl_sT, re_SacTava, txt_sT) },
                            //Tatlılar
                            { "Sıcak Burma Kadayıf", (lbl_bK, re_burmaKadayıf, txt_bK) },{ "Gaziantep Katmeri", (lbl_Ka, re_Katmer, txt_Ka) },
                            { "Fıstıklı Baklava", (lbl_fB, re_FistikliBaklava, txt_fB) }, { "Cevizli Baklava", (lbl_cB, re_CevizliBaklava, txt_cB) },
                            { "Dondurmalı Havuç Dilimi", (lbl_hD, re_HavucDilimi, txt_hD) },{ "Sütlaç", (lbl_Su, re_sutlac, txt_Su) },
                            { "Künefe", (lbl_ku, re_kunefe, txt_ku) },{ "Şöbiyet", (lbl_so, re_sobiyet, txt_so) },
                            //İçecekler
                            { "Ayran", (lbl_ayran, re_ayran, txt_ayran) },{ "Çay", (lbl_cay, re_cay, txt_cay) },
                            { "Kola", (lbl_kola, re_kola, txt_kola) }, { "Gazoz", (lbl_gazoz, re_gazoz, txt_gazoz) },
                            { "Soda", (lbl_soda, re_soda, txt_soda) },{ "Limonata", (lbl_lim, re_limonata, txt_lim) },
                            { "Şalgam", (lbl_salgam, re_salgam, txt_salgam) }, { "Meyve Suyu", (lbl_meyveS, re_meyveSuyu, txt_meyveS) }
                        };

                        foreach (var pb in yemekler.Values)
                        {
                            pb.Item2.SizeMode = PictureBoxSizeMode.StretchImage;
                        }

                        while (reader.Read())
                        {
                            string yemekAdi = reader["YiyecekAdı"].ToString();
                            if (yemekler.ContainsKey(yemekAdi))
                            {
                                var (label, pictureBox, textbox) = yemekler[yemekAdi];

                                label.Text = yemekAdi;

                                pictureBox.Image = reader["Resim"] is byte[] resimBytes && resimBytes.Length > 0
                                    ? Image.FromStream(new MemoryStream(resimBytes))
                                    : null;

                                decimal fiyat = Convert.ToDecimal(reader["Fiyat"]);
                                textbox.Text = fiyat.ToString("C2"); 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }     

        private void btn_kapat_Click(object sender, EventArgs e) => Application.Exit();
        private void btn_buyut_Click(object sender, EventArgs e) => WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        private void SepeteEkle(string urunAdi, NumericUpDown numericUpDown)
        {
            int adet = (int)numericUpDown.Value;
            decimal fiyat = 0;

            if (adet <= 0)
            {
                MessageBox.Show("Lütfen en az 1 adet seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(baglantiString))
                {
                    con.Open();
                    string fiyatQuery = "SELECT Fiyat FROM Yemekler WHERE YiyecekAdı = @urun";
                    using (SqlCommand cmd = new SqlCommand(fiyatQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@urun", urunAdi);
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value || !decimal.TryParse(result.ToString(), out fiyat))
                        {
                            MessageBox.Show($"'{urunAdi}' için fiyat bilgisi bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 🔒 Adet sıfır değil ve fiyat bulunduysa ekle:
                    if (secilenUrunler.ContainsKey(urunAdi))
                        secilenUrunler[urunAdi] += adet;
                    else
                        secilenUrunler.Add(urunAdi, adet);

                    toplamTutar += fiyat * adet;

                    // ✅ Sadece gerçekten eklenirse mesaj göster:
                    MessageBox.Show($"{adet} adet {urunAdi} sepete eklendi!\nToplam Tutar: {toplamTutar:F2}₺",
                                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Veritabanı hatası: " + sqlEx.Message, "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void sepet_kahvaltiTabagi_Click(object sender, EventArgs e) => SepeteEkle("Kahvaltı Tabağı", numericUpDown);
        private void sepet_serpmeKahvalti_Click(object sender, EventArgs e) => SepeteEkle("Serpme Kahvaltı", numericUpDown1);
        private void sepet_sahandaYumurta_Click(object sender, EventArgs e) => SepeteEkle("Sahanda Yumurta", numericUpDown2);
        private void sepet_sucukluYumurta_Click(object sender, EventArgs e) => SepeteEkle("Sucuklu Yumurta", numericUpDown3);
        private void sepet_pankekTabagı_Click(object sender, EventArgs e) => SepeteEkle("Pankek Tabağı", numericUpDown4);
        private void sepet_pisiTabagı_Click(object sender, EventArgs e) => SepeteEkle("Pişi Tabağı", numericUpDown5);
        private void sepet_Menemen_Click(object sender, EventArgs e) => SepeteEkle("Menemen", numericUpDown6);
        private void sepet_omlet_Click(object sender, EventArgs e) => SepeteEkle("Omlet", numericUpDown7);

        private void sepet_mercimekC_Click(object sender, EventArgs e) => SepeteEkle("Mercimek Çorbası", numericUpDown8);
        private void sepet_domatesC_Click(object sender, EventArgs e) => SepeteEkle("Domates Çorbası ", numericUpDown9);
        private void sepet_tavukSuC_Click(object sender, EventArgs e) => SepeteEkle("Tavuk Suyu Çorbası", numericUpDown10);
        private void sepet_kellePaC_Click(object sender, EventArgs e) => SepeteEkle("Kelle Paça Çorbası", numericUpDown11);
        private void sepet_byeran_Click(object sender, EventArgs e) => SepeteEkle("Beyran", numericUpDown12);
        private void sepet_mantarC_Click(object sender, EventArgs e) => SepeteEkle("Mantar Çorbası", numericUpDown13);
        private void sepet_yaylaC_Click(object sender, EventArgs e) => SepeteEkle("Yayla Çorbası", numericUpDown14);
        private void sepet_iskembeC_Click(object sender, EventArgs e) => SepeteEkle("İşkembe Çorbası", numericUpDown15);

        private void sepet_patlicanD_Click(object sender, EventArgs e) => SepeteEkle("Kuru Patlıcan Dolması", numericUpDown16);
        private void sepet_kIcliKofte_Click(object sender, EventArgs e) => SepeteEkle("Kızartma İçli Köfte", numericUpDown17);
        private void sepet_hIclİKofte_Click(object sender, EventArgs e) => SepeteEkle("Haşlama İçli Köfte", numericUpDown18);
        private void sepet_patatesK_Click(object sender, EventArgs e) => SepeteEkle("Patates Köftesi", numericUpDown19);
        private void sepet_mucver_Click(object sender, EventArgs e) => SepeteEkle("Mücver", numericUpDown20);
        private void sepet_sigaraB_Click(object sender, EventArgs e) => SepeteEkle("Sigara Böreği", numericUpDown21);
        private void sepet_pacangaB_Click(object sender, EventArgs e) => SepeteEkle("Paçanga Böreği", numericUpDown22);
        private void sepet_findikL_Click(object sender, EventArgs e) => SepeteEkle("Fındık Lahmacun", numericUpDown23);


        private void sepet_aciliE_Click(object sender, EventArgs e) => SepeteEkle("Acılı Ezme", numericUpDown24);
        private void sepet_Cacik_Click(object sender, EventArgs e) => SepeteEkle("Cacık", numericUpDown25);
        private void sepet_giritE_Click(object sender, EventArgs e) => SepeteEkle("Girit Ezmesi", numericUpDown26);
        private void sepet_humus_Click(object sender, EventArgs e) => SepeteEkle("Humus", numericUpDown27);
        private void sepet_haydari_Click(object sender, EventArgs e) => SepeteEkle("Haydari", numericUpDown28);
        private void sepet_zeytinP_Click(object sender, EventArgs e) => SepeteEkle("Zeytin Piyazı", numericUpDown29);
        private void sepet_patatesS_Click(object sender, EventArgs e) => SepeteEkle("Patlıcan Salatası", numericUpDown30);
        private void sepet_cigKofte_Click(object sender, EventArgs e) => SepeteEkle("Çiğ Köfte", numericUpDown31);


        private void sepet_mevsimS_Click(object sender, EventArgs e) => SepeteEkle("Mevsim Salata", numericUpDown32);
        private void sepet_nurdagıS_Click(object sender, EventArgs e) => SepeteEkle("Nurdağı Salata", numericUpDown33);
        private void sepet_cobanS_Click(object sender, EventArgs e) => SepeteEkle("Çoban Salata", numericUpDown34);
        private void sepet_yesilS_Click(object sender, EventArgs e) => SepeteEkle("Yeşil Salata", numericUpDown35);
        private void sepet_gavurdagıS_Click(object sender, EventArgs e) => SepeteEkle("Gavurdağı Salata", numericUpDown36);
        private void sepet_kasıkS_Click(object sender, EventArgs e) => SepeteEkle("Kaşık Salata", numericUpDown37);
        private void sepet_sezarS_Click(object sender, EventArgs e) => SepeteEkle("Sezar Salata", numericUpDown38);
        private void sepet_rusS_Click(object sender, EventArgs e) => SepeteEkle("Rus Salata", numericUpDown39);


        private void sepet_adanaK_Click(object sender, EventArgs e) => SepeteEkle("Adana Kebap", numericUpDown40);
        private void sepet_urfaK_Click(object sender, EventArgs e) => SepeteEkle("Urfa Kebap", numericUpDown41);
        private void sepet_kuzuS_Click(object sender, EventArgs e) => SepeteEkle("Kuzu Şiş", numericUpDown42);
        private void sepet_copS_Click(object sender, EventArgs e) => SepeteEkle("Çöp Şiş", numericUpDown43);
        private void sepet_patlicanK_Click(object sender, EventArgs e) => SepeteEkle("Patlıcan Kebabı", numericUpDown44);
        private void sepet_tavukS_Click(object sender, EventArgs e) => SepeteEkle("Tavuk Şiş", numericUpDown45);
        private void sepet_tavukK_Click(object sender, EventArgs e) => SepeteEkle("Tavuk Kanat", numericUpDown46);
        private void sepet_sacT_Click(object sender, EventArgs e) => SepeteEkle("Sac Tava", numericUpDown47);

        private void sepet_burmaK_Click(object sender, EventArgs e) => SepeteEkle("Sıcak Burma Kadayıf", numericUpDown48);
        private void sepet_katmer_Click(object sender, EventArgs e) => SepeteEkle("Gaziantep Katmeri", numericUpDown49);
        private void sepet_fistikliB_Click(object sender, EventArgs e) => SepeteEkle("Fıstıklı Baklava", numericUpDown50);
        private void sepet_cevizliB_Click(object sender, EventArgs e) => SepeteEkle("Cevizli Baklava", numericUpDown51);
        private void sepet_havucD_Click(object sender, EventArgs e) => SepeteEkle("Dondurmalı Havuç Dilimi", numericUpDown52);
        private void sepet_sutlac_Click(object sender, EventArgs e)=> SepeteEkle("Sütlaç", numericUpDown53);
        private void sepet_kunefe_Click(object sender, EventArgs e) => SepeteEkle("Künefe", numericUpDown54);
        private void sepet_sobiyet_Click(object sender, EventArgs e ) => SepeteEkle("Şöbiyet", numericUpDown55);


        private void sepet_ayran_Click(object sender, EventArgs e) => SepeteEkle("Ayran", numericUpDown56);
        private void sepet_cay_Click(object sender, EventArgs e) => SepeteEkle("Çay", numericUpDown57);
        private void sepet_kola_Click(object sender, EventArgs e) => SepeteEkle("Kola", numericUpDown58);
        private void sepet_gazoz_Click(object sender, EventArgs e) => SepeteEkle("Gazoz", numericUpDown59);
        private void sepet_soda_Click(object sender, EventArgs e) => SepeteEkle("Soda", numericUpDown60);
        private void sepet_limonata_Click(object sender, EventArgs e) => SepeteEkle("Limonata", numericUpDown61);
        private void sepet_salgam_Click(object sender, EventArgs e) => SepeteEkle("Şalgam", numericUpDown62);
        private void sepet_meyveS_Click(object sender, EventArgs e) => SepeteEkle("Meyve Suyu", numericUpDown63);

        private void btn_sepet_Click(object sender, EventArgs e)
        {
            if (secilenUrunler.Count == 0)
            {
                MessageBox.Show("Sepetinizde ürün bulunmamaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool enAzBirEklendi = false;

            try
            {
                using (SqlConnection con = new SqlConnection(baglantiString))
                {
                    con.Open();

                    foreach (var urun in secilenUrunler)
                    {
                        string urunAdi = urun.Key;
                        int adet = urun.Value;

                        if (adet <= 0)
                            continue;

                        string fiyatQuery = "SELECT Fiyat FROM Yemekler WHERE YiyecekAdı = @urunAdi";
                        using (SqlCommand fiyatCmd = new SqlCommand(fiyatQuery, con))
                        {
                            fiyatCmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                            object result = fiyatCmd.ExecuteScalar();

                            if (result == null || !decimal.TryParse(result.ToString(), out decimal birimFiyat))
                            {
                                MessageBox.Show($"{urunAdi} için fiyat bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }

                            decimal toplamFiyat = birimFiyat * adet;

                            string insertQuery = "INSERT INTO Siparisler (kullaniciAdi, urunAdi, Adet, Fiyat, ToplamFiyat, SiparisTarihi) " +
                                                 "VALUES (@kullaniciAdi, @urun, @adet, @fiyat, @toplam, @tarih)";

                            using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                            {
                                cmd.Parameters.AddWithValue("@kullaniciAdi", kAdi);
                                cmd.Parameters.AddWithValue("@urun", urunAdi);
                                cmd.Parameters.AddWithValue("@adet", adet);
                                cmd.Parameters.AddWithValue("@fiyat", birimFiyat);
                                cmd.Parameters.AddWithValue("@toplam", toplamFiyat);
                                cmd.Parameters.AddWithValue("@tarih", DateTime.Now);

                                cmd.ExecuteNonQuery();
                                enAzBirEklendi = true;
                            }
                        }
                    }
                }

                if (enAzBirEklendi)
                {
                    MessageBox.Show("Seçilen ürünler sepete başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    sepet frmsepet = new sepet(kAdi);
                    frmsepet.Show();
                }
                else
                {
                    MessageBox.Show("Geçerli adet girilmediği için ürün eklenemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Veritabanı hatası: " + sqlEx.Message, "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Genel Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_altsekme_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain(kAdi);
            frm.Show();
        }

        private void btn_hakkimizda_Click(object sender, EventArgs e)
        {
            this.Hide();
            hakkimizda frmHakkimizda = new hakkimizda(kAdi);
            frmHakkimizda.Show();
        }

        private void btn_bilgiGuncelle_Click(object sender, EventArgs e)
        {
            if (kAdi.ToLower() == "misafir")
            {
                MessageBox.Show("Lütfen bilgilerinizi görmek/güncellemek için giriş yapınız.");
                this.Hide(); // Ana formu gizle
                Giris frmGiris = new Giris();
                frmGiris.Show();
                return;
            }
            this.Hide();
            bilgiGuncelle bilgiGuncelleform = new bilgiGuncelle(kAdi);
            bilgiGuncelleform.Show();
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

        private void btn_gecmisSiparisler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GecmisSiparisler frm = new GecmisSiparisler(kAdi);
            frm.Show();
        }

        private void btn_gecmisSiparis_Click(object sender, EventArgs e)
        {

        }

        private void btn_menu_Click(object sender, EventArgs e)
        {

        }
    }
}

