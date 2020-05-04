﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using Kouvee.Control;
using Kouvee.Exceptions;
using Kouvee.Models;
using Kouvee.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kouvee.View.Transaksi.Pembayaran
{
    public partial class FormPembayaranProduk : Form
    {
        TransaksiProduk transaksiProduk;
        TransaksiProduk notaProduk;

        int diskon;
        int subtotal;
        int totalHarga;
        int kembalian;
        string NamaCS;
        string NamaPelanggan;
        string NamaKasir;
        string NamaHewan;
        string NoTelp;
        string Jenis_Hewan;

        public FormPembayaranProduk()
        {
            InitializeComponent();
            SetInitForm();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            var list = new TransaksiProdukControl();
            try
            {
                if (txtCari.Text != null && list.SearchTransaksiProduk(txtCari.Text) != null)
                {
                    transaksiProduk = list.SearchTransaksiProduk(txtCari.Text);
                    notaProduk = list.ShowNotaProduk(txtCari.Text);

                    NamaPelanggan = notaProduk.Nama_Pelanggan;
                    NamaHewan = notaProduk.Nama_Hewan;
                    NamaCS = notaProduk.Nama_CS;
                    NamaKasir = notaProduk.Nama_Kasir;
                    NoTelp = notaProduk.Nomor_Telpon;
                    Jenis_Hewan = notaProduk.Jenis_Hewan;
                    if (transaksiProduk.Status_Transaksi_Produk == 1)
                    {
                        txtNomorTransaksi.Text = transaksiProduk.ID_Transaksi_Produk;
                        txtNamaHewan.Text = transaksiProduk.Nama_Hewan;
                        txtNamaPelanggan.Text = transaksiProduk.Nama_Pelanggan;
                        txtStatusBayar.Text = "Lunas";
                        txtSubtotal.Text = Convert.ToString(transaksiProduk.Subtotal_Transaksi_Produk);
                        txtDiskon.Text = Convert.ToString(transaksiProduk.Diskon_Produk);
                        txtTotalHarga.Text = Convert.ToString(transaksiProduk.Total_Transaksi_Produk);
                        buttonCetak.Enabled = true;
                        MessageBox.Show("Transaksi Sudah Lunas!");
                    }
                    else
                    {
                        buttonHitungTotal.Enabled = true;
                        txtDiskon.Enabled = true;
                        subtotal = transaksiProduk.Subtotal_Transaksi_Produk;
                        txtNomorTransaksi.Text = transaksiProduk.ID_Transaksi_Produk;
                        txtNamaHewan.Text = transaksiProduk.Nama_Hewan;
                        txtNamaPelanggan.Text = transaksiProduk.Nama_Pelanggan;
                        txtSubtotal.Text = Convert.ToString(transaksiProduk.Subtotal_Transaksi_Produk);
                        txtStatusBayar.Text = "Belum Lunas";
                    }
                }
                else
                {
                    MessageBox.Show("Pencarian Tidak Ditemukan!");
                    txtCari.Text = string.Empty;
                    throw null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void buttonHitungTotal_Click(object sender, EventArgs e)
        {
            var ctrl = new TransaksiProdukControl();
            try
            {
                if (string.IsNullOrEmpty(txtDiskon.Text.Trim()))
                {
                    MessageBox.Show("Diskon Tidak Boleh Kosong!");
                    throw null;
                }
                ValidateNumberOnly(txtDiskon.Text);

                if (subtotal < Int32.Parse(txtDiskon.Text))
                {
                    MessageBox.Show("Diskon Melebihi Subtotal Harga!");
                    txtDiskon.Text = string.Empty;
                    throw null;
                }
                diskon = Int32.Parse(txtDiskon.Text);
                totalHarga = subtotal - Int32.Parse(txtDiskon.Text);
                txtTotalHarga.Text = Convert.ToString(totalHarga);
                MessageBox.Show("Diskon telah ditambahkan!");
                txtDiskon.Enabled = false;
                txtJumlahBayar.Enabled = true;
                buttonHitungTotal.Enabled = false;
                buttonBayar.Enabled = true;
            }
            catch (NumberOnlyException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void buttonBayar_Click(object sender, EventArgs e)
        {
            int status;
            var ctrl = new TransaksiProdukControl();
            try
            {
                if (string.IsNullOrEmpty(txtJumlahBayar.Text.Trim()))
                {
                    MessageBox.Show("Diskon Tidak Boleh Kosong!");
                    throw null;
                }
                ValidateNumberOnly(txtJumlahBayar.Text);

                if (totalHarga > Int32.Parse(txtJumlahBayar.Text))
                {
                    MessageBox.Show("Uang untuk Pembayaran Kurang!");
                    txtJumlahBayar.Text = string.Empty;
                    throw null;
                }
                status = 1;
                kembalian = Int32.Parse(txtJumlahBayar.Text) - totalHarga;
                txtKembalian.Text = Convert.ToString(kembalian);
                transaksiProduk = new TransaksiProduk(status, totalHarga, diskon, FormLogin.id_pegawai);
                ctrl.UpdatePembayaranProduk(transaksiProduk, txtCari.Text);
                MessageBox.Show("Pembayaran Berhasil!");
                txtJumlahBayar.Enabled = false;
                buttonBayar.Enabled = false;
                buttonCetak.Enabled = true;
            }
            catch (NumberOnlyException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            var boldFont = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
            var boldBig = FontFactory.GetFont(FontFactory.TIMES_BOLD, 14);
            var normalFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12);

            var pdfDoc = new Document(PageSize.A4, 40f, 40f, 60f, 60f);
            string path = "E:\\";
            PdfWriter.GetInstance(pdfDoc, new FileStream(path + "/NotaLunasProduk.pdf", FileMode.OpenOrCreate));
            pdfDoc.Open();

            var imagepath = @"E:\KPS.PNG";
            var png = iTextSharp.text.Image.GetInstance(imagepath);
            png.ScalePercent(87f);
            pdfDoc.Add(png);

            var spacer = new Paragraph("")
            {
                SpacingAfter = 10f,
                SpacingBefore = 10f,
            };
            pdfDoc.Add(spacer);

            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(p);
            Paragraph title = new Paragraph("Nota Lunas", boldBig);
            title.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(title);
            pdfDoc.Add(p);
            pdfDoc.Add(spacer);

            Paragraph tgl = new Paragraph(Convert.ToString(DateTime.Now));
            tgl.Alignment = Element.ALIGN_RIGHT;
            pdfDoc.Add(tgl);


            Paragraph nomorTransaksi = new Paragraph(txtNomorTransaksi.Text);
            nomorTransaksi.Alignment = Element.ALIGN_LEFT;
            pdfDoc.Add(nomorTransaksi);
            pdfDoc.Add(spacer);

            Chunk c1 = new Chunk("Member       : " + NamaPelanggan + " (" + NamaHewan + " - " + Jenis_Hewan + ")", normalFont);
            Chunk c2 = new Chunk("\nTelepon       : " + NoTelp, normalFont);
            Phrase p1 = new Phrase();
            p1.Add(c1);
            p1.Add(c2);

            Chunk c3 = new Chunk("\n\nNama CS       : " + NamaCS, normalFont);
            Chunk c4 = new Chunk("\nNama Kasir   : " + NamaKasir, normalFont);
            Phrase p2 = new Phrase();
            p2.Add(c3);
            p2.Add(c4);

            Paragraph dataPembeli = new Paragraph();
            dataPembeli.Add(p1);
            dataPembeli.Add(p2);
            pdfDoc.Add(dataPembeli);
            pdfDoc.Add(spacer);

            pdfDoc.Add(p);
            Paragraph subtitle = new Paragraph("Produk", boldBig);
            subtitle.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(subtitle);
            pdfDoc.Add(p);
            pdfDoc.Add(spacer);

            PdfPTable table = new PdfPTable(5);
            //actual width of table in points
            table.TotalWidth = 500f;
            //fix the absolute width of the table
            table.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widths = new float[] { 3f, 12f, 12f, 8f, 12f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 1;
            //leave a gap before and after the table
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            PdfPCell cell = new PdfPCell();
            cell.Colspan = 5;
            cell.Border = 0;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell("No");
            table.AddCell("Nama Produk");
            table.AddCell("Harga");
            table.AddCell("Jumlah");
            table.AddCell("Sub Total");

            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            using (MySqlConnection conn = new MySqlConnection(connect))
            {
                string query = "SELECT P.NAMA_PRODUK, P.HARGA_JUAL, D.JUMLAH_PRODUK, D.SUB_TOTAL_PRODUK " +
                "FROM detil_transaksi_produk D " +
                "JOIN produk P ON (D.ID_PRODUK = P.ID_PRODUK) " +
                "WHERE ID_TRANSAKSI_PRODUK = '" + txtCari.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    int i = 0;
                    conn.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            i++;
                            table.AddCell(Convert.ToString(i));
                            table.AddCell(rdr[0].ToString());
                            table.AddCell("Rp. " + rdr[1].ToString());
                            table.AddCell(rdr[2].ToString());
                            table.AddCell("Rp. " + rdr[3].ToString());
                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            pdfDoc.Add(table);



            Chunk c5 = new Chunk("Sub Total    : Rp. " + Convert.ToString(txtSubtotal.Text), normalFont);
            Chunk c6 = new Chunk("\n\nDiskon     : Rp. " + Convert.ToString(txtDiskon.Text), normalFont);
            Chunk c7 = new Chunk("\n\nTotal      : Rp. " + Convert.ToString(txtTotalHarga.Text), boldFont);
            Phrase p3 = new Phrase();
            p3.Add(c5);
            p3.Add(c6);
            p3.Add(c7);
            Paragraph datapembayaran = new Paragraph();
            datapembayaran.Add(p3);
            datapembayaran.Alignment = Element.ALIGN_RIGHT;
            pdfDoc.Add(datapembayaran);
            pdfDoc.Add(spacer);
            pdfDoc.Close();
            MessageBox.Show("Nota Pembayaran telah dicetak!");
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetInitForm()
        {
            txtNomorTransaksi.Enabled = false;
            txtNamaHewan.Enabled = false;
            txtNamaPelanggan.Enabled = false;
            txtStatusBayar.Enabled = false;
            txtTotalHarga.Enabled = false;
            txtSubtotal.Enabled = false;
            txtDiskon.Enabled = false;
            txtJumlahBayar.Enabled = false;
            txtKembalian.Enabled = false;
            buttonCetak.Enabled = false;
            buttonBayar.Enabled = false;
            buttonHitungTotal.Enabled = false;
        }

        private void ValidateNumberOnly(String number)
        {
            if (!Regex.Match(number, @"^[0-9]+$").Success)
            {
                throw (new NumberOnlyException());
            }
        }
    }
}