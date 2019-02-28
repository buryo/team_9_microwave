using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool MicrowaveStatus;       
        public bool DoorOpen { get; set; }
        private bool microwave = true;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private List<String> _recipe = new List<String>();
        public String[] recipearray = new String[5];
        public List<String> recipes = new List<String>();

        public MainWindow()
        {

            InitializeComponent();
            //Timer
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            


        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            MicrowaveTimer.Instance.CountDown();
            TBCountdown.Content = string.Format("{0}:{1}", MicrowaveTimer.Instance.Minute.ToString().PadLeft(2, '0'), MicrowaveTimer.Instance.Second.ToString().PadLeft(2, '0'));
        }

        private void StartButton_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (MicrowaveStatus || (MicrowaveTimer.Instance.Minute == 0 && MicrowaveTimer.Instance.Second == 0))
            {
                MicrowaveTimer.Instance.AddSeconds(30);
            }

            if (!DoorOpen)
            {
                MicrowaveStatus = true;
                dispatcherTimer.Start();
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-dicht-aan.jpg"));
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (!MicrowaveStatus)
            {
                MicrowaveTimer.Instance.CounterReset();
                TBCountdown.Content = "00:00";
            }

            MicrowaveStatus = false;
            dispatcherTimer.Stop();
            
            if (DoorOpen == false)
            {
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-dicht-uit.jpg"));
            }
        }

        private void DoorHandle_Click(object sender, RoutedEventArgs e)
        {
            DoorOpen = true;
        
            if (DoorOpen)
            {
                dispatcherTimer.Stop();
                MicrowaveStatus = false;
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-open-aan.jpg"));
            }
        }

        private void CloseDoorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DoorOpen = false;
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-dicht-uit.jpg"));
            }
            catch (Exception exception)
            {
                throw new Exception("Door closing failed");
            }
        }
    }
}
