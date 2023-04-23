
namespace Setup_database_for_device.View
{
    partial class ConsumerForm
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
            this.labelConsumerTitle = new System.Windows.Forms.Label();
            this.labelConsumerId = new System.Windows.Forms.Label();
            this.numericUpDownConsumerId = new System.Windows.Forms.NumericUpDown();
            this.labelCountingScheme = new System.Windows.Forms.Label();
            this.comboBoxCountingScheme = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsumerId)).BeginInit();
            this.SuspendLayout();
            // 
            // labelConsumerTitle
            // 
            this.labelConsumerTitle.AutoSize = true;
            this.labelConsumerTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConsumerTitle.Location = new System.Drawing.Point(12, 20);
            this.labelConsumerTitle.Name = "labelConsumerTitle";
            this.labelConsumerTitle.Size = new System.Drawing.Size(272, 39);
            this.labelConsumerTitle.TabIndex = 0;
            this.labelConsumerTitle.Text = "Потребитель №";
            // 
            // labelConsumerId
            // 
            this.labelConsumerId.AutoSize = true;
            this.labelConsumerId.Location = new System.Drawing.Point(16, 80);
            this.labelConsumerId.Name = "labelConsumerId";
            this.labelConsumerId.Size = new System.Drawing.Size(204, 17);
            this.labelConsumerId.TabIndex = 1;
            this.labelConsumerId.Text = "Идентификатор потребителя";
            // 
            // numericUpDownConsumerId
            // 
            this.numericUpDownConsumerId.Location = new System.Drawing.Point(246, 78);
            this.numericUpDownConsumerId.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownConsumerId.Name = "numericUpDownConsumerId";
            this.numericUpDownConsumerId.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownConsumerId.TabIndex = 2;
            // 
            // labelCountingScheme
            // 
            this.labelCountingScheme.AutoSize = true;
            this.labelCountingScheme.Location = new System.Drawing.Point(83, 115);
            this.labelCountingScheme.Name = "labelCountingScheme";
            this.labelCountingScheme.Size = new System.Drawing.Size(137, 17);
            this.labelCountingScheme.TabIndex = 3;
            this.labelCountingScheme.Text = "Номер схемы учета";
            // 
            // comboBoxCountingScheme
            // 
            this.comboBoxCountingScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountingScheme.FormattingEnabled = true;
            this.comboBoxCountingScheme.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxCountingScheme.Location = new System.Drawing.Point(246, 115);
            this.comboBoxCountingScheme.Name = "comboBoxCountingScheme";
            this.comboBoxCountingScheme.Size = new System.Drawing.Size(120, 24);
            this.comboBoxCountingScheme.TabIndex = 4;
            // 
            // ConsumerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxCountingScheme);
            this.Controls.Add(this.labelCountingScheme);
            this.Controls.Add(this.numericUpDownConsumerId);
            this.Controls.Add(this.labelConsumerId);
            this.Controls.Add(this.labelConsumerTitle);
            this.Name = "ConsumerForm";
            this.Text = "ConsumerForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsumerId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConsumerTitle;
        private System.Windows.Forms.Label labelConsumerId;
        private System.Windows.Forms.NumericUpDown numericUpDownConsumerId;
        private System.Windows.Forms.Label labelCountingScheme;
        private System.Windows.Forms.ComboBox comboBoxCountingScheme;
    }
}