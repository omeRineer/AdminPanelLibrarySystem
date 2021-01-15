namespace KütüphaneSistemi
{
    partial class GirisPaneli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisPaneli));
            this.btnKullanici = new System.Windows.Forms.Button();
            this.btnYonetici = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKullanici
            // 
            this.btnKullanici.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKullanici.BackgroundImage")));
            this.btnKullanici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKullanici.Location = new System.Drawing.Point(12, 12);
            this.btnKullanici.Name = "btnKullanici";
            this.btnKullanici.Size = new System.Drawing.Size(157, 145);
            this.btnKullanici.TabIndex = 0;
            this.btnKullanici.UseVisualStyleBackColor = true;
            this.btnKullanici.Click += new System.EventHandler(this.btnKullanici_Click);
            // 
            // btnYonetici
            // 
            this.btnYonetici.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYonetici.BackgroundImage")));
            this.btnYonetici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYonetici.Location = new System.Drawing.Point(13, 163);
            this.btnYonetici.Name = "btnYonetici";
            this.btnYonetici.Size = new System.Drawing.Size(156, 145);
            this.btnYonetici.TabIndex = 1;
            this.btnYonetici.UseVisualStyleBackColor = true;
            this.btnYonetici.Click += new System.EventHandler(this.btnYonetici_Click);
            // 
            // GirisPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(179, 319);
            this.Controls.Add(this.btnYonetici);
            this.Controls.Add(this.btnKullanici);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GirisPaneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris Paneli";
            this.Load += new System.EventHandler(this.GirisPaneli_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GirisPaneli_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GirisPaneli_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GirisPaneli_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKullanici;
        private System.Windows.Forms.Button btnYonetici;
    }
}