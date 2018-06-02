using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtelOtomasyonProgrami
{
    public partial class frmAnaMenuProgressBarLoading : Form
    {
        public frmMenu frm1;
        public frmKaydet frmKaydet;
        public frmUyeGirisi frmUyeGirisi;
        public frmAnaMenuProgressBarLoading()
        {
            InitializeComponent();
            frmUyeGirisi = new frmUyeGirisi();
            frmUyeGirisi.frmAnaMenuProgressBarLoading = this;
        }

        private void frmAnaMenuProgressBarLoading_Load(object sender, EventArgs e)
        {
            
        }
    }
}
