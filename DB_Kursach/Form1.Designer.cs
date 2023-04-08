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
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(899, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеОбАрендаторахToolStripMenuItem,
            this.информацияОбАрендахToolStripMenuItem,
            this.информацияОТоварахToolStripMenuItem});
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(71, 20);
            this.toolStripMenuItem2.Text = "Добавить";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(899, 484);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 45);
            this.panel1.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(598, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(69, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(673, 10);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(223, 23);
            this.textBoxSearch.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 508);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}