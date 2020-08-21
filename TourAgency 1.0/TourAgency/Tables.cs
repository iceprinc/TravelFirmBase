using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TourAgency
{
    public partial class Tables : Form
    {
        public static string loadTable = "";
        public static string id_ = "";
        public bool tableSaved = true;
        public Tables()
        {
            InitializeComponent(); 
            this.WindowState = FormWindowState.Maximized;
            toolStripLabel1.Text = User.LoginName;
            FillComboBox();
        }
        private void FillComboBox()
        {
            if (User.LoginAdmin == "null")
            {
                toolStripComboBox1.Enabled = false;
                BindingNavigatorSaveItem.Enabled = false;
                checkBox1.Enabled = false;
                autoSave.Enabled = false;
            }
            toolStripComboBox1.Items.Add("Orders");
            toolStripComboBox1.Items.Add("Tours");
            toolStripComboBox1.Items.Add("Hotels");
            toolStripComboBox1.Items.Add("Airports");
            toolStripComboBox1.Items.Add("BusStations");
            toolStripComboBox1.Items.Add("Cities");
            toolStripComboBox1.Items.Add("Countries");
            toolStripComboBox1.Items.Add("Eats");
            toolStripComboBox1.Items.Add("Clients");
            toolStripComboBox1.Items.Add("PassClients");
            toolStripComboBox1.Items.Add("LocationClients");
            if (User.LoginAdmin == "admin")
            {
                reportsButton.Enabled = true;
                toolStripComboBox1.Items.Add("Posts");
                toolStripComboBox1.Items.Add("Departments");
                toolStripComboBox1.Items.Add("Workers");
                toolStripComboBox1.Items.Add("PassWorkers");
                toolStripComboBox1.Items.Add("LocationWorkers");
            }
        }

        private void BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            if (toolStripComboBox1.Text == "Airports")
            {
                airportsBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "BusStations")
            {
                busStationsBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Cities")
            {
                citiesBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Clients")
            {
                clientsBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Countries")
            {
                countriesBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Departments")
            {
                departmentsBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Eats")
            {
                eatsBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Hotels")
            {
                hotelsBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "LocationClients")
            {
                locationClientsBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "LocationWorkers")
            {
                locationWorkersBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Orders")
            {
                ordersBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "PassClients")
            {
                passClientsBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "PassWorkers")
            {
                passWorkersBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Posts")
            {
                postsBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Tours")
            {
                toursBindingSource.EndEdit();
            }
            if (toolStripComboBox1.Text == "Workers")
            {
                workersBindingSource.EndEdit();
            }
            tableAdapterManager.UpdateAll(набор);
            tableSaved = true;
        }
        private void LoadTable()
        {
            if (User.LoginAdmin == "admin")
            {
                if (toolStripComboBox1.Text == "Posts")
                {
                    this.Text = "Posts";
                    postsTableAdapter.Fill(набор.Posts);
                    dataGridView1.DataSource = postsBindingSource;
                    BindingNavigator1.BindingSource = postsBindingSource;
                }
                if (toolStripComboBox1.Text == "Departments")
                {
                    this.Text = "Departments";
                    departmentsTableAdapter.Fill(набор.Departments);
                    dataGridView1.DataSource = departmentsBindingSource;
                    BindingNavigator1.BindingSource = departmentsBindingSource;
                }
                if (toolStripComboBox1.Text == "PassWorkers")
                {
                    this.Text = "PassWorkers";
                    passWorkersTableAdapter.Fill(набор.PassWorkers);
                    dataGridView1.DataSource = passWorkersBindingSource;
                    BindingNavigator1.BindingSource = passWorkersBindingSource;
                }
                if (toolStripComboBox1.Text == "LocationWorkers")
                {
                    this.Text = "LocationWorkers";
                    locationWorkersTableAdapter.Fill(набор.LocationWorkers);
                    dataGridView1.DataSource = locationWorkersBindingSource;
                    BindingNavigator1.BindingSource = locationWorkersBindingSource;
                }
                if (toolStripComboBox1.Text == "Workers")
                {
                    this.Text = "Workers";
                    workersTableAdapter.Fill(набор.Workers);
                    dataGridView1.DataSource = workersBindingSource;
                    BindingNavigator1.BindingSource = workersBindingSource;
                }
            }
            if (toolStripComboBox1.Text == "Airports")
            {
                this.Text = "Airports";
                airportsTableAdapter.Fill(набор.Airports);
                dataGridView1.DataSource = airportsBindingSource;
                BindingNavigator1.BindingSource = airportsBindingSource;
            }
            if (toolStripComboBox1.Text == "BusStations")
            {
                this.Text = "BusStations";
                busStationsTableAdapter.Fill(набор.BusStations);
                dataGridView1.DataSource = busStationsBindingSource;
                BindingNavigator1.BindingSource = busStationsBindingSource;
            }
            if (toolStripComboBox1.Text == "Cities")
            {
                this.Text = "Cities";
                citiesTableAdapter.Fill(набор.Cities);
                dataGridView1.DataSource = citiesBindingSource;
                BindingNavigator1.BindingSource = citiesBindingSource;
            }
            if (toolStripComboBox1.Text == "Clients")
            {
                this.Text = "Clients";
                clientsTableAdapter.Fill(набор.Clients);
                dataGridView1.DataSource = clientsBindingSource;
                BindingNavigator1.BindingSource = clientsBindingSource;
            }
            if (toolStripComboBox1.Text == "Countries")
            {
                this.Text = "Countries";
                countriesTableAdapter.Fill(набор.Countries);
                dataGridView1.DataSource = countriesBindingSource;
                BindingNavigator1.BindingSource = countriesBindingSource;
            }
            
            if (toolStripComboBox1.Text == "Eats")
            {
                this.Text = "Eats";
                eatsTableAdapter.Fill(набор.Eats);
                dataGridView1.DataSource = eatsBindingSource;
                BindingNavigator1.BindingSource = eatsBindingSource;
            }
            if (toolStripComboBox1.Text == "Hotels")
            {
                this.Text = "Hotels";
                hotelsTableAdapter.Fill(набор.Hotels);
                dataGridView1.DataSource = hotelsBindingSource;
                BindingNavigator1.BindingSource = hotelsBindingSource;
            }
            if (toolStripComboBox1.Text == "LocationClients")
            {
                this.Text = "LocationClients";
                locationClientsTableAdapter.Fill(набор.LocationClients);
                dataGridView1.DataSource = locationClientsBindingSource;
                BindingNavigator1.BindingSource = locationClientsBindingSource;
            }
            if (toolStripComboBox1.Text == "Orders")
            {
                this.Text = "Orders";
                ordersTableAdapter.Fill(набор.Orders);
                dataGridView1.DataSource = ordersBindingSource;
                BindingNavigator1.BindingSource = ordersBindingSource;
            }
            if (toolStripComboBox1.Text == "PassClients")
            {
                this.Text = "PassClients";
                passClientsTableAdapter.Fill(набор.PassClients);
                dataGridView1.DataSource = passClientsBindingSource;
                BindingNavigator1.BindingSource = passClientsBindingSource;
            }
            
            if (toolStripComboBox1.Text == "Tours")
            {
                this.Text = "Tours";
                toursTableAdapter.Fill(набор.Tours);
                dataGridView1.DataSource = toursBindingSource;
                BindingNavigator1.BindingSource = toursBindingSource;
            }
            tableSaved = false;
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if(autoSave.Checked==true)
            {
                BindingNavigatorSaveItem_Click(sender,e);
            }
                
            if(tableSaved==false)
            {
                DialogResult dialogResult = MessageBox.Show("Вы не сохранили данные, всё равно сменить таблицу ?", "Данные не сохранены", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    LoadTable();
                }
            }
            else
            {
                LoadTable();
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(checkBox1.Checked)
            {
                int row = dataGridView1.CurrentCell.RowIndex;
                int col = dataGridView1.CurrentCell.ColumnIndex;
                if(dataGridView1.Columns[col].HeaderText.StartsWith("id_"))
                {
                    loadTable = dataGridView1.Columns[col].HeaderText;
                    if(loadTable == "id_Worker")
                    {
                        int index = User.LoginName.IndexOf(" - ");
                        Tables.id_ = User.LoginName.Remove(0, index + 3);
                        List<string> strings = new List<string>();
                        strings.AddRange(Tables.id_.Split(' '));
                        Tables.id_ = strings[0];
                    }
                    else
                    {
                        idHelp idHelp = new idHelp();
                        idHelp.ShowDialog();
                    }
                    dataGridView1.Rows[row].Cells[col].Value = id_;
                }
                if(dataGridView1.Columns[col].HeaderText=="DateOrder")
                {
                    dataGridView1.Rows[row].Cells[col].Value = DateTime.Now.ToShortDateString();
                }
            }
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void Tables_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (autoSave.Checked == true)
            {
                BindingNavigatorSaveItem_Click(sender, e);
            }
        }

    }
}
