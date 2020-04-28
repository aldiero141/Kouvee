namespace Kouvee.View.Transaksi.Layanan
{
    partial class FormTampilTransaksiLayanan
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
            this.panelMenuTampil = new System.Windows.Forms.Panel();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.buttonTampilKembali = new System.Windows.Forms.Button();
            this.buttonDetilTransaksi = new System.Windows.Forms.Button();
            this.buttonTransaksi = new System.Windows.Forms.Button();
            this.panelTitleTampil = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCariData = new System.Windows.Forms.Panel();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.panelTampilData = new System.Windows.Forms.Panel();
            this.dataGridViewTampil = new System.Windows.Forms.DataGridView();
            this.panelMenuTampil.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.panelTitleTampil.SuspendLayout();
            this.panelCariData.SuspendLayout();
            this.panelTampilData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTampil)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenuTampil
            // 
            this.panelMenuTampil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(4)))), ((int)(((byte)(69)))));
            this.panelMenuTampil.Controls.Add(this.panelCommand);
            this.panelMenuTampil.Controls.Add(this.buttonDetilTransaksi);
            this.panelMenuTampil.Controls.Add(this.buttonTransaksi);
            this.panelMenuTampil.Controls.Add(this.panelTitleTampil);
            this.panelMenuTampil.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMenuTampil.Location = new System.Drawing.Point(798, 0);
            this.panelMenuTampil.Name = "panelMenuTampil";
            this.panelMenuTampil.Size = new System.Drawing.Size(200, 587);
            this.panelMenuTampil.TabIndex = 1;
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.buttonTampilKembali);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 479);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Size = new System.Drawing.Size(200, 108);
            this.panelCommand.TabIndex = 11;
            // 
            // buttonTampilKembali
            // 
            this.buttonTampilKembali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(2)))), ((int)(((byte)(63)))));
            this.buttonTampilKembali.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonTampilKembali.FlatAppearance.BorderSize = 0;
            this.buttonTampilKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTampilKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTampilKembali.ForeColor = System.Drawing.Color.Silver;
            this.buttonTampilKembali.Location = new System.Drawing.Point(0, 58);
            this.buttonTampilKembali.Name = "buttonTampilKembali";
            this.buttonTampilKembali.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonTampilKembali.Size = new System.Drawing.Size(200, 50);
            this.buttonTampilKembali.TabIndex = 18;
            this.buttonTampilKembali.Text = "Kembali";
            this.buttonTampilKembali.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTampilKembali.UseVisualStyleBackColor = false;
            this.buttonTampilKembali.Click += new System.EventHandler(this.buttonTampilKembali_Click);
            // 
            // buttonDetilTransaksi
            // 
            this.buttonDetilTransaksi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(16)))), ((int)(((byte)(144)))));
            this.buttonDetilTransaksi.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDetilTransaksi.FlatAppearance.BorderSize = 0;
            this.buttonDetilTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDetilTransaksi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDetilTransaksi.ForeColor = System.Drawing.Color.Silver;
            this.buttonDetilTransaksi.Location = new System.Drawing.Point(0, 120);
            this.buttonDetilTransaksi.Name = "buttonDetilTransaksi";
            this.buttonDetilTransaksi.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonDetilTransaksi.Size = new System.Drawing.Size(200, 50);
            this.buttonDetilTransaksi.TabIndex = 10;
            this.buttonDetilTransaksi.Text = "Detil Transaksi";
            this.buttonDetilTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDetilTransaksi.UseVisualStyleBackColor = false;
            this.buttonDetilTransaksi.Click += new System.EventHandler(this.buttonDetilTransaksi_Click);
            // 
            // buttonTransaksi
            // 
            this.buttonTransaksi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(5)))), ((int)(((byte)(94)))));
            this.buttonTransaksi.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTransaksi.FlatAppearance.BorderSize = 0;
            this.buttonTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTransaksi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransaksi.ForeColor = System.Drawing.Color.Silver;
            this.buttonTransaksi.Location = new System.Drawing.Point(0, 70);
            this.buttonTransaksi.Name = "buttonTransaksi";
            this.buttonTransaksi.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonTransaksi.Size = new System.Drawing.Size(200, 50);
            this.buttonTransaksi.TabIndex = 9;
            this.buttonTransaksi.Text = "Transaksi";
            this.buttonTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTransaksi.UseVisualStyleBackColor = false;
            this.buttonTransaksi.Click += new System.EventHandler(this.buttonTransaksi_Click);
            // 
            // panelTitleTampil
            // 
            this.panelTitleTampil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(2)))), ((int)(((byte)(63)))));
            this.panelTitleTampil.Controls.Add(this.label1);
            this.panelTitleTampil.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleTampil.Location = new System.Drawing.Point(0, 0);
            this.panelTitleTampil.Name = "panelTitleTampil";
            this.panelTitleTampil.Size = new System.Drawing.Size(200, 70);
            this.panelTitleTampil.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaksi Layanan";
            // 
            // panelCariData
            // 
            this.panelCariData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(1)))), ((int)(((byte)(42)))));
            this.panelCariData.Controls.Add(this.txtCari);
            this.panelCariData.Controls.Add(this.btnCari);
            this.panelCariData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCariData.Location = new System.Drawing.Point(0, 565);
            this.panelCariData.Name = "panelCariData";
            this.panelCariData.Size = new System.Drawing.Size(798, 22);
            this.panelCariData.TabIndex = 2;
            // 
            // txtCari
            // 
            this.txtCari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCari.Location = new System.Drawing.Point(0, 0);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(740, 22);
            this.txtCari.TabIndex = 2;
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(5)))), ((int)(((byte)(94)))));
            this.btnCari.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCari.FlatAppearance.BorderSize = 0;
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.ForeColor = System.Drawing.Color.Silver;
            this.btnCari.Location = new System.Drawing.Point(740, 0);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(58, 22);
            this.btnCari.TabIndex = 1;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // panelTampilData
            // 
            this.panelTampilData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(22)))), ((int)(((byte)(115)))));
            this.panelTampilData.Controls.Add(this.dataGridViewTampil);
            this.panelTampilData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTampilData.Location = new System.Drawing.Point(0, 0);
            this.panelTampilData.Name = "panelTampilData";
            this.panelTampilData.Size = new System.Drawing.Size(798, 565);
            this.panelTampilData.TabIndex = 3;
            // 
            // dataGridViewTampil
            // 
            this.dataGridViewTampil.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(2)))), ((int)(((byte)(63)))));
            this.dataGridViewTampil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTampil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTampil.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridViewTampil.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTampil.Name = "dataGridViewTampil";
            this.dataGridViewTampil.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewTampil.Size = new System.Drawing.Size(798, 565);
            this.dataGridViewTampil.TabIndex = 0;
            // 
            // FormTampilTransaksiLayanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 587);
            this.Controls.Add(this.panelTampilData);
            this.Controls.Add(this.panelCariData);
            this.Controls.Add(this.panelMenuTampil);
            this.Name = "FormTampilTransaksiLayanan";
            this.Text = "FormTampilTransaksiLayanan";
            this.Load += new System.EventHandler(this.FormTampilTransaksiLayanan_Load);
            this.panelMenuTampil.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.panelTitleTampil.ResumeLayout(false);
            this.panelTitleTampil.PerformLayout();
            this.panelCariData.ResumeLayout(false);
            this.panelCariData.PerformLayout();
            this.panelTampilData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTampil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuTampil;
        private System.Windows.Forms.Button buttonDetilTransaksi;
        private System.Windows.Forms.Button buttonTransaksi;
        private System.Windows.Forms.Panel panelTitleTampil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCariData;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Panel panelTampilData;
        private System.Windows.Forms.DataGridView dataGridViewTampil;
        private System.Windows.Forms.Panel panelCommand;
        private System.Windows.Forms.Button buttonTampilKembali;
    }
}