using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                        "SkiPolesLength) LIKE '%" + textBoxSearch.Text + "%'";
                    break;
                case "ProductsSkis":
                    sqlQuery = "SELECT * FROM ProductsSkis WHERE CONCAT (Number, ProductGroup, Name, RidingStyle, SkiLength) " +
                        "LIKE '%" + textBoxSearch.Text + "%'";
                    break;
                case "ProductsSleigh":
                    sqlQuery = "SELECT * FROM ProductsSleigh WHERE CONCAT (Number, ProductGroup, Name, Construction, RunnersType, MaxLoad) " +
                        "LIKE '%" + textBoxSearch.Text + "%'";
                    break;
                case "ProductsSkates":
                    sqlQuery = "SELECT * FROM ProductsSkates WHERE CONCAT (Number, ProductGroup, Name, BladeSteel, Fixation, Size) " +
                        "LIKE '%" + textBoxSearch.Text + "%'";
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

        private void забронированныеТоварыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "BookedProducts";
            dataAdapter = new SqlDataAdapter("SELECT * FROM BookedProducts", dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }

        private void товарыВРемонтеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "ProductsUnderRepair";
            dataAdapter = new SqlDataAdapter("SELECT * FROM ProductsUnderRepair", dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }

        private void добавитьНовыйТоварToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sqlExpression;
            NewProductForm npForm = new();
            DialogResult result = npForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                dataBase.openConnection();
                SqlCommand command;
                SqlParameter numberParam = new("@Number", npForm.Number);
                SqlParameter subCategoryCodeParam = new("@ProductSubCategoryCode", npForm.ProductSubCategoryCode);
                SqlParameter codeParam = new("@Code", npForm.Code);
                SqlParameter nameParam = new("@Name", npForm.Name);
                SqlParameter rentCostInhourParam = new("@RentCostInHour", npForm.RentCostInHour);
                switch (npForm.selectedCategory)
                {
                    case "ProductsSkiPoles":
                        sqlExpression = "sp_insertSkiPoles";
                        command = new(sqlExpression, dataBase.getSqlConnection());
                        SqlParameter shaftMaterialParam = new("@ShaftMaterial", npForm.ShaftMaterial);
                        SqlParameter handleMaterialParam = new("@HandleMaterial", npForm.HandleMaterial);
                        SqlParameter skiPolesLengthParam = new("@SkiPolesLength", npForm.SkiPolesLength);
                        command.Parameters.Add(shaftMaterialParam);
                        command.Parameters.Add(handleMaterialParam);
                        command.Parameters.Add(skiPolesLengthParam);
                        break;
                    case "ProductsSkis":
                        sqlExpression = "sp_insertSki";
                        command = new(sqlExpression, dataBase.getSqlConnection());
                        SqlParameter ridingStyleParam = new("@RidingStyle", npForm.RidingStyle);
                        SqlParameter skiLengthParam = new("@SkiLength", npForm.SkiLength);
                        command.Parameters.Add(ridingStyleParam);
                        command.Parameters.Add(skiLengthParam);
                        break;
                    case "ProductsSleigh":
                        sqlExpression = "sp_insertSleigh";
                        command = new(sqlExpression, dataBase.getSqlConnection());
                        SqlParameter bladeSteelParam = new("@BladeSteel", npForm.BladeSteel);
                        SqlParameter fixationParam = new("@Fixation", npForm.Fixation);
                        SqlParameter sizeParam = new("@Size", npForm.Size);
                        command.Parameters.Add(bladeSteelParam);
                        command.Parameters.Add(fixationParam);
                        command.Parameters.Add(sizeParam);
                        break;
                    case "ProductsSkates":
                        sqlExpression = "sp_insertSkates";
                        command = new(sqlExpression, dataBase.getSqlConnection());
                        SqlParameter constructionParam = new("@Construction", npForm.Construction);
                        SqlParameter runnersTypeParam = new("@RunnersType", npForm.RunnersType);
                        SqlParameter maxLoadParam = new("@MaxLoad", npForm.MaxLoad);
                        command.Parameters.Add(constructionParam);
                        command.Parameters.Add(runnersTypeParam);
                        command.Parameters.Add(maxLoadParam);
                        break;
                    default:
                        dataBase.closeConnection();
                        return;
                }
                command.Parameters.Add(numberParam);
                command.Parameters.Add(subCategoryCodeParam);
                command.Parameters.Add(codeParam);
                command.Parameters.Add(nameParam);
                command.Parameters.Add(rentCostInhourParam);
                command.CommandType = CommandType.StoredProcedure;
                var queryResult = command.ExecuteNonQuery();
                dataBase.closeConnection();
            }
            if (result == DialogResult.Cancel)
                return;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            string sqlQuery = $"SELECT * FROM {currentTableName}";
            dataAdapter = new SqlDataAdapter(sqlQuery, dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }
    }
}
