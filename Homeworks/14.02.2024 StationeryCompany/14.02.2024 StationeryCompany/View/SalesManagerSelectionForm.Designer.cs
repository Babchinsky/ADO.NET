namespace _14._02._2024_StationeryCompany.View
{
    partial class SalesManagerSelectionForm
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
            comboBoxSalesManagers = new ComboBox();
            btnSelect = new Button();
            SuspendLayout();
            // 
            // comboBoxSalesManagers
            // 
            comboBoxSalesManagers.FormattingEnabled = true;
            comboBoxSalesManagers.Location = new Point(12, 16);
            comboBoxSalesManagers.Name = "comboBoxSalesManagers";
            comboBoxSalesManagers.Size = new Size(342, 23);
            comboBoxSalesManagers.TabIndex = 0;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(279, 45);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(75, 23);
            btnSelect.TabIndex = 1;
            btnSelect.Text = "Выбрать";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // SalesManagerSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 77);
            Controls.Add(btnSelect);
            Controls.Add(comboBoxSalesManagers);
            Name = "SalesManagerSelectionForm";
            Text = "Выбор типа канцтоваров";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxSalesManagers;
        private Button btnSelect;
    }
}