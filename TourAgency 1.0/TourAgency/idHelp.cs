using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TourAgency
{
    public partial class idHelp : Form
    {
        public idHelp()
        {
            InitializeComponent();
            Text = Tables.loadTable;
            LoadTables();
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void LoadTables()
        {
            if (Text == "id_Post")
            {
                Tables.postsTableAdapter.Fill(Tables.набор.Posts);
                dataGridView1.DataSource = Tables.postsBindingSource;
            }
            if (Text == "id_Department")
            {
                Tables.departmentsTableAdapter.Fill(Tables.набор.Departments);
                dataGridView1.DataSource = Tables.departmentsBindingSource;
            }
            if (Text == "id_PassWorker")
            {
                Tables.passWorkersTableAdapter.Fill(Tables.набор.PassWorkers);
                dataGridView1.DataSource = Tables.passWorkersBindingSource;
            }
            if (Text == "id_LocationWorker")
            {
                Tables.locationWorkersTableAdapter.Fill(Tables.набор.LocationWorkers);
                dataGridView1.DataSource = Tables.locationWorkersBindingSource;
            }
            if (Text == "id_Airport")
            {
                Tables.airportsTableAdapter.Fill(Tables.набор.Airports);
                dataGridView1.DataSource = Tables.airportsBindingSource;
            }
            if (Text == "id_BusStation")
            {
                Tables.busStationsTableAdapter.Fill(Tables.набор.BusStations);
                dataGridView1.DataSource = Tables.busStationsBindingSource;
            }
            if (Text == "id_City")
            {
                Tables.citiesTableAdapter.Fill(Tables.набор.Cities);
                dataGridView1.DataSource = Tables.citiesBindingSource;
            }
            if (Text == "id_Client")
            {
                Tables.clientsTableAdapter.Fill(Tables.набор.Clients);
                dataGridView1.DataSource = Tables.clientsBindingSource;
            }
            if (Text == "id_Country")
            {
                Tables.countriesTableAdapter.Fill(Tables.набор.Countries);
                dataGridView1.DataSource = Tables.countriesBindingSource;
            }

            if (Text == "id_Eat")
            {
                Tables.eatsTableAdapter.Fill(Tables.набор.Eats);
                dataGridView1.DataSource = Tables.eatsBindingSource;
            }
            if (Text == "id_Hotel")
            {
                Tables.hotelsTableAdapter.Fill(Tables.набор.Hotels);
                dataGridView1.DataSource = Tables.hotelsBindingSource;
            }
            if (Text == "id_LocationClient")
            {
                Tables.locationClientsTableAdapter.Fill(Tables.набор.LocationClients);
                dataGridView1.DataSource = Tables.locationClientsBindingSource;
            }
            if (Text == "id_Order")
            {
                Tables.ordersTableAdapter.Fill(Tables.набор.Orders);
                dataGridView1.DataSource = Tables.ordersBindingSource;
            }
            if (Text == "id_PassClient")
            {
                Tables.passClientsTableAdapter.Fill(Tables.набор.PassClients);
                dataGridView1.DataSource = Tables.passClientsBindingSource;
            }

            if (Text == "id_Tour")
            {
                Tables.toursTableAdapter.Fill(Tables.набор.Tours);
                dataGridView1.DataSource = Tables.toursBindingSource;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tables.id_ = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            Close();
        }
    }
}
