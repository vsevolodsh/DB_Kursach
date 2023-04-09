using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DB_Kursach
{
    public partial class Form1 : Form
    {
        DataBase dataBase;
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder commandBuilder;
        string currentTableName;
        public Form1(DataBase dataBase)
        {
            InitializeComponent();
            this.dataBase = dataBase;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void информацияОбАрендахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "RentInfo";
            dataAdapter = new SqlDataAdapter("SELECT * FROM RentInfo", dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }
        private void данныеОбАрендаторахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "Tenant";
            dataAdapter = new SqlDataAdapter("SELECT * FROM Tenant", dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void информацияОВсехТоварахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "PrPrGroups";
            dataAdapter = new SqlDataAdapter("SELECT * FROM PrPrGroups", dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }

        private void подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryForm ctgForm = new();
            DialogResult result = ctgForm.ShowDialog(this);
            bool onlyProductsInWarehouse;
            if (result == DialogResult.OK)
                currentTableName = ctgForm.selectedCategory;
            onlyProductsInWarehouse = ctgForm.onlyProductsInWarehouse;
            if (result == DialogResult.Cancel)
                return;
            string sqlQuery = $"SELECT * FROM {currentTableName}";
            if (onlyProductsInWarehouse)
            {
                sqlQuery = sqlQuery + " WHERE IsProductInWarehouse = 1";
            }
            dataAdapter = new SqlDataAdapter(sqlQuery, dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);

        }

        public void Search(DataGridView dgw)
        {
            string sqlQuery = "";
            switch (currentTableName)
            {
                case "RentInfo":
                    sqlQuery = "SELECT * FROM RentInfo WHERE CONCAT (Id, TenantName, ProductsNumbers) LIKE '%" + textBoxSearch.Text + "%'";
                    break;
                case "PrPrGroups":
                    sqlQuery = "SELECT * FROM PrPrGroups WHERE CONCAT (Number, Name, ProductGroup, RentCostInHour) LIKE '%" + textBoxSearch.Text + "%'";
                    break;
                case "ProductsSkiPoles":
                    sqlQuery = "SELECT * FROM ProductsSkiPoles WHERE CONCAT (Number, ProductGroup, Name, HandleMaterial, ShaftMaterial," +
                        "SkiPolesLength, RentCostInHour) LIKE '%" + textBoxSearch.Text + "%'";
                    break;
                default:
                    break;
            }
            dataAdapter = new SqlDataAdapter(sqlQuery, dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);

        }
        private void добавитьНовогоАрендатораToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string fio = "";
            byte age = 1;
            string telNumber = "";
            string gender = "";
            NewTenantForm ntForm = new();
            DialogResult result = ntForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                fio = ntForm.fio;
                age = ntForm.age;
                telNumber = ntForm.telNumber;
                gender = ntForm.gender;
            }
            if (result == DialogResult.Cancel)
                return;
            string sqlExpression = "sp_InsertTenant";
            dataBase.openConnection();
            SqlCommand command = new(sqlExpression, dataBase.getSqlConnection());
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter fioParam = new SqlParameter
            {
                ParameterName = "@FIO",
                Value = fio
            };
            SqlParameter ageParam = new SqlParameter
            {
                ParameterName = "@Age",
                Value = age
            };
            SqlParameter telNumberParam = new SqlParameter
            {
                ParameterName = "@Phone",
                Value = telNumber
            };
            SqlParameter genderParam = new SqlParameter
            {
                ParameterName = "@Gender",
                Value = gender
            };
            command.Parameters.Add(fioParam);
            command.Parameters.Add(ageParam);
            command.Parameters.Add(telNumberParam);
            command.Parameters.Add(genderParam);
            var queryResult = command.ExecuteNonQuery();
            dataBase.closeConnection();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // удаляем выделенные строки из dataGridView1
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void FillDataAdapter(DataGridView dgw)
        {
            dgw.DataSource = null;
            dataBase.openConnection();
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgw.DataSource = dataSet.Tables[0];
            dataGridView1.Columns[0].ReadOnly = true;
            labelCount.Text = $"Количество записей в таблице: {dgw.Rows.Count}";
            dataBase.closeConnection();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => dataBase.closeConnection();

        private void buttonSave_Click(object sender, EventArgs e)
        {
            commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataSet);
        }
    }
}
