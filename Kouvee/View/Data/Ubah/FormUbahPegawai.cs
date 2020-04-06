using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kouvee.View.Data.Ubah
{
    public partial class FormUbahPegawai : Form
    {
        public FormUbahPegawai()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUbahPegawai_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name");
            table.Columns.Add("value");
            table.Rows.Add("Admin", "Admin");
            table.Rows.Add("CS", "CS");
            table.Rows.Add("Kasir", "Kasir");

            comboBoxJabatan.DataSource = table;
            comboBoxJabatan.DisplayMember = "username";
        }
    }
}
