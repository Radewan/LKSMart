using System;
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
            object hasil = Koneksi.QueryReturn("SELECT tipe_user FROM tbl_user WHERE username = 'gudang' AND password = 'gudang'");

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Pastikan semua field wajib di isi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (hasil != null)
            {
                Console.WriteLine("aa");

                switch (hasil)
                {
                    case "Admin":
                        Admin admin = new Admin();
                        admin.Show();
                        this.Hide();
                        break;

                    case "Gudang":
                        Gudang gudang = new Gudang();
                        gudang.Show();
                        this.Hide();
                        break;

                    case "Kasir":
                        Kasir kasir = new Kasir();
                        kasir.Show();
                        this.Hide();
                        break;
                }
            }
            else
            {
                MessageBox.Show("username atau password yang anda masukkan tidak sesuai !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Admin admin = new Admin();
            //admin.Show();

            //this.Hide();
        }
    }
}
