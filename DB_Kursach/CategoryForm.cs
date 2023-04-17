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
    public partial class CategoryForm : Form
    {
        public string selectedCategory;
        public bool onlyProductsInWarehouse = false;
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Лыжные палки":
                    selectedCategory = "ProductsSkiPoles";
                    break;
                case "Лыжи":
                    selectedCategory = "ProductsSkis";
                    break;
                case "Сани":
                    selectedCategory = "ProductsSleigh";
                    break;
                case "Коньки":
                    selectedCategory = "ProductsSkates";
                    break;
                default:
                    MessageBox.Show("Необходимо выбрать одну из категорий!");
                    return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            onlyProductsInWarehouse = true;
        }
    }
}
