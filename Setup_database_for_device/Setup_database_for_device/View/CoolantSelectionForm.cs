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
    public partial class CoolantSelectionForm : Form
    {
        /*Данные из WPF могут быть получены следующим образом:
         * (elementHost1.Child as CoolantSelectionWPF).coolantTypeValue - тип теплоносителя
         * (elementHost1.Child as CoolantSelectionWPF).flowMeterValue - тип расходомера
         * (elementHost1.Child as CoolantSelectionWPF).sensorTypeValue - тип датчика (возвращает индекс)
         * (elementHost1.Child as CoolantSelectionWPF).saturationWidthValue - ширина зоны насыщения
         * (elementHost1.Child as CoolantSelectionWPF).drynessValue - степень сухости
        */
        public CoolantSelectionForm()
        {
            InitializeComponent();
            elementHost1.Dock = DockStyle.Fill;
        }
    }
}
