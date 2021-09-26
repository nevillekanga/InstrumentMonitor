using System;
using System.Security.Cryptography;

namespace InstrumentMonitor.CommonLibrary
{
    public class Instrument : IComparable<Instrument>, IDisposable
    {
        private readonly string _isin;
        private readonly string _ticker;
        private decimal _price;
        private readonly RandomNumberGenerator _rng;
        private bool _disposed;

        public string ISIN => _isin;
        public string Ticker => _ticker;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public event EventHandler<decimal> PriceChanged;

        public Instrument(string isin, string ticker, decimal initialPrice)
        {
            _isin = isin;
            _ticker = ticker;
            _price = initialPrice;
            _rng = RandomNumberGenerator.Create();
        }

        // Assumes that the combination of ISIN and Ticker uniquely identify the instrument.
        public override bool Equals(object obj)
        {
            return obj is Instrument instrument && instrument.ISIN == ISIN && instrument.Ticker == Ticker;
        }

        public static bool operator ==(Instrument a, Instrument b)
        {
            if (object.ReferenceEquals(a, b))
                return true;

            return !(a is null) && a.Equals(b);
        }

        public static bool operator !=(Instrument a, Instrument b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            // Based on Jon Skeet's solution: https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-overriding-gethashcode
            unchecked
            {
                int hash = (int)2166136261;
                hash = _isin is null ? hash : (hash * 16777619) ^ _isin.GetHashCode();
                hash = _ticker is null ? hash : (hash * 16777619) ^ _ticker.GetHashCode();
                return hash;
            }
        }

        public int CompareTo(Instrument other)
        {
            int retVal = _ticker.CompareTo(other.Ticker);
            return retVal == 0 ? _isin.CompareTo(other.ISIN) : retVal;
        }

        public void SimulateTrade()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);

            byte[] ba = new byte[2];
            _rng.GetBytes(ba);

            if (ba[0] <= 160)
                return; // Trade is at current price

            decimal priceDelta;
            if (ba[0] <= 200)
                priceDelta = 0.01M; // Trade is $0.01 away from previous price
            else if (ba[0] <= 225)
                priceDelta = 0.02M;
            else if (ba[0] <= 240)
                priceDelta = 0.03M;
            else if (ba[0] <= 250)
                priceDelta = 0.04M;
            else
                priceDelta = 0.05M;

            if (ba[1] < 128)
                priceDelta *= -1; // Determines if new price is higher or lower than previous price

            _price += priceDelta; // Adjust the price to reflect the new trade

            if (priceDelta != 0)
                OnPriceChanged();
        }

        protected virtual void OnPriceChanged()
        {
            PriceChanged?.Invoke(this, Price);
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
                if (_rng != null)
                    _rng.Dispose();
            }

            _disposed = true;
        }
    }
}
