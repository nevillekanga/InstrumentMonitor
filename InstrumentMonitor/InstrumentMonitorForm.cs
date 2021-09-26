using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InstrumentMonitor.CommonLibrary;
using InstrumentMonitor.SimulationEngine;

namespace InstrumentMonitor
{
    public partial class InstrumentMonitorForm : Form
    {
        private readonly SimulationEngine.SimulationEngine _simulationEngine;
        private readonly BindingList<Instrument> _subscribedInstruments = new();

        public InstrumentMonitorForm(SimulationEngine.SimulationEngine simulationEngine)
        {
            InitializeComponent();

            _simulationEngine = simulationEngine;
            _simulationEngine.InstrumentsUpdated += SimulationEngine_InstrumentsUpdated;
            _simulationEngine.EngineStarted += SimulationEngine_EngineStarted;
            _simulationEngine.EngineStopped += SimulationEngine_EngineStopped;

            UpdateEngineStatusMessage(_simulationEngine.IsRunning);

            if (_simulationEngine.IsRunning)
                UpdateInstrumentList(_simulationEngine.GetInstruments());

            dataGridViewPrices.DataSource = _subscribedInstruments;
            lblLastUpdate.Text = string.Empty;
        }

        private void SimulationEngine_InstrumentsUpdated(object sender, ICollection<Instrument> e)
        {
            UpdateInstrumentList(e);
        }

        private void UpdateInstrumentList(ICollection<Instrument> instruments)
        {
            checkBoxSubscribeAll.Checked = false;
            panelInstruments.Controls.Clear();

            List<Instrument> instrumentList = new(instruments);
            instrumentList.Sort();

            instrumentList.ForEach(instrument =>
            {
                CheckBox checkBox = new()
                {
                    AutoSize = true,
                    Text = instrument.Ticker,
                    Tag = instrument
                };

                checkBox.Font = new Font(checkBox.Font, FontStyle.Regular);
                checkBox.CheckedChanged += CheckBoxInstrument_CheckedChanged;
                checkBox.Click += CheckBoxInstrument_Click;
                panelInstruments.Controls.Add(checkBox);
            });
        }


        private void CheckBoxInstrument_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                if (checkBox.Checked)
                {
                    Instrument instrument = checkBox.Tag as Instrument;
                    _simulationEngine.Subscribe(instrument, PriceChanged);
                    _subscribedInstruments.Add(instrument);
                }
                else
                {
                    Instrument instrument = checkBox.Tag as Instrument;
                    _simulationEngine.Unsubscribe(instrument, PriceChanged);
                    _subscribedInstruments.Remove(instrument);
                }
            }
        }

        private void CheckBoxInstrument_Click(object sender, EventArgs e)
        {
            checkBoxSubscribeAll.CheckState = CheckState.Indeterminate;

            foreach (Control control in panelInstruments.Controls)
            {
                CheckBox checkBox = control as CheckBox;

                if (checkBoxSubscribeAll.CheckState != CheckState.Indeterminate && checkBoxSubscribeAll.CheckState != checkBox.CheckState)
                {
                    checkBoxSubscribeAll.CheckState = CheckState.Indeterminate;
                    return;
                }
                else
                {
                    checkBoxSubscribeAll.CheckState = checkBox.CheckState;
                }
            }
        }

        private void CheckBoxSubscribeAll_Click(object sender, EventArgs e)
        {
            foreach (Control control in panelInstruments.Controls)
            {
                CheckBox checkBox = control as CheckBox;
                checkBox.Checked = checkBoxSubscribeAll.Checked;
            }
        }

        private void SimulationEngine_EngineStarted(object sender, EventArgs e)
        {
            _subscribedInstruments.Clear();

            foreach (Control control in panelInstruments.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    Instrument instrument = checkBox.Tag as Instrument;
                    _simulationEngine.Subscribe(instrument, PriceChanged);
                    _subscribedInstruments.Add(instrument);
                }
            }

            UpdateEngineStatusMessage(true);
        }

        private void SimulationEngine_EngineStopped(object sender, EventArgs e)
        {
            foreach (Instrument instrument in _subscribedInstruments)
                _simulationEngine.Unsubscribe(instrument, PriceChanged);

            UpdateEngineStatusMessage(false);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            foreach (Instrument instrument in _subscribedInstruments)
                _simulationEngine.Unsubscribe(instrument, PriceChanged);

            base.OnFormClosed(e);
        }

        private void UpdateEngineStatusMessage(bool isRunning)
        {
            lblEngineStatus.Text = isRunning ? "Engine: RUNNING" : "Engine: STOPPED";
        }

        private void PriceChanged(Instrument instrument)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Instrument>(PriceChanged), instrument);
                return;
            }

            Instrument matchingInstrument = _subscribedInstruments.FirstOrDefault(i => i.Equals(instrument));
            if (matchingInstrument != null)
            {
                matchingInstrument.Price = instrument.Price;
                dataGridViewPrices.ClearSelection();
                var matchingRow = dataGridViewPrices.Rows[_subscribedInstruments.IndexOf(matchingInstrument)];
                matchingRow.Cells["ISIN"].Selected = true;
                dataGridViewPrices.InvalidateCell(matchingRow.Cells["Price"]);
                lblLastUpdate.Text = "Last Update: " + matchingInstrument.Ticker + " - " + matchingInstrument.Price.ToString();
            }
        }
    }
}
