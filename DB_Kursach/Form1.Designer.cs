namespace DB_Kursach
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеОбАрендаторахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОбАрендахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОТоварахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОВсехТоварахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.забронированныеТоварыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.товарыВРемонтеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списанныеТоварыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовогоАрендатораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовыйТоварToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовуюАрендуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовуюБроньToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonReturnProductFromRepair = new System.Windows.Forms.Button();
            this.buttonSendProductForRepair = new System.Windows.Forms.Button();
            this.buttonDecommisProduct = new System.Windows.Forms.Button();
            this.buttonCloseRent = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1143, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеОбАрендаторахToolStripMenuItem,
            this.информацияОбАрендахToolStripMenuItem,
            this.информацияОТоварахToolStripMenuItem,
            this.забронированныеТоварыToolStripMenuItem,
            this.товарыВРемонтеToolStripMenuItem,
            this.списанныеТоварыToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem1.Text = "Открыть";
            // 
            // данныеОбАрендаторахToolStripMenuItem
            // 
            this.данныеОбАрендаторахToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.данныеОбАрендаторахToolStripMenuItem.Name = "данныеОбАрендаторахToolStripMenuItem";
            this.данныеОбАрендаторахToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.данныеОбАрендаторахToolStripMenuItem.Text = "Информация об арендаторах";
            this.данныеОбАрендаторахToolStripMenuItem.Click += new System.EventHandler(this.данныеОбАрендаторахToolStripMenuItem_Click);
            // 
            // информацияОбАрендахToolStripMenuItem
            // 
            this.информацияОбАрендахToolStripMenuItem.Name = "информацияОбАрендахToolStripMenuItem";
            this.информацияОбАрендахToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.информацияОбАрендахToolStripMenuItem.Text = "Информация об арендах";
            this.информацияОбАрендахToolStripMenuItem.Click += new System.EventHandler(this.информацияОбАрендахToolStripMenuItem_Click);
            // 
            // информацияОТоварахToolStripMenuItem
            // 
            this.информацияОТоварахToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.информацияОВсехТоварахToolStripMenuItem,
            this.подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem});
            this.информацияОТоварахToolStripMenuItem.Name = "информацияОТоварахToolStripMenuItem";
            this.информацияОТоварахToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.информацияОТоварахToolStripMenuItem.Text = "Информация о товарах";
            // 
            // информацияОВсехТоварахToolStripMenuItem
            // 
            this.информацияОВсехТоварахToolStripMenuItem.Name = "информацияОВсехТоварахToolStripMenuItem";
            this.информацияОВсехТоварахToolStripMenuItem.Size = new System.Drawing.Size(403, 22);
            this.информацияОВсехТоварахToolStripMenuItem.Text = "Информация о всех товарах";
            this.информацияОВсехТоварахToolStripMenuItem.Click += new System.EventHandler(this.информацияОВсехТоварахToolStripMenuItem_Click);
            // 
            // подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem
            // 
            this.подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem.Name = "подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem";
            this.подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem.Size = new System.Drawing.Size(403, 22);
            this.подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem.Text = "Подробная информация о товарах в конкретной категории";
            this.подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem.Click += new System.EventHandler(this.подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem_Click);
            // 
            // забронированныеТоварыToolStripMenuItem
            // 
            this.забронированныеТоварыToolStripMenuItem.Name = "забронированныеТоварыToolStripMenuItem";
            this.забронированныеТоварыToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.забронированныеТоварыToolStripMenuItem.Text = "Забронированные товары";
            this.забронированныеТоварыToolStripMenuItem.Click += new System.EventHandler(this.забронированныеТоварыToolStripMenuItem_Click);
            // 
            // товарыВРемонтеToolStripMenuItem
            // 
            this.товарыВРемонтеToolStripMenuItem.Name = "товарыВРемонтеToolStripMenuItem";
            this.товарыВРемонтеToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.товарыВРемонтеToolStripMenuItem.Text = "Товары в ремонте";
            this.товарыВРемонтеToolStripMenuItem.Click += new System.EventHandler(this.товарыВРемонтеToolStripMenuItem_Click);
            // 
            // списанныеТоварыToolStripMenuItem
            // 
            this.списанныеТоварыToolStripMenuItem.Name = "списанныеТоварыToolStripMenuItem";
            this.списанныеТоварыToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.списанныеТоварыToolStripMenuItem.Text = "Списанные товары";
            this.списанныеТоварыToolStripMenuItem.Click += new System.EventHandler(this.списанныеТоварыToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьНовогоАрендатораToolStripMenuItem,
            this.добавитьНовыйТоварToolStripMenuItem,
            this.добавитьНовуюАрендуToolStripMenuItem,
            this.добавитьНовуюБроньToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(71, 20);
            this.toolStripMenuItem2.Text = "Добавить";
            // 
            // добавитьНовогоАрендатораToolStripMenuItem
            // 
            this.добавитьНовогоАрендатораToolStripMenuItem.Name = "добавитьНовогоАрендатораToolStripMenuItem";
            this.добавитьНовогоАрендатораToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.добавитьНовогоАрендатораToolStripMenuItem.Text = "Добавить нового арендатора";
            this.добавитьНовогоАрендатораToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовогоАрендатораToolStripMenuItem_Click_1);
            // 
            // добавитьНовыйТоварToolStripMenuItem
            // 
            this.добавитьНовыйТоварToolStripMenuItem.Name = "добавитьНовыйТоварToolStripMenuItem";
            this.добавитьНовыйТоварToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.добавитьНовыйТоварToolStripMenuItem.Text = "Добавить новый товар";
            this.добавитьНовыйТоварToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовыйТоварToolStripMenuItem_Click);
            // 
            // добавитьНовуюАрендуToolStripMenuItem
            // 
            this.добавитьНовуюАрендуToolStripMenuItem.Name = "добавитьНовуюАрендуToolStripMenuItem";
            this.добавитьНовуюАрендуToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.добавитьНовуюАрендуToolStripMenuItem.Text = "Добавить новую аренду";
            this.добавитьНовуюАрендуToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовуюАрендуToolStripMenuItem_Click);
            // 
            // добавитьНовуюБроньToolStripMenuItem
            // 
            this.добавитьНовуюБроньToolStripMenuItem.Name = "добавитьНовуюБроньToolStripMenuItem";
            this.добавитьНовуюБроньToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.добавитьНовуюБроньToolStripMenuItem.Text = "Добавить новую бронь";
            this.добавитьНовуюБроньToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовуюБроньToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1143, 520);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 484);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 60);
            this.panel1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 38);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1143, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "Количесво записей в таблице: ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(679, 9);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(76, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(761, 10);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(842, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(69, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(917, 10);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(223, 23);
            this.textBoxSearch.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(3, 420);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(173, 34);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить изменения";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.buttonReturnProductFromRepair);
            this.panel2.Controls.Add(this.buttonSendProductForRepair);
            this.panel2.Controls.Add(this.buttonDecommisProduct);
            this.panel2.Controls.Add(this.buttonCloseRent);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(964, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 460);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 54);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonReturnProductFromRepair
            // 
            this.buttonReturnProductFromRepair.Location = new System.Drawing.Point(15, 42);
            this.buttonReturnProductFromRepair.Name = "buttonReturnProductFromRepair";
            this.buttonReturnProductFromRepair.Size = new System.Drawing.Size(152, 41);
            this.buttonReturnProductFromRepair.TabIndex = 7;
            this.buttonReturnProductFromRepair.Text = "Вернуть товар из ремонта";
            this.buttonReturnProductFromRepair.UseVisualStyleBackColor = true;
            this.buttonReturnProductFromRepair.Visible = false;
            this.buttonReturnProductFromRepair.Click += new System.EventHandler(this.buttonReturnProductFromRepair_Click);
            // 
            // buttonSendProductForRepair
            // 
            this.buttonSendProductForRepair.Location = new System.Drawing.Point(15, 42);
            this.buttonSendProductForRepair.Name = "buttonSendProductForRepair";
            this.buttonSendProductForRepair.Size = new System.Drawing.Size(152, 40);
            this.buttonSendProductForRepair.TabIndex = 6;
            this.buttonSendProductForRepair.Text = "Отправить товар на ремонт";
            this.buttonSendProductForRepair.UseVisualStyleBackColor = true;
            this.buttonSendProductForRepair.Visible = false;
            this.buttonSendProductForRepair.Click += new System.EventHandler(this.buttonSendProductForRepair_Click);
            // 
            // buttonDecommisProduct
            // 
            this.buttonDecommisProduct.Location = new System.Drawing.Point(15, 13);
            this.buttonDecommisProduct.Name = "buttonDecommisProduct";
            this.buttonDecommisProduct.Size = new System.Drawing.Size(152, 23);
            this.buttonDecommisProduct.TabIndex = 5;
            this.buttonDecommisProduct.Text = "Списать товар";
            this.buttonDecommisProduct.UseVisualStyleBackColor = true;
            this.buttonDecommisProduct.Visible = false;
            this.buttonDecommisProduct.Click += new System.EventHandler(this.buttonDecommisProduct_Click);
            // 
            // buttonCloseRent
            // 
            this.buttonCloseRent.Location = new System.Drawing.Point(15, 13);
            this.buttonCloseRent.Name = "buttonCloseRent";
            this.buttonCloseRent.Size = new System.Drawing.Size(152, 23);
            this.buttonCloseRent.TabIndex = 4;
            this.buttonCloseRent.Text = "Завершить аренду";
            this.buttonCloseRent.UseVisualStyleBackColor = true;
            this.buttonCloseRent.Visible = false;
            this.buttonCloseRent.Click += new System.EventHandler(this.buttonCloseRent_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 544);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Учет аренды спорт. инвентаря";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private DataGridView dataGridView1;
        private Panel panel1;
        private ToolStripMenuItem данныеОбАрендаторахToolStripMenuItem;
        private ToolStripMenuItem информацияОбАрендахToolStripMenuItem;
        private Button buttonSearch;
        private TextBox textBoxSearch;
        private ToolStripMenuItem информацияОТоварахToolStripMenuItem;
        private ToolStripMenuItem информацияОВсехТоварахToolStripMenuItem;
        private ToolStripMenuItem подробнаяИнформацияОТоварахВКонкретнойКатегорииToolStripMenuItem;
        private ToolStripMenuItem добавитьНовогоАрендатораToolStripMenuItem;
        private Button buttonDelete;
        private Button buttonSave;
        private ToolStripMenuItem забронированныеТоварыToolStripMenuItem;
        private ToolStripMenuItem товарыВРемонтеToolStripMenuItem;
        private ToolStripMenuItem добавитьНовыйТоварToolStripMenuItem;
        private Button buttonRefresh;
        private ToolStripMenuItem списанныеТоварыToolStripMenuItem;
        private Panel panel2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Button buttonCloseRent;
        private Button buttonDecommisProduct;
        private Button buttonSendProductForRepair;
        private Button buttonReturnProductFromRepair;
        private ToolStripMenuItem добавитьНовуюАрендуToolStripMenuItem;
        private Button button1;
        private ToolStripMenuItem добавитьНовуюБроньToolStripMenuItem;
    }
}
