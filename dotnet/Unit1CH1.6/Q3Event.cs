#if false
using System;

namespace Unit1CH1._6
{
    // Declare a delegate
    public delegate void ButtonClickHandler(object sender, EventArgs e);

    class Button
    {
        // Declare an event using the delegate
        public event ButtonClickHandler OnClick;

        public void Click()
        {
            Console.WriteLine("Button is clicked...");
            // Raise the event
            OnClick?.Invoke(this, EventArgs.Empty);
        }
    }

    class Form
    {
        public void OnButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine("Form handled the button click event.");
        }
    }

    internal class EventDemo
    {
        /*
        static void Main(string[] args)
        {
            Button btn = new Button();
            Form form = new Form();

            // Subscribe to the event
            btn.OnClick += form.OnButtonClick;

            // Simulate button click
            btn.Click();
        }
        */
    }
}

#endif

