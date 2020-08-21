using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Data;

namespace TourAgency
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            FillTextboxes();
        }
        private void FillTextboxes()
        {
            DateTime dateNow = DateTime.Today;
            dateNow.ToShortDateString();
            textBox1.Text = dateNow.AddDays(-30).ToShortDateString().ToString();
            textBox2.Text = dateNow.ToShortDateString().ToString();
            textBox3.Text = dateNow.AddDays(-30).ToShortDateString().ToString();
            textBox4.Text = dateNow.ToShortDateString().ToString();
        }

        public void ClearTempTable(DataGridView dataGridView)
        {
            while (dataGridView.Rows.Count > 1)
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    dataGridView.Rows.Remove(dataGridView.Rows[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTempTable(dataGridView1);
            SqlConnection connection = DBSQLServerUtils.GetDBConnection();
            if (radioButton1.Checked)
            {
                richTextBox1.Text += $"\n{DateTime.Now}\nCREATING REPORT - ALL TIME PROFIT\n";
                richTextBox1.Text += "FROM Orders:\n";
                SqlCommand command = new SqlCommand("SELECT * FROM Orders", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                List<string> id_Tours = new List<string>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    id_Tours.Add(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value));
                    richTextBox1.Text +="id = "+dataGridView1.Rows[i].Cells[0].Value.ToString() + "\tid_Tour = " + dataGridView1.Rows[i].Cells[1].Value.ToString() + "\tid_Client = " 
                        + dataGridView1.Rows[i].Cells[2].Value.ToString() + "\tid_Worker = " + dataGridView1.Rows[i].Cells[3].Value.ToString() + "\tDateOrder = " 
                        + dataGridView1.Rows[i].Cells[4].Value.ToString().Replace(" 0:00:00","") + "\n";
                }
                int sum_profit = 0;
                richTextBox1.Text += "FROM Tours:\n";
                for (int i =0;i<id_Tours.Count;i++)
                {
                    SqlCommand command2 = new SqlCommand("SELECT Price FROM Tours WHERE id='"+id_Tours[i]+"'", connection);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                    DataTable table2 = new DataTable();
                    adapter2.Fill(table2);
                    dataGridView1.DataSource = table2;
                    sum_profit += Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
                    richTextBox1.Text += "id_Tour = "+id_Tours[i].ToString()+"\tPrice = " + dataGridView1.Rows[0].Cells[0].Value.ToString()+"\n";
                }
                richTextBox1.Text += $"END REPORT - ALL TIME PROFIT\t= {sum_profit.ToString()}\n";
            }
            if (radioButton2.Checked)
            {
                richTextBox1.Text += $"\n{DateTime.Now}\nCREATING REPORT - PROFIT FROM {textBox1.Text} TO {textBox2.Text}\n";
                richTextBox1.Text += "FROM Orders:\n";
                SqlCommand command = new SqlCommand("select * from Orders where DateOrder <= '"+textBox2.Text+"' and DateOrder>= '"+textBox1.Text+"'",connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                List<string> id_Tours = new List<string>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    id_Tours.Add(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value));
                    richTextBox1.Text += "id = " + dataGridView1.Rows[i].Cells[0].Value.ToString() + "\tid_Tour = " + dataGridView1.Rows[i].Cells[1].Value.ToString() + "\tid_Client = "
                        + dataGridView1.Rows[i].Cells[2].Value.ToString() + "\tid_Worker = " + dataGridView1.Rows[i].Cells[3].Value.ToString() + "\tDateOrder = "
                        + dataGridView1.Rows[i].Cells[4].Value.ToString().Replace(" 0:00:00", "") + "\n";
                }
                int sum_profit = 0;
                richTextBox1.Text += "FROM Tours:\n";
                for (int i = 0; i < id_Tours.Count; i++)
                {
                    SqlCommand command2 = new SqlCommand("SELECT Price FROM Tours WHERE id='" + id_Tours[i] + "'", connection);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                    DataTable table2 = new DataTable();
                    adapter2.Fill(table2);
                    dataGridView1.DataSource = table2;
                    sum_profit += Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
                    richTextBox1.Text += "id_Tour = " + id_Tours[i].ToString() + "\tPrice = " + dataGridView1.Rows[0].Cells[0].Value.ToString() + "\n";
                }
                richTextBox1.Text += $"END REPORT - PROFIT FROM {textBox1.Text} TO {textBox2.Text}\t= {sum_profit.ToString()}\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearTempTable(dataGridView1);
            SqlConnection connection = DBSQLServerUtils.GetDBConnection();
            if (radioButton3.Checked)
            {
                richTextBox1.Text += $"\n{DateTime.Now}\nCREATING REPORT - ALL TIME PROFIT BY WORKER 'ID = {textBox5.Text}'\n";
                richTextBox1.Text += "FROM Orders:\n";
                SqlCommand command = new SqlCommand($"SELECT * FROM Orders where id_Worker = {textBox5.Text}", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                List<string> id_Tours = new List<string>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    id_Tours.Add(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value));
                    richTextBox1.Text += "id = " + dataGridView1.Rows[i].Cells[0].Value.ToString() + "\tid_Tour = " + dataGridView1.Rows[i].Cells[1].Value.ToString() + "\tid_Client = "
                        + dataGridView1.Rows[i].Cells[2].Value.ToString() + "\tid_Worker = " + dataGridView1.Rows[i].Cells[3].Value.ToString() + "\tDateOrder = "
                        + dataGridView1.Rows[i].Cells[4].Value.ToString().Replace(" 0:00:00", "") + "\n";
                }
                int sum_profit = 0;
                richTextBox1.Text += "FROM Tours:\n";
                for (int i = 0; i < id_Tours.Count; i++)
                {
                    SqlCommand command2 = new SqlCommand("SELECT Price FROM Tours WHERE id='" + id_Tours[i] + "'", connection);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                    DataTable table2 = new DataTable();
                    adapter2.Fill(table2);
                    dataGridView1.DataSource = table2;
                    sum_profit += Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
                    richTextBox1.Text += "id_Tour = " + id_Tours[i].ToString() + "\tPrice = " + dataGridView1.Rows[0].Cells[0].Value.ToString() + "\n";
                }
                richTextBox1.Text += $"END REPORT - ALL TIME PROFIT BY WORKER 'ID = {textBox5.Text}'\t= {sum_profit.ToString()}\n";
            }
            if (radioButton4.Checked)
            {
                richTextBox1.Text += $"\n{DateTime.Now}\nCREATING REPORT - PROFIT FROM {textBox3.Text} TO {textBox4.Text} BY WORKER 'ID = {textBox5.Text}'\n";
                richTextBox1.Text += "FROM Orders:\n";
                SqlCommand command = new SqlCommand($"select * from Orders where id_Worker = {textBox5.Text} and DateOrder <= '" + textBox4.Text + "' and DateOrder>= '" + textBox3.Text + "'", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                List<string> id_Tours = new List<string>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    id_Tours.Add(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value));
                    richTextBox1.Text += "id = " + dataGridView1.Rows[i].Cells[0].Value.ToString() + "\tid_Tour = " + dataGridView1.Rows[i].Cells[1].Value.ToString() + "\tid_Client = "
                        + dataGridView1.Rows[i].Cells[2].Value.ToString() + "\tid_Worker = " + dataGridView1.Rows[i].Cells[3].Value.ToString() + "\tDateOrder = "
                        + dataGridView1.Rows[i].Cells[4].Value.ToString().Replace(" 0:00:00", "") + "\n";
                }
                int sum_profit = 0;
                richTextBox1.Text += "FROM Tours:\n";
                for (int i = 0; i < id_Tours.Count; i++)
                {
                    SqlCommand command2 = new SqlCommand("SELECT Price FROM Tours WHERE id='" + id_Tours[i] + "'", connection);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                    DataTable table2 = new DataTable();
                    adapter2.Fill(table2);
                    dataGridView1.DataSource = table2;
                    sum_profit += Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
                    richTextBox1.Text += "id_Tour = " + id_Tours[i].ToString() + "\tPrice = " + dataGridView1.Rows[0].Cells[0].Value.ToString() + "\n";
                }
                richTextBox1.Text += $"END REPORT - PROFIT FROM {textBox3.Text} TO {textBox4.Text} BY WORKER 'ID = {textBox5.Text}'\t= {sum_profit.ToString()}\n";
            }
        }
    }
}
