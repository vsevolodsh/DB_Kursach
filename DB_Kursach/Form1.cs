using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DB_Kursach
{
    public partial class Form1 : Form
    {
        DataBase dataBase;
        string currentTableName;
        public Form1(DataBase dataBase)
        {
            InitializeComponent();
            this.dataBase = dataBase;
        }

        private void информацияОбАрендахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "RentInfo";
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM RentInfo", dataBase.getSqlConnection());
            FillDataAdapter(dataAdapter, dataGridView1);
        }
        private void данныеОбАрендаторахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "Tenant";
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Tenant", dataBase.getSqlConnection());
            FillDataAdapter(dataAdapter, dataGridView1);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void информацияОВсехТоварахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "PrPrGroups";
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM PrPrGroups", dataBase.getSqlConnection());
            FillDataAdapter(dataAdapter, dataGridView1);
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, dataBase.getSqlConnection());
            FillDataAdapter(dataAdapter, dataGridView1);

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
                case "ProductSkiPoles":
                    sqlQuery = "SELECT * FROM ProductSkiPoles WHERE CONCAT (Number, ProductGroup, Name, HandleMaterial, ShaftMaterial," +
                        "SkiPolesLength, RentCostInHour) LIKE '%" + textBoxSearch.Text + "%'";
                    break;
                default:
                    break;
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, dataBase.getSqlConnection());
            FillDataAdapter(dataAdapter, dataGridView1);

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

        private void FillDataAdapter(SqlDataAdapter dataAdapter, DataGridView dgw)
        {
            dgw.DataSource = null;
            dataBase.openConnection();
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgw.DataSource = dataSet.Tables[0];
            labelCount.Text = $"Количество записей в таблице: {dgw.Rows.Count}";
            dataBase.closeConnection();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => dataBase.closeConnection();

        
    }
}
