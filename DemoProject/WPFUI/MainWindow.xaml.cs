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

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool LampOn { get; set; }
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
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

        }

        private void StartButton_Click_1(object sender, RoutedEventArgs e)
        {
            LampOn = true;
            if ((LampOn) && DoorOpen == false)
            {
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-dicht-aan.jpg"));
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            LampOn = false;
            if ((LampOn == false) && (DoorOpen == false))
            {
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-dicht-uit.jpg"));
            }
        }

        private void DoorHandle_Click(object sender, RoutedEventArgs e)
        {
            DoorOpen = true;
            LampOn = true;
            if (DoorOpen && LampOn)
            {
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-open-aan.jpg"));
            }
        }

        private void CloseDoorButton_Click(object sender, RoutedEventArgs e)
        {
            DoorOpen = true;
            LampOn = false;
            if (DoorOpen && (LampOn == false))
            {
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-dicht-uit.jpg"));
            }

            DoorOpen = false;
        }
    }
}
