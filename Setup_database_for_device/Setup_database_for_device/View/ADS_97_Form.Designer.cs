
namespace Setup_database_for_device.View
{
    partial class ADS_97_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AdaptersCountCombobox = new System.Windows.Forms.ComboBox();
            this.labelFirstAdapter = new System.Windows.Forms.Label();
            this.labelSecondAdapter = new System.Windows.Forms.Label();
            this.FirstAdapterNumber = new System.Windows.Forms.NumericUpDown();
            this.SecondAdapterNumber = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FirstAdapterNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondAdapterNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Необходимо применить АДС-97,\r\nиначе продолжение невозможно";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество адаптеров";
            // 
            // AdaptersCountCombobox
            // 
            this.AdaptersCountCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AdaptersCountCombobox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdaptersCountCombobox.FormattingEnabled = true;
            this.AdaptersCountCombobox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.AdaptersCountCombobox.Location = new System.Drawing.Point(246, 113);
            this.AdaptersCountCombobox.Name = "AdaptersCountCombobox";
            this.AdaptersCountCombobox.Size = new System.Drawing.Size(109, 26);
            this.AdaptersCountCombobox.TabIndex = 2;
            this.AdaptersCountCombobox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelFirstAdapter
            // 
            this.labelFirstAdapter.AutoSize = true;
            this.labelFirstAdapter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFirstAdapter.Location = new System.Drawing.Point(70, 168);
            this.labelFirstAdapter.Name = "labelFirstAdapter";
            this.labelFirstAdapter.Size = new System.Drawing.Size(143, 18);
            this.labelFirstAdapter.TabIndex = 3;
            this.labelFirstAdapter.Text = "Адрес адаптера 1";
            // 
            // labelSecondAdapter
            // 
            this.labelSecondAdapter.AutoSize = true;
            this.labelSecondAdapter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSecondAdapter.Location = new System.Drawing.Point(70, 219);
            this.labelSecondAdapter.Name = "labelSecondAdapter";
            this.labelSecondAdapter.Size = new System.Drawing.Size(143, 18);
            this.labelSecondAdapter.TabIndex = 4;
            this.labelSecondAdapter.Text = "Адрес адаптера 2";
            // 
            // FirstAdapterNumber
            // 
            this.FirstAdapterNumber.Location = new System.Drawing.Point(246, 164);
            this.FirstAdapterNumber.Maximum = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.FirstAdapterNumber.Name = "FirstAdapterNumber";
            this.FirstAdapterNumber.Size = new System.Drawing.Size(109, 22);
            this.FirstAdapterNumber.TabIndex = 5;
            // 
            // SecondAdapterNumber
            // 
            this.SecondAdapterNumber.Location = new System.Drawing.Point(246, 219);
            this.SecondAdapterNumber.Maximum = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.SecondAdapterNumber.Name = "SecondAdapterNumber";
            this.SecondAdapterNumber.Size = new System.Drawing.Size(109, 22);
            this.SecondAdapterNumber.TabIndex = 6;
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(229, 259);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(94, 41);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // ADS_97_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 326);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.SecondAdapterNumber);
            this.Controls.Add(this.FirstAdapterNumber);
            this.Controls.Add(this.labelSecondAdapter);
            this.Controls.Add(this.labelFirstAdapter);
            this.Controls.Add(this.AdaptersCountCombobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ADS_97_Form";
            this.Text = "Применение АДС-97";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ADS_97_Form_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.FirstAdapterNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondAdapterNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFirstAdapter;
        private System.Windows.Forms.Label labelSecondAdapter;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.ComboBox AdaptersCountCombobox;
        public System.Windows.Forms.NumericUpDown FirstAdapterNumber;
        public System.Windows.Forms.NumericUpDown SecondAdapterNumber;
    }
}