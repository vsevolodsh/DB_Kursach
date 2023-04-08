using System.Data;
using System.Data.SqlClient;

namespace DB_Kursach
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase(textBoxLogin.Text, textBoxPassword.Text);
            try
            {
                dataBase.openConnection();
                MessageBox.Show("Вход успешно выполнен!");
                dataBase.closeConnection();
                Form1 form1 = new Form1(dataBase);
                this.Hide();
                form1.ShowDialog();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }
    }
}
