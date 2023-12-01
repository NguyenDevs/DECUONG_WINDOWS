using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Câu_3._5
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private DataSet myDataSet;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataTable myTable;
        private string conStr = @"Data Source=RAPHAEL-PC\RAPHAEL;
        Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=Blacksmith@0407";
        private void Display() {
            string sqlStr = "SELECT * FROM tblkhoa";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr))
            {
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "daotao");
                myTable = myDataSet.Tables["daotao"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoGenerateColumns = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            using (myConnection = new SqlConnection(conStr)) {
                myConnection.Open();
                Display();
                int rowCount = myTable.Rows.Count; 
                txt_tong.Text = rowCount.ToString();
            }
        }
        private void btn_thoat_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int row = e.RowIndex;
            if (row >= myTable.Rows.Count)
                row = myTable.Rows.Count - 1;
            else {
                txt_makhoa.Text = myTable.Rows[row]["MaKhoa"].ToString();
                txt_tenkhoa.Text = myTable.Rows[row]["TenKhoa"].ToString();
            }
        }
        private void btn_them_Click(object sender, EventArgs e) {
            txt_makhoa.Clear();
            txt_tenkhoa.Clear();
            txt_makhoa.Focus();
        }
        private void btn_xoa_Click(object sender, EventArgs e) {
            try {
                int pos = dataGridView1.CurrentRow.Index;
                string makhoaToDelete = myTable.Rows[pos]["Makhoa"].ToString();
                DeleteRecordFromDatabase(makhoaToDelete);
                myTable.Rows[pos].Delete();
                myTable.AcceptChanges();
                int rowCount = myTable.Rows.Count;
                txt_tong.Text = rowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteRecordFromDatabase(string masv) {
            try {
                using (myConnection = new SqlConnection(conStr)){
                    myConnection.Open();
                    string sqlStr = "DELETE FROM tblkhoa WHERE Makhoa = @Makhoa";
                    using (myCommand = new SqlCommand(sqlStr, myConnection)) {
                        myCommand.Parameters.AddWithValue("@Makhoa", masv);
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting from the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_luu_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txt_makhoa.Text)) {
                MessageBox.Show("Vui lòng nhập mã Khoa");
                return;
            }
            try {
                using (myConnection = new SqlConnection(conStr)) {
                    myConnection.Open();
                    string sqlStr3 = "INSERT INTO tblkhoa(Makhoa, Tenkhoa) " +
                                     "VALUES(@Makhoa, @Tenkhoa)";
                    using (myCommand = new SqlCommand(sqlStr3, myConnection)) {
                        myCommand.Parameters.AddWithValue("@Makhoa", txt_makhoa.Text);
                        myCommand.Parameters.AddWithValue("@Tenkhoa", txt_tenkhoa.Text);
                        myCommand.ExecuteNonQuery();

                    }
                    Display();
                    int rowCount = myTable.Rows.Count;
                    txt_tong.Text = rowCount.ToString();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
