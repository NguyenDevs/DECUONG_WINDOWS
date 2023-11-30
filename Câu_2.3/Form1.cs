using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Câu_2._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            int row = listBox1.SelectedIndex;
            if (row != -1)
            {
                string item = listBox1.SelectedItem.ToString();
                listBox2.Items.Add(item);
            }
        }

        private void btn_chonall_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            int row = listBox2.SelectedIndex;
            if (row != -1)
            {
                string item = listBox2.SelectedItem.ToString();
                listBox2.Items.Remove(item);
            }
        }

        private void btn_huyall_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void btn_tinhtien_Click(object sender, EventArgs e)
        {
            int totalPrice = 0;
            foreach (var item in listBox2.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int price))
                {
                    totalPrice += price;
                }
            }
            txt_thanhtien.Text = totalPrice.ToString();
            txt_sosuatchon.Text = listBox2.Items.Count.ToString();
        }

        private void btn_dattiep_Click(object sender, EventArgs e)
        {
            txt_thanhtien.Clear();
            txt_sosuatchon.Clear();
            listBox2.Items.Clear();
        }

        private string ExtractDigitsFromListBox(ListBox listBox2)
        {
            string digits = "";
            foreach (var item in listBox2.Items)
            {
                string text = item.ToString();
                foreach (char c in text)
                {
                    if (char.IsDigit(c))
                    {
                        digits += c;
                    }
                }
            }
            return digits;
        }
    }
}
   
