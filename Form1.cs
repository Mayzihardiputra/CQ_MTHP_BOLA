using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization; //add library

namespace PraktikumADO  // namespace sesuai dengan nama project, jika nama project berbeda maka sesuaikan dengan nama project kalian
{
    public partial class Form1 : Form // sesuaikan dengan nama form kalian, jika nama form kalian berbeda maka sesuaikan dengan nama form kalian
    {
        SqlConnection conn;
        SqlCommand cmd;

        public Form1() // sesuaikan dengan nama form kalian, jika nama form kalian berbeda maka sesuaikan dengan nama form kalian
        {
            InitializeComponent();
        }
        private void Koneksi() // method untuk koneksi ke database, sesuaikan dengan nama server, nama database, dan autentikasi yang kalian gunakan
        {
            conn = new SqlConnection("Data Source=MAYZIHARDIPUTRA\\MAYZIHARDIPUTRA;Initial Catalog=DBAkademikADO;Integrated Security=True");
        }  

        private void btnConnect_Click(object sender, EventArgs e) //    event handler untuk button connect, sesuaikan dengan nama button kalian, jika nama button kalian berbeda maka sesuaikan dengan nama button kalian
        {
            try // untuk menangani error jika koneksi gagal
            {
                Koneksi();
                conn.Open();

                MessageBox.Show("Koneksi ke database berhasil");

                conn.Close();
            } 
            catch (Exception ex) //     untuk menangani error jika koneksi gagal
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHitungMhs_Click(object sender, EventArgs e) // event handler untuk button hitung mahasiswa, sesuaikan dengan nama button
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT COUNT(*) FROM Mahasiswa"; // query untuk menghitung jumlah mahasiswa

                cmd = new SqlCommand(query, conn);

                int jumlah = (int)cmd.ExecuteScalar();

                txtHasil.Text = jumlah.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT COUNT(*) FROM MataKuliah";

                cmd = new SqlCommand(query, conn);

                int jumlah = (int)cmd.ExecuteScalar();

                txtHasil.Text = jumlah.ToString();

                conn.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "UPDATE Mahasiswa SET Alamat = 'Yogyakarta' WHERE NIM = '23110100001'";

                cmd = new SqlCommand(query, conn);

                int hasil = cmd.ExecuteNonQuery();

                MessageBox.Show("Jumlah baris terpengaruh : " + hasil);

                conn.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        private void btnHitungDSN_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT COUNT(*) FROM Dosen";

                cmd = new SqlCommand(query, conn);

                int jumlah = (int)cmd.ExecuteScalar();

                txtHasil.Text = jumlah.ToString();

                conn.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        private void btnUpdateMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "UPDATE MataKuliah SET SKS = 4 WHERE KodeMK = 'IF210101'";

                cmd = new SqlCommand(query, conn);

                int hasil = cmd.ExecuteNonQuery();

                MessageBox.Show("Berhasil update! Baris: " + hasil);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        private void btnInsertProdi_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "INSERT INTO ProgramStudi VALUES ('MI01','Manajemen Informatika')";

                cmd = new SqlCommand(query, conn);

                int hasil = cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil ditambahkan! Baris: " + hasil);

                conn.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}