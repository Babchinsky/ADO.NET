namespace _19._02._2024_Detached_model
{
    partial class FormProducts
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
            comboBoxType = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxSupplier = new ComboBox();
            numericUpDownQuantity = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            numericUpDownCost = new NumericUpDown();
            label5 = new Label();
            dateTimePicker = new DateTimePicker();
            buttonDelete = new Button();
            buttonChange = new Button();
            buttonAdd = new Button();
            label6 = new Label();
            comboBoxName = new ComboBox();
            textBoxNewName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCost).BeginInit();
            SuspendLayout();
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(12, 105);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(309, 23);
            comboBoxType.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 87);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 2;
            label1.Text = "Тип";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 132);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 4;
            label2.Text = "Поставщик";
            // 
            // comboBoxSupplier
            // 
            comboBoxSupplier.FormattingEnabled = true;
            comboBoxSupplier.Location = new Point(12, 150);
            comboBoxSupplier.Name = "comboBoxSupplier";
            comboBoxSupplier.Size = new Size(309, 23);
            comboBoxSupplier.TabIndex = 3;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(12, 197);
            numericUpDownQuantity.Maximum = new decimal(new int[] { 1215752191, 23, 0, 0 });
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(309, 23);
            numericUpDownQuantity.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 179);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 6;
            label3.Text = "Количество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 227);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 8;
            label4.Text = "Цена";
            // 
            // numericUpDownCost
            // 
            numericUpDownCost.Location = new Point(12, 245);
            numericUpDownCost.Maximum = new decimal(new int[] { 1874919423, 2328306, 0, 0 });
            numericUpDownCost.Name = "numericUpDownCost";
            numericUpDownCost.Size = new Size(309, 23);
            numericUpDownCost.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 275);
            label5.Name = "label5";
            label5.Size = new Size(85, 15);
            label5.TabIndex = 10;
            label5.Text = "Дата поставки";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(12, 293);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(309, 23);
            dateTimePicker.TabIndex = 11;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(246, 322);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 12;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonChange
            // 
            buttonChange.Location = new Point(165, 322);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(75, 23);
            buttonChange.TabIndex = 13;
            buttonChange.Text = "Изменить";
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange.Click += buttonChange_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(84, 322);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 14;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 10);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 16;
            label6.Text = "Название";
            // 
            // comboBoxName
            // 
            comboBoxName.FormattingEnabled = true;
            comboBoxName.Location = new Point(12, 28);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new Size(309, 23);
            comboBoxName.TabIndex = 17;
            comboBoxName.SelectedIndexChanged += comboBoxName_SelectedIndexChanged;
            // 
            // textBoxNewName
            // 
            textBoxNewName.Location = new Point(12, 61);
            textBoxNewName.Name = "textBoxNewName";
            textBoxNewName.Size = new Size(309, 23);
            textBoxNewName.TabIndex = 18;
            // 
            // FormProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 352);
            Controls.Add(textBoxNewName);
            Controls.Add(comboBoxName);
            Controls.Add(label6);
            Controls.Add(buttonAdd);
            Controls.Add(buttonChange);
            Controls.Add(buttonDelete);
            Controls.Add(dateTimePicker);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(numericUpDownCost);
            Controls.Add(label3);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(label2);
            Controls.Add(comboBoxSupplier);
            Controls.Add(label1);
            Controls.Add(comboBoxType);
            Name = "FormProducts";
            Text = "Продукты";
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxType;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxSupplier;
        private NumericUpDown numericUpDownQuantity;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDownCost;
        private Label label5;
        private DateTimePicker dateTimePicker;
        private Button buttonDelete;
        private Button buttonChange;
        private Button buttonAdd;
        private Label label6;
        private ComboBox comboBoxName;
        private TextBox textBoxNewName;
    }
}