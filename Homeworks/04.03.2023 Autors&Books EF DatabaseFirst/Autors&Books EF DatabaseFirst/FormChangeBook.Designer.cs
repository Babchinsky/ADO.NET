namespace Autors_Books_EF_DatabaseFirst
{
    partial class FormChangeBook
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
            comboBoxTitle = new ComboBox();
            textBoxNewTitle = new TextBox();
            buttonDelete = new Button();
            buttonChange = new Button();
            buttonAdd = new Button();
            comboBoxAuthor = new ComboBox();
            SuspendLayout();
            // 
            // comboBoxTitle
            // 
            comboBoxTitle.FormattingEnabled = true;
            comboBoxTitle.Location = new Point(12, 12);
            comboBoxTitle.Name = "comboBoxTitle";
            comboBoxTitle.Size = new Size(331, 23);
            comboBoxTitle.TabIndex = 0;
            comboBoxTitle.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBoxNewTitle
            // 
            textBoxNewTitle.Location = new Point(12, 41);
            textBoxNewTitle.Name = "textBoxNewTitle";
            textBoxNewTitle.Size = new Size(331, 23);
            textBoxNewTitle.TabIndex = 1;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(268, 99);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonChange
            // 
            buttonChange.Location = new Point(187, 99);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(75, 23);
            buttonChange.TabIndex = 3;
            buttonChange.Text = "Изменить";
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange.Click += buttonChange_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(106, 99);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 4;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // comboBoxAuthor
            // 
            comboBoxAuthor.FormattingEnabled = true;
            comboBoxAuthor.Location = new Point(12, 70);
            comboBoxAuthor.Name = "comboBoxAuthor";
            comboBoxAuthor.Size = new Size(331, 23);
            comboBoxAuthor.TabIndex = 5;
            // 
            // FormChangeBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 129);
            Controls.Add(comboBoxAuthor);
            Controls.Add(buttonAdd);
            Controls.Add(buttonChange);
            Controls.Add(buttonDelete);
            Controls.Add(textBoxNewTitle);
            Controls.Add(comboBoxTitle);
            Name = "FormChangeBook";
            Text = "Изменение книги";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxTitle;
        private TextBox textBoxNewTitle;
        private Button buttonDelete;
        private Button buttonChange;
        private Button buttonAdd;
        private ComboBox comboBoxAuthor;
    }
}