using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OtelOtomasyonProgrami
{
    public partial class frmGuncelle : Form
    {
        public frmMusteriler Musteriler;
        public frmMusteriIslemleri MusteriIslemleri;
        public frmMenu frm1;
        public frmGuncelle()
        {
            InitializeComponent();
            MusteriIslemleri = new frmMusteriIslemleri();
            MusteriIslemleri.guncelle = this;
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\vt.mdb");
        OleDbCommand kmt = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet dtst = new DataSet();

        void MusteriBilgileriListesiGuncelle()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "UPDATE MusteriBilgileriListesi SET TC='" + txtTcKimlikNo.Text + "',Ad='" + txtAd.Text + "',Soyad='" + txtSoyad.Text + "',BabaAdi='" + txtBabaAdi.Text + "',AnneAdi='" + txtAnneAdi.Text + "',DogumTarihi='" + datetimeDogumTarihi.Text + "',DogumYeri='" + txtDogumYeri.Text + "',Cinsiyet='" + comboCinsiyet.Text + "',MedeniHali='" + comboMedeniHal.Text + "',KanGrubu='" + comboKanGrubu.Text + "',CepTel='" + txtCepTel.Text + "',EvTel='" + txtEvTel.Text + "',IsTel='" + txtIsTel.Text + "',Fax='" + txtFax.Text + "',EMail='" + txtEmail.Text + "',Meslek='" + txtMeslek.Text + "',EvAdresi='" + txtEvAdresi.Text + "',IsAdresi='" + txtIsAdresi.Text + "' WHERE MusteriNo ='" + textBox2.Text + "'";
            kmt.ExecuteNonQuery();
            kmt.Dispose();
            bag.Close();
            MusteriIslemleri.MusteriBilgileriTablosunuListele();

        }
        public void MusterileriListele()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select TC,Ad,Soyad,CepTel,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,MedeniHali,KanGrubu,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,MusteriNo,RezarvasyonMu from MusteriBilgileri WHERE BaslangicRezarvasyonTarihi='" + datetimeBaslangicRezarvasyonTarihi.Text + "' and OdaNumarasi='" + txtOdaNumarasi.Text + "' ", bag);
            adptr.Fill(dt);
            Musteriler.dataGridView2.DataSource = dt;
        }
        public void OdaDurumlariListele()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select *  from OdaDurumlari WHERE GirisTarihi='" + datetimeBaslangicRezarvasyonTarihi.Text + "' and OdaIsmii='" + txtOdaNumarasi.Text + "'and TC='" + txtTcKimlikNo.Text + "' ", bag);
            adptr.Fill(dt);
        }
        public void Temizle()
        {
            txtTcKimlikNo.Text = "";
            txtAd.Text = "";
            txtAnneAdi.Text = "";
            txtSoyad.Text = "";
            txtBabaAdi.Text = "";
            txtAnneAdi.Text = "";
            datetimeDogumTarihi.Text = "";
            txtDogumYeri.Text = "";
            comboCinsiyet.Text = "";
            comboKanGrubu.Text = "";
            comboMedeniHal.Text = "";
            txtCepTel.Text = "";
            txtEvTel.Text = "";
            txtIsTel.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtMeslek.Text = "";
            txtEvAdresi.Text = "";
            txtIsAdresi.Text = "";
            //datetimeBaslangicRezarvasyonTarihi.Text = "";
            //datetimeBitisRezarvasyonTarihi.Text = "";
            comboOdemeTuru.Text = "";
            txtUcret.Text = "";

        }
        void btnMusteriGuncelle()
        {
            try
            {
                if (txtTcKimlikNo.Text != "" && txtAd.Text != "" && txtSoyad.Text != "")
                {
                    DialogResult sonuc;
                    sonuc = MessageBox.Show("BİLGİLER DEĞİŞTİRİLECEK EMİN MİSİNİZ ? ", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (sonuc == DialogResult.Yes)
                    {
                        //Kayıt Güncelleme
                        string Sorgu =
                            
                       "UPDATE MusteriBilgileri SET TC=@TC,Ad=@Ad, Soyad=@Soyad, BabaAdi=@BabaAdi,AnneAdi=@AnneAdi,DogumTarihi=@DogumTarihi,DogumYeri=@DogumYeri,Cinsiyet=@Cinsiyet,MedeniHali=@MedeniHali,KanGrubu=@KanGrubu,  CepTel=@CepTel,EvTel=@EvTel,IsTel=@IsTel,Fax=@Fax,EMail=@EMail,  Meslek=@MEslek,EvAdresi=@EvAdresi,IsAdresi=@IsAdresi,OdaNumarasi=@OdaNumarasi,BaslangicRezarvasyonTarihi=@BaslangicRezarvasyonTarihi,   BitisRezarvasyonTarihi=@BitisRezarvasyonTarihi,OdemeTuru=@OdemeTuru,Ucret=@Ucret  WHERE MusteriNo=@MusteriNo";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, bag);

                        Komut.Parameters.AddWithValue("@TC", txtTcKimlikNo.Text);
                        Komut.Parameters.AddWithValue("@Ad", txtAd.Text);
                        Komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                        Komut.Parameters.AddWithValue("@BabaAdi", txtBabaAdi.Text);
                        Komut.Parameters.AddWithValue("@AnneAdi", txtAnneAdi.Text);

                        Komut.Parameters.AddWithValue("@DogumTarihi", datetimeDogumTarihi.Text);
                        Komut.Parameters.AddWithValue("@DogumYeri", txtDogumYeri.Text);
                        Komut.Parameters.AddWithValue("@Cinsiyet", comboCinsiyet.Text);
                        Komut.Parameters.AddWithValue("@MedeniHali", comboMedeniHal.Text);
                        Komut.Parameters.AddWithValue("@KanGrubu", comboKanGrubu.Text);

                        Komut.Parameters.AddWithValue("@CepTel", txtCepTel.Text);
                        Komut.Parameters.AddWithValue("@EvTel", txtEvTel.Text);
                        Komut.Parameters.AddWithValue("@IsTel", txtIsTel.Text);
                        Komut.Parameters.AddWithValue("@Fax", txtFax.Text);
                        Komut.Parameters.AddWithValue("@EMail", txtEmail.Text);

                        Komut.Parameters.AddWithValue("@Meslek", txtMeslek.Text);
                        Komut.Parameters.AddWithValue("@EvAdresi", txtEvAdresi.Text);
                        Komut.Parameters.AddWithValue("@IsAdresi", txtIsAdresi.Text);
                        Komut.Parameters.AddWithValue("@OdaNumarasi", txtOdaNumarasi.Text);
                        Komut.Parameters.AddWithValue("@BaslangicRezarvasyonTarihi", datetimeBaslangicRezarvasyonTarihi.Text);

                        Komut.Parameters.AddWithValue("@BitisRezarvasyonTarihi", datetimeBitisRezarvasyonTarihi.Text);
                        Komut.Parameters.AddWithValue("@OdemeTuru", comboOdemeTuru.Text);
                        Komut.Parameters.AddWithValue("@Ucret", txtUcret.Text);

                        

                        Komut.Parameters.AddWithValue("@MusteriNo", textBox2.Text);// referans sahası


                        //Komut nesnesi ve parametreleri hazırlandı
                        bag.Open();
                        Komut.ExecuteNonQuery();
                        bag.Close();
                        MusterileriListele();
                        OdaDurumlariTablosuGuncelle();
                        //Temizle();
                        MessageBox.Show("GÜNCELLEME İŞLEMİ TAMAMLANDI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("ZORUNLU ALANLAR BOŞ GEÇİLEMEZ ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void OdaDurumlariTablosuGuncelle()
        {
                if (txtTcKimlikNo.Text != "" && txtAd.Text != "" && txtSoyad.Text != "")
                {
                        //Kayıt Güncelleme
                        string Sorgu =

                       "UPDATE OdaDurumlari SET OdaIsmi=@OdaIsmi, Adi=@Adi, Soyadi=@Soyadi,GirisTarihi=@GirisTarihi,CikisTarihi=@CikisTarihi WHERE TC=@TC and OdaIsmi=@OdaIsmi and GirisTarihi=@GirisTarihi";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, bag);
                        
                        Komut.Parameters.AddWithValue("@OdaIsmi", txtOdaNumarasi.Text); //1
                        Komut.Parameters.AddWithValue("@Adi", txtAd.Text); //2
                        Komut.Parameters.AddWithValue("@Soyadi", txtSoyad.Text); //3
                        Komut.Parameters.AddWithValue("@GirisTarihi", datetimeBaslangicRezarvasyonTarihi.Text); //4
                        Komut.Parameters.AddWithValue("@CikisTarihi", datetimeBitisRezarvasyonTarihi.Text); //5

                        Komut.Parameters.AddWithValue("@TC", txtTcKimlikNo.Text);// referans sahası

                        //Komut nesnesi ve parametreleri hazırlandı
                        bag.Open();
                        Komut.ExecuteNonQuery();
                        bag.Close();
                        //OdaDurumlariListele();
                }
        }
        void btnMusteriGuncelleFrmMenu1()
        {
            try
            {
                if (txtTcKimlikNo.Text != "" && txtAd.Text != "" && txtSoyad.Text != "")
                {
                    DialogResult sonuc;
                    sonuc = MessageBox.Show("BİLGİLER DEĞİŞTİRİLECEK EMİN MİSİNİZ ? ", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (sonuc == DialogResult.Yes)
                    {
                        //Kayıt Güncelleme
                        string Sorgu =
                      "UPDATE MusteriBilgileriListesi SET TC=@TC,Ad=@Ad, Soyad=@Soyad, BabaAdi=@BabaAdi,AnneAdi=@AnneAdi,DogumTarihi=@DogumTarihi,DogumYeri=@DogumYeri,Cinsiyet=@Cinsiyet,MedeniHali=@MedeniHali,KanGrubu=@KanGrubu,  CepTel=@CepTel,EvTel=@EvTel,IsTel=@IsTel,Fax=@Fax,EMail=@EMail,  Meslek=@MEslek,EvAdresi=@EvAdresi,IsAdresi=@IsAdresi WHERE MusteriNo=@MusteriNo";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, bag);

                        Komut.Parameters.AddWithValue("@TC", txtTcKimlikNo.Text);
                        Komut.Parameters.AddWithValue("@Ad", txtAd.Text);
                        Komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
                        Komut.Parameters.AddWithValue("@BabaAdi", txtBabaAdi.Text);
                        Komut.Parameters.AddWithValue("@AnneAdi", txtAnneAdi.Text);

                        Komut.Parameters.AddWithValue("@DogumTarihi", datetimeDogumTarihi.Text);
                        Komut.Parameters.AddWithValue("@DogumYeri", txtDogumYeri.Text);
                        Komut.Parameters.AddWithValue("@Cinsiyet", comboCinsiyet.Text);
                        Komut.Parameters.AddWithValue("@MedeniHali", comboMedeniHal.Text);
                        Komut.Parameters.AddWithValue("@KanGrubu", comboKanGrubu.Text);

                        Komut.Parameters.AddWithValue("@CepTel", txtCepTel.Text);
                        Komut.Parameters.AddWithValue("@EvTel", txtEvTel.Text);
                        Komut.Parameters.AddWithValue("@IsTel", txtIsTel.Text);
                        Komut.Parameters.AddWithValue("@Fax", txtFax.Text);
                        Komut.Parameters.AddWithValue("@EMail", txtEmail.Text);

                        Komut.Parameters.AddWithValue("@Meslek", txtMeslek.Text);
                        Komut.Parameters.AddWithValue("@EvAdresi", txtEvAdresi.Text);
                        Komut.Parameters.AddWithValue("@IsAdresi", txtIsAdresi.Text);

                        Komut.Parameters.AddWithValue("@MusteriNo", textBox3.Text);// referans sahası


                        //Komut nesnesi ve parametreleri hazırlandı
                        bag.Open();
                        Komut.ExecuteNonQuery();
                        bag.Close();
                        frm1.MusteriBilgileriTablosunuListele();
                        //Temizle();
                        MessageBox.Show("GÜNCELLEME İŞLEMİ TAMAMLANDI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("ZORUNLU ALANLAR BOŞ GEÇİLEMEZ ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void MusteriGuncelle_Click(object sender, EventArgs e)
        {
            btnMusteriGuncelle(); 
            //OdaDurumlariTablosuGuncelle();
        }

        private void GuncelleCikis_Click(object sender, EventArgs e)
        {
             Temizle(); this.Close();
        }

        private void Guncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Temizle();
        }
        private void txtTcKimlikNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtAd.Focus(); }
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtSoyad.Focus(); }
        }

        private void Kaydet_Load(object sender, EventArgs e)
        {
            txtTcKimlikNo.Focus();
        }

        private void txtBabaAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtAnneAdi.Focus(); }
        }

        private void txtAnneAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { datetimeDogumTarihi.Focus(); }
        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtBabaAdi.Focus(); }
        }

        private void datetimeDogumTarihi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtDogumYeri.Focus(); }
        }

        private void txtDogumYeri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { comboCinsiyet.Focus(); }
        }

        private void comboCinsiyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { comboMedeniHal.Focus(); }
        }

        private void comboMedeniHal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { comboKanGrubu.Focus(); }
        }

        private void comboKanGrubu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtCepTel.Focus(); }
        }

        private void txtCepTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtEvTel.Focus(); }
        }

        private void txtEvTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtIsTel.Focus(); }
        }

        private void txtIsTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtFax.Focus(); }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtEmail.Focus(); }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtMeslek.Focus(); }
        }

        private void txtMeslek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtEvAdresi.Focus(); }
        }

        private void txtEvAdresi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtIsAdresi.Focus(); }
        }

        private void txtIsAdresi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { datetimeBitisRezarvasyonTarihi.Focus(); }
        }

        private void datetimeBitisRezarvasyonTarihi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { comboOdemeTuru.Focus(); }
        }

        private void txtUcret_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { MusteriGuncelle.Focus(); }
        }

        private void comboOdemeTuru_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtUcret.Focus(); }
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            MusteriIslemleri.KaydetmiGuncellemi = "0"; MusteriIslemleri.ShowDialog();
        }

        private void frmGuncelle_Load(object sender, EventArgs e)
        {

        }

        private void btnMusteriGuncelleFrmMenu_Click(object sender, EventArgs e)
        {
            btnMusteriGuncelleFrmMenu1();
        }

        private void frmGuncelle_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
            if (MusteriGuncelle.Visible==true)
            {
                switch (e.KeyData)
                {
                    case Keys.F2:
                        btnMusteriGuncelle();
                        break;
                    default:
                        break;
                }
             }
            else if (btnMusteriGuncelleFrmMenu.Visible == true)
            {
                switch (e.KeyData)
                {
                    case Keys.F2:
                        btnMusteriGuncelleFrmMenu1();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
