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
    public partial class frmUyeGirisi : Form
    {
        public frmMenu frm1;
        public frmAnaMenuProgressBarLoading frmAnaMenuProgressBarLoading;
        public frmUyeGirisi()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            OleDbConnection erisim = new OleDbConnection();
            if (erisim.State == ConnectionState.Closed)
            {
                erisim.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\vt.mdb");
                erisim.Open();
            }

            OleDbCommand komut = new OleDbCommand("select KullaniciAdi from Kullanicilar where  KullaniciAdi='" + txtKullaniciAdi.Text + "' and Sifre='" + txtKullaniciSifre.Text + "'", erisim);
            string donen = Convert.ToString(komut.ExecuteScalar());
            erisim.Close();
            if (donen == "")
            {

                MessageBox.Show("KULLANICI ADI VEYA ŞİFRE YANLIŞ !!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Clear();
                txtKullaniciSifre.Clear();

            }
            else
            {
                this.Hide();
                frmMenu digerformagec = new frmMenu();
                digerformagec.Show(); 
            }
        }

        private void btnYeniUye_Click(object sender, EventArgs e)
        {
            frmYeniUyeKayit gec = new frmYeniUyeKayit();
            gec.Show();
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

        private void txtKullaniciAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            { txtKullaniciSifre.Focus(); }
        }

        private void txtKullaniciSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                OleDbConnection erisim = new OleDbConnection();
                if (erisim.State == ConnectionState.Closed)
                {
                    erisim.ConnectionString = ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\bin\\Debug\vt.mdb");
                    erisim.Open();
                }

                OleDbCommand komut = new OleDbCommand("select KullaniciAdi from Kullanicilar where  KullaniciAdi='" + txtKullaniciAdi.Text + "' and Sifre='" + txtKullaniciSifre.Text + "'", erisim);
                string donen = Convert.ToString(komut.ExecuteScalar());
                erisim.Close();
                if (donen == "")
                {

                    MessageBox.Show("Kullanıcı Adı veya Şifreniz Yanlış !!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKullaniciAdi.Clear();
                    txtKullaniciSifre.Clear();
                    txtKullaniciAdi.Focus();

                }
                else
                {
                    this.Hide();
                    frmMenu digerformagec = new frmMenu();
                    digerformagec.Show();
                    
                }
            }
        }

        private void frmUyeGirisi_Load(object sender, EventArgs e)
        {
            
        }

    }
}
