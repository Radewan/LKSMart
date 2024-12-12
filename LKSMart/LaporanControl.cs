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
    public partial class LaporanControl : System.Windows.Forms.UserControl
    {
        public LaporanControl()
        {
            InitializeComponent();
        }

        private void LaporanControl_Load(object sender, EventArgs e)
        {
            using (var db = new lks_martEntities())
            {
                var query = db.tbl_transaksi
                    .Select(s => new { s.no_transaksi, s.tgl_transaksi, s.total_bayar, s.nama_kasir, s.tbl_pelanggan.nama })
                    .ToList();

                dataRead.DataSource = query;
            }
        }
    }
}
