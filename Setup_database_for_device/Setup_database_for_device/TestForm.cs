using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device
{
    public partial class TestForm : View.WindowForm
    {
        public TestForm(string text) : base(text)
        {
            InitializeComponent();

            label1.Text = text;

            Panel inputPanel = new Panel();
            inputPanel.Controls.Add(new TextBox());

            Controls.Add(inputPanel);

            ElementHost host = new ElementHost
            {
                Child = _backOkComponent,
                Dock = DockStyle.Fill
            };
            Buttons.Controls.Add(host);

        }
    }
}
