using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LKSMart
{
    public partial class Gudang : Form
    {
        public Gudang(int userId)
        {
            InitializeComponent();

            UserId = userId;

            dataRead.CellPainting += dataRead_CellPainting;
            dataRead.CellMouseClick += dataRead_CellMouseClick;


        }

        private int UserId;


        private void Gudang_Load(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
      "Apakah Anda yakin ingin menambah data",
      "Konfirmasi Tambah",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                using (var db = new lks_martEntities())
                {
                    int jumlah = int.Parse(txtJumlah.Text), harga = int.Parse(txtHarga.Text);

                    string kode = txtKode.Text, nama = txtBarang.Text, satuan = txtSatuan.Text;

                    DateTime expired = DateTime.Parse(dateExpired.Text);



                    var st = new tbl_barang
                    {
                        kode_barang = kode,
                        nama_barang = nama,
                        expired_date = expired,
                        jumlah_barang = jumlah,
                        satuan = satuan,
                        harga_satuan = harga,
                    };
                    db.tbl_barang.Add(st);
                    db.SaveChanges();

                    ReadData();
                }

            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            using (var db = new lks_martEntities())
            {

                var log = new tbl_log
                {

                    waktu = DateTime.Now,
                    aktivitas = "Logout",
                    id_user = UserId,
                };
                db.tbl_log.Add(log);
                db.SaveChanges();

                Console.Write(UserId);

                Login login = new Login();
                login.Show();
                Close();
            }

        }

        public void ReadData()
        {
            using (var db = new lks_martEntities())
            {
                var query = db.tbl_barang
                    .Select(s => s)
                    .ToList();

                dataRead.DataSource = query;

                dataRead.Columns["id_barang"].HeaderText = "ID Barang";
                dataRead.Columns["kode_barang"].HeaderText = "Kode Barang";
                dataRead.Columns["nama_barang"].HeaderText = "Nama Barang";
                dataRead.Columns["expired_date"].HeaderText = "Expired Date";
                dataRead.Columns["jumlah_barang"].HeaderText = "Qty";
                dataRead.Columns["satuan"].HeaderText = "Satuan";
                dataRead.Columns["harga_satuan"].HeaderText = "Harga Satuan";

            }
        }




        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
      "Apakah Anda yakin ingin menambah edit data",
      "Konfirmasi Edit",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Information);

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
      "Apakah Anda yakin ingin menhapus data",
      "Konfirmasi Hapus",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Information);

        
        }

        private void dataRead_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataRead_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void dataRead_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                bool isChecked = Convert.ToBoolean(dataRead.Rows[e.RowIndex].Cells[0].Value);

                if (isChecked)
                {
                    dataRead.Rows[e.RowIndex].Cells[0].Value = false;
                }
                else
                {
                    dataRead.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }

            //make
        }
    }
}
