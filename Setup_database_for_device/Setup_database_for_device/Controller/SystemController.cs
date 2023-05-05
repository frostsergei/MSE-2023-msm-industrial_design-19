using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup_database_for_device.Controller
{
    public class SystemController : Controller
    {

        private View.SystemForm.SystemForm _view;
        private Model.SystemWideSettings _systemModel;

        public SystemController(View.SystemForm.SystemForm view, Model.Model model)
        {
            _view = view;
            _systemModel = model.SystemWideSettings;

        }

        public override void SaveDataToModel()
        {
            Dictionary<string, string> currentData = _view.GetSystemWindowData();

            foreach (KeyValuePair<string, string> paramValuePair in currentData)
            {
                _systemModel.ChangeParameterValue(paramValuePair.Key, paramValuePair.Value);  
            }
        }

    }
}
