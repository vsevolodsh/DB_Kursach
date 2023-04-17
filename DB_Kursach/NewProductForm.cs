
using System.Text.RegularExpressions;

namespace DB_Kursach
{
    public partial class NewProductForm : Form
    {
        public string selectedCategory;
        public string Number { get; private set; }
        public int ProductSubCategoryCode { get; private set; }
        public int Code { get; private set; }
        public string Name { get; private set; }
        public decimal RentCostInHour { get; private set; }
        public string ShaftMaterial { get; private set; }
        public string HandleMaterial { get; private set; }
        public byte SkiPolesLength { get; private set; }
        public string RidingStyle { get; private set; }
        public int SkiLength { get; private set; }
        public string BladeSteel { get; private set; }
        public string Fixation { get; private set; }
        public byte Size { get; private set; }
        public string Construction { get; private set; }
        public string RunnersType { get; private set; }
        public byte MaxLoad { get; private set; }

        List<Label> labels = new();
        List<ComboBox> comboBoxes = new();
        List<TextBox> textBoxes = new();
        List<NumericUpDown> numericUpDowns = new();
        string subCategoryName;

        public NewProductForm()
        {
            InitializeComponent();
            labels.Add(labelSkatesBladeSteel);
            labels.Add(labelSkatesFixation);
            labels.Add(labelSkatesSize);
            labels.Add(labelSkiPolesHandMatterial);
            labels.Add(labelSkiPolesShaftMaterial);
            labels.Add(labelSkiPolesLength);
            labels.Add(labelSkisRidingStyle);
            labels.Add(labelSkisLength);
            labels.Add(labelSleighConstruction);
            labels.Add(labelSleighMaxLoad);
            labels.Add(labelSleighRunnersType);
            comboBoxes.Add(comboBoxSkiPolesGroup);
            comboBoxes.Add(comboBoxSkisGroup);
            comboBoxes.Add(comboBoxSkatesGroup);
            comboBoxes.Add(comboBoxSleighGroup);
            textBoxes.Add(textBoxSkiPolesHandMatterial);
            textBoxes.Add(textBoxSkiPolesShaftMaterial);
            textBoxes.Add(textBoxSkiPolesLength);
            textBoxes.Add(textBoxSkisRidingStyle);
            textBoxes.Add(textBoxSkisLength);
            textBoxes.Add(textBoxSkatesBladeSteel);
            textBoxes.Add(textBoxSkatesFixation);
            textBoxes.Add(textBoxSleighConstruction);
            textBoxes.Add(textBoxSleighRunnersType);
            numericUpDowns.Add(numericUpDownSkatesSize);
            numericUpDowns.Add(numericUpDownSleighMaxLoad);
        }

        private void textBoxProductNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Лыжные палки":
                    subCategoryName = "SkiPoles";
                    selectedCategory = "ProductsSkiPoles";
                    ProductSubCategoryCode = 10;
                    break;
                case "Лыжи":
                    subCategoryName = "Skis";
                    selectedCategory = "ProductsSkis";
                    ProductSubCategoryCode = 16;
                    break;
                case "Сани":
                    subCategoryName = "Sleigh";
                    selectedCategory = "ProductsSleigh";
                    ProductSubCategoryCode = 13;
                    break;
                case "Коньки":
                    subCategoryName = "Skates";
                    selectedCategory = "ProductsSkates";
                    ProductSubCategoryCode = 11;
                    break;
            }
            Regex regex = new Regex($@"{subCategoryName}(\w+)");
            foreach (var item in labels)
            {
                MatchCollection matches = regex.Matches(item.Name.ToString());
                if (matches.Count > 0)
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
            foreach (var item in comboBoxes)
            {
                MatchCollection matches = regex.Matches(item.Name.ToString());
                if (matches.Count > 0)
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
            foreach (var item in textBoxes)
            {
                MatchCollection matches = regex.Matches(item.Name.ToString());
                if (matches.Count > 0)
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
            foreach (var item in numericUpDowns)
            {
                MatchCollection matches = regex.Matches(item.Name.ToString());
                if (matches.Count > 0)
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Number = textBoxProductNumber.Text;
            Name = textBoxProductName.Text;
            RentCostInHour = numericUpDown1.Value;
            ShaftMaterial = textBoxSkiPolesShaftMaterial.Text;
            HandleMaterial = textBoxSkiPolesHandMatterial.Text;
            SkiPolesLength = byte.Parse(textBoxSkiPolesLength.Text);
            RidingStyle = textBoxSkisRidingStyle.Text;
            SkiLength = int.Parse(textBoxSkisLength.Text);
            Construction = textBoxSleighConstruction.Text;
            RunnersType = textBoxSleighRunnersType.Text;
            MaxLoad = (byte)numericUpDownSleighMaxLoad.Value;
            BladeSteel = textBoxSkatesBladeSteel.Text;
            Fixation = textBoxSkatesFixation.Text;
            Size = (byte)numericUpDownSkatesSize.Value;
        }

        private void comboBoxSleighGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Code = comboBoxSleighGroup.SelectedIndex+1;
        }

        private void comboBoxSkatesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Code = comboBoxSkatesGroup.SelectedIndex + 1;
        }

        private void comboBoxSkisGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Code = comboBoxSkisGroup.SelectedIndex + 1;
        }

        private void comboBoxSkiPolesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Code = comboBoxSkiPolesGroup.SelectedIndex + 1;
        }
    }
}
