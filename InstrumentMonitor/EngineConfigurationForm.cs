using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InstrumentMonitor.SimulationEngine;

namespace InstrumentMonitor
{
    public partial class EngineConfigurationForm : Form
    {
        private readonly SimulationEngine.SimulationEngine _simulationEngine;

        public EngineConfigurationForm(SimulationEngine.SimulationEngine simulationEngine)
        {
            InitializeComponent();

            _simulationEngine = simulationEngine;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _simulationEngine.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _simulationEngine.Stop();
        }

        private void EngineConfigurationForm_Load(object sender, EventArgs e)
        {
            _simulationEngine.EngineStarted += SimulationEngine_EngineStarted;
            _simulationEngine.EngineStopped += SimulationEngine_EngineStopped;

            ICollection<string> priceSourceIdentifiers = _simulationEngine.GetAvailablePriceSourceIdentifiers();
            foreach (string identifier in priceSourceIdentifiers)
            {
                CheckBox checkBox = new()
                {
                    AutoSize = true,
                    Text = identifier
                };
                checkBox.Font = new Font(checkBox.Font, FontStyle.Regular);
                checkBox.CheckedChanged += CheckBoxPriceSource_CheckedChanged;
                panelPriceSources.Controls.Add(checkBox);
            }
        }

        private void SimulationEngine_EngineStarted(object sender, EventArgs e)
        {
            panelPriceSources.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void SimulationEngine_EngineStopped(object sender, EventArgs e)
        {
            panelPriceSources.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _simulationEngine.EngineStarted -= SimulationEngine_EngineStarted;
            _simulationEngine.EngineStopped -= SimulationEngine_EngineStopped;

            base.OnFormClosed(e);
        }

        private void CheckBoxPriceSource_CheckedChanged(object sender, EventArgs e)
        {
            List<string> priceSources = new();

            foreach (Control control in panelPriceSources.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                    priceSources.Add(checkBox.Text);
            }

            btnStart.Enabled = priceSources.Count > 0;
            if (priceSources.Count == 0)
                return;

            _simulationEngine.SelectPriceSources(priceSources);
        }
    }
}
