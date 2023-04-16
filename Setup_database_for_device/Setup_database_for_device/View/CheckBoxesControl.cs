using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup_database_for_device.View
{
    public partial class CheckBoxesControl : Control
    {
        public List<CheckBox> CheckBoxesList;
        private Label binaryString;
        private int checkboxesAmount = 16;
        private string type = "т";

        public int CheckboxesAmount
        {
            get => checkboxesAmount;
            set
            {
                checkboxesAmount = value;
                Invalidate();
            }
        }
        public string Type
        {
            get => type;
            set
            {
                type = value;
                Invalidate();
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(445, 120);
            }
        }

        public CheckBoxesControl()
        {
            InitializeComponent();
            CheckBoxesList = new List<CheckBox>();
            int curX = 10;
            int curY = 10;
            for (int i = 0; i < 16; i++)
            {
                if (i == 8)
                {
                    curX = 10;
                    curY += 40;
                }

                CheckBox checkBox = new CheckBox
                {
                    Width = 20,
                    Location = new Point(curX, curY)
                };

                curX += 60;

                CheckBoxesList.Add(checkBox);
            }
            binaryString = new Label
            {
                Width = 200,
                BackColor = Color.LightGray,
                Font = new Font("Tahoma", 10),
                TextAlign = ContentAlignment.MiddleCenter
            };

        }

        public string GetBinaryString()
        {
            return binaryString.Text;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            int curX = 10;
            int curY = 10;

            binaryString.Text = "";
            for (int i = 0; i < checkboxesAmount; i++)
                binaryString.Text += "0";

            for (int i = 0; i < checkboxesAmount; i++)
            {
                if (i == 8)
                {
                    curX = 10;
                    curY += 40;
                }

                Label label = new Label();
                label.Width = 40;
                label.Text = type + (i + 1).ToString();

                curX += 20;
                label.Location = new Point(curX, curY + 5);
                curX += 40;

                this.Controls.Add(CheckBoxesList[i]);
                this.Controls.Add(label);

                CheckBoxesList[i].CheckedChanged += (s, ea) => {
                    string temp = "";
                    for (int j = 0; j < checkboxesAmount; j++)
                        temp += CheckBoxesList[j].Checked ? '1' : '0';

                    binaryString.Text = temp;

                    binaryString.Update();
                };
            }

            binaryString.Location = new Point(150, 100);
            this.Controls.Add(binaryString); //закомментировать если не нужно показывать бинарную строку в интерфейсе

            base.OnPaint(pe);
        }
    }
}
