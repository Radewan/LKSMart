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
    public partial class UserControl : System.Windows.Forms.UserControl
    {
        public UserControl()
        {
            InitializeComponent();
        }

        private int CurrentPageIndex = 1;
        private const int PageSize = 6;
        private int TotalPages = 1;

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (var db = new lks_martEntities())
            {
                var user = new tbl_user
                {
                    tipe_user = null,
                    nama = txtNama.Text,
                    alamat = txtAlamat.Text,
                    username = txtUsername.Text,
                    telepon = txtTelepon.Text,
                    password = txtPassword.Text,
                };

                db.tbl_user.Add(user);
                db.SaveChanges();

                ReadUsers();
            }
        }

        private void ReadUsers()
        {
            using (var db = new lks_martEntities())
            {
                var rows = db.tbl_log
                    .Count(s => s.id_log >= 1);

                TotalPages = (int)Math.Ceiling((double)rows / PageSize);

                var users = db.tbl_user
                    .OrderBy(s => s.id_user)
                    .Skip((CurrentPageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .Select(s => new
                    {
                        s.id_user,
                        s.tipe_user,
                        s.nama,
                        s.alamat,
                        s.telepon,
                    })
                    .ToList();

                dataRead.DataSource = users;

                dataRead.Columns[1].HeaderText = "No";
                dataRead.Columns[2].HeaderText = "Tipe User";
                dataRead.Columns[3].HeaderText = "Nama User";
                dataRead.Columns[4].HeaderText = "Alamat";
                dataRead.Columns[5].HeaderText = "Telepon";
            }
        }

        private void UserControl_Load(object sender, EventArgs e)
        {
            ReadUsers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ReadUsers();
            }
            else
            {
                using (var db = new lks_martEntities())
                {
                    var rows = db.tbl_log
                         .Count(s => s.id_log >= 1);

                    TotalPages = (int)Math.Ceiling((double)rows / PageSize);

                    var users = db.tbl_user
                        .OrderBy(s => s.id_user)
                        .Skip((CurrentPageIndex - 1) * PageSize)
                        .Take(PageSize)
                        .Select(s => new
                        {
                            s.id_user,
                            s.tipe_user,
                            s.nama,
                            s.alamat,
                            s.telepon,
                        })
                        .Where(s => s.nama.Contains(txtSearch.Text))
                        .ToList();

                    dataRead.DataSource = users;

                    dataRead.Columns[1].HeaderText = "No";
                    dataRead.Columns[2].HeaderText = "Tipe User";
                    dataRead.Columns[3].HeaderText = "Nama User";
                    dataRead.Columns[4].HeaderText = "Alamat";
                    dataRead.Columns[5].HeaderText = "Telepon";
                }

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPages)
            {
                CurrentPageIndex++;
                ReadUsers();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                CurrentPageIndex--;
                ReadUsers();
            }
        }
    }
}
