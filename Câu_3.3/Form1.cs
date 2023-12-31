﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Câu_3._3{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private DataSet myDataSet;
        private SqlConnection myConnection;
        private DataTable myTable;
        private string conStr = @"Data Source=RAPHAEL-PC\RAPHAEL;Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=Blacksmith@0407";

        private int currentIndex = 0;
        private void Display() {
            string sqlStr = "SELECT * FROM tblnhanvien";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr)) {
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
        private void MoveToRow(int index){
            try {
                if (index >= 0 && index < myTable.Rows.Count) {
                    currentIndex = index;
                    txt_manv.Text = myTable.Rows[currentIndex]["MaNV"].ToString();
                    txt_hoten.Text = myTable.Rows[currentIndex]["HovaTen"].ToString();
                    txt_hesoluong.Text = myTable.Rows[currentIndex]["HSLuong"].ToString();
                    txt_dienthoai.Text = myTable.Rows[currentIndex]["DienThoai"].ToString();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
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
        private void btn_thoat_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private void btn_thongke_Click(object sender, EventArgs e) {
            string sqlQuery = $"SELECT * FROM tblnhanvien WHERE HovaTen = 'Lam'";
            using (myDataAdapter = new SqlDataAdapter(sqlQuery, conStr)) {
                DataTable resultTable = new DataTable();
                myDataAdapter.Fill(resultTable);
                if (resultTable.Rows.Count > 0) {
                    MoveToRow(resultTable.Rows[0].Table.Rows.IndexOf(resultTable.Rows[0]));
                }
                else {
                    MessageBox.Show($"Không tìm thấy nhân viên có tên là Lam");
                }
            }
        }
    }
}
