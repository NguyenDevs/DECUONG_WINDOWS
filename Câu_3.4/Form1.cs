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
using System.Windows.Input;

namespace Câu_3._4 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void btn_thoat_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private DataSet myDataSet;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private SqlDataAdapter myDataAdapter;
        private DataTable myTable;
        private string conStr = @"Data Source=RAPHAEL-PC\RAPHAEL;Initial Catalog=QLSV;
        Persist Security Info=True;User ID=sa;Password=Blacksmith@0407";
        private void Display() {
            string sqlStr = "SELECT * FROM tblnhanvien";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr)) {
                myTable = new DataTable();
                myDataAdapter.Fill(myTable);
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoGenerateColumns = false;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int row = e.RowIndex;
            if (row >= myTable.Rows.Count)
                row = myTable.Rows.Count - 1;
            else
            {
                MoveToRow(row);
            }
        }
        private int currentIndex = 0;
        private void MoveToRow(int index)
        {
            try
            {
                if (index >= 0 && index < myTable.Rows.Count)
                {
                    currentIndex = index;
                    myTable.Rows[currentIndex]["Manv"].ToString();
                    myTable.Rows[currentIndex]["HovaTen"].ToString();
                    myTable.Rows[currentIndex]["NgaySinh"].ToString();
                    myTable.Rows[currentIndex]["DiaChi"].ToString();
                    myTable.Rows[currentIndex]["DienThoai"].ToString();
                    myTable.Rows[currentIndex]["HSLuong"].ToString();
                    myTable.Rows[currentIndex]["Madonvi"].ToString();
                    dataGridView1.Rows[index].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            Display();
        }
        private void btn_first_Click(object sender, EventArgs e) {
            MoveToRow(0);
        }
        private void btn_previous_Click(object sender, EventArgs e) {
            MoveToRow(currentIndex - 1);
        }
        private void btn_next_Click(object sender, EventArgs e) {
            if (currentIndex < myTable.Rows.Count - 1)
                MoveToRow(currentIndex + 1);
        }
        private void btn_last_Click(object sender, EventArgs e) {
            MoveToRow(myTable.Rows.Count - 1);
        }
        private void btn_timkiem_Click(object sender, EventArgs e) {
            try {
                string sqlQuery = "SELECT * FROM tblnhanvien WHERE HSLuong IN (2.34, 2.67, 3.0)";
                using (myDataAdapter = new SqlDataAdapter(sqlQuery, conStr))
                {
                    myDataSet = new DataSet();
                    myDataAdapter.Fill(myDataSet, "daotao");
                    myTable = myDataSet.Tables["daotao"];
                    dataGridView1.DataSource = myTable;
                    dataGridView1.AutoGenerateColumns = false;
                    if (myTable.Rows.Count > 0)
                    {
                        MoveToRow(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}