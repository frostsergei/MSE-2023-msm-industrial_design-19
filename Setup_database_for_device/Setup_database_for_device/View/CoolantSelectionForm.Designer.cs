
namespace Setup_database_for_device.View
{
    partial class CoolantSelectionForm
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
            this.CoolantSelectionBlock = new System.Windows.Forms.Integration.ElementHost();
            this.coolantSelectionWPF1 = new Setup_database_for_device.View.CoolantSelectionWPF();
            this.SuspendLayout();
            // 
            // CoolantSelectionBlock
            // 
            this.CoolantSelectionBlock.Location = new System.Drawing.Point(13, 13);
            this.CoolantSelectionBlock.Name = "CoolantSelectionBlock";
            this.CoolantSelectionBlock.Size = new System.Drawing.Size(775, 425);
            this.CoolantSelectionBlock.TabIndex = 0;
            this.CoolantSelectionBlock.Text = "elementHost1";
            this.CoolantSelectionBlock.Child = this.coolantSelectionWPF1;
            // 
            // CoolantSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CoolantSelectionBlock);
            this.Name = "CoolantSelectionForm";
            this.Text = "Настройка трубопроводов. Тип теплоносителя.";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost CoolantSelectionBlock;
        private CoolantSelectionWPF coolantSelectionWPF1;
    }
}