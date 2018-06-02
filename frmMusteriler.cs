using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;
namespace OtelOtomasyonProgrami
{
    public partial class frmMusteriler : Form
    {
        public frmMenu frm1;
        public frmMusteriIslemleri MusteriIslemleri;

        public frmKaydet kaydet;
        public frmGuncelle guncelle;
        public frmMusteriler()
        {
            InitializeComponent();
            MusteriIslemleri = new frmMusteriIslemleri();
            MusteriIslemleri.Musteriler = this;

            kaydet = new frmKaydet();
            kaydet.Musteriler = this;

            guncelle = new frmGuncelle();
            guncelle.Musteriler = this;
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\vt.mdb");
        OleDbCommand kmt = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet dtst = new DataSet();
        
        public void MusterileriListele()
         {
             DataTable dt = new DataTable();
             dt.Clear();
             OleDbDataAdapter adptr = new OleDbDataAdapter("Select TC,Ad,Soyad,CepTel,OdaNumarasi,BaslangicRezarvasyonTarihi,BitisRezarvasyonTarihi,OdemeTuru,Ucret,BabaAdi,AnneAdi,DogumTarihi,DogumYeri,Cinsiyet,MedeniHali,KanGrubu,EvTel,IsTel,Fax,EMail,Meslek,EvAdresi,IsAdresi,MusteriNo,RezarvasyonMu from MusteriBilgileri WHERE BaslangicRezarvasyonTarihi='" + dateTimeBaslangicTarihiYaz.Text + "' and OdaNumarasi='" + txtOdaNoYaz.Text + "'order by TC desc ", bag);
             adptr.Fill(dt);
             dataGridView2.DataSource = dt;
         }
        public void OdaDurumlariListele()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from OdaDurumlari WHERE GirisTarihi='" + dateTimeBaslangicTarihiYaz.Text + "' and OdaIsmi='" + txtOdaNoYaz.Text + "'order by TC desc ", bag);
            adptr.Fill(dt);
            
        }
        void MusteriKaydetBtn()
        {
            kaydet.oda1.Text = oda1.Text; kaydet.oda2.Text = oda2.Text; kaydet.oda3.Text = oda3.Text; kaydet.oda4.Text = oda4.Text; kaydet.oda5.Text = oda5.Text; kaydet.oda6.Text = oda6.Text; kaydet.oda7.Text = oda7.Text; kaydet.oda8.Text = oda8.Text; kaydet.oda9.Text = oda9.Text; kaydet.oda10.Text = oda10.Text;
            kaydet.gun1.Text = gun1.Text; kaydet.gun2.Text = gun2.Text; kaydet.gun3.Text = gun3.Text; kaydet.gun4.Text = gun4.Text; kaydet.gun5.Text = gun5.Text; kaydet.gun6.Text = gun6.Text; kaydet.gun7.Text = gun7.Text;
            kaydet.txtOdaNumarasi.Text = txtOdaNoYaz.Text;                                    //Oda numarasını yolla
            kaydet.datetimeBaslangicRezarvasyonTarihi.Text = dateTimeBaslangicTarihiYaz.Text; // rezarvasyon baslangıç numarasını yolla
            kaydet.ShowDialog();  // kaydet formuna git
        }
        void MusteriDuzenleBtn()
        {
            try
            {
                if (dataGridView2.RowCount == 1)
                {
                    MessageBox.Show("LİSTEDE DÜZELTİLECEK KAYIT BULUNAMADI! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (txtTCYazDuzeltBtn.Text == "")
                {
                    MessageBox.Show("DÜZELTME İŞLEMİ İÇİN LİSTEDEN KAYIT SEÇİNİZ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    txtMusteriNoYaz.Text = guncelle.textBox2.Text;
                    guncelle.ShowDialog();  // kaydet formuna git
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        void MusteriSilBtn()
        {
            try
            {
                if (dataGridView2.RowCount != 1)
                {
                    DialogResult cevap;
                    cevap = MessageBox.Show("KAYDI SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ ?", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {

                        string Sorgu = "DELETE FROM MusteriBilgileri WHERE MusteriNo=@MusteriNo";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, bag);
                        Komut.Parameters.AddWithValue("@MusteriNo", dataGridView2.CurrentRow.Cells[23].Value.ToString());
                        bag.Open();
                        Komut.ExecuteNonQuery();
                        bag.Close();
                        OdaDurunlariSil();
                        MusterileriListele();
                        OdaDurumlariListele();
                        frm1.DoldurTarih1(gun1.Text, gun2.Text, gun3.Text, gun4.Text, gun5.Text, gun6.Text, gun7.Text);
                        MessageBox.Show("KAYDI SİLME İŞLEMİ TAMAMLANDI ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else if (dataGridView2.RowCount == 1)
                {
                    MessageBox.Show("SİLİNCEK KAYIT BULUNAMADI! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void OdaDurunlariSil()
        {
            try
            {
                string Sorgu = "DELETE FROM OdaDurumlari WHERE OdaIsmi=@OdaIsmi and GirisTarihi=@GirisTarihi and TC=@TC";
                        OleDbCommand Komut = new OleDbCommand(Sorgu, bag);
                        Komut.Parameters.AddWithValue("@OdaIsmi", dataGridView2.CurrentRow.Cells[4].Value.ToString());
                        Komut.Parameters.AddWithValue("@GirisTarihi", dataGridView2.CurrentRow.Cells[5].Value.ToString());
                        Komut.Parameters.AddWithValue("@TC", dataGridView2.CurrentRow.Cells[0].Value.ToString());
                        bag.Open();
                        Komut.ExecuteNonQuery();
                        bag.Close();
                        OdaDurumlariListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       private void MusteriKaydet_Click(object sender, EventArgs e)
       {
           MusteriKaydetBtn();     
       }

        private void Kat1Oda1_Load(object sender, EventArgs e)
        {
            txtTCYazDuzeltBtn.Text = "";
            txtMusteriNoYaz.Text = "";
            //Müşteri Listesi Gridinin Başlık İsimleri
            dataGridView2.Columns[0].HeaderText = "T.C Kimlik Numarası";
            dataGridView2.Columns[1].HeaderText = "Adı";
            dataGridView2.Columns[2].HeaderText = "Soyadı";
            dataGridView2.Columns[3].HeaderText = "Cep Telefon Numarası";
            dataGridView2.Columns[4].HeaderText = "Oda Numarası";
            dataGridView2.Columns[5].HeaderText = "Rezarvasyon Başlangınç Tarihi";
            dataGridView2.Columns[6].HeaderText = "Rezarvasyon Bitiş Tarihi";
            dataGridView2.Columns[7].HeaderText = "Ödeme Türü";
            dataGridView2.Columns[8].HeaderText = "Ücret";
            dataGridView2.Columns[9].HeaderText = "Baba Adı";
            dataGridView2.Columns[10].HeaderText = "Anne Adı";
            dataGridView2.Columns[11].HeaderText = "Doğum Tarihi";
            dataGridView2.Columns[12].HeaderText = "Doğum Yeri";
            dataGridView2.Columns[13].HeaderText = "Cinsiyet";
            dataGridView2.Columns[14].HeaderText = "Medeni Hali";
            dataGridView2.Columns[15].HeaderText = "Kan Grubu";
            dataGridView2.Columns[16].HeaderText = "Ev Telefon Numarası";
            dataGridView2.Columns[17].HeaderText = "İş Telefon Numarası";
            dataGridView2.Columns[18].HeaderText = "Fax Numarası";
            dataGridView2.Columns[19].HeaderText = "E-Posta";
            dataGridView2.Columns[20].HeaderText = "Meslek";
            dataGridView2.Columns[21].HeaderText = "Ev Adresi";
            dataGridView2.Columns[22].HeaderText = "İş Adresi";
            dataGridView2.Columns[23].HeaderText = "Müşteri No";
            
        }
        
       
        private void btnSil_Click(object sender, EventArgs e)
        {
            MusteriSilBtn();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dt1.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString(); // odaya giriş tarihini önce bu datepickere atıp daha sonra güncelle formuna gönderilmek üzere hazır bekletiliyor.Eger bu işlem yapılmassa tarih olarak sistem tarihini görüyor.
            dt2.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString(); // odaya çıkış tarihini önce bu datepickere atıp daha sonra güncelle formuna gönderilmek üzere hazır bekletiliyor.Eger bu işlem yapılmassa tarih olarak sistem tarihini görüyor.

            guncelle.textBox2.Text = dataGridView2.CurrentRow.Cells[23].Value.ToString();
            txtMusteriNoYaz.Text = dataGridView2.CurrentRow.Cells[23].Value.ToString();
            txtTCYazDuzeltBtn.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            guncelle.txtTcKimlikNo.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            guncelle.txtAd.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            guncelle.txtSoyad.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            guncelle.txtCepTel.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            guncelle.txtOdaNumarasi.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            guncelle.datetimeBaslangicRezarvasyonTarihi.Text = dt1.Text; // dt1 datepickerina alınan değer güncelle formuna gönderiliyor.
            guncelle.datetimeBitisRezarvasyonTarihi.Text = dt2.Text;    // dt2 datepickerina alınan değer güncelle formuna gönderiliyor.
            guncelle.comboOdemeTuru.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            guncelle.txtUcret.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            
            guncelle.txtBabaAdi.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            guncelle.txtAnneAdi.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
            guncelle.datetimeDogumTarihi.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            guncelle.txtDogumYeri.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
            guncelle.comboCinsiyet.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
            guncelle.comboMedeniHal.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();
            guncelle.comboKanGrubu.Text = dataGridView2.CurrentRow.Cells[15].Value.ToString();

            guncelle.txtEvTel.Text = dataGridView2.CurrentRow.Cells[16].Value.ToString();
            guncelle.txtIsTel.Text = dataGridView2.CurrentRow.Cells[17].Value.ToString();
            guncelle.txtFax.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
            guncelle.txtEmail.Text = dataGridView2.CurrentRow.Cells[19].Value.ToString();
            guncelle.txtMeslek.Text = dataGridView2.CurrentRow.Cells[20].Value.ToString();
            guncelle.txtEvAdresi.Text = dataGridView2.CurrentRow.Cells[21].Value.ToString();
            guncelle.txtIsAdresi.Text = dataGridView2.CurrentRow.Cells[22].Value.ToString();

            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            MusteriDuzenleBtn();
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            MusteriIslemleri.ShowDialog();
        }

        private void MusterilerCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oda1tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda1Tarih1.Text = oda1tarih1.Text;
        }

        private void oda1tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda1Tarih2.Text = oda1tarih2.Text;
        }

        private void oda1tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda1Taarih3.Text = oda1tarih3.Text;
        }

        private void oda1tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda1Tarih4.Text = oda1tarih4.Text;
        }

        private void oda1tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda1Tarih5.Text = oda1tarih5.Text;
        }

        private void oda1tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda1Tarih6.Text = oda1tarih6.Text;
        }

        private void oda1tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda1Tarih7.Text = oda1tarih7.Text;
        }
        private void oda2tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda2Tarih1.Text = oda2tarih1.Text;
        }

        private void oda2tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda2Tarih2.Text = oda2tarih2.Text;
        }

        private void oda2tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda2Tarih3.Text = oda2tarih3.Text;
        }

        private void oda2tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda2Tarih4.Text = oda2tarih4.Text;
        }

        private void oda2tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda2Tarih5.Text = oda2tarih5.Text;
        }

        private void oda2tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda2Tarih6.Text = oda2tarih6.Text;
        }

        private void oda2tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda2Tarih7.Text = oda2tarih7.Text;
        }

        private void oda3tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda3Tarih1.Text = oda3tarih1.Text;
        }

