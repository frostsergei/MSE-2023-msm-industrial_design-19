﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View
{
    public partial class CoolantSelectionForm : WindowForm
    {
        private static readonly string SensorParamName = "034н00";

        private CoolantSelectionWPF _coolantSelectionWindow;

        private PipelineSettingsLimits _pipelineSettingsLimitsForm;
        private WindowForm _previousPipelinesSettings;


        public CoolantSelectionForm(int index) : base($"Теплоноситель {index}")
        {
            InitializeComponent();

            _formIndex = index;

            ElementHost host = new ElementHost();

            _coolantSelectionWindow = new CoolantSelectionWPF();
            _coolantSelectionWindow.AddOkBackButtons(_backOkComponent);
            host.Child = _coolantSelectionWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);

        }
        public Dictionary<string, string> GetCoolantWindowData()
        {
            return coolantSelectionWPF1.GetAllCoolantSettings();
        }

        public void SetPreviousPipelineSettings(WindowForm form)
        {
            _previousPipelinesSettings = form;
        }

        public void SetNextPipelineSettings(PipelineSettingsLimits form)
        {
            _pipelineSettingsLimitsForm = form;
        }


        protected override bool IsAbleToGoToNext()
        {
            string result = coolantSelectionWPF1.GetAllCoolantSettings()[SensorParamName];
            result = result.Substring(0, result.Length - 1);
            if (result != "")
            {
                paramsToNextForm = new Dictionary<string, string>()
                {
                    { "curIndicator", result }
                };
                return true;
            }
            return false;
        }

        public override bool IsFormFilledOut()
        {
            Dictionary<string, string> pars = coolantSelectionWPF1.GetAllCoolantSettings();
            if (pars["101"] == "" || pars["102н00"] == "" || pars["034н00"] == "000")
                return false;

            if (pars["101"] == "0")
                return true;

            if (pars["101"] == "1" || pars["101"] == "2")
            {
                if (pars["104"] == "" || pars["105"] == "")
                    return false;
                return true;
            }

            if(pars["101"] == "3")
            {
                if (pars["125н00"] == "" || pars["125н01"] == "" || pars["125н02"] == "" || pars["125н03"] == "" ||
                    pars["125н04"] == "" || pars["125н05"] == "" || pars["125н06"] == "" || pars["125н07"] == "")
                    return false;
                return true;
            }
            return false;
        }
    }
}
