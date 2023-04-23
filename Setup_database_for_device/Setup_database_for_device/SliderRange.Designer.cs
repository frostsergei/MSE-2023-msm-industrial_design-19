
namespace Setup_database_for_device
{
    partial class SliderRange
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.low_Limit = new System.Windows.Forms.TextBox();
            this.high_Limit = new System.Windows.Forms.TextBox();
            this.lowSlider = new System.Windows.Forms.TrackBar();
            this.UpperSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.lowSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(45, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(725, 108);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Введите нижний и верхний диапазон измерений по паспорту прибора. Нижний предел ди" +
    "апазона измерений должен соответствовать настройкам выхода расходомера";
            // 
            // low_Limit
            // 
            this.low_Limit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.low_Limit.Location = new System.Drawing.Point(45, 239);
            this.low_Limit.Name = "low_Limit";
            this.low_Limit.Size = new System.Drawing.Size(148, 31);
            this.low_Limit.TabIndex = 1;
            this.low_Limit.Text = "0";
            this.low_Limit.TextChanged += new System.EventHandler(this.low_Limit_TextChanged);
            this.low_Limit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.low_Limit_KeyPress);
            // 
            // high_Limit
            // 
            this.high_Limit.Location = new System.Drawing.Point(545, 238);
            this.high_Limit.Name = "high_Limit";
            this.high_Limit.Size = new System.Drawing.Size(148, 31);
            this.high_Limit.TabIndex = 2;
            this.high_Limit.Text = "763";
            this.high_Limit.TextChanged += new System.EventHandler(this.high_Limit_TextChanged);
            this.high_Limit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.high_Limit_KeyPress);
            //
            // lowSlider
            // 
            this.lowSlider.Location = new System.Drawing.Point(45, 143);
            this.lowSlider.Maximum = 400;
            this.lowSlider.Name = "lowSlider";
            this.lowSlider.Size = new System.Drawing.Size(361, 90);
            this.lowSlider.TabIndex = 3;
            this.lowSlider.Scroll += new System.EventHandler(this.lowSlider_Scroll);
            // 
            // UpperSlider
            // 
            this.UpperSlider.LargeChange = 1;
            this.UpperSlider.Location = new System.Drawing.Point(392, 143);
            this.UpperSlider.Maximum = 763;
            this.UpperSlider.Minimum = 401;
            this.UpperSlider.Name = "UpperSlider";
            this.UpperSlider.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UpperSlider.Size = new System.Drawing.Size(378, 90);
            this.UpperSlider.TabIndex = 4;
            this.UpperSlider.Value = 763;
            this.UpperSlider.Scroll += new System.EventHandler(this.UpperSlider_Scroll);
            // 
            // SliderRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1208, 718);
            this.Controls.Add(this.lowSlider);
            this.Controls.Add(this.high_Limit);
            this.Controls.Add(this.low_Limit);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.UpperSlider);
            this.Name = "SliderRange";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lowSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpperSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox low_Limit;
        private System.Windows.Forms.TextBox high_Limit;
        public float lowest_input = 0;//from model
        public float highest_input = 763;//from model
        private System.Windows.Forms.TrackBar lowSlider;
        private System.Windows.Forms.TrackBar UpperSlider;
    }
}

