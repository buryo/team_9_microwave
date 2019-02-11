using System;
using System.Collections.Generic;
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
        private bool microwave = true;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private List<String> _recipe = new List<String>();
        public String recipe;
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            _recipe.Add("Lasagna");
            _recipe.Add("Lady gaga");
            _recipe.Add("mac and cheese");
            _recipe.Add("Cake");
            _recipe.Add("Chicken");

            foreach (string line in _recipe)
            {
              Combo1.Items.Add(line);
            }

             recipe = Combo1.SelectedValue.ToString();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //timer.Text += dispatcherTimer.Interval.Seconds.ToString();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            switch (microwave)
            {
                case true:
                    MicroWaveImage.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\microwave_closed.png"));
                    microwave = false;
                    break;
                case false:
                    MicroWaveImage.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\microwave_opened.png"));
                    microwave = true;
                    break;
            }
        }
    }
}
