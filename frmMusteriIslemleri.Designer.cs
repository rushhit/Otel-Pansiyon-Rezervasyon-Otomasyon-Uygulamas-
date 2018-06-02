namespace OtelOtomasyonProgrami
{
    partial class frmMusteriIslemleri
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMusteriIslemleri));
            this.MusteriSecGrupbox = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnMuseteriSecGuncelle = new System.Windows.Forms.Button();
            this.ımageList3 = new System.Windows.Forms.ImageList(this.components);
            this.btnCikis = new System.Windows.Forms.Button();
            this.MusteriSec = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAraSoyad = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblVergiNo = new System.Windows.Forms.Label();
            this.txtAraAd = new System.Windows.Forms.TextBox();
            this.txtAraTcKimlikNo = new System.Windows.Forms.TextBox();
            this.lblSirketAdi2 = new System.Windows.Forms.Label();
            this.lblSirketAdi = new System.Windows.Forms.Label();
            this.txtAraMusteriNo = new System.Windows.Forms.TextBox();
            this.txtTCYaz = new System.Windows.Forms.TextBox();
            this.MusteriSecGrupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MusteriSecGrupbox
            // 
            this.MusteriSecGrupbox.Controls.Add(this.dataGridView2);
            this.MusteriSecGrupbox.Location = new System.Drawing.Point(104, 63);
            this.MusteriSecGrupbox.Name = "MusteriSecGrupbox";
            this.MusteriSecGrupbox.Size = new System.Drawing.Size(874, 531);
            this.MusteriSecGrupbox.TabIndex = 127;
            this.MusteriSecGrupbox.TabStop = false;
            this.MusteriSecGrupbox.Text = "Müşteri Bilgileri";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Location = new System.Drawing.Point(1, 15);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Lime;
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(867, 510);
            this.dataGridView2.StandardTab = true;
            this.dataGridView2.TabIndex = 170;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.BackColor = System.Drawing.Color.Wheat;
            this.groupBox8.Controls.Add(this.btnMuseteriSecGuncelle);
            this.groupBox8.Controls.Add(this.btnCikis);
            this.groupBox8.Controls.Add(this.MusteriSec);
            this.groupBox8.Location = new System.Drawing.Point(1, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(101, 630);
            this.groupBox8.TabIndex = 171;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "İşlemler";
            // 
            // btnMuseteriSecGuncelle
            // 
            this.btnMuseteriSecGuncelle.BackColor = System.Drawing.Color.Azure;
            this.btnMuseteriSecGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMuseteriSecGuncelle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMuseteriSecGuncelle.ImageKey = "Actions-tools-check-spelling-icon (1).png";
            this.btnMuseteriSecGuncelle.ImageList = this.ımageList3;
            this.btnMuseteriSecGuncelle.Location = new System.Drawing.Point(10, 180);
            this.btnMuseteriSecGuncelle.Name = "btnMuseteriSecGuncelle";
            this.btnMuseteriSecGuncelle.Size = new System.Drawing.Size(80, 57);
            this.btnMuseteriSecGuncelle.TabIndex = 53;
            this.btnMuseteriSecGuncelle.Tag = "";
            this.btnMuseteriSecGuncelle.Text = "F2-> Seç";
            this.btnMuseteriSecGuncelle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMuseteriSecGuncelle.UseVisualStyleBackColor = false;
            this.btnMuseteriSecGuncelle.Visible = false;
            this.btnMuseteriSecGuncelle.Click += new System.EventHandler(this.btnMuseteriSecGuncelle_Click);
            // 
            // ımageList3
            // 
            this.ımageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList3.ImageStream")));
            this.ımageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList3.Images.SetKeyName(0, "Custom-Icon-Design-Pretty-Office-7-Save.ico");
            this.ımageList3.Images.SetKeyName(1, "Custom-Icon-Design-Pretty-Office-7-Save-as.ico");
            this.ımageList3.Images.SetKeyName(2, "Hopstarter-Button-Button-Add.ico");
            this.ımageList3.Images.SetKeyName(3, "Hopstarter-Button-Button-Delete.ico");
            this.ımageList3.Images.SetKeyName(4, "Hopstarter-Soft-Scraps-Button-Refresh.ico");
            this.ımageList3.Images.SetKeyName(5, "Visualpharm-Icons8-Metro-Style-System-Save.ico");
            this.ımageList3.Images.SetKeyName(6, "Visualpharm-Icons8-Metro-Style-System-Save-as.ico");
            this.ımageList3.Images.SetKeyName(7, "Visualpharm-Must-Have-Delete.ico");
            this.ımageList3.Images.SetKeyName(8, "Button-Add-icon (1).png");
            this.ımageList3.Images.SetKeyName(9, "Button-Add-icon (2).png");
            this.ımageList3.Images.SetKeyName(10, "Button-Add-icon (3).png");
            this.ımageList3.Images.SetKeyName(11, "Button-Add-icon (4).png");
            this.ımageList3.Images.SetKeyName(12, "Button-Add-icon.png");
            this.ımageList3.Images.SetKeyName(13, "Button-Delete-icon (1).png");
            this.ımageList3.Images.SetKeyName(14, "Button-Delete-icon (2).png");
            this.ımageList3.Images.SetKeyName(15, "Button-Delete-icon (3).png");
            this.ımageList3.Images.SetKeyName(16, "Button-Delete-icon (4).png");
            this.ımageList3.Images.SetKeyName(17, "Button-Delete-icon.png");
            this.ımageList3.Images.SetKeyName(18, "Button-Refresh-icon (1).png");
            this.ımageList3.Images.SetKeyName(19, "Button-Refresh-icon (2).png");
            this.ımageList3.Images.SetKeyName(20, "Button-Refresh-icon (3).png");
            this.ımageList3.Images.SetKeyName(21, "Button-Refresh-icon (4).png");
            this.ımageList3.Images.SetKeyName(22, "Button-Refresh-icon (5).png");
            this.ımageList3.Images.SetKeyName(23, "Button-Refresh-icon.png");
            this.ımageList3.Images.SetKeyName(24, "Delete-icon (1).png");
            this.ımageList3.Images.SetKeyName(25, "Delete-icon (2).png");
            this.ımageList3.Images.SetKeyName(26, "Delete-icon.png");
            this.ımageList3.Images.SetKeyName(27, "Save-as-icon (1).png");
            this.ımageList3.Images.SetKeyName(28, "Save-as-icon (2).png");
            this.ımageList3.Images.SetKeyName(29, "Save-as-icon (3).png");
            this.ımageList3.Images.SetKeyName(30, "Save-as-icon (4).png");
            this.ımageList3.Images.SetKeyName(31, "Save-as-icon (5).png");
            this.ımageList3.Images.SetKeyName(32, "Save-as-icon.png");
            this.ımageList3.Images.SetKeyName(33, "Save-icon (1).png");
            this.ımageList3.Images.SetKeyName(34, "Save-icon (2).png");
            this.ımageList3.Images.SetKeyName(35, "Save-icon (3).png");
            this.ımageList3.Images.SetKeyName(36, "Save-icon (4).png");
            this.ımageList3.Images.SetKeyName(37, "Save-icon (5).png");
            this.ımageList3.Images.SetKeyName(38, "Save-icon.png");
            this.ımageList3.Images.SetKeyName(39, "System-Save-as-icon (1).png");
            this.ımageList3.Images.SetKeyName(40, "System-Save-as-icon (2).png");
            this.ımageList3.Images.SetKeyName(41, "System-Save-as-icon (3).png");
            this.ımageList3.Images.SetKeyName(42, "System-Save-as-icon (4).png");
            this.ımageList3.Images.SetKeyName(43, "System-Save-as-icon.png");
            this.ımageList3.Images.SetKeyName(44, "System-Save-icon (1).png");
            this.ımageList3.Images.SetKeyName(45, "System-Save-icon (2).png");
            this.ımageList3.Images.SetKeyName(46, "System-Save-icon (3).png");
            this.ımageList3.Images.SetKeyName(47, "System-Save-icon (4).png");
            this.ımageList3.Images.SetKeyName(48, "System-Save-icon.png");
            this.ımageList3.Images.SetKeyName(49, "Accept-Male-User-icon (1).png");
            this.ımageList3.Images.SetKeyName(50, "Accept-Male-User-icon (2).png");
            this.ımageList3.Images.SetKeyName(51, "Accept-Male-User-icon.png");
            this.ımageList3.Images.SetKeyName(52, "Actions-dialog-ok-icon (1).png");
            this.ımageList3.Images.SetKeyName(53, "Actions-dialog-ok-icon (2).png");
            this.ımageList3.Images.SetKeyName(54, "Actions-dialog-ok-icon (3).png");
            this.ımageList3.Images.SetKeyName(55, "Actions-dialog-ok-icon.png");
            this.ımageList3.Images.SetKeyName(56, "Actions-tools-check-spelling-icon (1).png");
            this.ımageList3.Images.SetKeyName(57, "Actions-tools-check-spelling-icon (2).png");
            this.ımageList3.Images.SetKeyName(58, "Actions-tools-check-spelling-icon (3).png");
            this.ımageList3.Images.SetKeyName(59, "Actions-tools-check-spelling-icon (4).png");
            this.ımageList3.Images.SetKeyName(60, "Actions-tools-check-spelling-icon.png");
            this.ımageList3.Images.SetKeyName(61, "Check-icon (1).png");
            this.ımageList3.Images.SetKeyName(62, "Check-icon (2).png");
            this.ımageList3.Images.SetKeyName(63, "Check-icon (3).png");
            this.ımageList3.Images.SetKeyName(64, "Check-icon (4).png");
            this.ımageList3.Images.SetKeyName(65, "Check-icon (5).png");
            this.ımageList3.Images.SetKeyName(66, "Check-icon.png");
            this.ımageList3.Images.SetKeyName(67, "picture-check-icon (1).png");
            this.ımageList3.Images.SetKeyName(68, "picture-check-icon (2).png");
            this.ımageList3.Images.SetKeyName(69, "picture-check-icon (3).png");
            this.ımageList3.Images.SetKeyName(70, "Sign-Select-icon (1).png");
            this.ımageList3.Images.SetKeyName(71, "Sign-Select-icon (2).png");
            this.ımageList3.Images.SetKeyName(72, "Sign-Select-icon.png");
            this.ımageList3.Images.SetKeyName(73, "symbol-check-icon (1).png");
            this.ımageList3.Images.SetKeyName(74, "symbol-check-icon (2).png");
            this.ımageList3.Images.SetKeyName(75, "symbol-check-icon (3).png");
            this.ımageList3.Images.SetKeyName(76, "symbol-check-icon.png");
            this.ımageList3.Images.SetKeyName(77, "user-check-icon (1).png");
            this.ımageList3.Images.SetKeyName(78, "user-check-icon (2).png");
            this.ımageList3.Images.SetKeyName(79, "user-check-icon (3).png");
            this.ımageList3.Images.SetKeyName(80, "user-check-icon.png");
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Azure;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCikis.ImageKey = "Delete-icon (1).png";
            this.btnCikis.ImageList = this.ımageList3;
            this.btnCikis.Location = new System.Drawing.Point(10, 98);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(80, 57);
            this.btnCikis.TabIndex = 52;
            this.btnCikis.Tag = "656";
            this.btnCikis.Text = "Esc->Çıkış";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // MusteriSec
            // 
            this.MusteriSec.BackColor = System.Drawing.Color.Azure;
            this.MusteriSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MusteriSec.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MusteriSec.ImageKey = "Actions-tools-check-spelling-icon (1).png";
            this.MusteriSec.ImageList = this.ımageList3;
            this.MusteriSec.Location = new System.Drawing.Point(10, 27);
            this.MusteriSec.Name = "MusteriSec";
            this.MusteriSec.Size = new System.Drawing.Size(80, 57);
            this.MusteriSec.TabIndex = 21;
            this.MusteriSec.Tag = "";
            this.MusteriSec.Text = "F2-> Seç";
            this.MusteriSec.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MusteriSec.UseVisualStyleBackColor = false;
            this.MusteriSec.Click += new System.EventHandler(this.MusteriSec_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtAraSoyad);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lblVergiNo);
            this.groupBox4.Controls.Add(this.txtAraAd);
            this.groupBox4.Controls.Add(this.txtAraTcKimlikNo);
            this.groupBox4.Controls.Add(this.lblSirketAdi2);
            this.groupBox4.Controls.Add(this.lblSirketAdi);
            this.groupBox4.Controls.Add(this.txtAraMusteriNo);
            this.groupBox4.Location = new System.Drawing.Point(283, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(456, 55);
            this.groupBox4.TabIndex = 178;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ara";
            // 
            // txtAraSoyad
            // 
            this.txtAraSoyad.Location = new System.Drawing.Point(347, 27);
            this.txtAraSoyad.Name = "txtAraSoyad";
            this.txtAraSoyad.Size = new System.Drawing.Size(100, 20);
            this.txtAraSoyad.TabIndex = 10;
            this.txtAraSoyad.TextChanged += new System.EventHandler(this.txtAraSoyad_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(373, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Soyad";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVergiNo
            // 
            this.lblVergiNo.AutoSize = true;
            this.lblVergiNo.Location = new System.Drawing.Point(274, 11);
            this.lblVergiNo.Name = "lblVergiNo";
            this.lblVergiNo.Size = new System.Drawing.Size(20, 13);
            this.lblVergiNo.TabIndex = 8;
            this.lblVergiNo.Text = "Ad";
            this.lblVergiNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAraAd
            // 
            this.txtAraAd.Location = new System.Drawing.Point(234, 27);
            this.txtAraAd.MaxLength = 11;
            this.txtAraAd.Name = "txtAraAd";
            this.txtAraAd.Size = new System.Drawing.Size(100, 20);
            this.txtAraAd.TabIndex = 7;
            this.txtAraAd.TextChanged += new System.EventHandler(this.txtAraAd_TextChanged);
            // 
            // txtAraTcKimlikNo
            // 
            this.txtAraTcKimlikNo.Location = new System.Drawing.Point(124, 27);
            this.txtAraTcKimlikNo.Name = "txtAraTcKimlikNo";
            this.txtAraTcKimlikNo.Size = new System.Drawing.Size(100, 20);
            this.txtAraTcKimlikNo.TabIndex = 6;
            this.txtAraTcKimlikNo.TextChanged += new System.EventHandler(this.txtAraTcKimlikNo_TextChanged);
            // 
            // lblSirketAdi2
            // 
            this.lblSirketAdi2.AutoSize = true;
            this.lblSirketAdi2.Location = new System.Drawing.Point(137, 11);
            this.lblSirketAdi2.Name = "lblSirketAdi2";
            this.lblSirketAdi2.Size = new System.Drawing.Size(71, 13);
            this.lblSirketAdi2.TabIndex = 5;
            this.lblSirketAdi2.Text = "T.C Kimlik No";
            this.lblSirketAdi2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSirketAdi
            // 
            this.lblSirketAdi.AutoSize = true;
            this.lblSirketAdi.Location = new System.Drawing.Point(38, 11);
            this.lblSirketAdi.Name = "lblSirketAdi";
            this.lblSirketAdi.Size = new System.Drawing.Size(58, 13);
            this.lblSirketAdi.TabIndex = 2;
            this.lblSirketAdi.Text = "Müşteri No";
            this.lblSirketAdi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAraMusteriNo
            // 
            this.txtAraMusteriNo.Location = new System.Drawing.Point(14, 27);
            this.txtAraMusteriNo.MaxLength = 11;
            this.txtAraMusteriNo.Name = "txtAraMusteriNo";
            this.txtAraMusteriNo.Size = new System.Drawing.Size(100, 20);
            this.txtAraMusteriNo.TabIndex = 1;
            this.txtAraMusteriNo.TextChanged += new System.EventHandler(this.txtAraMusteriNo_TextChanged);
            // 
            // txtTCYaz
            // 
            this.txtTCYaz.Location = new System.Drawing.Point(820, 27);
            this.txtTCYaz.Name = "txtTCYaz";
            this.txtTCYaz.Size = new System.Drawing.Size(50, 20);
            this.txtTCYaz.TabIndex = 11;
            this.txtTCYaz.Visible = false;
            // 
            // frmMusteriIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(982, 597);
            this.Controls.Add(this.txtTCYaz);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.MusteriSecGrupbox);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(998, 635);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(998, 635);
            this.Name = "frmMusteriIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Musteri Seç";
            this.Load += new System.EventHandler(this.MusteriIslemleri_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMusteriIslemleri_KeyDown);
            this.MusteriSecGrupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MusteriSecGrupbox;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button MusteriSec;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtAraSoyad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblVergiNo;
        private System.Windows.Forms.TextBox txtAraAd;
        private System.Windows.Forms.TextBox txtAraTcKimlikNo;
        private System.Windows.Forms.Label lblSirketAdi2;
        private System.Windows.Forms.Label lblSirketAdi;
        private System.Windows.Forms.TextBox txtAraMusteriNo;
        private System.Windows.Forms.ImageList ımageList3;
        private System.Windows.Forms.Button btnMuseteriSecGuncelle;
        private System.Windows.Forms.TextBox txtTCYaz;
    }
}