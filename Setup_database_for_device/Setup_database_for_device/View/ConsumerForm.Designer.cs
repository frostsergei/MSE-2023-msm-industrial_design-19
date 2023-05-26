
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsumerForm));
            this.labelConsumerTitle = new System.Windows.Forms.Label();
            this.labelConsumerId = new System.Windows.Forms.Label();
            this.numericUpDownConsumerId = new System.Windows.Forms.NumericUpDown();
            this.labelCountingScheme = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.schemeNumberControl = new Setup_database_for_device.View.SchemeNumberControl();
            this.OkButtonContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsumerId)).BeginInit();
            this.SuspendLayout();
            // 
            // labelConsumerTitle
            // 
            this.labelConsumerTitle.AutoSize = true;
            this.labelConsumerTitle.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConsumerTitle.Location = new System.Drawing.Point(14, 22);
            this.labelConsumerTitle.Name = "labelConsumerTitle";
            this.labelConsumerTitle.Size = new System.Drawing.Size(193, 26);
            this.labelConsumerTitle.TabIndex = 0;
            this.labelConsumerTitle.Text = "Потребитель №";
            // 
            // labelConsumerId
            // 
            this.labelConsumerId.AutoSize = true;
            this.labelConsumerId.Location = new System.Drawing.Point(18, 62);
            this.labelConsumerId.Name = "labelConsumerId";
            this.labelConsumerId.Size = new System.Drawing.Size(229, 18);
            this.labelConsumerId.TabIndex = 1;
            this.labelConsumerId.Text = "Идентификатор потребителя";
            // 
            // numericUpDownConsumerId
            // 
            this.numericUpDownConsumerId.Location = new System.Drawing.Point(277, 60);
            this.numericUpDownConsumerId.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownConsumerId.Name = "numericUpDownConsumerId";
            this.numericUpDownConsumerId.Size = new System.Drawing.Size(135, 26);
            this.numericUpDownConsumerId.TabIndex = 2;
            // 
            // labelCountingScheme
            // 
            this.labelCountingScheme.AutoSize = true;
            this.labelCountingScheme.Location = new System.Drawing.Point(18, 99);
            this.labelCountingScheme.Name = "labelCountingScheme";
            this.labelCountingScheme.Size = new System.Drawing.Size(158, 18);
            this.labelCountingScheme.TabIndex = 3;
            this.labelCountingScheme.Text = "Номер схемы учета";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "scheme_0.jpg");
            this.imageList.Images.SetKeyName(1, "scheme_1.jpg");
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(21, 131);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(582, 127);
            this.elementHost1.TabIndex = 5;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.schemeNumberControl;
            // 
            // OkButtonContainer
            // 
            this.OkButtonContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButtonContainer.Location = new System.Drawing.Point(52, 580);
            this.OkButtonContainer.Name = "OkButtonContainer";
            this.OkButtonContainer.Size = new System.Drawing.Size(799, 50);
            this.OkButtonContainer.TabIndex = 6;
            // 
            // ConsumerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 632);
            this.Controls.Add(this.OkButtonContainer);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.labelCountingScheme);
            this.Controls.Add(this.numericUpDownConsumerId);
            this.Controls.Add(this.labelConsumerId);
            this.Controls.Add(this.labelConsumerTitle);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ConsumerForm";
            this.Text = "ConsumerForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsumerId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConsumerTitle;
        private System.Windows.Forms.Label labelConsumerId;
        private System.Windows.Forms.Label labelCountingScheme;
        private System.Windows.Forms.ImageList imageList;
        public System.Windows.Forms.NumericUpDown numericUpDownConsumerId;
        public System.Windows.Forms.Integration.ElementHost elementHost1;
        public SchemeNumberControl schemeNumberControl;
        private System.Windows.Forms.Panel OkButtonContainer;
    }
}