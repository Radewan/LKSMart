using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKSMart
{
    public partial class Gudang : Form
    {
        public Gudang()
        {
            InitializeComponent();
        }

        private void Gudang_Load(object sender, EventArgs e)
        {
            Koneksi.QueryRead("SELECT * FROM tbl_barang", dataRead);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login= new Login();
            login.Show();

            this.Hide();

        }



        private void btnTambah_Click(object sender, EventArgs e)
        {
            Koneksi.QueryRead("SELECT * FROM tbl_barang", dataRead);

        }
    }
}
