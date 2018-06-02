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
    public partial class frmKaydet : Form
    {
        public frmMusteriler Musteriler;
        public frmMenu frm1;
        public frmMusteriIslemleri MusteriIslemleri;
        public frmAnaMenuProgressBarLoading frmAnaMenuIcınProgressBarLoading;
        public frmKaydet()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            MusteriIslemleri = new frmMusteriIslemleri();
            MusteriIslemleri.Kaydet = this;
            frmAnaMenuIcınProgressBarLoading = new frmAnaMenuProgressBarLoading();
            frmAnaMenuIcınProgressBarLoading.frmKaydet = this;
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\vt.mdb");
        OleDbCommand kmt = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet dtst = new DataSet();
        string TC,TCKontrol, OdaDurumu="dolu";

        void MusteriKaydetOdaDurumlariTablosu()
        {
           
            try
            {
                
                //bag.Open();
                //kmt.Connection = bag;
                //kmt.CommandText = "select TC from OdaDurumlari where GirisTarihi= '" + datetimeBaslangicRezarvasyonTarihi.Text + "' and OdaIsmi='" + txtOdaNumarasi.Text + "'";
                //OleDbDataReader oku = kmt.ExecuteReader();
                //while (oku.Read())
                //{
                //    TC = oku["TC"].ToString(); //MessageBox.Show(TC);

                //}
                //bag.Close();

                //if (txtTcKimlikNo.Text != TC)
                //{
                if (txtAd.Text != "" && txtSoyad.Text != "")
                {
                    if (datetimeBaslangicRezarvasyonTarihi.Value <= datetimeBitisRezarvasyonTarihi.Value)
                    {
                        bag.Open();
                        kmt.Connection = bag;
                        kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + datetimeBaslangicRezarvasyonTarihi.Text + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz1 = "";
                            DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz1 = "";
                            DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz2 = "";
                            DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz1 = "";
                            DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz2 = "";
                            DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz3 = "";
                            DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz1 = "";
                            DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz2 = "";
                            DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz3 = "";
                            DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz4 = "";
                            DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz1 = "";
                            DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz2 = "";
                            DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz3 = "";
                            DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz4 = "";
                            DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz5 = "";
                            DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz1 = "";
                            DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz2 = "";
                            DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz3 = "";
                            DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz4 = "";
                            DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz5 = "";
                            DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz6 = "";
                            DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz1 = "";
                            DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz2 = "";
                            DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz3 = "";
                            DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz4 = "";
                            DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz5 = "";
                            DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz6 = "";
                            DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz7 = "";
                            DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz1 = "";
                            DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz2 = "";
                            DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz3 = "";
                            DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz4 = "";
                            DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz5 = "";
                            DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz6 = "";
                            DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz7 = "";
                            DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();

                            //---------------------
                            string GunYaz8 = "";
                            DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
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
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz1 = "";
                            DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz2 = "";
                            DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz3 = "";
                            DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz4 = "";
                            DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz5 = "";
                            DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz6 = "";
                            DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz7 = "";
                            DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();

                            //---------------------
                            string GunYaz8 = "";
                            DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();


                            //---------------------
                            string GunYaz9 = "";
                            DateTime ilkdeger9 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz9 = ilkdeger9.AddDays(10).ToShortDateString();
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO OdaDurumlari(OdaIsmi,OdaDurumu,Adi,Soyadi,GirisTarihi,CikisTarihi,TC) VALUES ('" + txtOdaNumarasi.Text + "','" + OdaDurumu + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + GunYaz9 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + txtTcKimlikNo.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();

                        }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 11 Gün varsa 
                        DoldurTarih1(gun1.Text, gun2.Text, gun3.Text, gun4.Text, gun5.Text, gun6.Text, gun7.Text);

                        // Temizle();
                        //MessageBox.Show("KAYIT İŞLEMİ TAMAMLANDI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //}

                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        public void MusterileriListele()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select TC,Ad,Soyad,CepTel,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,MedeniHali,KanGrubu,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,MusteriNo from MusteriBilgileri WHERE BaslangicRezarvasyonTarihi='" + datetimeBaslangicRezarvasyonTarihi.Text + "' and OdaNumarasi='" + txtOdaNumarasi.Text + "' ", bag);
            adptr.Fill(dt);
             Musteriler.dataGridView2.DataSource = dt;
        }
        public void DoldurTarih1(string tarih1, string tarih2, string tarih3, string tarih4, string tarih5, string tarih6, string tarih7)
        {
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda1.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda1tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda1tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                    else
                    {
                        Musteriler.oda1tarih1.Text = "";
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda1.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda1tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda1tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                    else
                    {
                        Musteriler.oda1tarih2.Text = "";
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda1.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda1tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda1tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                    else
                    {
                        Musteriler.oda1tarih3.Text = "";
                    }
                }
                bag.Close();

            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda1.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda1tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda1tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                    else
                    {
                        Musteriler.oda1tarih4.Text = "";
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda1.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda1tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda1tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                    else 
                    {
                        Musteriler.oda1tarih5.Text = "";
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda1.Text + "' and GirisTarihi='" + gun6.Text + "'order by TC desc";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda1tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda1tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                    else
                    {
                        Musteriler.oda1tarih6.Text = "";
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda1.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda1tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda1tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                    else
                    {
                        Musteriler.oda1tarih7.Text = "";
                    }
                }
                bag.Close();
            }
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda2.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda2tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda2tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda2.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda2tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda2tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda2.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda2tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda2tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda2.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda2tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda2tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select * from OdaDurumlari where OdaIsmi= '" + oda2.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda2tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda2tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda2.Text + "' and GirisTarihi='" + gun6.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda2tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda2tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda2.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda2tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda2tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda3.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda3tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda3tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda3.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda3tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda3tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda3.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda3tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda3tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda3.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda3tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda3tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda3.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda3tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda3tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda3.Text + "' and GirisTarihi='" + gun6.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda3tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda3tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda3.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda3tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda3tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda4.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda4tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda4tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda4.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda4tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda4tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda4.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda4tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda4tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda4.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda4tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda4tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda4.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda4tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda4tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda4.Text + "' and GirisTarihi='" + gun6.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda4tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda4tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda4.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda4tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda4tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda5.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda5tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda5tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda5.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda5tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda5tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda5.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda5tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda5tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda5.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda5tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda5tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda5.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda5tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda5tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda5.Text + "' and GirisTarihi='" + gun6.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda5tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda5tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda5.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda5tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda5tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda6.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda6tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda6tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda6.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda6tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda6tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda6.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda6tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda6tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda6.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda6tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda6tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda6.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda6tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda6tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda6.Text + "' and GirisTarihi='" + gun6.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda6tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda6tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda6.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda6tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda6tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda7.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda7tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda7tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda7.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda7tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda7tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda7.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda7tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda7tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda7.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda7tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda7tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda7.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda7tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda7tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda7.Text + "' and GirisTarihi='" + gun6.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda7tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda7tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda7.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda7tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda7tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda8.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda8tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda8tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda8.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda8tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda8tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda8.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda8tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda8tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda8.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda8tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda8tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda8.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda8tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda8tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda8.Text + "' and GirisTarihi='" + gun6.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda8tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda8tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda8.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda8tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda8tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda9.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda9tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda9tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda9.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda9tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda9tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda9.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda9tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda9tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda9.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda9tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda9tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda9.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda9tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda9tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda9.Text + "' and GirisTarihi='" + gun6.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda9tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda9tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda9.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda9tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda9tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun1.Text == tarih1)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda10.Text + "' and GirisTarihi='" + gun1.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda10tarih1.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda10tarih1.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun2.Text == tarih2)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda10.Text + "' and GirisTarihi='" + gun2.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda10tarih2.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda10tarih2.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun3.Text == tarih3)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda10.Text + "' and GirisTarihi='" + gun3.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda10tarih3.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda10tarih3.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun4.Text == tarih4)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda10.Text + "' and GirisTarihi='" + gun4.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda10tarih4.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda10tarih4.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun5.Text == tarih5)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda10.Text + "' and GirisTarihi='" + gun5.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda10tarih5.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda10tarih5.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun6.Text == tarih6)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda10.Text + "' and GirisTarihi='" + gun6.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda10tarih6.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda10tarih6.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }
            if (gun7.Text == tarih7)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select *  from OdaDurumlari where OdaIsmi= '" + oda10.Text + "' and GirisTarihi='" + gun7.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    string TcKimlikNo = oku["TC"].ToString();
                    string Ad = oku["Adi"].ToString();
                    string Soyad = oku["Soyadi"].ToString();
                    string OdaDurumu = oku["OdaDurumu"].ToString();
                    if (OdaDurumu == "Rezerve")
                    {
                        Musteriler.oda10tarih7.Text = "Adı: " + Ad + "\n" + "Soyadı: " + Soyad + "\n" + "\n\n" + "OdaDurumu: " + OdaDurumu;
                    }
                    else if (OdaDurumu == "dolu")
                    {
                        Musteriler.oda10tarih7.Text = "TC: " + TcKimlikNo + "\n" + "Adı: " + Ad + "\n" + "Soyadı: " + Soyad;
                    }
                }
                bag.Close();
            }

        }

       
        public void MusterileriListeleContexMenuIcın() ////bu fonksiyon contexMenu için kullanılmıştır
        {
            DataTable dt = new DataTable();
            dt.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select TC,Ad,Soyad,CepTel,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,MedeniHali,KanGrubu,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,MusteriNo from MusteriBilgileri WHERE BaslangicRezarvasyonTarihi='" + datetimeBaslangicRezarvasyonTarihi.Text + "' and OdaNumarasi='" + txtOdaNumarasi.Text + "' ", bag);
            adptr.Fill(dt);
            //Musteriler.dataGridView2.DataSource = dt;
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
            datetimeBitisRezarvasyonTarihi.Text = "";
            comboOdemeTuru.Text = "";
            txtUcret.Text = "";

        }
        void MusteriBilgileriListesiKaydet()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "select TC from MusteriBilgileriListesi where TC= '" + txtTcKimlikNo.Text + "' ";
            OleDbDataReader oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                TCKontrol = oku["TC"].ToString(); //MessageBox.Show(TC);

            }
            bag.Close();
            if (txtTcKimlikNo.Text!=TCKontrol)
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "INSERT INTO MusteriBilgileriListesi(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "') ";
                kmt.ExecuteNonQuery();
                kmt.Dispose();
                bag.Close();
                MusteriIslemleri.MusteriBilgileriTablosunuListele();  
            }
        }
        void btnMusteriKaydet()//Müşteri kaydet buttonu için
        {
            
            try
            {
                bag.Open();
                kmt.Connection = bag;
                //kmt.CommandText = "select TC from MusteriBilgileri where BaslangicRezarvasyonTarihi= '" + datetimeBaslangicRezarvasyonTarihi.Text + "' and OdaNumarasi='" + txtOdaNumarasi.Text + "'";
                kmt.CommandText = "select TC from OdaDurumlari where GirisTarihi= '" + datetimeBaslangicRezarvasyonTarihi.Text + "' and OdaIsmi='" + txtOdaNumarasi.Text + "'and TC='" + txtTcKimlikNo.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                     TC = oku["TC"].ToString(); //MessageBox.Show(TC);

                }
                bag.Close();

                if (txtTcKimlikNo.Text != TC)
                {
                    if (txtTcKimlikNo.Text != "" && txtAd.Text != "" && txtSoyad.Text != "")
                    {
                        if (datetimeBaslangicRezarvasyonTarihi.Value <= datetimeBitisRezarvasyonTarihi.Value)
                        {
                            DialogResult sonuc;
                            sonuc = MessageBox.Show("BİLGİLER KAYIT EDİLECEK EMİN MİSİNİZ ? ", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (sonuc == DialogResult.Yes)
                            {
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + datetimeBaslangicRezarvasyonTarihi.Text + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                //kmt.CommandText = "INSERT INTO MusteriBilgileriListesi(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();
                                MusterileriListele();
                                MusteriBilgileriListesiKaydet();
                                

                                /*Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında Kaç Gün Olduğunu Bulur*/
                                DateTime ilkTarih = datetimeBaslangicRezarvasyonTarihi.Value; //1
                                DateTime SonTarih = datetimeBitisRezarvasyonTarihi.Value; //2
                                System.TimeSpan Gun; //3
                                Gun = SonTarih.Subtract(ilkTarih); //4
                                int ToplamGunSayisi = Convert.ToInt32(Gun.TotalDays); //5
                                /*Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında Kaç Gün Olduğunu Bulundu*/

                                if (ToplamGunSayisi == 2 ) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 2 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 2 Gün varsa 

                                if (ToplamGunSayisi == 3 ) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 3 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 3 Gün varsa 

                                if (ToplamGunSayisi == 4) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 4 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 4 Gün varsa 

                                if (ToplamGunSayisi == 5) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 5 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 5 Gün varsa

                                if (ToplamGunSayisi == 6) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 6 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 6 Gün varsa 

                                if (ToplamGunSayisi == 7) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 7 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 7 Gün varsa 
                                if (ToplamGunSayisi == 8) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 8 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 8 Gün varsa 
                                if (ToplamGunSayisi == 9) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 9 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz7 = "";
                                    DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 9 Gün varsa 
                                if (ToplamGunSayisi == 10) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 10 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz7 = "";
                                    DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz8 = "";
                                    DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 10 Gün varsa 
                                if (ToplamGunSayisi == 11) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 11 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz7 = "";
                                    DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz8 = "";
                                    DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    

                                    //---------------------
                                    string GunYaz9 = "";
                                    DateTime ilkdeger9 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz9 = ilkdeger9.AddDays(10).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz9 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListele();
                                    
                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 11 Gün varsa 
                                MusteriKaydetOdaDurumlariTablosu();
                                DoldurTarih1(gun1.Text, gun2.Text, gun3.Text, gun4.Text, gun5.Text, gun6.Text, gun7.Text);
                                MusterileriListele(); 
                                Temizle();
                                MessageBox.Show("KAYIT İŞLEMİ TAMAMLANDI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ODADAN ÇIKIŞ TARİHİ, ODAYA GİRİŞ TARİHİNDEN BÜYÜK VEYA BU TARİHE EŞİT OLMALIDIR ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ZORUNLU ALANLAR BOŞ GEÇİLEMEZ ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("KAYDEDİLMEK İSTENEN MÜŞTERİ, " + datetimeBaslangicRezarvasyonTarihi.Text + " TARİHLİ " +txtOdaNumarasi.Text + " İSİMLİ ODADA KAYITLI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void btnContexMenuKaydet()
        {
            /* bu button contexMenuden kaydetme işlemi için konulmuştur.*/
            try
            {
                bag.Open();
                kmt.Connection = bag;
                //kmt.CommandText = "select TC from MusteriBilgileri where BaslangicRezarvasyonTarihi= '" + datetimeBaslangicRezarvasyonTarihi.Text + "' and OdaNumarasi='" + txtOdaNumarasi.Text + "'";
                kmt.CommandText = "select TC from OdaDurumlari where GirisTarihi= '" + datetimeBaslangicRezarvasyonTarihi.Text + "' and OdaIsmi='" + txtOdaNumarasi.Text + "'and TC='" + txtTcKimlikNo.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    TC = oku["TC"].ToString(); //MessageBox.Show(TC);

                }
                bag.Close();

                if (txtTcKimlikNo.Text != TC)
                {
                    if (txtTcKimlikNo.Text != "" && txtAd.Text != "" && txtSoyad.Text != "")
                    {
                        if (datetimeBaslangicRezarvasyonTarihi.Value <= datetimeBitisRezarvasyonTarihi.Value)
                        {
                            DialogResult sonuc;
                            sonuc = MessageBox.Show("BİLGİLER KAYIT EDİLECEK EMİN MİSİNİZ ? ", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (sonuc == DialogResult.Yes)
                            {
                                bag.Open();
                                kmt.Connection = bag;
                                kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + datetimeBaslangicRezarvasyonTarihi.Text + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                kmt.ExecuteNonQuery();
                                kmt.Dispose();
                                bag.Close();
                                MusterileriListeleContexMenuIcın(); //bu fonksiyon contexMenu için kullanılmıştır
                                MusteriBilgileriListesiKaydet();

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
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 2 Gün varsa 

                                if (ToplamGunSayisi == 3) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 3 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 3 Gün varsa 

                                if (ToplamGunSayisi == 4) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 4 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 4 Gün varsa 

                                if (ToplamGunSayisi == 5) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 5 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 5 Gün varsa

                                if (ToplamGunSayisi == 6) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 6 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 6 Gün varsa 

                                if (ToplamGunSayisi == 7) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 7 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 7 Gün varsa 
                                if (ToplamGunSayisi == 8) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 8 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 8 Gün varsa 
                                if (ToplamGunSayisi == 9) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 9 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz7 = "";
                                    DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                }                          // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 9 Gün varsa 
                                if (ToplamGunSayisi == 10) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 10 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz7 = "";
                                    DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz8 = "";
                                    DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 10 Gün varsa 
                                if (ToplamGunSayisi == 11) // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 11 Gün varsa 
                                {
                                    string GunYaz = "";
                                    DateTime ilkdeger = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz = ilkdeger.AddDays(1).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz1 = "";
                                    DateTime ilkdeger1 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz1 = ilkdeger1.AddDays(2).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz1 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz2 = "";
                                    DateTime ilkdeger2 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz2 = ilkdeger2.AddDays(3).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz2 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz3 = "";
                                    DateTime ilkdeger3 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz3 = ilkdeger3.AddDays(4).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz3 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz4 = "";
                                    DateTime ilkdeger4 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz4 = ilkdeger4.AddDays(5).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz4 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz5 = "";
                                    DateTime ilkdeger5 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz5 = ilkdeger5.AddDays(6).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz5 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz6 = "";
                                    DateTime ilkdeger6 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz6 = ilkdeger6.AddDays(7).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz6 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz7 = "";
                                    DateTime ilkdeger7 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz7 = ilkdeger7.AddDays(8).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz7 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz8 = "";
                                    DateTime ilkdeger8 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz8 = ilkdeger8.AddDays(9).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz8 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();

                                    //---------------------
                                    string GunYaz9 = "";
                                    DateTime ilkdeger9 = datetimeBaslangicRezarvasyonTarihi.Value; GunYaz9 = ilkdeger9.AddDays(10).ToShortDateString();
                                    bag.Open();
                                    kmt.Connection = bag;
                                    kmt.CommandText = "INSERT INTO MusteriBilgileri(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "','" + txtOdaNumarasi.Text + "','" + GunYaz9 + "','" + datetimeBitisRezarvasyonTarihi.Text + "','" + comboOdemeTuru.Text + "','" + txtUcret.Text + "') ";
                                    kmt.ExecuteNonQuery();
                                    kmt.Dispose();
                                    bag.Close();
                                    MusterileriListeleContexMenuIcın();
                                }                         // Başlangınç Rezarvasyon Tarihi ile Bitiş Rezarvasyon Tarihi Arasında 11 Gün varsa 
                                MusteriKaydetOdaDurumlariTablosu();
                                frm1.DoldurTarih1(frm1.Lblgun1.Text, frm1.Lblgun2.Text, frm1.Lblgun3.Text, frm1.Lblgun4.Text, frm1.Lblgun5.Text, frm1.Lblgun6.Text, frm1.Lblgun7.Text);
                                MusterileriListeleContexMenuIcın(); 
                                Temizle();
                                MessageBox.Show("KAYIT İŞLEMİ TAMAMLANDI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ODADAN ÇIKIŞ TARİHİ, ODAYA GİRİŞ TARİHİNDEN BÜYÜK VEYA BU TARİHE EŞİT OLMALIDIR ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ZORUNLU ALANLAR BOŞ GEÇİLEMEZ ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("KAYDEDİLMEK İSTENEN MÜŞTERİ, " + datetimeBaslangicRezarvasyonTarihi.Text + " TARİHLİ " + txtOdaNumarasi.Text + " İSİMLİ ODADA KAYITLI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void btnFrmMenuKaydet()
        {
            try
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "select TC from MusteriBilgileriListesi where TC= '" + txtTcKimlikNo.Text + "' ";
                OleDbDataReader oku = kmt.ExecuteReader();
                while (oku.Read())
                {
                    TC = oku["TC"].ToString(); //MessageBox.Show(TC);
                }
                bag.Close();

                if (txtTcKimlikNo.Text != "" && txtAd.Text != "" && txtSoyad.Text != "")
                {

                    if (txtTcKimlikNo.Text != TC)
                    {
                        DialogResult sonuc;
                        sonuc = MessageBox.Show("BİLGİLER KAYIT EDİLECEK EMİN MİSİNİZ ? ", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (sonuc == DialogResult.Yes)
                        {
                            bag.Open();
                            kmt.Connection = bag;
                            kmt.CommandText = "INSERT INTO MusteriBilgileriListesi(TC,Ad,Soyad,MedeniHali,KanGrubu,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,CepTel,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi) VALUES ('" + txtTcKimlikNo.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboMedeniHal.Text + "','" + comboKanGrubu.Text + "','" + txtBabaAdi.Text + "','" + txtAnneAdi.Text + "','" + datetimeDogumTarihi.Text + "','" + txtDogumYeri.Text + "','" + comboCinsiyet.Text + "','" + txtCepTel.Text + "','" + txtEvTel.Text + "','" + txtIsTel.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtMeslek.Text + "','" + txtEvAdresi.Text + "','" + txtIsAdresi.Text + "') ";
                            kmt.ExecuteNonQuery();
                            kmt.Dispose();
                            bag.Close();
                            //MusterileriListele();
                            //MusteriBilgileriListesiKaydet();
                            frm1.MusteriBilgileriTablosunuListele();
                            Temizle();
                            MessageBox.Show("KAYIT İŞLEMİ TAMAMLANDI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                    }
                    else
                    {
                        MessageBox.Show("KAYDEDİLMEK İSTENEN MÜŞTERİ, MÜŞTERİ LİSTESİNDE KAYITLI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        private void MusteriKaydet_Click(object sender, EventArgs e)
        {
            btnMusteriKaydet();
            //MusteriKaydetOdaDurumlariTablosu(); 
            //Temizle();
            //backgroundWorkerKaydetLoading.RunWorkerAsync();
        }

        private void KaydetCikis_Click(object sender, EventArgs e)
        {
            Temizle(); this.Close();
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            MusteriIslemleri.ShowDialog();
        }

        private void Kaydet_FormClosing(object sender, FormClosingEventArgs e)
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
            //MusteriKaydet.Text = "F2->\nKaydet";
            //KaydetCikis.Text = "ESC->\nÇıkış";
            //btnKaydetContexMenu.Text = "F2->\nKaydet";
            //btnFrmMenu.Text = "F2->\nKaydet";
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
            { MusteriKaydet.Focus(); }
        }

        private void comboOdemeTuru_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtUcret.Focus(); }
        }

        private void btnKaydetContexMenu_Click(object sender, EventArgs e)
        {
            btnContexMenuKaydet();
            //Temizle();
        }

        private void btnFrmMenu_Click(object sender, EventArgs e)
        {
            btnFrmMenuKaydet();
        }

        private void frmKaydet_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
            if (MusteriKaydet.Visible==true)
            {
                switch (e.KeyData)
                {
                    case Keys.F2:
                        btnMusteriKaydet();
                        break;
                    default:
                        break;
                }
                
            }
            else if (btnKaydetContexMenu.Visible==true)
            {
                switch (e.KeyData)
                {
                    case Keys.F2:
                        btnContexMenuKaydet();
                        break;
                    default:
                        break;
                }
            }
            else if (btnFrmMenu.Visible == true)
            {
                switch (e.KeyData)
                {
                    case Keys.F2:
                        btnFrmMenuKaydet();
                        break;
                    default:
                        break;
                }
            }
        }

        private void backgroundWorkerKaydetLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            //btnMusteriKaydet();
            
        }
    }
}
