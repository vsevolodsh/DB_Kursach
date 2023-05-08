using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Kursach
{
    public partial class SendProductForRepair : Form
    {
        public int RepairCompanyId { get; private set; }
        public decimal Cost { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public SendProductForRepair()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            RepairCompanyId = comboBox1.SelectedIndex + 1;
            Cost = numericUpDown1.Value;
            DateStart = dateTimePickerStart.Value;
            DateEnd = dateTimePickerEnd.Value;
        }
    }
}
