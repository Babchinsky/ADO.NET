namespace _19._02._2024_Detached_model.View
{
    partial class FormSuppliers
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
            comboBoxName = new ComboBox();
            textBoxName = new TextBox();
            btnDelete = new Button();
            btnChange = new Button();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // comboBoxName
            // 
            comboBoxName.FormattingEnabled = true;
            comboBoxName.Location = new Point(12, 12);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new Size(407, 23);
            comboBoxName.TabIndex = 0;
            comboBoxName.SelectedIndexChanged += comboBoxName_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBoxName.Location = new Point(12, 41);
            textBoxName.Name = "textBox1";
            textBoxName.Size = new Size(407, 23);
            textBoxName.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(344, 70);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(263, 70);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(75, 23);
            btnChange.TabIndex = 3;
            btnChange.Text = "Изменить";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(182, 70);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // FormSuppliers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 104);
            Controls.Add(btnAdd);
            Controls.Add(btnChange);
            Controls.Add(btnDelete);
            Controls.Add(textBoxName);
            Controls.Add(comboBoxName);
            Name = "FormSuppliers";
            Text = "Поставщики";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxName;
        private TextBox textBoxName;
        private Button btnDelete;
        private Button btnChange;
        private Button btnAdd;
    }
}