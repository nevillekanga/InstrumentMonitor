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
    public partial class SimulationControllerForm : Form
    {
        private readonly SimulationEngine.SimulationEngine _simulationEngine = new();
        private readonly EngineConfigurationForm _engineConfigurationForm;
        private readonly InstrumentMonitorForm _instrumentMonitorForm;
        private bool _closing;

        public SimulationControllerForm()
        {
            InitializeComponent();

            _engineConfigurationForm = new(_simulationEngine);
            _engineConfigurationForm.FormClosing += ChildForm_FormClosing;

            _instrumentMonitorForm = new(_simulationEngine);
            _instrumentMonitorForm.FormClosing += ChildForm_FormClosing;
        }

        private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_closing && sender is Form form)
            {
                form.Hide();
                e.Cancel = true;
            }
        }

        private void SimulationControllerForm_Load(object sender, EventArgs e)
        {
            tbAssumptions.Text = GetAssumptions();
        }

        private void BtnConfigureEngine_Click(object sender, EventArgs e)
        {
            _engineConfigurationForm.Show();
        }

        private void BtnShowClient_Click(object sender, EventArgs e)
        {
            _instrumentMonitorForm.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _closing = true;
            _simulationEngine.Stop();
            _engineConfigurationForm.Close();
            _instrumentMonitorForm.Close();
            _closing = false;

            base.OnFormClosing(e);
        }

        private static string GetAssumptions()
        {
            StringBuilder sb = new();
            sb.Append("SIMULATION ASSUMPTIONS");
            sb.Append(Environment.NewLine);
            sb.Append("----------------------");
            sb.Append(Environment.NewLine);
            sb.Append("1) Engine is always available (not handling connect / disconnect or client attempting to connect to unavailable engine).");
            sb.Append(Environment.NewLine);
            sb.Append("2) Engine can't add / remove price sources while running. In a real-world scenario, this would likely be done EOD.");
            sb.Append(Environment.NewLine);
            sb.Append("3) In-memory implementation allows for communication between client and engine via events. Real-world, this would be handled with a messaging solution across a network.");
            sb.Append(Environment.NewLine);
            sb.Append("4) Instruments are uniquely identified by the combination of ISIN and Ticker.");
            sb.Append(Environment.NewLine);
            sb.Append("5) For the simulation, the number of instruments is limited, and the client UI uses checkboxes for selection. In a real-world application with a large number of instruments, a more robust UI would be needed.");
            sb.Append(Environment.NewLine);
            sb.Append("6) For the simulation, a single application is used for engine configuration as well as to display the client UI. These are handled in separate windows, but they would likely be separate applications in a real-world scenario.");
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
