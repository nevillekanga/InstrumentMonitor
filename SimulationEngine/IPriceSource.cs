using System;
using System.Collections.Generic;
using System.Text;

using InstrumentMonitor.CommonLibrary;

namespace InstrumentMonitor.SimulationEngine
{
    public interface IPriceSource
    {
        public string Identifier { get; }
        public bool IsRunning { get; }
        public ICollection<Instrument> GetInstruments();
        public void Start();
        public void Stop();
        public void Subscribe(Instrument instrument, Action<Instrument> callback);
        public void Unsubscribe(Instrument instrument, Action<Instrument> callback);
    }
}
