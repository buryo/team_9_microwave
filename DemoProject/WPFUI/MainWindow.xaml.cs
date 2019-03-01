using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool MicrowaveStatus;       
        public bool DoorOpen { get; set; }
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

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var comboBox = sender as ComboBox;
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
                Combo1.Items.Add("Pasta Bolognese");
                MicrowaveRecipe.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Recepten/pasta-bolo.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void MicrowaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            MicrowaveRecipe.Source = null;
            deleteRecipe(sender, e); 
        }

        private void deleteRecipe(object sender, RoutedEventArgs e)
        { 
            MicrowaveStatus = true;
            dispatcherTimer.Start();
            this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-dicht-aan.jpg"));
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
                DoorOpen = false;
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-dicht-uit.jpg"));
        }
    }
}
