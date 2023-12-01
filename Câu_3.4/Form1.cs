using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Câu_3._4 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void btn_thoat_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private SqlDataAdapter myDataAdapter;
        private DataSet myDataSet;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataTable myTable;
        private string conStr = @"Data Source=RAPHAEL-PC\RAPHAEL;
        Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=Blacksmith@0407";
        private void Display() {
            string sqlStr = "SELECT * FROM tblnhanvien";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr))
            {
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "daotao");
                myTable = myDataSet.Tables["daotao"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoGenerateColumns = false;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int row = e.RowIndex;
            if (row >= myTable.Rows.Count)
                row = myTable.Rows.Count - 1;
            else {
                DisplayRecord();
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            using (myConnection = new SqlConnection(conStr)) {
                myConnection.Open();
                Display();
            }
        }
        private void btn_first_Click(object sender, EventArgs e) {
            if (myTable.Rows.Count > 0) {
                currentRowIndex = 0;
                DisplayRecord();
            }
        }
        private void btn_previous_Click(object sender, EventArgs e) {
            if (currentRowIndex > 0) {
                currentRowIndex--;
                DisplayRecord();
            }
        }
        private void btn_next_Click(object sender, EventArgs e) {
            if (currentRowIndex < myTable.Rows.Count - 1) {
                currentRowIndex++;
                DisplayRecord();
            }
        }
        private void btn_last_Click(object sender, EventArgs e) {
            if (myTable.Rows.Count > 0) {
                currentRowIndex = myTable.Rows.Count - 1;
                DisplayRecord();
            }
        }
        private int currentRowIndex = 0;
        private void DisplayRecord() {
            if (currentRowIndex >= 0 && currentRowIndex < myTable.Rows.Count) {
                myTable.Rows[currentRowIndex]["Manv"].ToString();
                myTable.Rows[currentRowIndex]["HovaTen"].ToString();
                myTable.Rows[currentRowIndex]["NgaySinh"].ToString();
                myTable.Rows[currentRowIndex]["DiaChi"].ToString();
                myTable.Rows[currentRowIndex]["DienThoai"].ToString();
                myTable.Rows[currentRowIndex]["HSLuong"].ToString();
                myTable.Rows[currentRowIndex]["Madonvi"].ToString();
                dataGridView1.ClearSelection();
                dataGridView1.Rows[currentRowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[currentRowIndex].Cells[0];
            }
        }
        private void btn_timkiem_Click(object sender, EventArgs e) {
            try {
                string sqlQuery = "SELECT Manv, HovaTen, DienThoai, HSLuong FROM tblnhanvien WHERE HSLuong IN (2.34, 2.67, 3.0)";
                using (myConnection = new SqlConnection(conStr)) {
                    myConnection.Open();
                    DataTable searchResultTable = new DataTable();
                    using (myCommand = new SqlCommand(sqlQuery, myConnection)) {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(myCommand)) {
                            adapter.Fill(searchResultTable);
                        }
                    }
                    dataGridView1.DataSource = searchResultTable;
                    if (searchResultTable.Rows.Count > 0) {
                        currentRowIndex = 0;
                        DisplayRecord();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
