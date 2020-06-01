using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kouvee.Control;
using Kouvee.Models;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Kouvee.View.Data.Tampil
{
    public partial class FormTampil : Form
    {
        String stat = null;
        public FormTampil()
        {
            InitializeComponent();
            setAuthority();
        }

        public void setAuthority()
        {
            if (FormLogin.jabatan == "Admin")
            {
                buttonTampilCustomer.Enabled = false;
                buttonTampilHewan.Enabled = false;
            }
            else if (FormLogin.jabatan == "CS")
            {
                buttonTampilPegawai.Enabled = false;
                buttonTampilSupplier.Enabled = false;
                buttonTampilJenisHewan.Enabled = false;
                buttonTampilLayanan.Enabled = false;
                buttonTampilProduk.Enabled = false;
                buttonTampilUkuranHewan.Enabled = false;
            }
            else if (FormLogin.jabatan == "Kasir")
            {
                buttonTampilCustomer.Enabled = false;
                buttonTampilHewan.Enabled = false;
                buttonTampilPegawai.Enabled = false;
                buttonTampilSupplier.Enabled = false;
                buttonTampilJenisHewan.Enabled = false;
                buttonTampilLayanan.Enabled = false;
                buttonTampilProduk.Enabled = false;
                buttonTampilUkuranHewan.Enabled = false;
            }
        }
        private void buttonTampilCustomer_Click(object sender, EventArgs e)
        {
            txtCari.Enabled = true;
            btnCari.Enabled = true;

            stat = "customer";
            var ctrl = new CustomerControl();
            dataGridViewTampil.DataSource = ctrl.ShowCustomer();
        }

        private void buttonTampilHewan_Click(object sender, EventArgs e)
        {
            txtCari.Enabled = true;
            btnCari.Enabled = true;

            stat = "hewan";
            var ctrl = new HewanControl();
            dataGridViewTampil.DataSource = ctrl.ShowHewan();

            for (int i = 0; i<dataGridViewTampil.Columns.Count; i++) 
            {
                string str = dataGridViewTampil.Columns[i].HeaderText;
                if (str == "Nama_Pelanggan" || str == "JenisHewan")
                {
                    dataGridViewTampil.Columns[i].Visible = false;
                }
            }
        }

        private void buttonTampilJenisHewan_Click(object sender, EventArgs e)
        {
            txtCari.Enabled = true;
            btnCari.Enabled = true;

            stat = "jenishewan";
            var ctrl = new JenisHewanControl();
            dataGridViewTampil.DataSource = ctrl.ShowJenisHewan();
        }

        private void buttonTampilLayanan_Click(object sender, EventArgs e)
        {
            txtCari.Enabled = true;
            btnCari.Enabled = true;

            stat = "layanan";
            var ctrl = new LayananControl();
            dataGridViewTampil.DataSource = ctrl.ShowLayanan();
            for (int i = 0; i < dataGridViewTampil.Columns.Count; i++)
            {
                string str = dataGridViewTampil.Columns[i].HeaderText;
                if (str == "Ukuran" || str == "JenisHewan")
                {
                    dataGridViewTampil.Columns[i].Visible = false;
                }
            }
        }

        private void buttonTampilPegawai_Click(object sender, EventArgs e)
        {
            txtCari.Enabled = true;
            btnCari.Enabled = true;

            stat = "pegawai";
            var ctrl = new PegawaiControl();
            dataGridViewTampil.DataSource = ctrl.ShowPegawai();
        }

        private void buttonTampilProduk_Click(object sender, EventArgs e)
        {
            txtCari.Enabled = true;
            btnCari.Enabled = true;
            stat = "produk";

            string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string selectQuery = "SELECT * FROM produk";
            MySqlCommand command = new MySqlCommand(selectQuery, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            dataGridViewTampil.RowTemplate.Height = 100;
            dataGridViewTampil.AllowUserToAddRows = false;
            
            da.Fill(table);
            dataGridViewTampil.DataSource = table;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridViewTampil.Columns[9];
            dataGridViewTampil.Columns[8].Visible = false;
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            da.Dispose();
        }

        private void buttonTampilSupplier_Click(object sender, EventArgs e)
        {
            txtCari.Enabled = true;
            btnCari.Enabled = true;

            stat = "supplier";
            var ctrl = new SupplierControl();
            dataGridViewTampil.DataSource = ctrl.ShowSupplier();
        }

        private void buttonTampilUkuranHewan_Click(object sender, EventArgs e)
        {
            txtCari.Enabled = true;
            btnCari.Enabled = true;

            stat = "ukuranhewan";
            var ctrl = new UkuranHewanControl();
            dataGridViewTampil.DataSource = ctrl.ShowUkuranHewan();
        }

        private void buttonTampilKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCari.Text.Trim()))
                {
                    MessageBox.Show("Text Pencarian Kosong");
                    throw null;
                }

                if (stat == "customer")
                {
                    var ctrl = new CustomerControl();
                    if (ctrl.SearchCustomer(txtCari.Text) == null)
                    {
                        MessageBox.Show("Pencarian Tidak Ditemukan");
                        throw null;
                    }
                    else 
                    {
                        List<Customer> CustomerList = new List<Customer>();
                        CustomerList.Add(ctrl.SearchCustomer(txtCari.Text));
                        dataGridViewTampil.DataSource = CustomerList;
                    }
                }
                else if (stat == "hewan")
                {
                    var ctrl = new HewanControl();
                    if (ctrl.SearchHewan(txtCari.Text) == null)
                    {
                        MessageBox.Show("Pencarian Tidak Ditemukan");
                        throw null;
                    }
                    else
                    {
                        List<Hewan> HewanList = new List<Hewan>();
                        HewanList.Add(ctrl.SearchHewan(txtCari.Text));
                        dataGridViewTampil.DataSource = HewanList;
                    }
                }
                else if (stat == "jenishewan")
                {
                    var ctrl = new JenisHewanControl();
                    if (ctrl.SearchJenisHewan(txtCari.Text) == null)
                    {
                        MessageBox.Show("Pencarian Tidak Ditemukan");
                        throw null;
                    }
                    else
                    {
                        List<JenisHewan> JenisHewanList = new List<JenisHewan>();
                        JenisHewanList.Add(ctrl.SearchJenisHewan(txtCari.Text));
                        dataGridViewTampil.DataSource = JenisHewanList;
                    }
                }
                else if (stat == "layanan")
                {
                    var ctrl = new LayananControl();
                    if (ctrl.SearchLayanan(txtCari.Text) == null)
                    {
                        MessageBox.Show("Pencarian Tidak Ditemukan");
                        throw null;
                    }
                    else
                    {
                        List<Layanan> LayananList = new List<Layanan>();
                        LayananList.Add(ctrl.SearchLayanan(txtCari.Text));
                        dataGridViewTampil.DataSource = LayananList;
                    }
                }
                else if (stat == "pegawai")
                {
                    var ctrl = new PegawaiControl();
                    if (ctrl.SearchPegawai(txtCari.Text) == null)
                    {
                        MessageBox.Show("Pencarian Tidak Ditemukan");
                        throw null;
                    }
                    else
                    {
                        List<Pegawai> PegawaiList = new List<Pegawai>();
                        PegawaiList.Add(ctrl.SearchPegawai(txtCari.Text));
                        dataGridViewTampil.DataSource = PegawaiList;
                    }
                }
                else if (stat == "produk")
                {
                    string connStr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kouvee;Convert Zero Datetime=True;";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    string selectQuery = "SELECT * FROM produk WHERE NAMA_PRODUK = '" + txtCari.Text + "'";
                    MySqlCommand command = new MySqlCommand(selectQuery, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    
                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("Pencarian Tidak Ditemukan");
                        da.Dispose();
                        throw null;
                    }
                    else
                    {
                        dataGridViewTampil.DataSource = table;
                        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                        imageColumn = (DataGridViewImageColumn)dataGridViewTampil.Columns[9];
                        dataGridViewTampil.Columns[8].Visible = false;
                        imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        da.Dispose();
                    }
                }
                else if (stat == "supplier")
                {
                    var ctrl = new SupplierControl();
                    if (ctrl.SearchSupplier(txtCari.Text) == null)
                    {
                        MessageBox.Show("Pencarian Tidak Ditemukan");
                        throw null;
                    }
                    else
                    {
                        List<Supplier> SupplierList = new List<Supplier>();
                        SupplierList.Add(ctrl.SearchSupplier(txtCari.Text));
                        dataGridViewTampil.DataSource = SupplierList;
                    }
                }
                else if (stat == "ukuranhewan")
                {
                    var ctrl = new UkuranHewanControl();
                    if (ctrl.SearchUkuran(txtCari.Text) == null)
                    {
                        MessageBox.Show("Pencarian Tidak Ditemukan");
                        throw null;
                    }
                    else
                    {
                        List<UkuranHewan> UkuranHewanList = new List<UkuranHewan>();
                        UkuranHewanList.Add(ctrl.SearchUkuran(txtCari.Text));
                        dataGridViewTampil.DataSource = UkuranHewanList;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void FormTampil_Load(object sender, EventArgs e)
        {
            dataGridViewTampil.RowTemplate.Height = 100;
            dataGridViewTampil.AllowUserToAddRows = false;
            dataGridViewTampil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtCari.Enabled = false;
            btnCari.Enabled = false;
        }
    }
}
