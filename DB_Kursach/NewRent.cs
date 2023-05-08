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

namespace DB_Kursach
{
    public partial class NewRent : Form
    {
        DataBase _dataBase;
        DataSet dataSet = new DataSet();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        SqlCommandBuilder commandBuilder;
        public int[] ProductsNumber { get; private set; }
        public int TenantId { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public decimal TotalRentCost { get; private set; }
        public decimal TotalDeposit { get; private set; }
        public int RentId { get; private set; }
        SqlCommand _commandProducts;
        SqlCommand _commandTenants;
        public bool stop { get; set; } = false;
        public NewRent(DataBase dataBase)
        {
            _dataBase = dataBase;
            InitializeComponent();
            dateTimePickerHourStart.Format = DateTimePickerFormat.Time;
            dateTimePickerHourStart.ShowUpDown = true;
            dateTimePickerHourEnd.Format = DateTimePickerFormat.Time;
            dateTimePickerHourEnd.ShowUpDown = true;
            _dataBase.openConnection();
            _commandProducts = new("SELECT Number AS Артикул, Name AS Навание, ProductGroup AS \"Группа товара\", RentCostInHour AS \"Стоимость за час\"," +
                " IsProductInWarehouse AS \"Товар на складе\" FROM PrPrGroups WHERE IsProductInWarehouse = 1", dataBase.getSqlConnection());
            _commandTenants = new("SELECT Id, FIO AS ФИО, Phone AS \"Номер телефона\", Age AS Возраст, Gender AS Пол FROM Tenant", dataBase.getSqlConnection());
            dataAdapter.SelectCommand = _commandProducts;
            dataAdapter.Fill(dataSet, "Products");
            dataAdapter.SelectCommand = _commandTenants;
            dataAdapter.Fill(dataSet, "Tenants");
            dataGridViewProducts.DataSource = dataSet.Tables[0];
            dataGridViewTenants.DataSource = dataSet.Tables[1];
            _dataBase.closeConnection();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DateStart = dateTimePickerDayStart.Value.Date + dateTimePickerHourStart.Value.TimeOfDay;
            DateEnd = dateTimePickerDayEnd.Value.Date + dateTimePickerHourEnd.Value.TimeOfDay;
            if (DateStart > DateEnd)
            {
                MessageBox.Show("Срок окончания аренды раньше срока начала! Попробуйте заново.");
                stop = true;
                return;
            }
            ProductsNumber = new int[dataGridViewProducts.SelectedRows.Count];
            for (int i = 0; i < ProductsNumber.Length; i++)
            {
                ProductsNumber[i] = (int)dataSet.Tables[0].Rows[dataGridViewProducts.SelectedRows[i].Index][0];
            }
            TenantId = (int)dataSet.Tables[1].Rows[dataGridViewTenants.SelectedRows[0].Index][0];
            TotalRentCost = numericUpDownRent.Value;
            TotalDeposit = numericUpDownDeposit.Value;
            _dataBase.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT IDENT_CURRENT('Rent')", _dataBase.getSqlConnection());
            RentId = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            _dataBase.closeConnection();
        }
    }
}
