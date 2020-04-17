namespace KelimeEzberleUI
{
    partial class frmKullaniciListele
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
            this.cmbKullanicilar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsIslemler = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasifleştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktifleştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvKullanicilar = new System.Windows.Forms.DataGridView();
            this.cmsIslemler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKullanicilar
            // 
            this.cmbKullanicilar.FormattingEnabled = true;
            this.cmbKullanicilar.Location = new System.Drawing.Point(28, 36);
            this.cmbKullanicilar.Name = "cmbKullanicilar";
            this.cmbKullanicilar.Size = new System.Drawing.Size(315, 24);
            this.cmbKullanicilar.TabIndex = 0;
            this.cmbKullanicilar.SelectedIndexChanged += new System.EventHandler(this.cmbKullanicilar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Görüntülemek istediğiniz kullanıcı listesini seçiniz.";
            // 
            // cmsIslemler
            // 
            this.cmsIslemler.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsIslemler.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silToolStripMenuItem,
            this.güncelleToolStripMenuItem,
            this.pasifleştirToolStripMenuItem,
            this.aktifleştirToolStripMenuItem});
            this.cmsIslemler.Name = "cmsPasifli";
            this.cmsIslemler.Size = new System.Drawing.Size(211, 128);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // güncelleToolStripMenuItem
            // 
            this.güncelleToolStripMenuItem.Name = "güncelleToolStripMenuItem";
            this.güncelleToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.güncelleToolStripMenuItem.Text = "Güncelle";
            this.güncelleToolStripMenuItem.Click += new System.EventHandler(this.güncelleToolStripMenuItem_Click);
            // 
            // pasifleştirToolStripMenuItem
            // 
            this.pasifleştirToolStripMenuItem.Name = "pasifleştirToolStripMenuItem";
            this.pasifleştirToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.pasifleştirToolStripMenuItem.Text = "Pasifleştir";
            this.pasifleştirToolStripMenuItem.Click += new System.EventHandler(this.pasifleştirToolStripMenuItem_Click);
            // 
            // aktifleştirToolStripMenuItem
            // 
            this.aktifleştirToolStripMenuItem.Name = "aktifleştirToolStripMenuItem";
            this.aktifleştirToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.aktifleştirToolStripMenuItem.Text = "Aktifleştir";
            this.aktifleştirToolStripMenuItem.Click += new System.EventHandler(this.aktifleştirToolStripMenuItem_Click);
            // 
            // dgvKullanicilar
            // 
            this.dgvKullanicilar.AllowUserToAddRows = false;
            this.dgvKullanicilar.AllowUserToDeleteRows = false;
            this.dgvKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKullanicilar.ContextMenuStrip = this.cmsIslemler;
            this.dgvKullanicilar.Location = new System.Drawing.Point(28, 107);
            this.dgvKullanicilar.MultiSelect = false;
            this.dgvKullanicilar.Name = "dgvKullanicilar";
            this.dgvKullanicilar.ReadOnly = true;
            this.dgvKullanicilar.RowHeadersWidth = 51;
            this.dgvKullanicilar.RowTemplate.Height = 24;
            this.dgvKullanicilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKullanicilar.Size = new System.Drawing.Size(760, 331);
            this.dgvKullanicilar.TabIndex = 2;
            // 
            // frmKullaniciListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvKullanicilar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKullanicilar);
            this.Name = "frmKullaniciListele";
            this.Text = "frmKullaniciListele";
            this.Load += new System.EventHandler(this.frmKullaniciListele_Load);
            this.cmsIslemler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKullanicilar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsIslemler;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasifleştirToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvKullanicilar;
        private System.Windows.Forms.ToolStripMenuItem aktifleştirToolStripMenuItem;
    }
}