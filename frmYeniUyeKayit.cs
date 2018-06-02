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
    public partial class frmYeniUyeKayit : Form
    {
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\vt.mdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public frmYeniUyeKayit()
        {
            InitializeComponent();
        }
        void UyeKaydet()
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {

                    bag.Open();
                    kmt.Connection = bag;
                    kmt.CommandText = "INSERT INTO Kullanicilar(TC,Adi,Soyadi,Telefonu,Mail,Sehir,KullaniciAdi,Sifre) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox9.Text + "') ";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    DialogResult sonuc;
                    sonuc = MessageBox.Show("ÜYE BİLGİLERİ KAYIT EDİLECEK EMİN MİSİNİZ ? ", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sonuc == DialogResult.Yes)
                    {
                        if (MessageBox.Show("BİLGİLERİNİZ BAŞARIYLA KAYDEDİLMİŞTİR !", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            frmUyeGirisi gecis = new frmUyeGirisi();
                            gecis.Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ZORUNLU ALANLAR BOŞ GEÇİLEMEZ !", "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("BİLİNMEYEN BİR HATA İLE KARŞILAŞILDI !!! \n\n" + "HATA İÇERİĞİ : \n " + hata.Message, "DİKKAT !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            UyeKaydet();           
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmUyeGirisi gecis = new frmUyeGirisi();
            gecis.Show();
            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("PROGRAMDAN ÇIKMAK İSTEDİĞİNİZDEN, EMİN MİSİNİZ ? ", "DİKKAT !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.Yes)
            {
                Application.Exit();
            }
         }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { textBox2.Focus(); }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { textBox3.Focus(); }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { textBox4.Focus(); }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { textBox5.Focus(); }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { textBox6.Focus(); }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { textBox8.Focus(); }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { textBox9.Focus(); }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            { btnKaydet.Focus(); }

        }

        private void frmYeniUyeKayit_KeyDown(object sender, KeyEventArgs e)
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
                    UyeKaydet();
                    break;
                default:
                    break;
            }
            switch (e.KeyData)
            {
                case Keys.F3:
               frmUyeGirisi gecis = new frmUyeGirisi();
               gecis.Show();
              this.Hide();
                    break;
                default:
                    break;
            }
        }
     }
}
