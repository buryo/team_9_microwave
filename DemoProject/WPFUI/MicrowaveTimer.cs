namespace WPFUI
{
    public class MicrowaveTimer : MainWindow
    {
        public int Minute { get; set; }
        public int Second { get; set; }
        public static readonly MicrowaveTimer Instance = new MicrowaveTimer();

        private MicrowaveTimer() { }

        // Splitting second into minute + seconds
        public void ParseSecond()
        {
            if (Second > 60)
            {
                Minute = Second / 60;
                Second %= 60;
            }
        }

        /// <summary>
        /// Add second method
        /// </summary>
        /// <param name="seconds"></param>
        public void AddSeconds(int seconds)
        {
            // check if door is closed
            if (!DoorOpen)
            {
                // if minute is not 0, do the math
                if (Minute != 0)
                    Second += (Minute * 60);

                // adding 1 extra second because of the delay
                Second += (seconds + 1);

                ParseSecond();
            }
        }

        /// <summary>
        /// Base countdown method
        /// </summary>
        public void CountDown()
        {
            // Check if minute or second is higher than zero
            if (Minute > 0 || Second > 0)
            {
                Second--;

                // Check if second goes into negative
                if (Second < 0)
                {
                    // Check if any minutes left
                    if (Minute > 0)
                    {
                        Minute--;
                        Second = 59;
                    }
                }
            }
        }

        /// <summary>
        /// Reseting counter
        /// </summary>
        public void CounterReset()
        {
            Minute = 0;
            Second = 0;
        }
    }
}