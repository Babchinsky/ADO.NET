namespace Homework_3
{
    partial class UpdateProductsForm
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
            textBoxName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxType = new ComboBox();
            comboBoxSupplier = new ComboBox();
            label3 = new Label();
            numericUpDownQuantity = new NumericUpDown();
            numericUpDownCost = new NumericUpDown();
            dateTimePicker = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            buttonChange = new Button();
            buttonDone = new Button();
            comboBoxName = new ComboBox();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCost).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(101, 41);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(219, 23);
            textBoxName.TabIndex = 0;
            textBoxName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 1;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 2;
            label2.Text = "Тип";
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(101, 70);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(219, 23);
            comboBoxType.TabIndex = 3;
            // 
            // comboBoxSupplier
            // 
            comboBoxSupplier.FormattingEnabled = true;
            comboBoxSupplier.Location = new Point(101, 99);
            comboBoxSupplier.Name = "comboBoxSupplier";
            comboBoxSupplier.Size = new Size(219, 23);
            comboBoxSupplier.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 102);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 4;
            label3.Text = "Поставщик";
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(101, 128);
            numericUpDownQuantity.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(219, 23);
            numericUpDownQuantity.TabIndex = 6;
            numericUpDownQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownCost
            // 
            numericUpDownCost.Location = new Point(101, 157);
            numericUpDownCost.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownCost.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCost.Name = "numericUpDownCost";
            numericUpDownCost.Size = new Size(219, 23);
            numericUpDownCost.TabIndex = 7;
            numericUpDownCost.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(101, 186);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(219, 23);
            dateTimePicker.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 130);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 9;
            label4.Text = "Количество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 159);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 10;
            label5.Text = "Цена";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 190);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 11;
            label6.Text = "Дата поставки";
            // 
            // buttonChange
            // 
            buttonChange.Enabled = false;
            buttonChange.Location = new Point(83, 215);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(75, 23);
            buttonChange.TabIndex = 12;
            buttonChange.Text = "Изменить";
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange.Click += buttonChange_Click;
            // 
            // buttonDone
            // 
            buttonDone.Location = new Point(245, 215);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(75, 23);
            buttonDone.TabIndex = 13;
            buttonDone.Text = "Готово";
            buttonDone.UseVisualStyleBackColor = true;
            buttonDone.Click += buttonDone_Click;
            // 
            // comboBoxName
            // 
            comboBoxName.FormattingEnabled = true;
            comboBoxName.Location = new Point(12, 12);
            comboBoxName.Name = "comboBoxName";
            comboBoxName.Size = new Size(308, 23);
            comboBoxName.TabIndex = 14;
            comboBoxName.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(164, 215);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 15;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // UpdateProductsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 247);
            Controls.Add(buttonDelete);
            Controls.Add(comboBoxName);
            Controls.Add(buttonDone);
            Controls.Add(buttonChange);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dateTimePicker);
            Controls.Add(numericUpDownCost);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(comboBoxSupplier);
            Controls.Add(label3);
            Controls.Add(comboBoxType);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Name = "UpdateProductsForm";
            Text = "Добавить новый товар";
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxType;
        private ComboBox comboBoxSupplier;
        private Label label3;
        private NumericUpDown numericUpDownQuantity;
        private NumericUpDown numericUpDownCost;
        private DateTimePicker dateTimePicker;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button buttonChange;
        private Button buttonDone;
        private ComboBox comboBoxName;
        private Button buttonDelete;
    }
}