using InstrumentMonitor.CommonLibrary;

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace InstrumentMonitor.SimulationEngine
{
    class PriceSource : IPriceSource, IDisposable
    {
        private readonly string _identifier;
        private readonly List<Instrument> _instruments;
        private readonly Dictionary<Instrument, List<Action<Instrument>>> _callbacks = new Dictionary<Instrument, List<Action<Instrument>>>();
        private readonly RandomNumberGenerator _rng;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private Thread _simulationThread;
        private bool _disposed;

        public string Identifier => _identifier;
        public bool IsRunning => _simulationThread != null;

        public PriceSource(string identifier, ICollection<Instrument> instruments)
        {
            _identifier = identifier;
            _instruments = new List<Instrument>(instruments); // This is the full set of instruments for this PriceSource
            _rng = RandomNumberGenerator.Create();
        }

        public ICollection<Instrument> GetInstruments()
        {
            if (_disposed)
                throw new ObjectDisposedException("PriceSource");

            return _instruments;
        }

        public void Start()
        {
            if (_disposed)
                throw new ObjectDisposedException("PriceSource");

            if (_simulationThread == null)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationToken = _cancellationTokenSource.Token;

                _simulationThread = new Thread(SimulateTrading)
                {
                    Name = _identifier + ": Simulation Thread"
                };

                _simulationThread.Start();
            }
        }

        public void Stop()
        {
            if (_disposed)
                throw new ObjectDisposedException("PriceSource");

            if (_simulationThread != null)
            {
                _cancellationTokenSource.Cancel();
                _simulationThread = null;
            }
        }

        public void Subscribe(Instrument instrument, Action<Instrument> callback)
        {
            if (_disposed)
                throw new ObjectDisposedException("PriceSource");

            Instrument matchingInstrument = _instruments.Find(i => { return i.Equals(instrument); });
            if (matchingInstrument is null)
                return;

            if (!_callbacks.ContainsKey(matchingInstrument))
            {
                _callbacks[matchingInstrument] = new List<Action<Instrument>>();
                matchingInstrument.PriceChanged += Instrument_PriceChanged;
            }

            _callbacks[matchingInstrument].Add(callback);
        }

        public void Unsubscribe(Instrument instrument, Action<Instrument> callback)
        {
            if (_disposed)
                throw new ObjectDisposedException("PriceSource");

            Instrument matchingInstrument = _instruments.Find(i => { return i.Equals(instrument); });
            if (matchingInstrument is null)
                return;

            if (!_callbacks.ContainsKey(matchingInstrument))
                return;

            _callbacks[matchingInstrument].Remove(callback);

            if (_callbacks[matchingInstrument].Count == 0)
            {
                matchingInstrument.PriceChanged -= Instrument_PriceChanged;
                _callbacks.Remove(matchingInstrument);
            }
        }

        private void Instrument_PriceChanged(object sender, decimal e)
        {
            Instrument instrument = sender as Instrument;

            if (_callbacks.ContainsKey(instrument))
                _callbacks[instrument].ForEach(a => { a.Invoke(instrument); });
        }

        private void SimulateTrading()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                // Choose a random Instrument and simulate a trade
                byte[] ba = new byte[4];
                _rng.GetBytes(ba);
                int val = Math.Abs(BitConverter.ToInt32(ba, 0));
                int index = val % _instruments.Count;
                _instruments[index].SimulateTrade();
                Thread.Sleep(1);
            }
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
                if (_cancellationTokenSource != null)
                    _cancellationTokenSource.Dispose();

                if (_rng != null)
                    _rng.Dispose();
            }

            _disposed = true;
        }
    }
}
