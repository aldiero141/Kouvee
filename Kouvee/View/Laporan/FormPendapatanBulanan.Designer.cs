namespace Kouvee.View.Laporan
{
    partial class FormPendapatanBulanan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPendapatanBulanan));
            this.panelLaporan = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerYear = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerMonth = new System.Windows.Forms.DateTimePicker();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.adobeReader = new AxAcroPDFLib.AxAcroPDF();
            this.panelSide = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnCetak = new System.Windows.Forms.Button();
            this.buttonKembali = new System.Windows.Forms.Button();
            this.panelLaporan.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adobeReader)).BeginInit();
            this.panelSide.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLaporan
            // 
            this.panelLaporan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(16)))), ((int)(((byte)(144)))));
            this.panelLaporan.Controls.Add(this.panel1);
            this.panelLaporan.Controls.Add(this.label2);
            this.panelLaporan.Controls.Add(this.adobeReader);
            this.panelLaporan.Controls.Add(this.panelSide);
            this.panelLaporan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLaporan.Location = new System.Drawing.Point(0, 0);
            this.panelLaporan.Name = "panelLaporan";
            this.panelLaporan.Size = new System.Drawing.Size(998, 587);
            this.panelLaporan.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(2)))), ((int)(((byte)(63)))));
            this.panel1.Controls.Add(this.dateTimePickerYear);
            this.panel1.Controls.Add(this.dateTimePickerMonth);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 50);
            this.panel1.TabIndex = 16;
            // 
            // dateTimePickerYear
            // 
            this.dateTimePickerYear.Location = new System.Drawing.Point(534, 15);
            this.dateTimePickerYear.Name = "dateTimePickerYear";
            this.dateTimePickerYear.Size = new System.Drawing.Size(73, 20);
            this.dateTimePickerYear.TabIndex = 22;
            // 
            // dateTimePickerMonth
            // 
            this.dateTimePickerMonth.Location = new System.Drawing.Point(455, 15);
            this.dateTimePickerMonth.Name = "dateTimePickerMonth";
            this.dateTimePickerMonth.Size = new System.Drawing.Size(73, 20);
            this.dateTimePickerMonth.TabIndex = 21;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(16)))), ((int)(((byte)(144)))));
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.Silver;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.Location = new System.Drawing.Point(613, 13);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(71, 22);
            this.btnPreview.TabIndex = 20;
            this.btnPreview.Text = "Lihat";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(280, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 29);
            this.label2.TabIndex = 13;
            this.label2.Text = "Pendapatan Bulanan";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // adobeReader
            // 
            this.adobeReader.Enabled = true;
            this.adobeReader.Location = new System.Drawing.Point(131, 41);
            this.adobeReader.Name = "adobeReader";
            this.adobeReader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("adobeReader.OcxState")));
            this.adobeReader.Size = new System.Drawing.Size(553, 490);
            this.adobeReader.TabIndex = 11;
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(5)))), ((int)(((byte)(94)))));
            this.panelSide.Controls.Add(this.panelButton);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSide.Location = new System.Drawing.Point(798, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(200, 587);
            this.panelSide.TabIndex = 8;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnCetak);
            this.panelButton.Controls.Add(this.buttonKembali);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 486);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(200, 101);
            this.panelButton.TabIndex = 1;
            // 
            // btnCetak
            // 
            this.btnCetak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(16)))), ((int)(((byte)(144)))));
            this.btnCetak.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCetak.FlatAppearance.BorderSize = 0;
            this.btnCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCetak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCetak.ForeColor = System.Drawing.Color.Silver;
            this.btnCetak.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCetak.Location = new System.Drawing.Point(0, 1);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnCetak.Size = new System.Drawing.Size(200, 50);
            this.btnCetak.TabIndex = 19;
            this.btnCetak.Text = "Cetak";
            this.btnCetak.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCetak.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // buttonKembali
            // 
            this.buttonKembali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(5)))), ((int)(((byte)(94)))));
            this.buttonKembali.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonKembali.FlatAppearance.BorderSize = 0;
            this.buttonKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKembali.ForeColor = System.Drawing.Color.Silver;
            this.buttonKembali.Location = new System.Drawing.Point(0, 51);
            this.buttonKembali.Name = "buttonKembali";
            this.buttonKembali.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonKembali.Size = new System.Drawing.Size(200, 50);
            this.buttonKembali.TabIndex = 18;
            this.buttonKembali.Text = "Kembali";
            this.buttonKembali.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonKembali.UseVisualStyleBackColor = false;
            this.buttonKembali.Click += new System.EventHandler(this.buttonKembali_Click);
            // 
            // FormPendapatanBulanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 587);
            this.Controls.Add(this.panelLaporan);
            this.Name = "FormPendapatanBulanan";
            this.Text = "FormPendapatanBulanan";
            this.panelLaporan.ResumeLayout(false);
            this.panelLaporan.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adobeReader)).EndInit();
            this.panelSide.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLaporan;
        private AxAcroPDFLib.AxAcroPDF adobeReader;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button buttonKembali;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerYear;
        private System.Windows.Forms.DateTimePicker dateTimePickerMonth;
        private System.Windows.Forms.Button btnPreview;
    }
}