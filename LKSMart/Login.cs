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
            if (String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Pastikan semua field wajib di isi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                using (var db = new lks_martEntities())
                {


                    var user = db.tbl_user
                        .Where(s => s.username.Equals(txtUsername.Text)
                        && s.password.Equals(txtPassword.Text))
                        .Select(s => new { s.id_user ,s.tipe_user })
                        .FirstOrDefault();

                    if (user == null)
                    {
                        MessageBox.Show("username atau password yang anda masukkan tidak sesuai !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var log = new tbl_log
                        {

                            waktu = DateTime.Now,
                            aktivitas = "Login",
                            id_user = user.id_user,
                        };
                        db.tbl_log.Add(log);
                        db.SaveChanges();

                        switch (user.tipe_user)
                        {
                            case "Admin":
                                AdminForm admin = new AdminForm(user.id_user);
                                admin.Show();
                                Hide();
                                break;

                            case "Gudang":
                                Gudang gudang = new Gudang(user.id_user);
                                gudang.Show();
                                Hide();
                                break;

                            case "Kasir":
                                Kasir kasir = new Kasir(user.id_user);
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
