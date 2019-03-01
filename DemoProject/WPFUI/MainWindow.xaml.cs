using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool microwave { get; set; }
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

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (recipearray.Contains("Tomaat") && recipearray.Contains("Vlees") && recipearray.Contains("Spaghetti") && recipearray.Contains("Ui") && recipearray.Contains("Knoflook"))
            {
                Combo1.Items.Add("Pasta Bolognese");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            switch (microwave)
            {
                case true:
                    //MicroWaveImage.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\ingrediënten\microwave_closed.png"));
                    microwave = false;
                    break;
                case false:
                    //MicroWaveImage.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\ingrediënten\microwave_opened.png"));
                    microwave = true;
                    break;
            }
        }

        private void Button_AnswerClick(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Name.ToString();

            switch (content)
            {
                case "Button1":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Bacon";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\bacon.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Bacon";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\bacon.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Bacon";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\bacon.png"));

                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Bacon";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\bacon.png"));

                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Bacon";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\bacon.png"));

                    }
                    break;

                case "Button2":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Vlees";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\vlees.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Vlees";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\vlees.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Vlees";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\vlees.png"));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Vlees";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\vlees.png"));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Vlees";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\vlees.png"));

                    }
                    break;

                case "Button3":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Kip";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\kip.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Kip";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\kip.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Kip";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\kip.png"));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Kip";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\kip.png"));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Kip";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\kip.png"));

                    }
                    break;

                case "Button4":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Macaroni";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\macaroni.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Macaroni";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\macaroni.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Macaroni";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\macaroni.png"));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Macaroni";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\macaroni.png"));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Macaroni";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\macaroni.png"));

                    }
                    break;

                case "Button5":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Spaghetti";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\spaghetti.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Spaghetti";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\spaghetti.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Spaghetti";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\spaghetti.png"));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Spaghetti";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\spaghetti.png"));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Spaghetti";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\spaghetti.png"));

                    }
                    break;

                case "Button6":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Broccoli";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\brocoli.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Broccoli";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\brocoli.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Broccoli";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\brocoli.png"));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Broccoli";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\brocoli.png"));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Broccoli";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\brocoli.png"));

                    }
                    break;

                case "Button7":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Ui";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\ui.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Ui";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\ui.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Ui";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\ui.png"));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Ui";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\ui.png"));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Ui";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\ui.png"));

                    }
                    break;

                case "Button8":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Knoflook";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\knoflook.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Knoflook";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\knoflook.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Knoflook";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\knoflook.png"));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Knoflook";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\knoflook.png"));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Knoflook";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\knoflook.png"));

                    }
                    break;

                case "Button9":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Tomaat";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\tomaten.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Tomaat";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\tomaten.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Tomaat";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\tomaten.png"));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Tomaat";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\tomaten.png"));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Tomaat";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\tomaten.png"));
                    }
                    break;

                case "Button10":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Paprika";
                        recipe1.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\paprika.png"));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Paprika";
                        recipe2.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\paprika.png"));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Paprika";
                        recipe3.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\paprika.png"));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Paprika";
                        recipe4.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\paprika.png"));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Paprika";
                        recipe5.Source = new BitmapImage(new Uri(@"C:\Users\Reggie\Desktop\school\Programmeren\C#\Les 2\Ingrediënten\paprika.png"));
                    }
                    break;
            }
        }
    }
}
