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
    public partial class KasirForm : Form
    {
        public KasirForm(int bb)
        {
            InitializeComponent();

            this.UserId = bb;
        }

        private int UserId;

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
                this.Close();
            }
        }

        private void Kasir_Load(object sender, EventArgs e)
        {

        }
    }
}
