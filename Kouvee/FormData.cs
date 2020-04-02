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
using Kouvee.DAO;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kouvee
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridRead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnPegawai_Click(object sender, EventArgs e)
        {
            var list = new PegawaiControl();
            list.ShowPegawai();
            dataGridRead.DataSource = list.ShowPegawai();
        }
    }
}
