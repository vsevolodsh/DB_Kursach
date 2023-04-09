
namespace DB_Kursach
{
    public partial class NewTenantForm : Form
    {
        public string fio;
        public byte age;
        public string telNumber;
        public string gender;

        public NewTenantForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            fio = textBoxFIO.Text;
            age = (byte)numericUpDownAge.Value;
            telNumber = textBoxTelNumber.Text;
            gender = comboBoxGender.SelectedItem.ToString();
            if (fio == null || telNumber == null || gender == null)
            {
                MessageBox.Show("Введены не все данные! Попробуйте еще раз.");
                return;
            }
        }
    }
}
