using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace Kouvee.View.Laporan
{
    public partial class FormPengadaanTahunan : Form
    {
        int totalpengeluaran = 0;
        public FormPengadaanTahunan()
        {
            InitializeComponent();
            SetMyCustomFormat();
        }

        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            var boldFont = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
            var boldBig = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18);
            var normalFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12);

            var pdfDoc = new Document(PageSize.A4, 40f, 40f, 60f, 60f);
            string path = "E:\\";
            PdfWriter.GetInstance(pdfDoc, new FileStream(path + "/PengadaanProdukTahunan.pdf", FileMode.OpenOrCreate));
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
            Paragraph title = new Paragraph("LAPORAN PENGADAAN PRODUK TAHUNAN", boldBig);
            title.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(title);
            pdfDoc.Add(p);
            pdfDoc.Add(spacer);

            Paragraph tgl = new Paragraph("Tahun : " + Convert.ToString(dateTimePicker1.Text));
            tgl.Alignment = Element.ALIGN_LEFT;
            pdfDoc.Add(tgl);

            PdfPTable table = new PdfPTable(3);
            //actual width of table in points
            table.TotalWidth = 500f;
            //fix the absolute width of the table
            table.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widths = new float[] { 3f, 12f, 16f};
            table.SetWidths(widths);
            table.HorizontalAlignment = 1;
            //leave a gap before and after the table
            table.SpacingBefore = 30f;
            table.SpacingAfter = 30f;
            PdfPCell cell = new PdfPCell();
            cell.Colspan = 5;
            cell.Border = 0;
            cell.HorizontalAlignment = 1;

            table.AddCell(cell);
            table.AddCell("No");
            table.AddCell("Bulan");
            table.AddCell("Jumlah Pengeluaran");

            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            using (MySqlConnection conn = new MySqlConnection(connect))
            {
                string query = "SELECT m.Nama AS 'BULAN', COALESCE(SUM(p.total), 0) AS 'JUMLAH PENGELUARAN'" +
                    "FROM (SELECT * FROM BULAN )AS m " +
                    "LEFT JOIN ( " +
                    "SELECT TANGGAL_PEMESANAN, TOTAL AS total " +
                    "FROM PEMESANAN " +
                    "WHERE YEAR(TANGGAL_PEMESANAN) = '"+ dateTimePicker1.Text + "' " +
                    "GROUP BY ID_PEMESANAN " +
                    ")AS p ON MONTHNAME(p.TANGGAL_PEMESANAN) = m.Nama " +
                    "GROUP BY m.Nama " +
                    "ORDER BY m.Nomor ASC";

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
                            totalpengeluaran = totalpengeluaran + Convert.ToInt32(rdr[1].ToString());
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
            Paragraph total = new Paragraph("Total  Rp. " + totalpengeluaran, boldBig);
            total.Alignment = Element.ALIGN_RIGHT;
            pdfDoc.Add(total);

            pdfDoc.Add(spacer);
            Paragraph tanggal = new Paragraph("Dicetak tanggal " + Convert.ToString(DateTime.Now));
            tanggal.Alignment = Element.ALIGN_RIGHT;
            pdfDoc.Add(tanggal);
            pdfDoc.Add(spacer);
            pdfDoc.Close();
            totalpengeluaran = 0;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var boldFont = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12);
            var boldBig = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18);
            var normalFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12);

            var pdfDoc = new Document(PageSize.A4, 40f, 40f, 60f, 60f);
            string path = "E:\\";
            PdfWriter.GetInstance(pdfDoc, new FileStream(path + "/PengadaanProdukTahunan.pdf", FileMode.OpenOrCreate));
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
            Paragraph title = new Paragraph("LAPORAN PENGADAAN PRODUK TAHUNAN", boldBig);
            title.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(title);
            pdfDoc.Add(p);
            pdfDoc.Add(spacer);

            Paragraph tgl = new Paragraph("Tahun : " + Convert.ToString(dateTimePicker1.Text));
            tgl.Alignment = Element.ALIGN_LEFT;
            pdfDoc.Add(tgl);

            PdfPTable table = new PdfPTable(3);
            //actual width of table in points
            table.TotalWidth = 500f;
            //fix the absolute width of the table
            table.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widths = new float[] { 3f, 12f, 16f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 1;
            //leave a gap before and after the table
            table.SpacingBefore = 30f;
            table.SpacingAfter = 30f;
            PdfPCell cell = new PdfPCell();
            cell.Colspan = 5;
            cell.Border = 0;
            cell.HorizontalAlignment = 1;

            table.AddCell(cell);
            table.AddCell("No");
            table.AddCell("Bulan");
            table.AddCell("Jumlah Pengeluaran");

            string connect = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            using (MySqlConnection conn = new MySqlConnection(connect))
            {
                string query = "SELECT m.Nama AS 'BULAN', COALESCE(SUM(p.total), 0) AS 'JUMLAH PENGELUARAN'" +
                    "FROM (SELECT * FROM BULAN )AS m " +
                    "LEFT JOIN ( " +
                    "SELECT TANGGAL_PEMESANAN, TOTAL AS total " +
                    "FROM PEMESANAN " +
                    "WHERE YEAR(TANGGAL_PEMESANAN) = '" + dateTimePicker1.Text + "' " +
                    "GROUP BY ID_PEMESANAN " +
                    ")AS p ON MONTHNAME(p.TANGGAL_PEMESANAN) = m.Nama " +
                    "GROUP BY m.Nama " +
                    "ORDER BY m.Nomor ASC";

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
                            totalpengeluaran = totalpengeluaran + Convert.ToInt32(rdr[1].ToString());
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
            Paragraph total = new Paragraph("Total  Rp. " + totalpengeluaran, boldBig);
            total.Alignment = Element.ALIGN_RIGHT;
            pdfDoc.Add(total);
            pdfDoc.Close();

            adobeReader.src = "file:///e:/PengadaanProdukTahunan.pdf";
            totalpengeluaran = 0;
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
