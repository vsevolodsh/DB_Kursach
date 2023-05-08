namespace DB_Kursach
{
    partial class NewBooking
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerDayEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTenants = new System.Windows.Forms.DataGridView();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(976, 380);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 67;
            this.buttonOk.Text = "ОК";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(1057, 380);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 66;
            this.buttonCancel.Text = "Закрыть";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDayEnd
            // 
            this.dateTimePickerDayEnd.Location = new System.Drawing.Point(138, 306);
            this.dateTimePickerDayEnd.Name = "dateTimePickerDayEnd";
            this.dateTimePickerDayEnd.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerDayEnd.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 21);
            this.label4.TabIndex = 60;
            this.label4.Text = "Конец брони: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(794, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 21);
            this.label2.TabIndex = 57;
            this.label2.Text = "Выберите арендатора";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(187, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 21);
            this.label1.TabIndex = 56;
            this.label1.Text = "Выберите товары для брони";
            // 
            // dataGridViewTenants
            // 
            this.dataGridViewTenants.AllowUserToAddRows = false;
            this.dataGridViewTenants.AllowUserToDeleteRows = false;
            this.dataGridViewTenants.AllowUserToOrderColumns = true;
            this.dataGridViewTenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTenants.Location = new System.Drawing.Point(617, 40);
            this.dataGridViewTenants.Name = "dataGridViewTenants";
            this.dataGridViewTenants.RowTemplate.Height = 25;
            this.dataGridViewTenants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTenants.Size = new System.Drawing.Size(518, 253);
            this.dataGridViewTenants.TabIndex = 55;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(12, 40);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowTemplate.Height = 25;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(578, 253);
            this.dataGridViewProducts.TabIndex = 54;
            // 
            // NewBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 415);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.dateTimePickerDayEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewTenants);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "NewBooking";
            this.Text = "Новая бронь";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonOk;
        private Button buttonCancel;
        private DateTimePicker dateTimePickerDayEnd;
        private Label label4;
        private Label label2;
        private Label label1;
        private DataGridView dataGridViewTenants;
        private DataGridView dataGridViewProducts;
    }
}