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
    public partial class frmMusteriIslemleri : Form
    {
        public frmMusteriler Musteriler;
        public frmKaydet Kaydet;
        public frmGuncelle guncelle;
        public frmMenu frm1;
        public frmMusteriIslemleri()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\vt.mdb");
        OleDbCommand kmt = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        public string KaydetmiGuncellemi;

        public void MusteriBilgileriTablosunuListele()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from MusteriBilgileriListesi  ", bag);
            adptr.Fill(dt);
            dataGridView2.DataSource = dt;
            //frm1.dataGridView2.DataSource = dt;
        }

        private void MusteriIslemleri_Load(object sender, EventArgs e)
        {
            MusteriBilgileriTablosunuListele();
            txtTCYaz.Text = "";
            dataGridView2.Columns[0].HeaderText = "Müşteri No";
            dataGridView2.Columns[1].HeaderText = "T.C Kimlik Numarası";
            dataGridView2.Columns[2].HeaderText = "Adı";
            dataGridView2.Columns[3].HeaderText = "Soyadı";
            dataGridView2.Columns[4].HeaderText = "Baba Adı";
            dataGridView2.Columns[5].HeaderText = "Anne Adı";
            dataGridView2.Columns[6].HeaderText = "Doğum Tarihi";
            dataGridView2.Columns[7].HeaderText = "Doğum Yeri";
            dataGridView2.Columns[8].HeaderText = "Cinsiyet";
            dataGridView2.Columns[9].HeaderText = "Medeni Hali";
            dataGridView2.Columns[10].HeaderText = "Kan Grubu";
            dataGridView2.Columns[11].HeaderText = "Cep Telefon Numarası";
            dataGridView2.Columns[12].HeaderText = "Ev Telefon Numarası";
            dataGridView2.Columns[13].HeaderText = "İş Telefon Numarası";
            dataGridView2.Columns[14].HeaderText = "Fax Numarası";
            dataGridView2.Columns[15].HeaderText = "E-Posta";
            dataGridView2.Columns[16].HeaderText = "Meslek";
            dataGridView2.Columns[17].HeaderText = "Ev Adresi";
            dataGridView2.Columns[18].HeaderText = "İş Adresi";
            
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //if (KaydetmiGuncellemi=="1")
            //{
                Kaydet.txtTcKimlikNo.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                Kaydet.txtAd.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                Kaydet.txtSoyad.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                Kaydet.txtBabaAdi.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                Kaydet.txtAnneAdi.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                Kaydet.datetimeDogumTarihi.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                Kaydet.txtDogumYeri.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                Kaydet.comboCinsiyet.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                Kaydet.comboMedeniHal.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                Kaydet.comboKanGrubu.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
                Kaydet.txtCepTel.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                Kaydet.txtEvTel.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
                Kaydet.txtIsTel.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
                Kaydet.txtFax.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();
                Kaydet.txtEmail.Text = dataGridView2.CurrentRow.Cells[15].Value.ToString();
                Kaydet.txtMeslek.Text = dataGridView2.CurrentRow.Cells[16].Value.ToString();
                Kaydet.txtEvAdresi.Text = dataGridView2.CurrentRow.Cells[17].Value.ToString();
                Kaydet.txtIsAdresi.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
                this.Close();
            //}
            //else if (KaydetmiGuncellemi=="0")
            //{
            //    guncelle.txtTcKimlikNo.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            //    guncelle.txtAd.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            //    guncelle.txtSoyad.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            //    guncelle.txtBabaAdi.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            //    guncelle.txtAnneAdi.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            //    guncelle.datetimeDogumTarihi.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            //    guncelle.txtDogumYeri.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            //    guncelle.comboCinsiyet.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            //    guncelle.comboMedeniHal.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            //    guncelle.comboKanGrubu.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
            //    guncelle.txtCepTel.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            //    guncelle.txtEvTel.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
            //    guncelle.txtIsTel.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
            //    guncelle.txtFax.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();
            //    guncelle.txtEmail.Text = dataGridView2.CurrentRow.Cells[15].Value.ToString();
            //    guncelle.txtMeslek.Text = dataGridView2.CurrentRow.Cells[16].Value.ToString();
            //    guncelle.txtEvAdresi.Text = dataGridView2.CurrentRow.Cells[17].Value.ToString();
            //    guncelle.txtIsAdresi.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
            //    this.Close();
            //}

           
        }

        private void MusteriSec_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.RowCount == 1)
                {
                    MessageBox.Show("LİSTEDE SEÇİLECEK KAYIT BULUNAMADI! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (txtTCYaz.Text == "")
                {
                    MessageBox.Show("LİSTEDEN KAYIT SEÇİNİZ! ", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    Kaydet.Show(); this.Close();
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (KaydetmiGuncellemi == "1")
            //{
                txtTCYaz.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();//gridden müşteri seçtimi
                Kaydet.txtTcKimlikNo.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                Kaydet.txtAd.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                Kaydet.txtSoyad.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                Kaydet.txtBabaAdi.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                Kaydet.txtAnneAdi.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                Kaydet.datetimeDogumTarihi.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                Kaydet.txtDogumYeri.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                Kaydet.comboCinsiyet.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                Kaydet.comboMedeniHal.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                Kaydet.comboKanGrubu.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
                Kaydet.txtCepTel.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                Kaydet.txtEvTel.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
                Kaydet.txtIsTel.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
                Kaydet.txtFax.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();
                Kaydet.txtEmail.Text = dataGridView2.CurrentRow.Cells[15].Value.ToString();
                Kaydet.txtMeslek.Text = dataGridView2.CurrentRow.Cells[16].Value.ToString();
                Kaydet.txtEvAdresi.Text = dataGridView2.CurrentRow.Cells[17].Value.ToString();
                Kaydet.txtIsAdresi.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
                
            //}
            //else if (KaydetmiGuncellemi == "0")
            //{
            //    guncelle.txtTcKimlikNo.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            //    guncelle.txtAd.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            //    guncelle.txtSoyad.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            //    guncelle.txtBabaAdi.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            //    guncelle.txtAnneAdi.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            //    guncelle.datetimeDogumTarihi.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            //    guncelle.txtDogumYeri.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            //    guncelle.comboCinsiyet.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            //    guncelle.comboMedeniHal.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            //    guncelle.comboKanGrubu.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
            //    guncelle.txtCepTel.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            //    guncelle.txtEvTel.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
            //    guncelle.txtIsTel.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
            //    guncelle.txtFax.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();
            //    guncelle.txtEmail.Text = dataGridView2.CurrentRow.Cells[15].Value.ToString();
            //    guncelle.txtMeslek.Text = dataGridView2.CurrentRow.Cells[16].Value.ToString();
            //    guncelle.txtEvAdresi.Text = dataGridView2.CurrentRow.Cells[17].Value.ToString();
            //    guncelle.txtIsAdresi.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
                
            //}
          }

        private void txtAraMusteriNo_TextChanged(object sender, EventArgs e)
        {
            if (txtAraMusteriNo.Text.Trim() == "")
            {
                DataTable dt = new DataTable();
                dt.Clear();
                OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from MusteriBilgileriListesi  ", bag);
                adptr.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Clear();
                OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from  MusteriBilgileriListesi where MusteriNo like '" + txtAraMusteriNo.Text + "%'  ", bag);
                adptr.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void txtAraTcKimlikNo_TextChanged(object sender, EventArgs e)
        {
            if (txtAraTcKimlikNo.Text.Trim() == "")
            {
                DataTable dt = new DataTable();
                dt.Clear();
                OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from MusteriBilgileriListesi ", bag);
                adptr.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Clear();
                OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from  MusteriBilgileriListesi where TC like '" + txtAraTcKimlikNo.Text + "%'  ", bag);
                adptr.Fill(dt);
                dataGridView2.DataSource = dt;
            }

        }

        private void txtAraAd_TextChanged(object sender, EventArgs e)
        {
            if (txtAraAd.Text.Trim() == "")
            {
                DataTable dt = new DataTable();
                dt.Clear();
                OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from MusteriBilgileriListesi ", bag);
                adptr.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Clear();
                OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from  MusteriBilgileriListesi where Ad like '" + txtAraAd.Text + "%'  ", bag);
                adptr.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void txtAraSoyad_TextChanged(object sender, EventArgs e)
        {
            if (txtAraSoyad.Text.Trim() == "")
            {
                DataTable dt = new DataTable();
                dt.Clear();
                OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from MusteriBilgileriListesi ", bag);
                adptr.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Clear();
                OleDbDataAdapter adptr = new OleDbDataAdapter("Select * from  MusteriBilgileriListesi where Soyad like '" + txtAraSoyad.Text + "%'  ", bag);
                adptr.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMuseteriSecGuncelle_Click(object sender, EventArgs e)
        {
            guncelle.Show(); this.Close();
        }

        private void frmMusteriIslemleri_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
            switch (e.KeyData)
            {
                case Keys.F2:
                    Kaydet.Show(); this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
