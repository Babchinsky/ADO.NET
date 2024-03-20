namespace Autors_Books_EF_DatabaseFirst
{
    partial class FormChangeAuthor
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            buttonDelete = new Button();
            buttonChange = new Button();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(331, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(331, 23);
            textBox1.TabIndex = 1;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(268, 70);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonChange
            // 
            buttonChange.Location = new Point(187, 70);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(75, 23);
            buttonChange.TabIndex = 3;
            buttonChange.Text = "Изменить";
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange.Click += buttonChange_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(106, 70);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 4;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // FormChangeAuthor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 99);
            Controls.Add(buttonAdd);
            Controls.Add(buttonChange);
            Controls.Add(buttonDelete);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Name = "FormChangeAuthor";
            Text = "Изменение автора";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button buttonDelete;
        private Button buttonChange;
        private Button buttonAdd;
    }
}