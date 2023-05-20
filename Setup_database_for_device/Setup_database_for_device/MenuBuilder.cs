using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup_database_for_device
{
    public class MenuBuilder
    {
        private View.ContentMenu _menu;

        public MenuBuilder(View.ContentMenu menu)
        {
            _menu = menu;
        }

        public void AddNewItemInMenu(object sender, EventsArgs.MenuEventArgs args)
        {
            _menu.AddDeepButtonsByButtonsNumbers(args.ButtonName, args.ButtonsNumbers);
        }

    }
}
