﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup_database_for_device.Controller
{
    public class CoolantController : Controller
    {
        private View.CoolantSelectionForm _view;

        private Model.Model _model;

        private Model.Pipeline _pipelineModel;

        public CoolantController(View.CoolantSelectionForm view, Model.Model model, int index)
        {
            _view = view;
            _model = model;
            _pipelineModel = model.GetPipelineByInd(index);
        }
        public override void SaveDataToModel()
        {
            Dictionary<string, string> currentData = _view.GetCoolantWindowData();

            foreach (KeyValuePair<string, string> paramValuePair in currentData)
            {
                if (paramValuePair.Value != "")
                {
                    _pipelineModel.ChangeParameterValue(paramValuePair.Key, paramValuePair.Value);
                }
            }
        }
    }
}
