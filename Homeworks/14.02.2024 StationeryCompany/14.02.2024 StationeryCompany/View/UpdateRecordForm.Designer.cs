namespace _14._02._2024_StationeryCompany.View
{
    partial class UpdateRecordForm
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
            comboBoxSelect = new ComboBox();
            textBoxNew = new TextBox();
            btnDelete = new Button();
            btnChange = new Button();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // comboBoxSelect
            // 
            comboBoxSelect.FormattingEnabled = true;
            comboBoxSelect.Location = new Point(12, 12);
            comboBoxSelect.Name = "comboBoxSelect";
            comboBoxSelect.Size = new Size(315, 23);
            comboBoxSelect.TabIndex = 0;
            comboBoxSelect.SelectedIndexChanged += comboBoxSelect_SelectedIndexChanged;
            // 
            // textBoxNew
            // 
            textBoxNew.Location = new Point(12, 41);
            textBoxNew.Name = "textBoxNew";
            textBoxNew.Size = new Size(315, 23);
            textBoxNew.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(252, 70);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnChange
            // 
            btnChange.Location = new Point(171, 70);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(75, 23);
            btnChange.TabIndex = 3;
            btnChange.Text = "Изменить";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(90, 70);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // UpdateRecordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 104);
            Controls.Add(btnAdd);
            Controls.Add(btnChange);
            Controls.Add(btnDelete);
            Controls.Add(textBoxNew);
            Controls.Add(comboBoxSelect);
            Name = "UpdateRecordForm";
            Text = "UpdateRecordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxSelect;
        private TextBox textBoxNew;
        private Button btnDelete;
        private Button btnChange;
        private Button btnAdd;
    }
}