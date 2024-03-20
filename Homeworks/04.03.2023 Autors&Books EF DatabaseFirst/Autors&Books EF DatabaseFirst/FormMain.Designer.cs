namespace Autors_Books_EF_DatabaseFirst
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
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            displayAllBooksToolStripMenuItem = new ToolStripMenuItem();
            displayAllAuthorsToolStripMenuItem = new ToolStripMenuItem();
            displayAuthorsBooksToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            changeAuthorToolStripMenuItem = new ToolStripMenuItem();
            changeBookToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(427, 411);
            dataGridView1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(451, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { displayAllBooksToolStripMenuItem, displayAllAuthorsToolStripMenuItem, displayAuthorsBooksToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // displayAllBooksToolStripMenuItem
            // 
            displayAllBooksToolStripMenuItem.Name = "displayAllBooksToolStripMenuItem";
            displayAllBooksToolStripMenuItem.Size = new Size(199, 22);
            displayAllBooksToolStripMenuItem.Text = "Показать все книги";
            displayAllBooksToolStripMenuItem.Click += displayAllBooksToolStripMenuItem_Click;
            // 
            // displayAllAuthorsToolStripMenuItem
            // 
            displayAllAuthorsToolStripMenuItem.Name = "displayAllAuthorsToolStripMenuItem";
            displayAllAuthorsToolStripMenuItem.Size = new Size(199, 22);
            displayAllAuthorsToolStripMenuItem.Text = "Показать всех авторов";
            displayAllAuthorsToolStripMenuItem.Click += displayAllAuthorsToolStripMenuItem_Click;
            // 
            // displayAuthorsBooksToolStripMenuItem
            // 
            displayAuthorsBooksToolStripMenuItem.Name = "displayAuthorsBooksToolStripMenuItem";
            displayAuthorsBooksToolStripMenuItem.Size = new Size(199, 22);
            displayAuthorsBooksToolStripMenuItem.Text = "Показать книги автора";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeAuthorToolStripMenuItem, changeBookToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(56, 20);
            optionsToolStripMenuItem.Text = "Опции";
            // 
            // changeAuthorToolStripMenuItem
            // 
            changeAuthorToolStripMenuItem.Name = "changeAuthorToolStripMenuItem";
            changeAuthorToolStripMenuItem.Size = new Size(180, 22);
            changeAuthorToolStripMenuItem.Text = "Изменение автора";
            changeAuthorToolStripMenuItem.Click += changeAuthorToolStripMenuItem_Click;
            // 
            // changeBookToolStripMenuItem
            // 
            changeBookToolStripMenuItem.Name = "changeBookToolStripMenuItem";
            changeBookToolStripMenuItem.Size = new Size(180, 22);
            changeBookToolStripMenuItem.Text = "Изменение книги";
            changeBookToolStripMenuItem.Click += changeBookToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 450);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "Библиотека";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem displayAllBooksToolStripMenuItem;
        private ToolStripMenuItem displayAllAuthorsToolStripMenuItem;
        private ToolStripMenuItem displayAuthorsBooksToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem changeAuthorToolStripMenuItem;
        private ToolStripMenuItem changeBookToolStripMenuItem;
    }
}