        private void oda3tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda3Tarih2.Text = oda3tarih2.Text;
        }

        private void oda3tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda3Tarih3.Text = oda3tarih3.Text;
        }

        private void oda3tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda3Tarih4.Text = oda3tarih4.Text;
        }

        private void oda3tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda3Tarih5.Text = oda3tarih5.Text;
        }

        private void oda3tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda3Tarih6.Text = oda3tarih6.Text;
        }

        private void oda3tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda3Tarih7.Text = oda3tarih7.Text;
        }

        private void oda4tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda4Tarih1.Text = oda4tarih1.Text;
        }

        private void oda4tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda4Tarih2.Text = oda4tarih2.Text;
        }

        private void oda4tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda4Tarih3.Text = oda4tarih3.Text;
        }

        private void oda4tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda4Tarih4.Text = oda4tarih4.Text;
        }

        private void oda4tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda4Tarih5.Text = oda4tarih5.Text;
        }

        private void oda4tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda4Tarih6.Text = oda4tarih6.Text;
        }

        private void oda4tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda4Tarih7.Text = oda4tarih7.Text;
        }

        private void oda5tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda5Tarih1.Text = oda5tarih1.Text;
        }

        private void oda5tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda5Tarih2.Text = oda5tarih2.Text;
        }

        private void oda5tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda5Tarih3.Text = oda5tarih3.Text;
        }

        private void oda5tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda5Tarih4.Text = oda5tarih4.Text;
        }

        private void oda5tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda5Tarih5.Text = oda5tarih5.Text;
        }

        private void oda5tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda5Tarih6.Text = oda5tarih6.Text;
        }

        private void oda5tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda5Tarih7.Text = oda5tarih7.Text;
        }

        private void oda6tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda6Tarih1.Text = oda6tarih1.Text;
        }

        private void oda6tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda6Tarih2.Text = oda6tarih2.Text;
        }

        private void oda6tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda6Tarih3.Text = oda6tarih3.Text;
        }

        private void oda6tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda6Tarih4.Text = oda6tarih4.Text;
        }

        private void oda6tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda6Tarih5.Text = oda6tarih5.Text;
        }

        private void oda6tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda6Tarih6.Text = oda6tarih6.Text;
        }

        private void oda6tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda6Tarih7.Text = oda6tarih7.Text;
        }

        private void oda7tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda7Tarih1.Text = oda7tarih1.Text;
        }

        private void oda7tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda7Tarih2.Text = oda7tarih2.Text;
        }

        private void oda7tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda7Tarih3.Text = oda7tarih3.Text;
        }

        private void oda7tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda7Tarih4.Text = oda7tarih4.Text;
        }

        private void oda7tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda7Tarih5.Text = oda7tarih5.Text;
        }

        private void oda7tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda7Tarih6.Text = oda7tarih6.Text;
        }

        private void oda7tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda7Tarih7.Text = oda7tarih7.Text;
        }

        private void oda8tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda8Tarih1.Text = oda8tarih1.Text;
        }

        private void oda8tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda8Tarih2.Text = oda8tarih2.Text;
        }

        private void oda8tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda8Tarih3.Text = oda8tarih3.Text;
        }

        private void oda8tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda8Tarih4.Text = oda8tarih4.Text;
        }

        private void oda8tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda8Tarih5.Text = oda8tarih5.Text;
        }

        private void oda8tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda8Tarih6.Text = oda8tarih6.Text;
        }

        private void oda8tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda8Tarih7.Text = oda8tarih7.Text;
        }

        private void oda9tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda9Tarih1.Text = oda9tarih1.Text;
        }

        private void oda9tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda9Tarih2.Text = oda9tarih2.Text;
        }

        private void oda9tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda9Tarih3.Text = oda9tarih3.Text;
        }

        private void oda9tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda9Tarih4.Text = oda9tarih4.Text;
        }

        private void oda9tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda9Tarih5.Text = oda9tarih5.Text;
        }

        private void oda9tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda9Tarih6.Text = oda9tarih6.Text;
        }

        private void oda9tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda9Tarih7.Text = oda9tarih7.Text;
        }

        private void oda10tarih1_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda10Tarih1.Text = oda10tarih1.Text;
        }

        private void oda10tarih2_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda10Tarih2.Text = oda10tarih2.Text;
        }

        private void oda10tarih3_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda10Tarih3.Text = oda10tarih3.Text;
        }

        private void oda10tarih4_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda10Tarih4.Text = oda10tarih4.Text;
        }

        private void oda10tarih5_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda10Tarih5.Text = oda10tarih5.Text;
        }

        private void oda10tarih6_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda10Tarih6.Text = oda10tarih6.Text;
        }

        private void oda10tarih7_TextChanged(object sender, EventArgs e)
        {
            frm1.LblOda10Tarih7.Text = oda10tarih7.Text;
        }

        private void frmMusteriler_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape :
                    this.Close();
                    break;
                    default:
                    break;
            }
            switch (e.KeyData)
            {
                case Keys.F9: //Müşteriler sayfasında F9 kısayol tuşu müşteri kaydet formunu açar
                    MusteriKaydetBtn();   
                    break;
                default:
                    break;
            }
            switch (e.KeyData)
            {
                case Keys.F10: //Müşteriler sayfasında F10 kısayol tuşu müşteri bilgileri düzenle formunu açar 
                    MusteriDuzenleBtn();
                    break;
                default:
                    break;
            }
            switch (e.KeyData)
            {
                case Keys.F11: //Müşteriler sayfasında F11 kısayol tuşu ile seçilen müşteriyi siler
                    MusteriSilBtn();
                    break;
                default:
                    break;
            }
        }

     }
}





               