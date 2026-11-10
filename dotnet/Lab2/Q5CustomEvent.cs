#if false
using System;

namespace CustomEventApp
{
    public class PriceChangedEventArgs : EventArgs
    {
        public string Symbol { get; }
        public double OldPrice { get; }
        public double NewPrice { get; }
        public PriceChangedEventArgs(string symbol, double old, double New)
        {
            Symbol = symbol;
            OldPrice = old;
            NewPrice = New;
        }
    }

    class Stock
    {
        public event EventHandler<PriceChangedEventArgs> PriceChanged;
        private double _price;

        public double Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    double old = _price;
                    _price = value;
                    PriceChanged?.Invoke(this, new PriceChangedEventArgs("AAPL", old, _price));
                }
            }
        }

        public Stock(double initial) => _price = initial;
    }

    class Program
    {
        static void OnPriceChange(object s, PriceChangedEventArgs e)
            => Console.WriteLine($"{e.Symbol}: ${e.OldPrice} -> ${e.NewPrice}");

        /*
        static void Main(string[] args)
        {
            Stock s = new Stock(150);
            s.PriceChanged += OnPriceChange;
            s.Price = 155;
            s.Price = 148;
        }
        */
    }
}

#endif

