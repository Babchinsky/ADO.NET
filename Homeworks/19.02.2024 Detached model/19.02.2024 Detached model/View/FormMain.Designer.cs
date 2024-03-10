namespace _19._02._2024_Detached_model
{
    partial class FormMain
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
            dataGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            updateToolStripMenuItem = new ToolStripMenuItem();
            localDatabaseToolStripMenuItem = new ToolStripMenuItem();
            realDatabaseToolStripMenuItem = new ToolStripMenuItem();
            showToolStripMenuItem = new ToolStripMenuItem();
            productTypesToolStripMenuItem = new ToolStripMenuItem();
            suppliersToolStripMenuItem = new ToolStripMenuItem();
            productsToolStripMenuItem = new ToolStripMenuItem();
            changeToolStripMenuItem = new ToolStripMenuItem();
            productTypesToolStripMenuItem1 = new ToolStripMenuItem();
            suppliersToolStripMenuItem1 = new ToolStripMenuItem();
            productsToolStripMenuItem1 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 27);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(776, 411);
            dataGridView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { updateToolStripMenuItem, showToolStripMenuItem, changeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localDatabaseToolStripMenuItem, realDatabaseToolStripMenuItem });
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(57, 20);
            updateToolStripMenuItem.Text = "Update";
            // 
            // localDatabaseToolStripMenuItem
            // 
            localDatabaseToolStripMenuItem.Name = "localDatabaseToolStripMenuItem";
            localDatabaseToolStripMenuItem.Size = new Size(153, 22);
            localDatabaseToolStripMenuItem.Text = "Local Database";
            localDatabaseToolStripMenuItem.Click += loadDatabaseFromSourceToolStripMenuItem_Click;
            // 
            // realDatabaseToolStripMenuItem
            // 
            realDatabaseToolStripMenuItem.Name = "realDatabaseToolStripMenuItem";
            realDatabaseToolStripMenuItem.Size = new Size(153, 22);
            realDatabaseToolStripMenuItem.Text = "Real Database";
            realDatabaseToolStripMenuItem.Click += updateDataSourceToolStripMenuItem_Click;
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productTypesToolStripMenuItem, suppliersToolStripMenuItem, productsToolStripMenuItem });
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(48, 20);
            showToolStripMenuItem.Text = "Show";
            // 
            // productTypesToolStripMenuItem
            // 
            productTypesToolStripMenuItem.Name = "productTypesToolStripMenuItem";
            productTypesToolStripMenuItem.Size = new Size(148, 22);
            productTypesToolStripMenuItem.Text = "Product Types";
            productTypesToolStripMenuItem.Click += productTypesToolStripMenuItem_Click;
            // 
            // suppliersToolStripMenuItem
            // 
            suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            suppliersToolStripMenuItem.Size = new Size(148, 22);
            suppliersToolStripMenuItem.Text = "Suppliers";
            suppliersToolStripMenuItem.Click += suppliersToolStripMenuItem_Click;
            // 
            // productsToolStripMenuItem
            // 
            productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            productsToolStripMenuItem.Size = new Size(148, 22);
            productsToolStripMenuItem.Text = "Products";
            productsToolStripMenuItem.Click += productsToolStripMenuItem_Click;
            // 
            // changeToolStripMenuItem
            // 
            changeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productTypesToolStripMenuItem1, suppliersToolStripMenuItem1, productsToolStripMenuItem1 });
            changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            changeToolStripMenuItem.Size = new Size(60, 20);
            changeToolStripMenuItem.Text = "Change";
            // 
            // productTypesToolStripMenuItem1
            // 
            productTypesToolStripMenuItem1.Name = "productTypesToolStripMenuItem1";
            productTypesToolStripMenuItem1.Size = new Size(180, 22);
            productTypesToolStripMenuItem1.Text = "Product Types";
            productTypesToolStripMenuItem1.Click += changeProductTypesToolStripMenuItem1_Click;
            // 
            // suppliersToolStripMenuItem1
            // 
            suppliersToolStripMenuItem1.Name = "suppliersToolStripMenuItem1";
            suppliersToolStripMenuItem1.Size = new Size(180, 22);
            suppliersToolStripMenuItem1.Text = "Suppliers";
            suppliersToolStripMenuItem1.Click += changeSuppliersToolStripMenuItem1_Click;
            // 
            // productsToolStripMenuItem1
            // 
            productsToolStripMenuItem1.Name = "productsToolStripMenuItem1";
            productsToolStripMenuItem1.Size = new Size(180, 22);
            productsToolStripMenuItem1.Text = "Products";
            productsToolStripMenuItem1.Click += changeProductsToolStripMenuItem1_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            Name = "FormMain";
            Text = "Stock Database";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem localDatabaseToolStripMenuItem;
        private ToolStripMenuItem realDatabaseToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem productTypesToolStripMenuItem;
        private ToolStripMenuItem suppliersToolStripMenuItem;
        private ToolStripMenuItem productsToolStripMenuItem;
        private ToolStripMenuItem changeToolStripMenuItem;
        private ToolStripMenuItem productTypesToolStripMenuItem1;
        private ToolStripMenuItem suppliersToolStripMenuItem1;
        private ToolStripMenuItem productsToolStripMenuItem1;
    }
}
