namespace Homework_3
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            добавитьToolStripMenuItem = new ToolStripMenuItem();
            insertingNewProductsToolStripMenuItem = new ToolStripMenuItem();
            insertingNewTypesТоваровToolStripMenuItem = new ToolStripMenuItem();
            insertingNewSuppliersToolStripMenuItem = new ToolStripMenuItem();
            обновлениеToolStripMenuItem = new ToolStripMenuItem();
            updateProductsToolStripMenuItem = new ToolStripMenuItem();
            updateTypesToolStripMenuItem = new ToolStripMenuItem();
            updateSuppliersToolStripMenuItem = new ToolStripMenuItem();
            списокToolStripMenuItem = new ToolStripMenuItem();
            всегоСкладаToolStripMenuItem = new ToolStripMenuItem();
            всехТиповТовараToolStripMenuItem = new ToolStripMenuItem();
            всехПоставщиковToolStripMenuItem = new ToolStripMenuItem();
            среднееКолToolStripMenuItem = new ToolStripMenuItem();
            найтиToolStripMenuItem = new ToolStripMenuItem();
            подробностиToolStripMenuItem = new ToolStripMenuItem();
            поставщикаToolStripMenuItem = new ToolStripMenuItem();
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem = new ToolStripMenuItem();
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem = new ToolStripMenuItem();
            типТовараToolStripMenuItem = new ToolStripMenuItem();
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1 = new ToolStripMenuItem();
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1 = new ToolStripMenuItem();
            товарToolStripMenuItem = new ToolStripMenuItem();
            сНаибольшимКоличествомToolStripMenuItem = new ToolStripMenuItem();
            сНаименьшимКоличествомToolStripMenuItem = new ToolStripMenuItem();
            сНаибольшейСебестоимостьюToolStripMenuItem = new ToolStripMenuItem();
            сНаименьшейСебестоимостьюToolStripMenuItem = new ToolStripMenuItem();
            самыйСтарыйToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(763, 552);
            dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { добавитьToolStripMenuItem, обновлениеToolStripMenuItem, списокToolStripMenuItem, подробностиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(787, 24);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // добавитьToolStripMenuItem
            // 
            добавитьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { insertingNewProductsToolStripMenuItem, insertingNewTypesТоваровToolStripMenuItem, insertingNewSuppliersToolStripMenuItem });
            добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            добавитьToolStripMenuItem.Size = new Size(67, 20);
            добавитьToolStripMenuItem.Text = "Вставить";
            // 
            // insertingNewProductsToolStripMenuItem
            // 
            insertingNewProductsToolStripMenuItem.Name = "insertingNewProductsToolStripMenuItem";
            insertingNewProductsToolStripMenuItem.Size = new Size(189, 22);
            insertingNewProductsToolStripMenuItem.Text = "Новые товары";
            insertingNewProductsToolStripMenuItem.Click += insertingNewProductsToolStripMenuItem_Click;
            // 
            // insertingNewTypesТоваровToolStripMenuItem
            // 
            insertingNewTypesТоваровToolStripMenuItem.Name = "insertingNewTypesТоваровToolStripMenuItem";
            insertingNewTypesТоваровToolStripMenuItem.Size = new Size(189, 22);
            insertingNewTypesТоваровToolStripMenuItem.Text = "Новые типы товаров";
            insertingNewTypesТоваровToolStripMenuItem.Click += insertingNewTypesToolStripMenuItem_Click;
            // 
            // insertingNewSuppliersToolStripMenuItem
            // 
            insertingNewSuppliersToolStripMenuItem.Name = "insertingNewSuppliersToolStripMenuItem";
            insertingNewSuppliersToolStripMenuItem.Size = new Size(189, 22);
            insertingNewSuppliersToolStripMenuItem.Text = "Новых поставщиков";
            insertingNewSuppliersToolStripMenuItem.Click += insertingNewSuppliersToolStripMenuItem_Click;
            // 
            // обновлениеToolStripMenuItem
            // 
            обновлениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { updateProductsToolStripMenuItem, updateTypesToolStripMenuItem, updateSuppliersToolStripMenuItem });
            обновлениеToolStripMenuItem.Name = "обновлениеToolStripMenuItem";
            обновлениеToolStripMenuItem.Size = new Size(73, 20);
            обновлениеToolStripMenuItem.Text = "Изменить";
            // 
            // updateProductsToolStripMenuItem
            // 
            updateProductsToolStripMenuItem.Name = "updateProductsToolStripMenuItem";
            updateProductsToolStripMenuItem.Size = new Size(244, 22);
            updateProductsToolStripMenuItem.Text = "Существующих товаров";
            updateProductsToolStripMenuItem.Click += updateProductsToolStripMenuItem_Click;
            // 
            // updateTypesToolStripMenuItem
            // 
            updateTypesToolStripMenuItem.Name = "updateTypesToolStripMenuItem";
            updateTypesToolStripMenuItem.Size = new Size(244, 22);
            updateTypesToolStripMenuItem.Text = "Существующих типов товаров";
            updateTypesToolStripMenuItem.Click += updateTypesToolStripMenuItem_Click;
            // 
            // updateSuppliersToolStripMenuItem
            // 
            updateSuppliersToolStripMenuItem.Name = "updateSuppliersToolStripMenuItem";
            updateSuppliersToolStripMenuItem.Size = new Size(244, 22);
            updateSuppliersToolStripMenuItem.Text = "Существуюищх поставщиков";
            updateSuppliersToolStripMenuItem.Click += updateSuppliersToolStripMenuItem_Click;
            // 
            // списокToolStripMenuItem
            // 
            списокToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { всегоСкладаToolStripMenuItem, всехТиповТовараToolStripMenuItem, всехПоставщиковToolStripMenuItem, среднееКолToolStripMenuItem, найтиToolStripMenuItem });
            списокToolStripMenuItem.Name = "списокToolStripMenuItem";
            списокToolStripMenuItem.Size = new Size(65, 20);
            списокToolStripMenuItem.Text = "Вывести";
            // 
            // всегоСкладаToolStripMenuItem
            // 
            всегоСкладаToolStripMenuItem.Name = "всегоСкладаToolStripMenuItem";
            всегоСкладаToolStripMenuItem.Size = new Size(304, 22);
            всегоСкладаToolStripMenuItem.Text = "Весь склад";
            всегоСкладаToolStripMenuItem.Click += viewEntireWarehouseToolStripMenuItem_Click;
            // 
            // всехТиповТовараToolStripMenuItem
            // 
            всехТиповТовараToolStripMenuItem.Name = "всехТиповТовараToolStripMenuItem";
            всехТиповТовараToolStripMenuItem.Size = new Size(304, 22);
            всехТиповТовараToolStripMenuItem.Text = "Все типы товара";
            всехТиповТовараToolStripMenuItem.Click += viewAllProductTypesToolStripMenuItem_Click;
            // 
            // всехПоставщиковToolStripMenuItem
            // 
            всехПоставщиковToolStripMenuItem.Name = "всехПоставщиковToolStripMenuItem";
            всехПоставщиковToolStripMenuItem.Size = new Size(304, 22);
            всехПоставщиковToolStripMenuItem.Text = "Всех поставщиков";
            всехПоставщиковToolStripMenuItem.Click += viewAllSuppliersToolStripMenuItem_Click;
            // 
            // среднееКолToolStripMenuItem
            // 
            среднееКолToolStripMenuItem.Name = "среднееКолToolStripMenuItem";
            среднееКолToolStripMenuItem.Size = new Size(304, 22);
            среднееКолToolStripMenuItem.Text = "Среднее кол-ва товаров по каждому типу";
            среднееКолToolStripMenuItem.Click += среднееКолToolStripMenuItem_Click;
            // 
            // найтиToolStripMenuItem
            // 
            найтиToolStripMenuItem.Name = "найтиToolStripMenuItem";
            найтиToolStripMenuItem.Size = new Size(304, 22);
            найтиToolStripMenuItem.Text = "Найти";
            // 
            // подробностиToolStripMenuItem
            // 
            подробностиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { поставщикаToolStripMenuItem, типТовараToolStripMenuItem, товарToolStripMenuItem });
            подробностиToolStripMenuItem.Name = "подробностиToolStripMenuItem";
            подробностиToolStripMenuItem.Size = new Size(53, 20);
            подробностиToolStripMenuItem.Text = "Найти";
            // 
            // поставщикаToolStripMenuItem
            // 
            поставщикаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem, сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem });
            поставщикаToolStripMenuItem.Name = "поставщикаToolStripMenuItem";
            поставщикаToolStripMenuItem.Size = new Size(143, 22);
            поставщикаToolStripMenuItem.Text = "Поставщика";
            // 
            // сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem
            // 
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem.Name = "сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem";
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem.Size = new Size(313, 22);
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem.Text = "С наибольшим кол-вом товаров на складе";
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem.Click += сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem_Click;
            // 
            // сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem
            // 
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem.Name = "сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem";
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem.Size = new Size(313, 22);
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem.Text = "С наименьшим кол-вом товаров на складе";
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem.Click += сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem_Click;
            // 
            // типТовараToolStripMenuItem
            // 
            типТовараToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1, сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1 });
            типТовараToolStripMenuItem.Name = "типТовараToolStripMenuItem";
            типТовараToolStripMenuItem.Size = new Size(143, 22);
            типТовараToolStripMenuItem.Text = "Тип товара";
            // 
            // сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1
            // 
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1.Name = "сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1";
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1.Size = new Size(313, 22);
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1.Text = "С наибольшим кол-вом товаров на складе";
            сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1.Click += сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1_Click;
            // 
            // сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1
            // 
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1.Name = "сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1";
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1.Size = new Size(313, 22);
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1.Text = "С наименьшим кол-вом товаров на складе";
            сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1.Click += сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1_Click;
            // 
            // товарToolStripMenuItem
            // 
            товарToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сНаибольшимКоличествомToolStripMenuItem, сНаименьшимКоличествомToolStripMenuItem, сНаибольшейСебестоимостьюToolStripMenuItem, сНаименьшейСебестоимостьюToolStripMenuItem, самыйСтарыйToolStripMenuItem });
            товарToolStripMenuItem.Name = "товарToolStripMenuItem";
            товарToolStripMenuItem.Size = new Size(143, 22);
            товарToolStripMenuItem.Text = "Товар";
            // 
            // сНаибольшимКоличествомToolStripMenuItem
            // 
            сНаибольшимКоличествомToolStripMenuItem.Name = "сНаибольшимКоличествомToolStripMenuItem";
            сНаибольшимКоличествомToolStripMenuItem.Size = new Size(253, 22);
            сНаибольшимКоличествомToolStripMenuItem.Text = "С наибольшим количеством";
            сНаибольшимКоличествомToolStripMenuItem.Click += сНаибольшимКоличествомToolStripMenuItem_Click;
            // 
            // сНаименьшимКоличествомToolStripMenuItem
            // 
            сНаименьшимКоличествомToolStripMenuItem.Name = "сНаименьшимКоличествомToolStripMenuItem";
            сНаименьшимКоличествомToolStripMenuItem.Size = new Size(253, 22);
            сНаименьшимКоличествомToolStripMenuItem.Text = "С наименьшим количеством";
            сНаименьшимКоличествомToolStripMenuItem.Click += сНаименьшимКоличествомToolStripMenuItem_Click;
            // 
            // сНаибольшейСебестоимостьюToolStripMenuItem
            // 
            сНаибольшейСебестоимостьюToolStripMenuItem.Name = "сНаибольшейСебестоимостьюToolStripMenuItem";
            сНаибольшейСебестоимостьюToolStripMenuItem.Size = new Size(253, 22);
            сНаибольшейСебестоимостьюToolStripMenuItem.Text = "С наибольшей себестоимостью";
            сНаибольшейСебестоимостьюToolStripMenuItem.Click += сНаибольшейСебестоимостьюToolStripMenuItem_Click;
            // 
            // сНаименьшейСебестоимостьюToolStripMenuItem
            // 
            сНаименьшейСебестоимостьюToolStripMenuItem.Name = "сНаименьшейСебестоимостьюToolStripMenuItem";
            сНаименьшейСебестоимостьюToolStripMenuItem.Size = new Size(253, 22);
            сНаименьшейСебестоимостьюToolStripMenuItem.Text = "С наименьшей себестоимостью";
            сНаименьшейСебестоимостьюToolStripMenuItem.Click += сНаименьшейСебестоимостьюToolStripMenuItem_Click;
            // 
            // самыйСтарыйToolStripMenuItem
            // 
            самыйСтарыйToolStripMenuItem.Name = "самыйСтарыйToolStripMenuItem";
            самыйСтарыйToolStripMenuItem.Size = new Size(253, 22);
            самыйСтарыйToolStripMenuItem.Text = "Самый старый";
            самыйСтарыйToolStripMenuItem.Click += самыйСтарыйToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 585);
            button1.Name = "button1";
            button1.Size = new Size(636, 23);
            button1.TabIndex = 17;
            button1.Text = "Показать товары с поставки, которых прошло заданное количество дней";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(654, 585);
            numericUpDown1.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(121, 23);
            numericUpDown1.TabIndex = 18;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 617);
            Controls.Add(numericUpDown1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Склад";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem insertingNewProductsToolStripMenuItem;
        private ToolStripMenuItem insertingNewTypesТоваровToolStripMenuItem;
        private ToolStripMenuItem insertingNewSuppliersToolStripMenuItem;
        private ToolStripMenuItem обновлениеToolStripMenuItem;
        private ToolStripMenuItem updateProductsToolStripMenuItem;
        private ToolStripMenuItem updateTypesToolStripMenuItem;
        private ToolStripMenuItem updateSuppliersToolStripMenuItem;
        private ToolStripMenuItem списокToolStripMenuItem;
        private ToolStripMenuItem всегоСкладаToolStripMenuItem;
        private ToolStripMenuItem всехТиповТовараToolStripMenuItem;
        private ToolStripMenuItem всехПоставщиковToolStripMenuItem;
        private ToolStripMenuItem подробностиToolStripMenuItem;
        private ToolStripMenuItem поставщикаToolStripMenuItem;
        private ToolStripMenuItem сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem;
        private ToolStripMenuItem сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem;
        private ToolStripMenuItem типТовараToolStripMenuItem;
        private ToolStripMenuItem сНаибольшимКолвомТоваровНаСкладеToolStripMenuItem1;
        private ToolStripMenuItem сНаименьшимКолвомТоваровНаСкладеToolStripMenuItem1;
        private ToolStripMenuItem товарToolStripMenuItem;
        private ToolStripMenuItem сНаибольшимКоличествомToolStripMenuItem;
        private ToolStripMenuItem сНаименьшимКоличествомToolStripMenuItem;
        private ToolStripMenuItem сНаибольшейСебестоимостьюToolStripMenuItem;
        private ToolStripMenuItem сНаименьшейСебестоимостьюToolStripMenuItem;
        private ToolStripMenuItem самыйСтарыйToolStripMenuItem;
        private ToolStripMenuItem среднееКолToolStripMenuItem;
        private ToolStripMenuItem найтиToolStripMenuItem;
        private Button button1;
        private NumericUpDown numericUpDown1;
    }
}
