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
        string sqlSelectQueryWithParamNames;
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
                case "TenantInfo":
                    sqlQuery = "SELECT * FROM TenantInfo WHERE CONCAT (Id, Fio, Phone, Gender, RentId) LIKE '%" + textBoxSearch.Text + "%'";
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
                if (currentTableName.Equals("PrPrGroups") || currentTableName.Equals("DecommissionedProduct"))
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
            toolStripStatusLabel1.Text = $"Таблица: {currentTableName}";
            toolStripStatusLabel2.Text = $"Количество записей в таблице: {dgw.Rows.Count}";
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
                        dataAdapter.UpdateCommand = new SqlCommand("UPDATE Rent SET DateStart = @DateStart, DateEnd = @DateEnd, TotalRentCost = @TotalRentCost," +
                            " TotalDepositCost = @TotalDepositCost WHERE Id = @Id", dataBase.getSqlConnection());
                        dataAdapter.UpdateCommand.Parameters.Add("@DateStart", SqlDbType.DateTime).Value = dataSet.Tables[0].Rows[row.Index][3];
                        dataAdapter.UpdateCommand.Parameters.Add("@DateEnd", SqlDbType.DateTime).Value = dataSet.Tables[0].Rows[row.Index][4];
                        dataAdapter.UpdateCommand.Parameters.Add("@TotalRentCost", SqlDbType.Money).Value = dataSet.Tables[0].Rows[row.Index][5];
                        dataAdapter.UpdateCommand.Parameters.Add("@TotalDepositCost", SqlDbType.Money).Value = dataSet.Tables[0].Rows[row.Index][6];
                        dataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                        break;
                    case "PrPrGroups":
                        dataAdapter.UpdateCommand = new SqlCommand("UPDATE Product SET Name = @Name, RentCostInHour = @RentCostInHour WHERE Number = @Number",
                    dataBase.getSqlConnection());
                        dataAdapter.UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][1];
                        dataAdapter.UpdateCommand.Parameters.Add("@RentCostInHour", SqlDbType.Money).Value = dataSet.Tables[0].Rows[row.Index][3];
                        dataAdapter.UpdateCommand.Parameters.Add("@Number", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                        break;
                    case "ProductsSkiPoles":
                        dataAdapter.UpdateCommand = new SqlCommand("UPDATE SkiPoles SET HandMaterial = @HandMaterial, ShaftMaterial = @ShaftMaterial, SkiPolesLength = @SkiPolesLength " +
                            "WHERE ProductNumber = @ProductNumber", dataBase.getSqlConnection());
                        dataAdapter.UpdateCommand.Parameters.Add("@HandMaterial", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][3];
                        dataAdapter.UpdateCommand.Parameters.Add("@ShaftMaterial", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][4];
                        dataAdapter.UpdateCommand.Parameters.Add("@SkiPolesLength", SqlDbType.TinyInt).Value = dataSet.Tables[0].Rows[row.Index][5];
                        dataAdapter.UpdateCommand.Parameters.Add("@ProductNumber", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                        break;
                    case "ProductsSkis":
                        dataAdapter.UpdateCommand = new SqlCommand("UPDATE Ski SET RidingStyle = @RidingStyle, SkiLength = @SkiLength WHERE ProductNumber = @ProductNumber", dataBase.getSqlConnection());
                        dataAdapter.UpdateCommand.Parameters.Add("@RidingStyle", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][3];
                        dataAdapter.UpdateCommand.Parameters.Add("@SkiLength", SqlDbType.TinyInt).Value = dataSet.Tables[0].Rows[row.Index][4];
                        dataAdapter.UpdateCommand.Parameters.Add("@ProductNumber", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                        break;
                    case "ProductsSleigh":
                        dataAdapter.UpdateCommand = new SqlCommand("UPDATE Sleigh SET Construction = @Construction, RunnersType = @RunnersType, MaxLoad = @MaxLoad " +
                            "WHERE ProductNumber = @ProductNumber", dataBase.getSqlConnection());
                        dataAdapter.UpdateCommand.Parameters.Add("@Construction", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][3];
                        dataAdapter.UpdateCommand.Parameters.Add("@RunnersType", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][4];
                        dataAdapter.UpdateCommand.Parameters.Add("@MaxLoad", SqlDbType.TinyInt).Value = dataSet.Tables[0].Rows[row.Index][5];
                        dataAdapter.UpdateCommand.Parameters.Add("@ProductNumber", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                        break;
                    case "ProductsSkates":
                        dataAdapter.UpdateCommand = new SqlCommand("UPDATE Skates SET BladeSteel = @BladeSteel, Fixation = @Fixation, Size = @Size " +
                            "WHERE ProductNumber = @ProductNumber", dataBase.getSqlConnection());
                        dataAdapter.UpdateCommand.Parameters.Add("@BladeSteel", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][3];
                        dataAdapter.UpdateCommand.Parameters.Add("@Fixation", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][4];
                        dataAdapter.UpdateCommand.Parameters.Add("@Size", SqlDbType.TinyInt).Value = dataSet.Tables[0].Rows[row.Index][5];
                        dataAdapter.UpdateCommand.Parameters.Add("@ProductNumber", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                        break;
                    //case "TenantInfo":
                    //    dataAdapter.UpdateCommand = new SqlCommand("UPDATE Tenant SET FIO = @FIO, Age = @Age, Phone = @Phone, Gender = @Gender WHERE Id = @Id"
                    //        , dataBase.getSqlConnection());
                    //    dataAdapter.UpdateCommand.Parameters.Add("@FIO", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][1];
                    //    dataAdapter.UpdateCommand.Parameters.Add("@Age", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][2];
                    //    dataAdapter.UpdateCommand.Parameters.Add("@Phone", SqlDbType.VarChar).Value = dataSet.Tables[0].Rows[row.Index][3];
                    //    dataAdapter.UpdateCommand.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][4];
                    //    dataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
                    //    break;
                    case "DecommissionedProduct":
                        dataAdapter.UpdateCommand = new SqlCommand("UPDATE DecommissionedProduct SET @DecommissionedDate = @DecommissionedDate, Reason = @Reason " +
                            "WHERE ProductNumber = @ProductNumber", dataBase.getSqlConnection());
                        dataAdapter.UpdateCommand.Parameters.Add("@DecommissionedDate", SqlDbType.DateTime).Value = dataSet.Tables[0].Rows[row.Index][1];
                        dataAdapter.UpdateCommand.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = dataSet.Tables[0].Rows[row.Index][2];
                        dataAdapter.UpdateCommand.Parameters.Add("@ProductNumber", SqlDbType.Int).Value = dataSet.Tables[0].Rows[row.Index][0];
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
            HideButton();
            buttonSendProductForRepair.Visible = true;
            buttonDecommisProduct.Visible = true;
            buttonDelete.Enabled = true;
            currentTableName = "PrPrGroups";
            sqlSelectQueryWithParamNames = "SELECT Number AS Артикул, Name AS Навание, ProductGroup AS \"Группа товара\", RentCostInHour AS \"Стоимость за час\"," +
                " IsProductInWarehouse AS \"Товар на складе\" FROM PrPrGroups";
            dataAdapter = new SqlDataAdapter(sqlSelectQueryWithParamNames, dataBase.getSqlConnection());
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
                sqlQuery += " WHERE IsProductInWarehouse = 1";
            }
            dataAdapter = new SqlDataAdapter(sqlQuery, dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);

        }

        private void информацияОбАрендахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideButton();
            buttonCloseRent.Visible = true;
            currentTableName = "RentInfo";
            sqlSelectQueryWithParamNames = "SELECT Id, TenantName AS \"Имя арендатора\", ProductsNumbers AS \"Артикулы товаров\"," +
                " DateStart AS \"Дата начала\", DateEnd AS \"Дата конца\", RentCost AS \"Цена аренды\", Deposit AS Залог, isOver AS Завершена FROM RentInfo";
            dataAdapter = new SqlDataAdapter(sqlSelectQueryWithParamNames, dataBase.getSqlConnection());
            sqlDeleteQuery = "DELETE FROM Rent WHERE Id = @Id";
            FillDataAdapter(dataGridView1);
        }
        private void данныеОбАрендаторахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    currentTableName = "TenantInfo";
            //    sqlSelectQueryWithParamNames = "SELECT Id, FIO AS ФИО, Phone AS \"Номер телефона\", Age AS Возраст, Gender AS Пол, RentId AS \" Id аренд\", " +
            //        "ActiveRent AS \"С активной арендой\" FROM TenantInfo ";
            //    DialogResult result = MessageBox.Show(
            //"Вывести арендаторов только с активной арендой?",
            //"Сообщение",
            //MessageBoxButtons.YesNo,
            //MessageBoxIcon.Information,
            //MessageBoxDefaultButton.Button1);
            //    if (result == DialogResult.Yes)
            //    {
            //        sqlSelectQueryWithParamNames += "WHERE ActiveRent = 1";
            //    }
            //    dataAdapter = new SqlDataAdapter(sqlSelectQueryWithParamNames, dataBase.getSqlConnection());
            //    FillDataAdapter(dataGridView1);
            currentTableName = "Tenant";
            sqlSelectQueryWithParamNames = "SELECT Id, FIO AS ФИО, Phone AS \"Номер телефона\", Age AS Возраст, Gender AS Пол FROM Tenant";
            dataAdapter = new SqlDataAdapter(sqlSelectQueryWithParamNames, dataBase.getSqlConnection());
            sqlDeleteQuery = "DELETE FROM Tenant WHERE Id = @Id";
            FillDataAdapter(dataGridView1);
        }
        private void забронированныеТоварыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
            currentTableName = "BookedProducts";
            sqlSelectQueryWithParamNames = "SELECT Id, FIO AS ФИО, ProductsNumbers AS \"Артикулы товаров\", DateEnd AS \"Дата конца\" FROM BookedProducts";
            sqlDeleteQuery = "DELETE FROM Booking WHERE Id = @Id";
            dataAdapter = new SqlDataAdapter(sqlSelectQueryWithParamNames, dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }

        private void товарыВРемонтеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideButton();
            buttonReturnProductFromRepair.Visible = true;
            buttonDelete.Enabled = false;
            currentTableName = "ProductsUnderRepair";
            sqlSelectQueryWithParamNames = "SELECT Number AS Артикул, ProductGroup AS \"Группа товара\", Name AS \"Навание товара\"," +
                "RepairCompanyName AS \"Навание ремонтной компании\", Cost AS \"Стоимость ремонта\", DateStart AS \"Дата начала\", DateEnd AS \"Дата конца\", " +
                "isOver AS Завершена FROM ProductsUnderRepair ";
            DialogResult result = MessageBox.Show(
      "Вывести только товары проходящие ремонт в данынй момент?",
      "Сообщение",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Information,
      MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                sqlSelectQueryWithParamNames += "WHERE isOver = 0";
            }
            dataAdapter = new SqlDataAdapter(sqlSelectQueryWithParamNames, dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }

        private void списанныеТоварыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideButton();

            buttonDelete.Enabled = true;
            currentTableName = "DecommissionedProduct";
            sqlSelectQueryWithParamNames = "SELECT ProductNumber AS Артикул, DecommissionedDate AS \"Дата списания\", Reason AS Причина FROM DecommissionedProduct";
            dataAdapter = new SqlDataAdapter(sqlSelectQueryWithParamNames, dataBase.getSqlConnection());
            sqlDeleteQuery = "DELETE FROM DecommissionedProduct WHERE ProductNumber = @Number";
            FillDataAdapter(dataGridView1);
        }

        private void HideButton()
        {
            buttonCloseRent.Visible = false;
            buttonDecommisProduct.Visible = false;
            buttonSendProductForRepair.Visible = false;
            buttonReturnProductFromRepair.Visible = false;
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
            dataAdapter = new SqlDataAdapter(sqlSelectQueryWithParamNames, dataBase.getSqlConnection());
            FillDataAdapter(dataGridView1);
        }

        private void buttonCloseRent_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            string sqlExpression = "sp_CloseRent";
            SqlCommand command = new(sqlExpression, dataBase.getSqlConnection());
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    SqlParameter rentIdParam = new("@RentId", dataSet.Tables[0].Rows[row.Index][0]);
                    command.Parameters.Add(rentIdParam);
                    string[] productNumCol = dataSet.Tables[0].Rows[row.Index][2].ToString().Split(',');
                    foreach (var productNum in productNumCol)
                    {
                        SqlParameter productNumberParam = new("@ProductNumber", int.Parse(productNum));
                        command.Parameters.Add(productNumberParam);
                        command.CommandType = CommandType.StoredProcedure;
                        var queryResult = command.ExecuteNonQuery();
                        command.Parameters.Remove(productNumberParam);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Аренда успешна завершена, товары возвращены на склад!");
            dataBase.closeConnection();
        }

        private void buttonDecommisProduct_Click(object sender, EventArgs e)
        {
            DecommisProduct dcpForm = new();
            DialogResult result = dcpForm.ShowDialog(this);
            string sqlExpression = "sp_DecommisProduct";
            SqlCommand command = new(sqlExpression, dataBase.getSqlConnection());
            if (result == DialogResult.OK)
            {
                dataBase.openConnection();
                SqlParameter numberParam = new("@ProductNumber", dataSet.Tables[0].Rows[dataGridView1.SelectedRows[0].Index][0].ToString());
                SqlParameter DecommissionedDateParam = new("@DecommissionedDate", dcpForm.DecommissionedDate);
                SqlParameter ReasonParam = new("@Reason", dcpForm.Reason);
                command.Parameters.Add(numberParam);
                command.Parameters.Add(DecommissionedDateParam);
                command.Parameters.Add(ReasonParam);
                command.CommandType = CommandType.StoredProcedure;
                var queryResult = command.ExecuteNonQuery();
                dataBase.closeConnection();
            }
            if (result == DialogResult.Cancel)
                return;

        }

        private void buttonSendProductForRepair_Click(object sender, EventArgs e)
        {
            SendProductForRepair spfrForm = new();
            DialogResult result = spfrForm.ShowDialog(this);
            string sqlExpression = "sp_SendProductForRepair";
            SqlCommand command = new(sqlExpression, dataBase.getSqlConnection());
            if (result == DialogResult.OK)
            {
                dataBase.openConnection();
                SqlParameter numberParam = new("@ProductNumber", dataSet.Tables[0].Rows[dataGridView1.SelectedRows[0].Index][0].ToString());
                SqlParameter RepairCompanyIdParam = new("@RepairCompanyId", spfrForm.RepairCompanyId);
                SqlParameter CostParam = new("@Cost", spfrForm.Cost);
                SqlParameter DateStartParam = new("@DateStart", spfrForm.DateStart);
                SqlParameter DateEndParam = new("@DateEnd", spfrForm.DateEnd);
                command.Parameters.Add(numberParam);
                command.Parameters.Add(RepairCompanyIdParam);
                command.Parameters.Add(CostParam);
                command.Parameters.Add(DateStartParam);
                command.Parameters.Add(DateEndParam);
                command.CommandType = CommandType.StoredProcedure;
                var queryResult = command.ExecuteNonQuery();
                dataBase.closeConnection();
            }
            if (result == DialogResult.Cancel)
                return;
        }

        private void buttonReturnProductFromRepair_Click(object sender, EventArgs e)
        {
            string sqlExpression = "sp_ReturnProductFromRepair";
            SqlCommand command = new(sqlExpression, dataBase.getSqlConnection());
            dataBase.openConnection();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SqlParameter numberParam = new("@ProductNumber", dataSet.Tables[0].Rows[row.Index][0]);
                command.Parameters.Add(numberParam);
                command.CommandType = CommandType.StoredProcedure;
                var queryResult = command.ExecuteNonQuery();

            }

            dataBase.closeConnection();

        }

        private void добавитьНовуюАрендуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRent nrForm = new(dataBase);
            DialogResult result = nrForm.ShowDialog(this);
            string sqlExpression = "sp_InsertRent";
            SqlCommand command = new(sqlExpression, dataBase.getSqlConnection());
            if (result == DialogResult.OK && !nrForm.stop)
            {
                dataBase.openConnection();
                SqlParameter TenantIdParam = new("@TenantId", nrForm.TenantId);
                SqlParameter TotalRentCostParam = new("@TotalRentCost", nrForm.TotalRentCost);
                SqlParameter TotalDepositParam = new("@TotalDeposit", nrForm.TotalDeposit);
                SqlParameter DateStartParam = new("@DateStart", nrForm.DateStart);
                SqlParameter DateEndParam = new("@DateEnd", nrForm.DateEnd);
                SqlParameter RentIdParam = new("@RentId", nrForm.RentId);
                command.Parameters.Add(TenantIdParam);
                command.Parameters.Add(TotalRentCostParam);
                command.Parameters.Add(TotalDepositParam);
                command.Parameters.Add(DateStartParam);
                command.Parameters.Add(DateEndParam);
                command.Parameters.Add(RentIdParam);
                foreach (var productNumber in nrForm.ProductsNumber)
                {
                    SqlParameter productNumberParam = new("@ProductNumber", productNumber);
                    command.Parameters.Add(productNumberParam);
                    command.CommandType = CommandType.StoredProcedure;
                    var queryResult = command.ExecuteNonQuery();
                    command.Parameters.Remove(productNumberParam);
                }

                dataBase.closeConnection();
            }
            if (result == DialogResult.Cancel)
                return;
        }
    }
}

