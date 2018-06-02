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
    public partial class frmRezarvasyonIslemleri : Form
    {
        public frmMenu frm1;
        public frmRezarvasyonIslemleri()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\vt.mdb");
        OleDbCommand kmt = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        string OdaDurumu = "Rezerve";

        void RezarvasyonKaydetcontexButton()
        {
           /* bu fonksiyon contexMenuden kaydetme işlemi için konulmuştur.*/
            try
            {
                if (txtAd.Text != "" && txtSoyad.Text != "")
                    {
                        if (datetimeBaslangicRezarvasyonTarihi.Value <= datetimeBitisRezarvasyonTarihi.Value)
                        {
                            
                            DialogResult sonuc;
                            sonuc = MessageBox.Show("BİLGİLER KAYIT EDİLECEK EMİN MİSİNİZ ? ", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (sonuc == DialogResult.Yes)
                            {
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + datetimeBaslangicRezarvasyonTarihi.Text + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();
                        

                                /*Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında Kaç Gün Olduğunu Bulur*/
                                DateTime ilkTarih = datetimeBaslangicRezarvasyonTarihi.Value; //1
                                DateTime SonTarih = datetimeBitisRezarvasyonTarihi.Value; //2
                                System.TimeSpan Gun; //3
                                Gun = SonTarih.Subtract(ilkTarih); //4
                                int ToplamGunSayisi = Convert.ToInt32(Gun.TotalDays); //5
                                /*Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında Kaç Gün Olduğunu Bulundu*/

                                if (ToplamGunSayisi == 2) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 2 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                         

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 2 Gün varsa 

                                if (ToplamGunSayisi == 3) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 3 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                         

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                   
                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 3 Gün varsa 

                                if (ToplamGunSayisi == 4) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 4 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    
                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 4 Gün varsa 

                                if (ToplamGunSayisi == 5) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 5 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 5 Gün varsa

                                if (ToplamGunSayisi == 6) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 6 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 6 Gün varsa 

                                if (ToplamGunSayisi == 7) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 7 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 7 Gün varsa 
                                if (ToplamGunSayisi == 8) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 8 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 8 Gün varsa 
                                if (ToplamGunSayisi == 9) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 9 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz7 = "";
                                    DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                }                          // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 9 Gün varsa 
                                if (ToplamGunSayisi == 10) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 10 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz7 = "";
                                    DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz8 = "";
                                    DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 10 Gün varsa 
                                if (ToplamGunSayisi == 11) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 11 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz7 = "";
                                    DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz8 = "";
                                    DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    

                                    //---------------------
                                    string GunYaz9 = "";
                                    DateTime ilkdeger9 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz9 = ilkdeger9.AddDays(10).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO Rezarvasyon(Adi,Soyadi,Aciklama1Bilgiler,Aciklama2Bilgiler,Aciklama3Bilgiler,CepTel,EvTel,IsTel,Fax,EMail,OdaIsmi,RezarvasyonBaslangicTarihi,RezarvasyonBitisTarihi,OdaBilgilerAciklama1,OdaBilgilerAciklama2,OdaBilgilerAciklama3) VALUES ('" + txtAd.Text + "','" + txtSoyad.Text + "','" + txtBilgilerAciklama1.Text + "','" + txtBilgilerAciklama2.Text + "','" + txtBilgilerAciklama3.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz9 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtOdaBilgilerAciklama1.Text + "','" + txtOdaBilgilerAciklama2.Text + "','" + txtOdaBilgilerAciklama3.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    
                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 11 Gün varsa 
                                frm1.DoldurTarih1(frm1.Lblgun1.Text, frm1.Lblgun2.Text, frm1.Lblgun3.Text, frm1.Lblgun4.Text, frm1.Lblgun5.Text, frm1.Lblgun6.Text, frm1.Lblgun7.Text);
                                RezarvasyonKaydetOdaDurumlariContexButton(); // kaydetme işlemi sırasında OdaDurumlari tablosuna kaydetme yapsın 
                                frm1.RezarvasyonTextBoxlariTemizle();
                                MessageBox.Show("KAYIT İŞLEMİ TAMAMLANDI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("REZARVASYON BİTİŞ TARİHİ, REZARVASYON BAŞLANGINÇ TARİHİNDEN BÜYÜK VEYA EŞİT OLMALIDIR ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        void RezarvasyonKaydetOdaDurumlariContexButton()
        {
            /* bu fonksiyon contexMenuden OdaDurumlari tablosuna kaydetme işlemi için konulmuştur.*/
            try
            {
              if (txtAd.Text != "" && txtSoyad.Text != "")
                    {
                        if (datetimeBaslangicRezarvasyonTarihi.Value <= datetimeBitisRezarvasyonTarihi.Value)
                        {
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + datetimeBaslangicRezarvasyonTarihi.Text + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            /*Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında Kaç Gün Olduğunu Bulur*/
                            DateTime ilkTarih = datetimeBaslangicRezarvasyonTarihi.Value; //1
                            DateTime SonTarih = datetimeBitisRezarvasyonTarihi.Value; //2
                            System.TimeSpan Gun; //3
                            Gun = SonTarih.Subtract(ilkTarih); //4
                            int ToplamGunSayisi = Convert.ToInt32(Gun.TotalDays); //5
                            /*Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında Kaç Gün Olduğunu Bulundu*/

                            if (ToplamGunSayisi == 2) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 2 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                            }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 2 Gün varsa 

                            if (ToplamGunSayisi == 3) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 3 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz1 = "";
                                DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();

                            }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 3 Gün varsa 

                            if (ToplamGunSayisi == 4) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 4 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz1 = "";
                                DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz2 = "";
                                DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                            }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 4 Gün varsa 

                            if (ToplamGunSayisi == 5) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 5 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz1 = "";
                                DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz2 = "";
                                DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz3 = "";
                                DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                            }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 5 Gün varsa

                            if (ToplamGunSayisi == 6) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 6 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz1 = "";
                                DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz2 = "";
                                DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz3 = "";
                                DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz4 = "";
                                DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                            }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 6 Gün varsa 

                            if (ToplamGunSayisi == 7) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 7 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz1 = "";
                                DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz2 = "";
                                DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz3 = "";
                                DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz4 = "";
                                DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz5 = "";
                                DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                            }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 7 Gün varsa 
                            if (ToplamGunSayisi == 8) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 8 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz1 = "";
                                DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz2 = "";
                                DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz3 = "";
                                DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz4 = "";
                                DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz5 = "";
                                DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz6 = "";
                                DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                            }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 8 Gün varsa 
                            if (ToplamGunSayisi == 9) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 9 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz1 = "";
                                DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz2 = "";
                                DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz3 = "";
                                DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz4 = "";
                                DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz5 = "";
                                DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz6 = "";
                                DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz7 = "";
                                DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                            }                          // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 9 Gün varsa 
                            if (ToplamGunSayisi == 10) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 10 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz1 = "";
                                DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz2 = "";
                                DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz3 = "";
                                DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz4 = "";
                                DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz5 = "";
                                DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz6 = "";
                                DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz7 = "";
                                DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();

                                //---------------------
                                string GunYaz8 = "";
                                DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                            }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 10 Gün varsa 
                            if (ToplamGunSayisi == 11) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 11 Gün varsa 
                            {
                                string GunYaz = "";
                                DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz1 = "";
                                DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz2 = "";
                                DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz3 = "";
                                DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz4 = "";
                                DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz5 = "";
                                DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz6 = "";
                                DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz7 = "";
                                DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();

                                //---------------------
                                string GunYaz8 = "";
                                DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();


                                //---------------------
                                string GunYaz9 = "";
                                DateTime ilkdeger9 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz9 = ilkdeger9.AddDays(10).ToShortDateString();
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,Aciklama) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz9 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtBilgilerAciklama1.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();

                            }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 11 Gün varsa 
                            frm1.DoldurTarih1(frm1.Lblgun1.Text, frm1.Lblgun2.Text, frm1.Lblgun3.Text, frm1.Lblgun4.Text, frm1.Lblgun5.Text, frm1.Lblgun6.Text, frm1.Lblgun7.Text);
                        }
                   }                    
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }
        void btnRezarvasyonGuncelle()
        {
            try
            {
                if (txtAd.Text != "" && txtSoyad.Text != "")
                {
                    DialogResult sonuc;
                    sonuc = MessageBox.Show("BİLGİLER DEĞİŞTİRİLECEK EMİN MİSİNİZ ? ", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (sonuc == DialogResult.Yes)
                    {
                        //Kayıt Güncelleme
                        string Sorgu =

                       "UPDATE Rezarvasyon SET Adi=@Adi, Soyadi=@Soyadi, Aciklama1Bilgiler=@Aciklama1Bilgiler,Aciklama2Bilgiler=@Aciklama2Bilgiler,Aciklama3Bilgiler=@Aciklama3Bilgiler, CepTel=@CepTel,EvTel=@EvTel,IsTel=@IsTel,Fax=@Fax,EMail=@EMail, OdaIsmi=@OdaIsmi,RezarvasyonBaslangicTarihi=@RezarvasyonBaslangicTarihi,   RezarvasyonBitisTarihi=@RezarvasyonBitisTarihi,OdaBilgilerAciklama1=@OdaBilgilerAciklama1,OdaBilgilerAciklama2=@OdaBilgilerAciklama2,OdaBilgilerAciklama3=@OdaBilgilerAciklama3  WHERE MusteriNo=@MusteriNo";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, bag);

                        Komut.Parameters.AddWithValue("@Adi", txtAd.Text);
                        Komut.Parameters.AddWithValue("@Soyadi", txtSoyad.Text);
                        Komut.Parameters.AddWithValue("@Aciklama1Bilgiler", txtBilgilerAciklama1.Text);
                        Komut.Parameters.AddWithValue("@Aciklama2Bilgiler", txtBilgilerAciklama2.Text);
                        Komut.Parameters.AddWithValue("@Aciklama3Bilgiler", txtBilgilerAciklama3.Text);

                        Komut.Parameters.AddWithValue("@CepTel", txtCepTel.Text);
                        Komut.Parameters.AddWithValue("@EvTel", txtEvTel.Text);
                        Komut.Parameters.AddWithValue("@IsTel", txtIsTel.Text);
                        Komut.Parameters.AddWithValue("@Fax", txtFax.Text);
                        Komut.Parameters.AddWithValue("@EMail", txtEmail.Text);

                        Komut.Parameters.AddWithValue("@OdaIsmi", txtOdaNumarasi.Text);
                        Komut.Parameters.AddWithValue("@RezarvasyonBaslangicTarihi", datetimeBaslangicRezarvasyonTarihi.Text);

                        Komut.Parameters.AddWithValue("@RezarvasyonBitisTarihi", datetimeBitisRezarvasyonTarihi.Text);
                        Komut.Parameters.AddWithValue("@OdaBilgilerAciklama1", txtOdaBilgilerAciklama1.Text);
                        Komut.Parameters.AddWithValue("@OdaBilgilerAciklama2", txtOdaBilgilerAciklama2.Text);
                        Komut.Parameters.AddWithValue("@OdaBilgilerAciklama1", txtOdaBilgilerAciklama3.Text);



                        Komut.Parameters.AddWithValue("@MusteriNo", txtMusteriNo.Text);// referans sahası


                        //Komut nesnesi ve parametreleri hazırlandı
                        bag.Open();
                        Komut.ExecuteNonQuery();
                        bag.Close();
                        //MusterileriListele();
                        btnRezarvasyonGuncelleOdaDurumlari();
                        frm1.DoldurTarih1(frm1.Lblgun1.Text, frm1.Lblgun2.Text, frm1.Lblgun3.Text, frm1.Lblgun4.Text, frm1.Lblgun5.Text, frm1.Lblgun6.Text, frm1.Lblgun7.Text); 
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
        void btnRezarvasyonGuncelleOdaDurumlari()
        {
            try
            {
                //if (txtAd.Text != "" && txtSoyad.Text != "")
                //{
                    
                        //Kayıt Güncelleme
                        string Sorgu =

                       "UPDATE OdaDurumlari SET Adi=@Adi, Soyadi=@Soyadi, Aciklama=@Aciklama, CikisTarihi=@CikisTarihi WHERE GirisTarihi=@GirisTarihi and OdaIsmi=@OdaIsmi";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, bag);

                          
                        Komut.Parameters.AddWithValue("@Adi", txtAd.Text);
                        Komut.Parameters.AddWithValue("@Soyadi", txtSoyad.Text);
                        Komut.Parameters.AddWithValue("@Aciklama", txtBilgilerAciklama1.Text);
                        Komut.Parameters.AddWithValue("@CikisTarihi", datetimeBitisRezarvasyonTarihi.Text); 
                        
                        Komut.Parameters.AddWithValue("@GirisTarihi", datetimeBaslangicRezarvasyonTarihi.Text); //referans sahası 1
                        Komut.Parameters.AddWithValue("@OdaIsmi", txtOdaNumarasi.Text);      //referans sahası 2
                        
                        //Komut nesnesi ve parametreleri hazırlandı
                        bag.Open();
                        Komut.ExecuteNonQuery();
                        bag.Close();
                        
                //}
                //else
                //{
                //    MessageBox.Show("ZORUNLU ALANLAR BOŞ GEÇİLEMEZ ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //}
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frmRezarvasyonIslemleri_Load(object sender, EventArgs e)
        {
            txtAd.Focus();
        }
        private void btnRezarvasyonKaydetContex_Click(object sender, EventArgs e)
        {
            RezarvasyonKaydetcontexButton(); 
        }

        private void btnRezarvasyonCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenuGuncelle_Click(object sender, EventArgs e)
        {
            btnRezarvasyonGuncelle(); 
        }

        private void frmRezarvasyonIslemleri_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
            if (btnRezarvasyonKaydetContex.Visible == true)
            {
                switch (e.KeyData)
                {
                    case Keys.F2:
                        RezarvasyonKaydetcontexButton();
                        break;
                    default:
                        break;
                }

            }
            else if (btnMenuGuncelle.Visible == true)
            {
                switch (e.KeyData)
                {
                    case Keys.F3:
                        btnRezarvasyonGuncelle();
                        break;
                    default:
                        break;
                }
            }
        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtSoyad.Focus(); }
        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtBilgilerAciklama1.Focus(); }
        }

        private void txtBilgilerAciklama2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtBilgilerAciklama3.Focus(); }
        }

        private void txtBilgilerAciklama3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtCepTel.Focus(); }
        }

        private void txtBilgilerAciklama1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtBilgilerAciklama2.Focus(); }

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
            if (btnRezarvasyonKaydetContex.Visible==true)
            {
                if (e.KeyChar == (char)Keys.Enter)
                { datetimeBitisRezarvasyonTarihi.Focus(); }
            }
            else if (btnMenuGuncelle.Visible==true)
            {
                 if (e.KeyChar == (char)Keys.Enter)
                { txtOdaBilgilerAciklama1.Focus(); }
            }
        }

        private void datetimeBitisRezarvasyonTarihi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtOdaBilgilerAciklama1.Focus(); }
        }

        private void txtOdaBilgilerAciklama1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtOdaBilgilerAciklama2.Focus(); }
        }

        private void txtOdaBilgilerAciklama2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtOdaBilgilerAciklama3.Focus(); }
        }

        private void txtOdaBilgilerAciklama3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnRezarvasyonKaydetContex.Visible == true)
            {
                if (e.KeyChar == (char)Keys.Enter)
                { btnRezarvasyonKaydetContex.Focus(); }
            }
            else if (btnMenuGuncelle.Visible == true)
            {
                if (e.KeyChar == (char)Keys.Enter)
                { btnMenuGuncelle.Focus(); }
            }
        }

        private void txtCepTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtEvTel.Focus(); }
        }
    }
}
