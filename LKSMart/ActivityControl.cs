using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKSMart
{
    public partial class ActivityControl : System.Windows.Forms.UserControl
    {
        public ActivityControl()
        {
            InitializeComponent();

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, btnNext.Width, btnNext.Height);
                btnNext.Region = new Region(path);
                btnPrevious.Region = new Region(path);

                //path.AddEllipse(0, 0, labelCurentPage.Width, labelCurentPage.Height);
                //labelCurentPage.Region = new Region(path);
            }


        }

        private int CurrentPageIndex = 1;
        private const int PageSize = 6;
        private int TotalPages = 1;


        private void ActivityControl_Load(object sender, EventArgs e)
        {

            CultureInfo culture = new CultureInfo("id-ID");

            labelTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", culture);

            labelWaktu.Text = DateTime.Now.ToString("HH:mm:ss");

            ReadData();


        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (CurrentPageIndex < TotalPages)
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

        private void ReadData()
        {
            using (var db = new lks_martEntities())
            {
                var rows = db.tbl_log
                    .Count(s => s.id_log >= 1);

                TotalPages = (int)Math.Ceiling((double)rows / PageSize);

                var query = db.tbl_log
            .OrderBy(s => s.id_log)
            .Skip((CurrentPageIndex - 1) * PageSize)
            .Take(PageSize)
            .Select(s => new { s.id_log, s.tbl_user.username, s.waktu, s.aktivitas })
            .ToList();

                labelCurentPage.Text = CurrentPageIndex.ToString();

                Console.WriteLine(query.ToString());

                dataRead.DataSource = query;
                dataRead.Columns["id_log"].HeaderText = "No";
                dataRead.Columns["username"].HeaderText = "Username";
                dataRead.Columns["waktu"].HeaderText = "Waktu";
                dataRead.Columns["aktivitas"].HeaderText = "Aktivitas";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var db = new lks_martEntities())
            {
                var rows = db.tbl_log
                    .Count(s => s.id_log >= 1);

                TotalPages = (int)Math.Ceiling((double)rows / PageSize);

                var query = db.tbl_log
            .OrderBy(s => s.id_log)
            .Skip((CurrentPageIndex - 1) * PageSize)
            .Take(PageSize)
            .Where(s => s.waktu >= dateDari.Value && s.waktu <= dateSampai.Value)
            .Select(s => new { s.id_log, s.tbl_user.username, s.waktu, s.aktivitas })
            .ToList();

                labelCurentPage.Text = CurrentPageIndex.ToString();

                Console.WriteLine(query.ToString());

                dataRead.DataSource = query;
                dataRead.Columns["id_log"].HeaderText = "No";
                dataRead.Columns["username"].HeaderText = "Username";
                dataRead.Columns["waktu"].HeaderText = "Waktu";
                dataRead.Columns["aktivitas"].HeaderText = "Aktivitas";
            }
        }
    }
}
