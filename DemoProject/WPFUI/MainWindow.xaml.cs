using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
       // private List<String> _recipe = new List<String>();
        public String[] recipearray = new String[5];
        //public List<String> recipes = new List<String>();

        public MainWindow()
        {
            InitializeComponent();
            //Timer
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        //Method to pick the recipe when the selection changes
        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var comboBox = sender as ComboBox;
            //Switch statement to put the recipe in the microwave
            switch (Combo1.SelectedItem.ToString())
            {
                case "Pasta Bolognese":
                    MicrowaveRecipe.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Recepten/pasta-bolo.png", UriKind.RelativeOrAbsolute));
                    break;
                case "Chicken dish":
                    MicrowaveRecipe.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Recepten/kip.png", UriKind.RelativeOrAbsolute));
                    break;
                case "Fish dish":
                    MicrowaveRecipe.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Recepten/zee-gerecht.png", UriKind.RelativeOrAbsolute));
                    break;
                case "Steak":
                    MicrowaveRecipe.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Recepten/steak.png", UriKind.RelativeOrAbsolute));
                    break;
                case "Rice":
                    MicrowaveRecipe.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Recepten/rijst-gerecht.png", UriKind.RelativeOrAbsolute));
                    break;
                case "Macaroni":
                    MicrowaveRecipe.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Recepten/macaroni-gerecht.png", UriKind.RelativeOrAbsolute));
                    break;
                case "Wok dish":
                    MicrowaveRecipe.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Recepten/wok-gerecht.png", UriKind.RelativeOrAbsolute));
                    break;              
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //Timer for the microwave minutes and seconds
            MicrowaveTimer.Instance.CountDown();
            TBCountdown.Content = string.Format("{0}:{1}", MicrowaveTimer.Instance.Minute.ToString().PadLeft(2, '0'), MicrowaveTimer.Instance.Second.ToString().PadLeft(2, '0'));
            if (MicrowaveTimer.Instance.Second == 0 && MicrowaveTimer.Instance.Minute == 0)
            {
                DoorHandle_Click(sender, new RoutedEventArgs());
                recipeLabel.Content = "Enjoy your meal!";
            }
        }

        //Method to start the microwave
        private void StartButton_Click_1(object sender, RoutedEventArgs e)
        {
            //If the microwave door is closed or if the timer is on 0, add 30 seconds
            if (MicrowaveStatus || (MicrowaveTimer.Instance.Minute == 0 && MicrowaveTimer.Instance.Second == 0))
            {
                MicrowaveTimer.Instance.AddSeconds(30);
            }

            //Start the microwave if the door is closed
            if (!DoorOpen)
            {
                MicrowaveStatus = true;
                dispatcherTimer.Start();
                this.BackgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/WPFUI;component/Images/Microwave/micro-dicht-aan.jpg"));
            }
        }

        //Remove the recipe out of the microwave
        private void MicrowaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            MicrowaveRecipe.Source = null;
        }

        //Remove the ingredients from the list
        private void deleteRecipe(object sender, RoutedEventArgs e)
        {
            recipe1.Source = null;
            recipe2.Source = null;
            recipe3.Source = null;
            recipe4.Source = null;
            recipe5.Source = null;

            recipearray[0] = null;
            recipearray[1] = null;
            recipearray[2] = null;
            recipearray[3] = null;
            recipearray[4] = null;
        }

        //Method for stopping the microwave
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

        //
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (recipearray.Contains("Tomato") && recipearray.Contains("Meat") && recipearray.Contains("Spaghetti") && recipearray.Contains("Onion") && recipearray.Contains("Garlic"))
            {
                if (!Combo1.Items.Contains("Pasta Bolognese"))
                {
                    Combo1.Items.Add("Pasta Bolognese");
                    recipeLabel.Content = "You made some Pasta bolognese!";
                }
                
            }

            if (recipearray.Contains("Tomato") && recipearray.Contains("Rice") && recipearray.Contains("Chicken") && recipearray.Contains("Garlic"))
            {
                if (!Combo1.Items.Contains("Chicken dish"))
                {
                    Combo1.Items.Add("Chicken dish");
                    recipeLabel.Content = "You made a Chicken dish!";
                }
            
            }

            if (recipearray.Contains("Fish") && recipearray.Contains("Tomato") && recipearray.Contains("Garlic") && recipearray.Contains("Onion") && recipearray.Contains("Broccoli"))
            {
                if (!Combo1.Items.Contains("Fish dish"))
                {
                    Combo1.Items.Add("Fish dish");
                    recipeLabel.Content = "You made a Fish Dish!";
                }
            }

            if (recipearray.Contains("Meat") && recipearray.Contains("Bacon") && recipearray.Contains("Broccoli") && recipearray.Contains("Onion") && recipearray.Contains("Garlic"))
            {
                if (!Combo1.Items.Contains("Steak"))
                {
                    Combo1.Items.Add("Steak");
                    recipeLabel.Content = "You made a Steak dish!";

                }
            }

             
            
            if (recipearray[0] != null && recipearray[0].Contains("Rice"))
            {
                if (!Combo1.Items.Contains("Rice") && recipearray[1] == null)
                {
                    
                    Combo1.Items.Add("Rice");
                    recipeLabel.Content = "You made some Rice!";

                }
            }

            if (recipearray.Contains("Macaroni") && recipearray.Contains("Paprika") && recipearray.Contains("Tomato") && recipearray.Contains("Onion") && recipearray.Contains("Garlic"))

            {
                if (!Combo1.Items.Contains("Macaroni"))
                {
                    Combo1.Items.Add("Macaroni");
                    recipeLabel.Content = "You made some Macaroni!";

                }
            }

            if (recipearray.Contains("Meat") && recipearray.Contains("Broccoli") && recipearray.Contains("Fish") && recipearray.Contains("Onion") && recipearray.Contains("Garlic"))

            {
                if (!Combo1.Items.Contains("Wok dish"))
                {
                    Combo1.Items.Add("Wok dish");
                    recipeLabel.Content = "You made a Wok dish!";
                }
            }

            deleteRecipe(sender, e);
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
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/bacon.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Bacon";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/bacon.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Bacon";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/bacon.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Bacon";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/bacon.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Bacon";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/bacon.png", UriKind.RelativeOrAbsolute));

                    }
                    break;

                case "Button2":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Meat";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vlees.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Meat";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vlees.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Meat";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vlees.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Meat";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vlees.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Meat";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vlees.png", UriKind.RelativeOrAbsolute));

                    }
                    break;

                case "Button3":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Chicken";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/kip.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Chicken";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/kip.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Chicken";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/kip.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Chicken";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/kip.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Chicken";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/kip.png", UriKind.RelativeOrAbsolute));

                    }
                    break;

                case "Button4":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Macaroni";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/macaroni.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Macaroni";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/macaroni.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Macaroni";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/macaroni.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Macaroni";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/macaroni.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Macaroni";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/macaroni.png", UriKind.RelativeOrAbsolute));

                    }
                    break;

                case "Button5":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Spaghetti";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/spaghetti.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Spaghetti";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/spaghetti.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Spaghetti";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/spaghetti.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Spaghetti";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/spaghetti.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Spaghetti";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/spaghetti.png", UriKind.RelativeOrAbsolute));

                    }
                    break;

                case "Button6":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Broccoli";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/brocoli.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Broccoli";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/brocoli.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Broccoli";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/brocoli.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Broccoli";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/brocoli.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Broccoli";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/brocoli.png", UriKind.RelativeOrAbsolute));

                    }
                    break;

                case "Button7":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Onion";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/ui.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Onion";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/ui.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Onion";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/ui.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Onion";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/ui.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Onion";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/ui.png", UriKind.RelativeOrAbsolute));

                    }
                    break;

                case "Button8":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Garlic";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/knoflook.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Garlic";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/knoflook.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Garlic";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/knoflook.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Garlic";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/knoflook.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Garlic";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/knoflook.png", UriKind.RelativeOrAbsolute));

                    }
                    break;

                case "Button9":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Tomato";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/tomaten.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Tomato";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/tomaten.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Tomato";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/tomaten.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Tomato";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/tomaten.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Tomato";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/tomaten.png", UriKind.RelativeOrAbsolute));
                    }
                    break;

                case "Button10":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Paprika";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/paprika.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Paprika";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/paprika.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Paprika";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/paprika.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Paprika";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/paprika.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Paprika";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/paprika.png", UriKind.RelativeOrAbsolute));
                    }
                    break;

                case "Button11":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Rice";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/rijst.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Rice";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/rijst.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Rice";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/rijst.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Rice";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/rijst.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Rice";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/rijst.png", UriKind.RelativeOrAbsolute));
                    }
                    break;

                case "Button12":

                    if (recipearray[0] == null)
                    {
                        recipearray[0] = "Fish";
                        recipe1.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vis.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[1] == null)
                    {
                        recipearray[1] = "Fish";
                        recipe2.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vis.png", UriKind.RelativeOrAbsolute));

                    }
                    else if (recipearray[2] == null)
                    {
                        recipearray[2] = "Fish";
                        recipe3.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vis.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[3] == null)
                    {
                        recipearray[3] = "Fish";
                        recipe4.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vis.png", UriKind.RelativeOrAbsolute));
                    }
                    else if (recipearray[4] == null)
                    {
                        recipearray[4] = "Fish";
                        recipe5.Source = new BitmapImage(new Uri(@"/WPFUI;component/Images/Ingredienten/vis.png", UriKind.RelativeOrAbsolute));
                    }
                    break;
            }
        }
    }
}

