#if false
using System;

namespace Unit1CH1._6
{
    // Custom EventArgs to pass additional data
    public class TemperatureChangedEventArgs : EventArgs
    {
        public double OldTemperature { get; }
        public double NewTemperature { get; }
        public double Difference => NewTemperature - OldTemperature;

        public TemperatureChangedEventArgs(double oldTemp, double newTemp)
        {
            OldTemperature = oldTemp;
            NewTemperature = newTemp;
        }
    }

    class Thermostat
    {
        // Declare a custom event using EventHandler<T> with custom EventArgs
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        private double _temperature;

        public double Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    double oldTemp = _temperature;
                    _temperature = value;
                    // Raise custom event with custom data
                    TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(oldTemp, _temperature));
                }
            }
        }
    }

    class Display
    {
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"Temperature changed from {e.OldTemperature}°C to {e.NewTemperature}°C (Δ = {e.Difference}°C)");
        }
    }

    class Logger
    {
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"[LOG] Temperature updated: {e.OldTemperature}°C -> {e.NewTemperature}°C at {DateTime.Now:T}");
        }
    }

    internal class CustomEventDemo
    {
        /*
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();
            Display display = new Display();
            Logger logger = new Logger();

            // Subscribe to custom event
            thermostat.TemperatureChanged += display.OnTemperatureChanged;
            thermostat.TemperatureChanged += logger.OnTemperatureChanged;

            Console.WriteLine("Setting temperature values:");
            thermostat.Temperature = 22.5;
            thermostat.Temperature = 25.0;
            thermostat.Temperature = 19.8;
        }
        */
    }
}

#endif

