using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TourAgency
{
    public partial class Login : Form
    {
        public bool needClearText = true;
        public string lineConn = "";
        public Login()
        {
            InitializeComponent();
            OpenConn();
        }
        private void OpenConn()
        {
            SqlConnection conn = DBSQLServerUtils.GetDBConnection();
            try
            {
                lineConn += "Openning connection with data base ...\n";
                label3.Text = lineConn;
                conn.Open();
                lineConn += "Connection with Data Base successful!\n";
                label3.Text = lineConn;
            }
            catch (Exception error)
            {
                lineConn += "ERROR!-> " + error.Message;
                label3.Text = lineConn;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lineConn += "Getting users data from data base ...\n";
                label3.Text = lineConn;
                workersTableAdapter.Fill(this.набор.Workers);
                lineConn += "Users was loaded successful!\n";
                label3.Text = lineConn;
            }
            catch (Exception error)
            {
                lineConn += "ERROR!-> " + error.Message;
                label3.Text = lineConn;
            }
            bool login = false;
            for (int i = 0; i < workersDataGridView.Rows.Count - 1; i++)
            {
                if (textBox1.Text == Convert.ToString(workersDataGridView.Rows[i].Cells[3].Value) && textBox2.Text == Convert.ToString(workersDataGridView.Rows[i].Cells[4].Value))
                {
                    User.LoginAdmin = Convert.ToString(workersDataGridView.Rows[i].Cells[5].Value);
                    User.LoginName = User.LoginAdmin + " id - " + Convert.ToString(workersDataGridView.Rows[i].Cells[0].Value) + " " + Convert.ToString(workersDataGridView.Rows[i].Cells[6].Value) + " " + Convert.ToString(workersDataGridView.Rows[i].Cells[7].Value) + " " + Convert.ToString(workersDataGridView.Rows[i].Cells[8].Value);
                    User.LoginId = Convert.ToInt32(workersDataGridView.Rows[i].Cells[0].Value);
                    Hide();
                    Tables F = new Tables();
                    login = true;
                    F.ShowDialog();
                    this.Close();
                }
            }
            if (login == false)
            {
                MessageBox.Show("wrong login or password", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {
            if(textBox1.Text=="Login")
                if (needClearText == true)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    needClearText = false;
                }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1_Click(sender,e);
            }
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("( more detail in the readme.txt) If you don't have connection with data base - execute the query in the folder, into software SQL Server manegment studio with installed software SQL Server\n\n(Подробнее в readme.txt) Если у вас нет соеденения с базой данных - выполните запрос, лежащий в папке с приложением, в программе SQL Server manegment studio с установленной SQL Server");
        }
    }
}
