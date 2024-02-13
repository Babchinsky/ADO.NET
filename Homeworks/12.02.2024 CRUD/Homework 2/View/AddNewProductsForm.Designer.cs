namespace Homework_3
{
    partial class AddNewProductsForm
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
            buttonAdd = new Button();
            buttonDone = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCost).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(101, 6);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(219, 23);
            textBoxName.TabIndex = 0;
            textBoxName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 1;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 2;
            label2.Text = "Тип";
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(101, 35);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(219, 23);
            comboBoxType.TabIndex = 3;
            // 
            // comboBoxSupplier
            // 
            comboBoxSupplier.FormattingEnabled = true;
            comboBoxSupplier.Location = new Point(101, 64);
            comboBoxSupplier.Name = "comboBoxSupplier";
            comboBoxSupplier.Size = new Size(219, 23);
            comboBoxSupplier.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 4;
            label3.Text = "Поставщик";
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(101, 93);
            numericUpDownQuantity.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(219, 23);
            numericUpDownQuantity.TabIndex = 6;
            numericUpDownQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownCost
            // 
            numericUpDownCost.Location = new Point(101, 122);
            numericUpDownCost.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownCost.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCost.Name = "numericUpDownCost";
            numericUpDownCost.Size = new Size(219, 23);
            numericUpDownCost.TabIndex = 7;
            numericUpDownCost.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(101, 151);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(219, 23);
            dateTimePicker.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 95);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 9;
            label4.Text = "Количество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 124);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 10;
            label5.Text = "Цена";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 155);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 11;
            label6.Text = "Дата поставки";
            // 
            // buttonAdd
            // 
            buttonAdd.Enabled = false;
            buttonAdd.Location = new Point(163, 180);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 12;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDone
            // 
            buttonDone.Location = new Point(244, 180);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(75, 23);
            buttonDone.TabIndex = 13;
            buttonDone.Text = "Готово";
            buttonDone.UseVisualStyleBackColor = true;
            buttonDone.Click += buttonDone_Click;
            // 
            // AddNewProductsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 215);
            Controls.Add(buttonDone);
            Controls.Add(buttonAdd);
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
            Name = "AddNewProductsForm";
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
        private Button buttonAdd;
        private Button buttonDone;
    }
}