namespace EF_CRUD_DLL
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
            groupBox1 = new GroupBox();
            btnChangePart = new Button();
            btnDeletePart = new Button();
            btnAddPart = new Button();
            comboBoxPartName = new ComboBox();
            textBoxPartName = new TextBox();
            groupBox2 = new GroupBox();
            label5 = new Label();
            comboBoxPartForCountry = new ComboBox();
            textBoxCapital = new TextBox();
            numericUpDownArea = new NumericUpDown();
            numericUpDownPopulation = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnChangeCountry = new Button();
            btnDeleteCountry = new Button();
            btnAddCountry = new Button();
            comboBoxCountryName = new ComboBox();
            textBoxCountryName = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPopulation).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnChangePart);
            groupBox1.Controls.Add(btnDeletePart);
            groupBox1.Controls.Add(btnAddPart);
            groupBox1.Controls.Add(comboBoxPartName);
            groupBox1.Controls.Add(textBoxPartName);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 170);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Части света";
            // 
            // btnChangePart
            // 
            btnChangePart.Location = new Point(6, 138);
            btnChangePart.Name = "btnChangePart";
            btnChangePart.Size = new Size(188, 23);
            btnChangePart.TabIndex = 4;
            btnChangePart.Text = "Изменить";
            btnChangePart.UseVisualStyleBackColor = true;
            btnChangePart.Click += btnChangePart_Click;
            // 
            // btnDeletePart
            // 
            btnDeletePart.Location = new Point(6, 109);
            btnDeletePart.Name = "btnDeletePart";
            btnDeletePart.Size = new Size(188, 23);
            btnDeletePart.TabIndex = 3;
            btnDeletePart.Text = "Удалить";
            btnDeletePart.UseVisualStyleBackColor = true;
            btnDeletePart.Click += btnDeletePart_Click;
            // 
            // btnAddPart
            // 
            btnAddPart.Location = new Point(6, 80);
            btnAddPart.Name = "btnAddPart";
            btnAddPart.Size = new Size(188, 23);
            btnAddPart.TabIndex = 2;
            btnAddPart.Text = "Добавить";
            btnAddPart.UseVisualStyleBackColor = true;
            btnAddPart.Click += btnAddPart_Click;
            // 
            // comboBoxPartName
            // 
            comboBoxPartName.FormattingEnabled = true;
            comboBoxPartName.Location = new Point(6, 51);
            comboBoxPartName.Name = "comboBoxPartName";
            comboBoxPartName.Size = new Size(188, 23);
            comboBoxPartName.TabIndex = 1;
            comboBoxPartName.SelectedIndexChanged += comboBoxPartName_SelectedIndexChanged;
            // 
            // textBoxPartName
            // 
            textBoxPartName.Location = new Point(6, 22);
            textBoxPartName.Name = "textBoxPartName";
            textBoxPartName.Size = new Size(188, 23);
            textBoxPartName.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(comboBoxPartForCountry);
            groupBox2.Controls.Add(textBoxCapital);
            groupBox2.Controls.Add(numericUpDownArea);
            groupBox2.Controls.Add(numericUpDownPopulation);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnChangeCountry);
            groupBox2.Controls.Add(btnDeleteCountry);
            groupBox2.Controls.Add(btnAddCountry);
            groupBox2.Controls.Add(comboBoxCountryName);
            groupBox2.Controls.Add(textBoxCountryName);
            groupBox2.Location = new Point(218, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(479, 170);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Страны";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 141);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 13;
            label5.Text = "Часть света:";
            // 
            // comboBoxPartForCountry
            // 
            comboBoxPartForCountry.FormattingEnabled = true;
            comboBoxPartForCountry.Location = new Point(86, 138);
            comboBoxPartForCountry.Name = "comboBoxPartForCountry";
            comboBoxPartForCountry.Size = new Size(188, 23);
            comboBoxPartForCountry.TabIndex = 12;
            // 
            // textBoxCapital
            // 
            textBoxCapital.Location = new Point(86, 51);
            textBoxCapital.Name = "textBoxCapital";
            textBoxCapital.Size = new Size(188, 23);
            textBoxCapital.TabIndex = 11;
            // 
            // numericUpDownArea
            // 
            numericUpDownArea.Location = new Point(86, 109);
            numericUpDownArea.Maximum = new decimal(new int[] { 1874919423, 2328306, 0, 0 });
            numericUpDownArea.Name = "numericUpDownArea";
            numericUpDownArea.Size = new Size(188, 23);
            numericUpDownArea.TabIndex = 10;
            // 
            // numericUpDownPopulation
            // 
            numericUpDownPopulation.Location = new Point(86, 80);
            numericUpDownPopulation.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            numericUpDownPopulation.Name = "numericUpDownPopulation";
            numericUpDownPopulation.Size = new Size(188, 23);
            numericUpDownPopulation.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 113);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 8;
            label4.Text = "Площадь:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 84);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 7;
            label3.Text = "Население:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 6;
            label2.Text = "Столица:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 5;
            label1.Text = "Название:";
            // 
            // btnChangeCountry
            // 
            btnChangeCountry.Location = new Point(280, 109);
            btnChangeCountry.Name = "btnChangeCountry";
            btnChangeCountry.Size = new Size(188, 23);
            btnChangeCountry.TabIndex = 4;
            btnChangeCountry.Text = "Изменить";
            btnChangeCountry.UseVisualStyleBackColor = true;
            btnChangeCountry.Click += btnChangeCountry_Click;
            // 
            // btnDeleteCountry
            // 
            btnDeleteCountry.Location = new Point(280, 80);
            btnDeleteCountry.Name = "btnDeleteCountry";
            btnDeleteCountry.Size = new Size(188, 23);
            btnDeleteCountry.TabIndex = 3;
            btnDeleteCountry.Text = "Удалить";
            btnDeleteCountry.UseVisualStyleBackColor = true;
            btnDeleteCountry.Click += btnDeleteCountry_Click;
            // 
            // btnAddCountry
            // 
            btnAddCountry.Location = new Point(280, 51);
            btnAddCountry.Name = "btnAddCountry";
            btnAddCountry.Size = new Size(188, 23);
            btnAddCountry.TabIndex = 2;
            btnAddCountry.Text = "Добавить";
            btnAddCountry.UseVisualStyleBackColor = true;
            btnAddCountry.Click += btnAddCountry_Click;
            // 
            // comboBoxCountryName
            // 
            comboBoxCountryName.FormattingEnabled = true;
            comboBoxCountryName.Location = new Point(280, 22);
            comboBoxCountryName.Name = "comboBoxCountryName";
            comboBoxCountryName.Size = new Size(188, 23);
            comboBoxCountryName.TabIndex = 1;
            comboBoxCountryName.SelectedIndexChanged += comboBoxCountryName_SelectedIndexChanged;
            // 
            // textBoxCountryName
            // 
            textBoxCountryName.Location = new Point(86, 22);
            textBoxCountryName.Name = "textBoxCountryName";
            textBoxCountryName.Size = new Size(188, 23);
            textBoxCountryName.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 191);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormMain";
            Text = "Страны";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPopulation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnChangePart;
        private Button btnDeletePart;
        private Button btnAddPart;
        private ComboBox comboBoxPartName;
        private TextBox textBoxPartName;
        private GroupBox groupBox2;
        private Label label2;
        private Label label1;
        private Button btnChangeCountry;
        private Button btnDeleteCountry;
        private Button btnAddCountry;
        private ComboBox comboBoxCountryName;
        private TextBox textBoxCountryName;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDownArea;
        private NumericUpDown numericUpDownPopulation;
        private TextBox textBoxCapital;
        private Label label5;
        private ComboBox comboBoxPartForCountry;
    }
}
