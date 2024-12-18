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
    public partial class GudangForm : Form
    {
        public GudangForm(int userId)
        {
            InitializeComponent();

            UserId = userId;
        }

        private const int PageSize = 5;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;

        private int IdBarang = 0;

        private int UserId;


        private void Gudang_Load(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menambah data", "Konfirmasi Tambah", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                using (var db = new lks_martEntities())
                {
                    var barang = new tbl_barang
                    {
                        kode_barang = txtKode.Text,
                        nama_barang = txtNama.Text,
                        expired_date = Convert.ToDateTime(dateExpired.Value),
                        jumlah_barang = Convert.ToInt64(txtJumlah.Text),
                        satuan = txtSatuan.Text,
                        harga_satuan = Convert.ToInt64(txtHarga.Text),
                    };

                    db.tbl_barang.Add(barang);
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

                LoginForm login = new LoginForm();
                login.Show();
                Close();
            }

        }

        public void ReadData()
        {
            using (var db = new lks_martEntities())
            {
                var rows = db.tbl_barang
                    .Count(s => s.id_barang >= 1);

                TotalPage = (int)Math.Ceiling((double)rows / PageSize);

                var readQuery = db.tbl_barang
                    .OrderBy(s => s.id_barang)
                    .Skip((CurrentPageIndex - 1) * TotalPage)
                    .Take(PageSize)
                    .Select(s => s)
                    .ToList();
                dataRead.DataSource = readQuery;

                lblIndexPage.Text = CurrentPageIndex.ToString();

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
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menambah edit data", "Konfirmasi Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (var db = new lks_martEntities())
                {
                    var barang = db.tbl_barang
                        .Where(s => s.id_barang == IdBarang)
                        .FirstOrDefault();

                    barang.kode_barang = txtKode.Text;
                    barang.nama_barang = txtNama.Text;
                    barang.expired_date = Convert.ToDateTime(dateExpired.Value);
                    barang.jumlah_barang = Convert.ToInt64(txtJumlah.Text);
                    barang.satuan = txtSatuan.Text;
                    barang.harga_satuan = Convert.ToInt64(txtHarga.Text);

                    db.SaveChanges();

                    ReadData();
                }
            }

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menhapus data", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (var db = new lks_martEntities())
                {
                    var barang = db.tbl_barang
                        .Where(s => s.id_barang == IdBarang)
                        .Select(s => s)
                        .FirstOrDefault();

                    Console.WriteLine(barang);
                    db.tbl_barang.Remove(barang);
                    db.SaveChanges();

                    ReadData();
                }
            }

        }

        private void dataRead_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex >= 0)
            //{
            //    bool isChecked = Convert.ToBoolean(dataRead.Rows[e.RowIndex].Cells[0].Value);

            //    if (isChecked)
            //    {
            //        dataRead.Rows[e.RowIndex].Cells[0].Value = false;
            //    }
            //    else
            //    {
            //        dataRead.Rows[e.RowIndex].Cells[0].Value = true;
            //    }
            //}

            if (e.RowIndex >= 0)
            {
                bool isChecked = Convert.ToBoolean(dataRead.Rows[e.RowIndex].Cells[0].Value);

                if (isChecked)
                {
                    dataRead.Rows[e.RowIndex].Cells[0].Value = false;

                    IdBarang = 0;
                    txtKode.Clear();
                    txtJumlah.Clear();
                    txtNama.Clear();
                    txtSatuan.Clear();
                    //dateExpired
                    txtHarga.Clear();
                }
                else
                {


                    //Console.WriteLine(dataRead.Columns["checked"]);

                    IdBarang = (int)dataRead.Rows[e.RowIndex].Cells["id_barang"].Value;
                    txtKode.Text = dataRead.Rows[e.RowIndex].Cells["kode_barang"].Value.ToString();
                    txtJumlah.Text = dataRead.Rows[e.RowIndex].Cells["jumlah_barang"].Value.ToString();
                    txtNama.Text = dataRead.Rows[e.RowIndex].Cells["nama_barang"].Value.ToString();
                    txtSatuan.Text = dataRead.Rows[e.RowIndex].Cells["satuan"].Value.ToString();
                    dateExpired.Value = Convert.ToDateTime(dataRead.Rows[e.RowIndex].Cells["expired_date"].Value);
                    txtHarga.Text = dataRead.Rows[e.RowIndex].Cells["harga_satuan"].Value.ToString();

                    dataRead.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                CurrentPageIndex++;
                ReadData();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                CurrentPageIndex--;
                ReadData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var db = new lks_martEntities())
            {
                var rows = db.tbl_barang
                    .Count(s => s.id_barang >= 1);

                TotalPage = (int)Math.Ceiling((double)rows / PageSize);

                var readQuery = db.tbl_barang
                    .OrderBy(s => s.id_barang)
                    .Skip((CurrentPageIndex - 1) * TotalPage)
                    .Take(PageSize)
                    .Select(s => s)
                    .Where(s => s.nama_barang.Contains(txtSearch.Text))
                    .ToList();
                dataRead.DataSource = readQuery;

                lblIndexPage.Text = CurrentPageIndex.ToString();

                dataRead.Columns["id_barang"].HeaderText = "ID Barang";
                dataRead.Columns["kode_barang"].HeaderText = "Kode Barang";
                dataRead.Columns["nama_barang"].HeaderText = "Nama Barang";
                dataRead.Columns["expired_date"].HeaderText = "Expired Date";
                dataRead.Columns["jumlah_barang"].HeaderText = "Qty";
                dataRead.Columns["satuan"].HeaderText = "Satuan";
                dataRead.Columns["harga_satuan"].HeaderText = "Harga Satuan";
            }
        }
    }
}
