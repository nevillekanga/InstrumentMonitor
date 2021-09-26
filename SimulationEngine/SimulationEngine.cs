using InstrumentMonitor.CommonLibrary;

using System;
using System.Collections.Generic;

namespace InstrumentMonitor.SimulationEngine
{
    public class SimulationEngine : IPriceSource, IDisposable
    {
        public event EventHandler<ICollection<Instrument>> InstrumentsUpdated;
        public event EventHandler EngineStarted;
        public event EventHandler EngineStopped;

        private readonly List<IPriceSource> _availablePriceSources = new List<IPriceSource>();
        private readonly List<IPriceSource> _selectedPriceSources = new List<IPriceSource>();
        private readonly Dictionary<Instrument, List<IPriceSource>> _instruments = new Dictionary<Instrument, List<IPriceSource>>();
        private bool _disposed;

        public string Identifier => _selectedPriceSources.Count == 1 ? _selectedPriceSources[0].Identifier : string.Empty;
        public bool IsRunning => _selectedPriceSources.Find(ps => { return ps.IsRunning; }) != null;

        public SimulationEngine()
        {
            SetupPriceSources();
        }

        private void SetupPriceSources()
        {
            List<Instrument> instruments1 = new List<Instrument>()
            {
                new Instrument("US45866F1049", "ICE", 119.74M),
                new Instrument("US0231351067", "AMZN", 3425.52M),
                new Instrument("US5949181045", "MSFT", 299.35M),
                new Instrument("US4592001014", "IBM", 137.49M),
                new Instrument("US4581401001", "INTC", 54.22M),
                new Instrument("US0079031078", "AMD", 105.80M),
                new Instrument("US38141G1040", "GS", 390.85M),
                new Instrument("US1729674242", "C", 71.18M),
                new Instrument("US46625H1005", "JPM", 163.04M),
                new Instrument("US0605051046", "BAC", 42.14M)
            };

            List<Instrument> instruments2 = new List<Instrument>()
            {
                new Instrument("US45866F1049", "ICE", 119.74M),
                new Instrument("US0231351067", "AMZN", 3425.52M),
                new Instrument("US5949181045", "MSFT", 299.35M),
                new Instrument("US4592001014", "IBM", 137.49M),
                new Instrument("US4581401001", "INTC", 54.22M),
                new Instrument("US00206R1023", "T", 27.13M),
                new Instrument("US92343V1044", "VZ", 54.37M),
                new Instrument("US5801351017", "MCD", 246.42M),
                new Instrument("US1912161007", "KO", 53.89M),
                new Instrument("US7134481081", "PEP", 154.20M)
            };

            _availablePriceSources.Add(new PriceSource("Price Source 1 (ICE, AMZN, MSFT, IBM, INTC, AMD, GS, C, JPM, BAC)", instruments1));
            _availablePriceSources.Add(new PriceSource("Price Source 2 (ICE, AMZN, MSFT, IBM, INTC, T, VZ, MCD, KO, PEP)", instruments2));
        }

        public ICollection<string> GetAvailablePriceSourceIdentifiers()
        {
            if (_disposed)
                throw new ObjectDisposedException("SimulationEngine");

            List<string> identifiers = new List<string>();
            _availablePriceSources.ForEach(ps => { identifiers.Add(ps.Identifier); });
            return identifiers;
        }

        public ICollection<Instrument> GetInstruments()
        {
            if (_disposed)
                throw new ObjectDisposedException("SimulationEngine");

            return new List<Instrument>(_instruments.Keys);
        }

        public void SelectPriceSources(ICollection<string> priceSources)
        {
            if (_disposed)
                throw new ObjectDisposedException("SimulationEngine");

            // Assumes that it's not a requirement for price sources to be added / removed while the engine is running.
            if (IsRunning)
                return;

            _selectedPriceSources.Clear();

            _availablePriceSources.ForEach(ps =>
            {
                if (priceSources.Contains(ps.Identifier))
                    _selectedPriceSources.Add(ps);;
            });

            BuildInstrumentRepository();
        }

        private void BuildInstrumentRepository()
        {
            _instruments.Clear();

            _selectedPriceSources.ForEach(ps =>
            {
                foreach (Instrument instrument in ps.GetInstruments())
                {
                    if (!(_instruments.ContainsKey(instrument)))
                        _instruments[instrument] = new List<IPriceSource>();

                    _instruments[instrument].Add(ps);
                }
            });

            OnInstrumentsUpdated();
        }

        private void OnInstrumentsUpdated()
        {
            InstrumentsUpdated?.Invoke(this, GetInstruments());
        }

        public void Start()
        {
            if (_disposed)
                throw new ObjectDisposedException("SimulationEngine");

            if (!IsRunning && _selectedPriceSources.Count > 0)
            {
                _selectedPriceSources.ForEach(ps => { ps.Start(); });
                OnEngineStarted();
            }
        }

        private void OnEngineStarted()
        {
            EngineStarted?.Invoke(this, new EventArgs());
        }

        public void Stop()
        {
            if (_disposed)
                throw new ObjectDisposedException("SimulationEngine");

            if (IsRunning)
            {
                _selectedPriceSources.ForEach(ps => { ps.Stop(); });
                OnEngineStopped();
            }
        }

        private void OnEngineStopped()
        {
            EngineStopped?.Invoke(this, new EventArgs());
        }

        public void Subscribe(Instrument instrument, Action<Instrument> callback)
        {
            if (_disposed)
                throw new ObjectDisposedException("SimulationEngine");

            if (!IsRunning || !_instruments.ContainsKey(instrument))
                return;

            _instruments[instrument].ForEach(ps => { ps.Subscribe(instrument, callback); });
        }

        public void Unsubscribe(Instrument instrument, Action<Instrument> callback)
        {
            if (_disposed)
                throw new ObjectDisposedException("SimulationEngine");

            if (!_instruments.ContainsKey(instrument))
                return;

            _instruments[instrument].ForEach(ps => { ps.Unsubscribe(instrument, callback); });
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _availablePriceSources.ForEach(ps =>
                {
                    if (ps is PriceSource priceSource)
                    {
                        foreach (Instrument instrument in priceSource.GetInstruments())
                            instrument.Dispose();

                        priceSource.Dispose();
                    }
                });
            }

            _disposed = true;
        }
    }
}
