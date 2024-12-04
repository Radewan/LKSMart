using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LKSMart
{
    internal class Koneksi
    {
        static MySqlConnection Conn = new MySqlConnection("server=localhost;uid=root;pwd=;database=lks_mart");

        public static void Query(string query)
        {
            try
            {
                Conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, Conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("berhasil!!");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        public static DataTable QueryRead(string query, DataGridView data)
        {

            DataTable dt = new DataTable();

            try
            {
                Conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, Conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                data.DataSource = dt;
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conn.Close();
            }

            return dt;
        }

        public static object QueryReturn(string query)
        {
            object obj = null;

            try
            {
                Conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, Conn);
                obj = cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conn.Close();
            }

            return obj;

        }
    }
}
