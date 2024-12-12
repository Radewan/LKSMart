using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKSMart
{
    public partial class AdminForm : Form
    {
        public AdminForm(int userId)
        {
            InitializeComponent();

            this.UserId = userId;
        }

        private int UserId;

        private void Admin_Load(object sender, EventArgs e)
        {
            btnActivity.BackColor = ColorTranslator.FromHtml("#6FB5F0");

            ShowContent(new ActivityControl());
        }


        private void btnActivity_Click(object sender, EventArgs e)
        {
            btnActivity.BackColor = ColorTranslator.FromHtml("#6FB5F0");
            btnLaporan.BackColor = ColorTranslator.FromHtml("#5B86AB");
            btnUser.BackColor = ColorTranslator.FromHtml("#5B86AB");

            ShowContent( new ActivityControl());

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            using (var db = new lks_martEntities()) {

                var log = new tbl_log
                {

                    waktu = DateTime.Now,
                    aktivitas = "Logout",
                    id_user = UserId,
                };
                db.tbl_log.Add(log);
                db.SaveChanges();

                Console.WriteLine(UserId);

                Login login = new Login();
                login.Show();
                this.Close();

            }
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            btnLaporan.BackColor = ColorTranslator.FromHtml("#6FB5F0");
            btnActivity.BackColor = ColorTranslator.FromHtml("#5B86AB");
            btnUser.BackColor = ColorTranslator.FromHtml("#5B86AB");

            ShowContent(new LaporanControl());

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            btnUser.BackColor = ColorTranslator.FromHtml("#6FB5F0");
            btnLaporan.BackColor = ColorTranslator.FromHtml("#5B86AB");
            btnActivity.BackColor = ColorTranslator.FromHtml("#5B86AB");

            ShowContent(new UserControl());
        }

        public void ShowContent(Control content)
        {
            panelMain.Controls.Clear();
            content.Dock = DockStyle.Fill;
            panelMain.Controls.Add(content);
        }
    }
}
