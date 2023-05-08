namespace DB_Kursach
{
    partial class NewRent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.dataGridViewTenants = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDayStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerDayEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownRent = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDeposit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerHourStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHourEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeposit)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(12, 39);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowTemplate.Height = 25;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(578, 253);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // dataGridViewTenants
            // 
            this.dataGridViewTenants.AllowUserToAddRows = false;
            this.dataGridViewTenants.AllowUserToDeleteRows = false;
            this.dataGridViewTenants.AllowUserToOrderColumns = true;
            this.dataGridViewTenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTenants.Location = new System.Drawing.Point(617, 39);
            this.dataGridViewTenants.Name = "dataGridViewTenants";
            this.dataGridViewTenants.RowTemplate.Height = 25;
            this.dataGridViewTenants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTenants.Size = new System.Drawing.Size(518, 253);
            this.dataGridViewTenants.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(150, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите товары, берущиеся в аренду";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(812, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите арендатора";
            // 
            // dateTimePickerDayStart
            // 
            this.dateTimePickerDayStart.Location = new System.Drawing.Point(150, 311);
            this.dateTimePickerDayStart.Name = "dateTimePickerDayStart";
            this.dateTimePickerDayStart.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerDayStart.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Начало аренды: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Конец аренды: ";
            // 
            // dateTimePickerDayEnd
            // 
            this.dateTimePickerDayEnd.Location = new System.Drawing.Point(150, 349);
            this.dateTimePickerDayEnd.Name = "dateTimePickerDayEnd";
            this.dateTimePickerDayEnd.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerDayEnd.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Общая стоимость аренды:";
            // 
            // numericUpDownRent
            // 
            this.numericUpDownRent.Location = new System.Drawing.Point(217, 389);
            this.numericUpDownRent.Maximum = new decimal(new int[] {
            -1981284352,
            -1966660860,
            0,
            0});
            this.numericUpDownRent.Name = "numericUpDownRent";
            this.numericUpDownRent.Size = new System.Drawing.Size(133, 23);
            this.numericUpDownRent.TabIndex = 9;
            // 
            // numericUpDownDeposit
            // 
            this.numericUpDownDeposit.Location = new System.Drawing.Point(217, 427);
            this.numericUpDownDeposit.Maximum = new decimal(new int[] {
            -1981284352,
            -1966660860,
            0,
            0});
            this.numericUpDownDeposit.Name = "numericUpDownDeposit";
            this.numericUpDownDeposit.Size = new System.Drawing.Size(133, 23);
            this.numericUpDownDeposit.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(12, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Депозит:";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(979, 508);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 51;
            this.buttonOk.Text = "ОК";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(1060, 508);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 50;
            this.buttonCancel.Text = "Закрыть";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerHourStart
            // 
            this.dateTimePickerHourStart.Location = new System.Drawing.Point(365, 311);
            this.dateTimePickerHourStart.Name = "dateTimePickerHourStart";
            this.dateTimePickerHourStart.Size = new System.Drawing.Size(125, 23);
            this.dateTimePickerHourStart.TabIndex = 52;
            // 
            // dateTimePickerHourEnd
            // 
            this.dateTimePickerHourEnd.Location = new System.Drawing.Point(365, 349);
            this.dateTimePickerHourEnd.Name = "dateTimePickerHourEnd";
            this.dateTimePickerHourEnd.Size = new System.Drawing.Size(125, 23);
            this.dateTimePickerHourEnd.TabIndex = 53;
            // 
            // NewRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 543);
            this.Controls.Add(this.dateTimePickerHourEnd);
            this.Controls.Add(this.dateTimePickerHourStart);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownDeposit);
            this.Controls.Add(this.numericUpDownRent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerDayEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerDayStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewTenants);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "NewRent";
            this.Text = "Новая аренда";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeposit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewProducts;
        private DataGridView dataGridViewTenants;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePickerDayStart;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePickerDayEnd;
        private Label label5;
        private NumericUpDown numericUpDownRent;
        private NumericUpDown numericUpDownDeposit;
        private Label label6;
        private Button buttonOk;
        private Button buttonCancel;
        private DateTimePicker dateTimePickerHourStart;
        private DateTimePicker dateTimePickerHourEnd;
    }
}