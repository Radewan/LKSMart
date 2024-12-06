using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Windows.Forms;

namespace LKSMart
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua field wajib di isi", "W arning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                using (var db = new lks_martEntities2())
                {


                    string query = db.tbl_user
                        .Where(s => s.username.Equals(txtUsername.Text.ToString())
                        && s.password.Equals(txtPassword.Text.ToString()))
                        .Select(s => s.tipe_user)
                        .FirstOrDefault();

                    int queryId = db.tbl_user
                        .Where(s => s.username.Equals(txtUsername.Text.ToString())
                         && s.password.Equals(txtPassword.Text.ToString()))
                        .Select(s => s.id_user)
                        .FirstOrDefault();
                    //gak case sensitive

                    if (query == null)
                    {
                        MessageBox.Show("username atau password yang anda masukkan tidak sesuai !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var log = new tbl_log
                        {

                            waktu = DateTime.Now,
                            aktivitas = "Login",
                            id_user = queryId
                        };
                        db.tbl_log.Add(log);
                        db.SaveChanges();

                        switch (query)
                        {
                            case "Admin":
                                Admin admin = new Admin(queryId);
                                admin.Show();
                                Hide();
                                break;

                            case "Gudang":
                                Gudang gudang = new Gudang(queryId);
                                gudang.Show();
                                Hide();
                                break;

                            case "Kasir":
                                Kasir kasir = new Kasir(queryId);
                                kasir.Show();
                                Hide();
                                break;

                        }
                    }
                }

            }


        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
