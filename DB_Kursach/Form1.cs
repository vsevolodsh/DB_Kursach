using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
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
        string sqlDeleteQuery;
        public Form1(DataBase dataBase)
        {
            InitializeComponent();
            this.dataBase = dataBase;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search(dataGridView1);
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
            NewTenantForm ntForm = new();
            DialogResult result = ntForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                dataBase.openConnection();
                string sqlExpression = "sp_InsertTenant";
                SqlCommand command = new(sqlExpression, dataBase.getSqlConnection());
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter fioParam = new("@FIO", ntForm.fio);
                SqlParameter ageParam = new("@Age", ntForm.age);
                SqlParameter telNumberParam = new("@Phone", ntForm.telNumber);
                SqlParameter genderParam = new("@Gender", ntForm.gender);
                command.Parameters.Add(fioParam);
                command.Parameters.Add(ageParam);
                command.Parameters.Add(telNumberParam);
                command.Parameters.Add(genderParam);
                var queryResult = command.ExecuteNonQuery();
                //dataAdapter.DeleteCommand = new SqlCommand();
                dataBase.closeConnection();
            }
            if (result == DialogResult.Cancel)
                return;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // удаляем выделенные строки из dataGridView1
            dataBase.openConnection();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataAdapter.DeleteCommand = new SqlCommand(sqlDeleteQuery, dataBase.getSqlConnection());
                if (currentTableName.Equals("PrPrGroups"))
                    dataAdapter.DeleteCommand.Parameters.Add("@Number", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                else
                    dataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                dataAdapter.DeleteCommand.ExecuteNonQuery();
                dataGridView1.Rows.Remove(row);
            }
            dataBase.closeConnection();
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
            dataBase.openConnection();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                switch (currentTableName)
                {
                    case "RentInfo":
                        break;
                    case "PrPrGroups":
                        dataAdapter.UpdateCommand = new SqlCommand("UPDATE Product SET Name = @Name, RentCostInHour = @RentCostInHour WHERE Number = @Number",
                    dataBase.getSqlConnection());
                        dataAdapter.UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][1];
                        dataAdapter.UpdateCommand.Parameters.Add("@RentCostInHour", SqlDbType.Money).Value = dataSet.Tables[0].Rows[row.Index][3];
                        dataAdapter.UpdateCommand.Parameters.Add("@Number", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                        break;
                    case "ProductsSkiPoles":
                        break;
                    case "ProductsSkis":
                        break;
                    case "ProductsSleigh":
                        break;
                    case "ProductsSkates":
                        break;
                    case "Tenant":
                        dataAdapter.UpdateCommand = new SqlCommand("UPDATE Tenant SET FIO = @FIO, Age = @Age, Phone = @Phone, Gender = @Gender " +
                            "WHERE Id = @Id", dataBase.getSqlConnection());
                        dataAdapter.UpdateCommand.Parameters.Add("@FIO", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][1];
                        dataAdapter.UpdateCommand.Parameters.Add("@Age", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][2];
                        dataAdapter.UpdateCommand.Parameters.Add("@Phone", SqlDbType.VarChar).Value = dataSet.Tables[0].Rows[row.Index][3];
                        dataAdapter.UpdateCommand.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][4];
                        dataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                        break;
                    default:
                        break;
                }
                dataAdapter.UpdateCommand.ExecuteNonQuery();
                dataBase.closeConnection();


            }
        }

        private void информацияОВсехТоварахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "PrPrGroups";
            dataAdapter = new SqlDataAdapter("SELECT Number AS Артикул, Name AS Навание, ProductGroup AS \"Группа товара\", RentCostInHour AS \"Стоимость за час\"," +
                " IsProductInWarehouse AS \"Товар на складе\" FROM PrPrGroups", dataBase.getSqlConnection());
            sqlDeleteQuery = "DELETE FROM Product WHERE Number = @Number";
            FillDataAdapter(dataGridView1);
        }

        private void подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonDelete.Enabled = false;
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

        private void информацияОбАрендахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "RentInfo";
            dataAdapter = new SqlDataAdapter("SELECT Id, TenantName AS \"Имя арендатора\", ProductsNumbers AS \"Артикулы товаров\"," +
                " DateStart AS \"Дата начала\", DateEnd AS \"Дата конца\", RentCost AS \"Цена аренды\", Deposit AS Залог, isOver AS Завершена FROM RentInfo", dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }
        private void данныеОбАрендаторахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTableName = "Tenant";
            dataAdapter = new SqlDataAdapter("SELECT Id, FIO AS ФИО, Age AS Возраст, Phone AS \"Номер телефона\", Gender AS Пол FROM Tenant",
                dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }
        private void забронированныеТоварыToolStripMenuItem_Click(object sender, EventArgs e)
            {
                currentTableName = "BookedProducts";
                dataAdapter = new SqlDataAdapter("SELECT Id, FIO AS ФИО, ProductsNumbers AS \"Артикулы товаров\", DateEnd AS \"Дата конца\" " +
                    "FROM BookedProducts", dataBase.getSqlConnection());
                FillDataAdapter(dataGridView1);
            }

            private void товарыВРемонтеToolStripMenuItem_Click(object sender, EventArgs e)
            {
                currentTableName = "ProductsUnderRepair";
                dataAdapter = new SqlDataAdapter("SELECT Number AS Артикул, ProductGroup AS \"Группа товара\", Name AS \"Навание товара\"," +
                    "RepairCompanyName AS \"Навание ремонтной компании\", Cost AS \"Стоимость ремонта\", DateStart AS \"Дата начала\", DateEnd AS \"Дата конца\", " +
                    "isOver AS Завершена, FROM ProductsUnderRepair", dataBase.getSqlConnection());
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
