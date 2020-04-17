namespace KelimeEzberleUI
{
    partial class frmAdminPaneli
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kullaniciIslemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kelimeRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uyeRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciroRaporuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullaniciIslemleriToolStripMenuItem,
            this.raporlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kullaniciIslemleriToolStripMenuItem
            // 
            this.kullaniciIslemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kullaniciListeleToolStripMenuItem});
            this.kullaniciIslemleriToolStripMenuItem.Name = "kullaniciIslemleriToolStripMenuItem";
            this.kullaniciIslemleriToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.kullaniciIslemleriToolStripMenuItem.Text = "Kullanıcı İşlemleri";
            // 
            // kullaniciListeleToolStripMenuItem
            // 
            this.kullaniciListeleToolStripMenuItem.Name = "kullaniciListeleToolStripMenuItem";
            this.kullaniciListeleToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.kullaniciListeleToolStripMenuItem.Text = "Kullanıcı Listele";
            this.kullaniciListeleToolStripMenuItem.Click += new System.EventHandler(this.kullaniciListeleToolStripMenuItem_Click);
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kelimeRaporuToolStripMenuItem,
            this.uyeRaporuToolStripMenuItem,
            this.ciroRaporuToolStripMenuItem});
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            // 
            // kelimeRaporuToolStripMenuItem
            // 
            this.kelimeRaporuToolStripMenuItem.Name = "kelimeRaporuToolStripMenuItem";
            this.kelimeRaporuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.kelimeRaporuToolStripMenuItem.Text = "Kelime Raporu";
            // 
            // uyeRaporuToolStripMenuItem
            // 
            this.uyeRaporuToolStripMenuItem.Name = "uyeRaporuToolStripMenuItem";
            this.uyeRaporuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.uyeRaporuToolStripMenuItem.Text = "Üye Raporu";
            // 
            // ciroRaporuToolStripMenuItem
            // 
            this.ciroRaporuToolStripMenuItem.Name = "ciroRaporuToolStripMenuItem";
            this.ciroRaporuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ciroRaporuToolStripMenuItem.Text = "Ciro Raporu";
            // 
            // frmAdminPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAdminPaneli";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kullaniciIslemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullaniciListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kelimeRaporuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uyeRaporuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciroRaporuToolStripMenuItem;
    }
}

