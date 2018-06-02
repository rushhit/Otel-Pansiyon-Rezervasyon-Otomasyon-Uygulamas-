namespace OtelOtomasyonProgrami
{
    partial class frmUyeGirisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUyeGirisi));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKullaniciSifre = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYeniUye = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCikis = new System.Windows.Forms.Button();
            this.ımageList3 = new System.Windows.Forms.ImageList(this.components);
            this.btnGiris = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.txtKullaniciSifre);
            this.groupBox1.Controls.Add(this.txtKullaniciAdi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnYeniUye);
            this.groupBox1.Controls.Add(this.btnCikis);
            this.groupBox1.Controls.Add(this.btnGiris);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 153);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Üye Girişi";
            // 
            // txtKullaniciSifre
            // 
            this.txtKullaniciSifre.Location = new System.Drawing.Point(118, 61);
            this.txtKullaniciSifre.Name = "txtKullaniciSifre";
            this.txtKullaniciSifre.PasswordChar = '*';
            this.txtKullaniciSifre.Size = new System.Drawing.Size(100, 20);
            this.txtKullaniciSifre.TabIndex = 1;
            this.txtKullaniciSifre.Tag = "1";
            this.txtKullaniciSifre.Text = "1";
            this.txtKullaniciSifre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKullaniciSifre_KeyPress);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(118, 24);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(100, 20);
            this.txtKullaniciAdi.TabIndex = 0;
            this.txtKullaniciAdi.Text = "admin";
            this.txtKullaniciAdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKullaniciAdi_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // btnYeniUye
            // 
            this.btnYeniUye.BackColor = System.Drawing.Color.Azure;
            this.btnYeniUye.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniUye.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnYeniUye.ImageKey = "Actions-user-group-new-icon.png";
            this.btnYeniUye.ImageList = this.ımageList1;
            this.btnYeniUye.Location = new System.Drawing.Point(193, 93);
            this.btnYeniUye.Name = "btnYeniUye";
            this.btnYeniUye.Size = new System.Drawing.Size(78, 49);
            this.btnYeniUye.TabIndex = 4;
            this.btnYeniUye.Text = "Yeni Üye";
            this.btnYeniUye.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYeniUye.UseVisualStyleBackColor = false;
            this.btnYeniUye.Click += new System.EventHandler(this.btnYeniUye_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Actions-user-group-delete-icon (1).png");
            this.ımageList1.Images.SetKeyName(1, "Actions-user-group-delete-icon (2).png");
            this.ımageList1.Images.SetKeyName(2, "Actions-user-group-delete-icon.png");
            this.ımageList1.Images.SetKeyName(3, "Actions-user-group-new-icon (1).png");
            this.ımageList1.Images.SetKeyName(4, "Actions-user-group-new-icon.png");
            this.ımageList1.Images.SetKeyName(5, "add-2-icon (1).png");
            this.ımageList1.Images.SetKeyName(6, "add-2-icon.png");
            this.ımageList1.Images.SetKeyName(7, "Add-Folder-icon (1).png");
            this.ımageList1.Images.SetKeyName(8, "Add-Folder-icon.png");
            this.ımageList1.Images.SetKeyName(9, "Add-icon (1).png");
            this.ımageList1.Images.SetKeyName(10, "Add-icon.png");
            this.ımageList1.Images.SetKeyName(11, "Apps-error-icon (1).png");
            this.ımageList1.Images.SetKeyName(12, "Apps-error-icon (2).png");
            this.ımageList1.Images.SetKeyName(13, "Apps-error-icon (3).png");
            this.ımageList1.Images.SetKeyName(14, "Apps-error-icon.png");
            this.ımageList1.Images.SetKeyName(15, "BOOK-icon.png");
            this.ımageList1.Images.SetKeyName(16, "book-open-icon.png");
            this.ımageList1.Images.SetKeyName(17, "books-icon.png");
            this.ımageList1.Images.SetKeyName(18, "check-user-icon (1).png");
            this.ımageList1.Images.SetKeyName(19, "check-user-icon.png");
            this.ımageList1.Images.SetKeyName(20, "Contract-icon (1).png");
            this.ımageList1.Images.SetKeyName(21, "Contract-icon (2).png");
            this.ımageList1.Images.SetKeyName(22, "Contract-icon.png");
            this.ımageList1.Images.SetKeyName(23, "folder-contract-icon (1).png");
            this.ımageList1.Images.SetKeyName(24, "folder-contract-icon (2).png");
            this.ımageList1.Images.SetKeyName(25, "folder-contract-icon.png");
            this.ımageList1.Images.SetKeyName(26, "Folder-Delete-icon (1).png");
            this.ımageList1.Images.SetKeyName(27, "Folder-Delete-icon.png");
            this.ımageList1.Images.SetKeyName(28, "folder-edit-icon (1).png");
            this.ımageList1.Images.SetKeyName(29, "folder-edit-icon.png");
            this.ımageList1.Images.SetKeyName(30, "full-basket-icon (1).png");
            this.ımageList1.Images.SetKeyName(31, "full-basket-icon.png");
            this.ımageList1.Images.SetKeyName(32, "home-icon (1).png");
            this.ımageList1.Images.SetKeyName(33, "home-icon.png");
            this.ımageList1.Images.SetKeyName(34, "house-icon.png");
            this.ımageList1.Images.SetKeyName(35, "Library-icon (1).png");
            this.ımageList1.Images.SetKeyName(36, "Library-icon.png");
            this.ımageList1.Images.SetKeyName(37, "Login-in-icon (1).png");
            this.ımageList1.Images.SetKeyName(38, "Login-in-icon.png");
            this.ımageList1.Images.SetKeyName(39, "Login-out-icon (1).png");
            this.ımageList1.Images.SetKeyName(40, "Login-out-icon.png");
            this.ımageList1.Images.SetKeyName(41, "logout-icon (1).png");
            this.ımageList1.Images.SetKeyName(42, "Log-Out-icon (1).png");
            this.ımageList1.Images.SetKeyName(43, "logout-icon (2).png");
            this.ımageList1.Images.SetKeyName(44, "logout-icon.png");
            this.ımageList1.Images.SetKeyName(45, "Log-Out-icon.png");
            this.ımageList1.Images.SetKeyName(46, "Misc-Home-icon.png");
            this.ımageList1.Images.SetKeyName(47, "shopping-basket-full-icon (1).png");
            this.ımageList1.Images.SetKeyName(48, "shopping-basket-full-icon (2).png");
            this.ımageList1.Images.SetKeyName(49, "shopping-basket-full-icon.png");
            this.ımageList1.Images.SetKeyName(50, "Text-Edit-icon (1).png");
            this.ımageList1.Images.SetKeyName(51, "Text-Edit-icon.png");
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Azure;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCikis.ImageKey = "Delete-icon (1).png";
            this.btnCikis.ImageList = this.ımageList3;
            this.btnCikis.Location = new System.Drawing.Point(109, 93);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(78, 49);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
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
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.Azure;
            this.btnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGiris.ImageKey = "Login-in-icon.png";
            this.btnGiris.ImageList = this.ımageList1;
            this.btnGiris.Location = new System.Drawing.Point(22, 93);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(81, 49);
            this.btnGiris.TabIndex = 2;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // frmUyeGirisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(314, 177);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUyeGirisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üye Girişi";
            this.Load += new System.EventHandler(this.frmUyeGirisi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKullaniciSifre;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYeniUye;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ImageList ımageList3;
    }
}

