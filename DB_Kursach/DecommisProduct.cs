namespace DB_Kursach
{
    public partial class DecommisProduct : Form
    {
        public DateTime DecommissionedDate { get; private set; }
        public string Reason { get; private set; }
        public DecommisProduct()
        {
            InitializeComponent();
            textBox1.Size = new Size(243, 80);

        }



        private void buttonOk_Click(object sender, EventArgs e)
        {
            DecommissionedDate = dateTimePicker1.Value;
            Reason = textBox1.Text;
        }


    }
}
