namespace Kouvee
{
    partial class MainForm
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
            this.panelJudul = new System.Windows.Forms.Panel();
            this.labelJudul = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnUkuranHewan = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnPegawai = new System.Windows.Forms.Button();
            this.btnProduk = new System.Windows.Forms.Button();
            this.btnLayanan = new System.Windows.Forms.Button();
            this.btnJenisHewan = new System.Windows.Forms.Button();
            this.btnHewan = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.panelAksi = new System.Windows.Forms.Panel();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridRead = new System.Windows.Forms.DataGridView();
            this.panelInputan = new System.Windows.Forms.Panel();
            this.labelPanelInputan = new System.Windows.Forms.Label();
            this.panelJudul.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelAksi.SuspendLayout();
            this.panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRead)).BeginInit();
            this.panelInputan.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelJudul
            // 
            this.panelJudul.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelJudul.BackColor = System.Drawing.Color.Silver;
            this.panelJudul.Controls.Add(this.labelJudul);
            this.panelJudul.Location = new System.Drawing.Point(12, 12);
            this.panelJudul.Name = "panelJudul";
            this.panelJudul.Size = new System.Drawing.Size(1363, 81);
            this.panelJudul.TabIndex = 0;
            // 
            // labelJudul
            // 
            this.labelJudul.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelJudul.AutoSize = true;
            this.labelJudul.Font = new System.Drawing.Font("Forte", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJudul.Location = new System.Drawing.Point(27, 20);
            this.labelJudul.Name = "labelJudul";
            this.labelJudul.Size = new System.Drawing.Size(124, 38);
            this.labelJudul.TabIndex = 0;
            this.labelJudul.Text = "Kouvee";
            this.labelJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.BackColor = System.Drawing.Color.Gray;
            this.panelMenu.Controls.Add(this.btnUkuranHewan);
            this.panelMenu.Controls.Add(this.btnSupplier);
            this.panelMenu.Controls.Add(this.btnPegawai);
            this.panelMenu.Controls.Add(this.btnProduk);
            this.panelMenu.Controls.Add(this.btnLayanan);
            this.panelMenu.Controls.Add(this.btnJenisHewan);
            this.panelMenu.Controls.Add(this.btnHewan);
            this.panelMenu.Controls.Add(this.btnCustomer);
            this.panelMenu.Location = new System.Drawing.Point(12, 99);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(164, 457);
            this.panelMenu.TabIndex = 1;
            // 
            // btnUkuranHewan
            // 
            this.btnUkuranHewan.Location = new System.Drawing.Point(14, 177);
            this.btnUkuranHewan.Name = "btnUkuranHewan";
            this.btnUkuranHewan.Size = new System.Drawing.Size(137, 49);
            this.btnUkuranHewan.TabIndex = 7;
            this.btnUkuranHewan.Text = "Data Ukuran Hewan";
            this.btnUkuranHewan.UseVisualStyleBackColor = true;
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(14, 397);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(137, 49);
            this.btnSupplier.TabIndex = 6;
            this.btnSupplier.Text = "Data Supplier";
            this.btnSupplier.UseVisualStyleBackColor = true;
            // 
            // btnPegawai
            // 
            this.btnPegawai.Location = new System.Drawing.Point(14, 342);
            this.btnPegawai.Name = "btnPegawai";
            this.btnPegawai.Size = new System.Drawing.Size(137, 49);
            this.btnPegawai.TabIndex = 5;
            this.btnPegawai.Text = "Data Pegawai";
            this.btnPegawai.UseVisualStyleBackColor = true;
            this.btnPegawai.Click += new System.EventHandler(this.btnPegawai_Click);
            // 
            // btnProduk
            // 
            this.btnProduk.Location = new System.Drawing.Point(14, 232);
            this.btnProduk.Name = "btnProduk";
            this.btnProduk.Size = new System.Drawing.Size(137, 49);
            this.btnProduk.TabIndex = 4;
            this.btnProduk.Text = "Data Produk";
            this.btnProduk.UseVisualStyleBackColor = true;
            // 
            // btnLayanan
            // 
            this.btnLayanan.Location = new System.Drawing.Point(14, 287);
            this.btnLayanan.Name = "btnLayanan";
            this.btnLayanan.Size = new System.Drawing.Size(137, 49);
            this.btnLayanan.TabIndex = 3;
            this.btnLayanan.Text = "Data Layanan";
            this.btnLayanan.UseVisualStyleBackColor = true;
            // 
            // btnJenisHewan
            // 
            this.btnJenisHewan.Location = new System.Drawing.Point(14, 122);
            this.btnJenisHewan.Name = "btnJenisHewan";
            this.btnJenisHewan.Size = new System.Drawing.Size(137, 49);
            this.btnJenisHewan.TabIndex = 2;
            this.btnJenisHewan.Text = "Data Jenis Hewan";
            this.btnJenisHewan.UseVisualStyleBackColor = true;
            // 
            // btnHewan
            // 
            this.btnHewan.Location = new System.Drawing.Point(14, 67);
            this.btnHewan.Name = "btnHewan";
            this.btnHewan.Size = new System.Drawing.Size(137, 49);
            this.btnHewan.TabIndex = 1;
            this.btnHewan.Text = "Data Hewan";
            this.btnHewan.UseVisualStyleBackColor = true;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(14, 12);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(137, 49);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Data Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // panelAksi
            // 
            this.panelAksi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelAksi.BackColor = System.Drawing.Color.Gray;
            this.panelAksi.Controls.Add(this.btnHapus);
            this.panelAksi.Controls.Add(this.btnUpdate);
            this.panelAksi.Controls.Add(this.btnRead);
            this.panelAksi.Controls.Add(this.btnCreate);
            this.panelAksi.Location = new System.Drawing.Point(182, 514);
            this.panelAksi.Name = "panelAksi";
            this.panelAksi.Size = new System.Drawing.Size(595, 42);
            this.panelAksi.TabIndex = 2;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(513, 6);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 29);
            this.btnHapus.TabIndex = 8;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(432, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(351, 6);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 29);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Tampil";
            this.btnRead.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(270, 6);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 29);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Tambah";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(14, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Cari";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // panelData
            // 
            this.panelData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelData.BackColor = System.Drawing.Color.Gray;
            this.panelData.Controls.Add(this.btnSearch);
            this.panelData.Controls.Add(this.textBox1);
            this.panelData.Controls.Add(this.dataGridRead);
            this.panelData.Location = new System.Drawing.Point(783, 99);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(592, 457);
            this.panelData.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(481, 29);
            this.textBox1.TabIndex = 5;
            // 
            // dataGridRead
            // 
            this.dataGridRead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRead.Location = new System.Drawing.Point(14, 41);
            this.dataGridRead.Name = "dataGridRead";
            this.dataGridRead.Size = new System.Drawing.Size(562, 405);
            this.dataGridRead.TabIndex = 0;
            this.dataGridRead.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRead_CellContentClick);
            // 
            // panelInputan
            // 
            this.panelInputan.BackColor = System.Drawing.Color.Gray;
            this.panelInputan.Controls.Add(this.labelPanelInputan);
            this.panelInputan.Location = new System.Drawing.Point(182, 99);
            this.panelInputan.Name = "panelInputan";
            this.panelInputan.Size = new System.Drawing.Size(595, 409);
            this.panelInputan.TabIndex = 4;
            // 
            // labelPanelInputan
            // 
            this.labelPanelInputan.AutoSize = true;
            this.labelPanelInputan.Location = new System.Drawing.Point(14, 12);
            this.labelPanelInputan.Name = "labelPanelInputan";
            this.labelPanelInputan.Size = new System.Drawing.Size(30, 13);
            this.labelPanelInputan.TabIndex = 0;
            this.labelPanelInputan.Text = "Data";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1387, 568);
            this.Controls.Add(this.panelInputan);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelAksi);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelJudul);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MainForm";
            this.Text = "Kouvee";
            this.panelJudul.ResumeLayout(false);
            this.panelJudul.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelAksi.ResumeLayout(false);
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRead)).EndInit();
            this.panelInputan.ResumeLayout(false);
            this.panelInputan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelJudul;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelAksi;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Label labelJudul;
        private System.Windows.Forms.Button btnUkuranHewan;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnPegawai;
        private System.Windows.Forms.Button btnProduk;
        private System.Windows.Forms.Button btnLayanan;
        private System.Windows.Forms.Button btnJenisHewan;
        private System.Windows.Forms.Button btnHewan;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridRead;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panelInputan;
        private System.Windows.Forms.Label labelPanelInputan;
    }
}

