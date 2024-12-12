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
            using(var db = new lks_martEntities())
            {
                var users = db.tbl_user
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
            }
        }

        private void UserControl_Load(object sender, EventArgs e)
        {
            ReadUsers();
        }
    }
}
