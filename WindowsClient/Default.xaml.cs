using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WindowsClient
{
    /// <summary>
    /// Interaction logic for Default.xaml
    /// </summary>
    public partial class Default : Window
    {
        // Preloading Controls
        BrushConverter bc = new BrushConverter();
        Border na = new Border();

        // Method Strings
        private string menuselectedtab { get; set; }

        public Default()
        {
            InitializeComponent();

            // apliyng softwate default behavior
            MenuDefaultState();

            // Preloading Controls Elements
            na.Margin = new Thickness(0, 0, 165, 0);
            na.Background = (Brush)bc.ConvertFrom("#FFD3E556");
        }

        private void MenuDefaultState()
        {
            // MainMenu buttons events
            HomeForm.Visibility = Visibility.Hidden;
            HomeForm.IsEnabled = false;

            CalculatorForm.Visibility = Visibility.Hidden;
            CalculatorForm.IsEnabled = false;

            DbForm.Visibility = Visibility.Hidden;
            DbForm.IsEnabled = false;

            HelpForm.Visibility = Visibility.Hidden;
            HelpForm.IsEnabled = false;

            // CalculateForm Configs
            ALatitude.InsertValues("Initial latitude", "Initial Frame Latitude Coordinates", "Ex: -22.801866");
            ALongitude.InsertValues("Initial longitude", "Initial Frame Longitude Coordinates", "Ex: -45.190323");
            AHeight.InsertValues("Initial height in meters", "Initial Frame Height", "in meters above mean sea level, Ex: 566.");

            BLatitude.InsertValues("Final latitude", "Final Frame Latitude Coordinates", "Ex: -7.148470");
            BLongitude.InsertValues("Final longitude", "Final Frame Longitude Coordinates", "Ex: -34.798074");
            BHeight.InsertValues("Final height in meters", "Final Frame Height", "in meters above mean sea level, Ex: 20.");

            ABTime.InsertValues("0.56", "Time interval between frames", "in seconds, Ex: 0.56");
            ABDensity.InsertValues("Meteorite Density", "Meteorite Density", "in miligrams per cm³, Ex: 3.25", 3.25);
            ABMass.InsertValues("Meteorite Mass", "Meteority Mass", "in kilos, Ex: 1");
        }

        private void CatchName(object sender, MouseEventArgs e)
        {
            // First see if it is a FrameworkElement
            var element = sender as FrameworkElement;
            if (element != null)
                menuselectedtab = element.Name;
            // If not, try reflection to get the value of a Name property.
            try { menuselectedtab = (string)sender.GetType().GetProperty("Name").GetValue(sender, null); }
            catch
            {
                // Last of all, try reflection to get the value of a Name field.
                try { menuselectedtab = (string)sender.GetType().GetField("Name").GetValue(sender); }
                catch { menuselectedtab = null; }
            }
        }

        private void MainMenuBtns_MouseEnter(object sender, MouseEventArgs e)
        {
            CatchName(sender, e);
            var bc = new BrushConverter();
            if (menuselectedtab == "HomeBtn")
            {
                HomeBtn.Background = (Brush)bc.ConvertFrom("#19FFFFFF");
            }
            else if (menuselectedtab == "CalculatorBtn")
            {
                CalculatorBtn.Background = (Brush)bc.ConvertFrom("#19FFFFFF");
            }
            else if (menuselectedtab == "DbBtn")
            {
                DbBtn.Background = (Brush)bc.ConvertFrom("#19FFFFFF");
            }
            else if (menuselectedtab == "HelpBtn")
            {
                HelpBtn.Background = (Brush)bc.ConvertFrom("#19FFFFFF");
            }
        }

        private void MainMenuBtns_MouseLeave(object sender, MouseEventArgs e)
        {
            if (menuselectedtab == "HomeBtn")
            {
                HomeBtn.Background = (Brush)bc.ConvertFrom("#00FFFFFF");
            }
            else if (menuselectedtab == "CalculatorBtn")
            {
                CalculatorBtn.Background = (Brush)bc.ConvertFrom("#00FFFFFF");
            }
            else if (menuselectedtab == "DbBtn")
            {
                DbBtn.Background = (Brush)bc.ConvertFrom("#00FFFFFF");
            }
            else if (menuselectedtab == "HelpBtn")
            {
                HelpBtn.Background = (Brush)bc.ConvertFrom("#00FFFFFF");
            }
        }

        // Use this behavior in all MainMenu Controls, this method default action is select the controlbehavior currect to execute.
        private void MainMenuBtns_MouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            HomeBtnGrid.Children.Remove(na);
            CalculatorBtnGrid.Children.Remove(na);
            DbBtnGrid.Children.Remove(na);
            HelpBtnGrid.Children.Remove(na);
            MenuDefaultState();

            if (menuselectedtab == "HomeBtn")
            {
                HomeForm.Visibility = Visibility.Visible;
                HomeBtnGrid.Children.Add(na);
                HomeForm.IsEnabled = true;
            }

            else if (menuselectedtab == "CalculatorBtn")
            {
                CalculatorForm.Visibility = Visibility.Visible;
                CalculatorBtnGrid.Children.Add(na);
                CalculatorForm.IsEnabled = true;

            }

            else if (menuselectedtab == "DbBtn")
            {
                DbForm.Visibility = Visibility.Visible;
                DbBtnGrid.Children.Add(na);
                DbForm.IsEnabled = true;
            }

            else if (menuselectedtab == "HelpBtn")
            {
                HelpForm.Visibility = Visibility.Visible;
                HelpBtnGrid.Children.Add(na);
                DbForm.IsEnabled = true;
            }

        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _Data._Actions.ModelConfig.InsertAllInputs(1, 2, 3);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string ss = _Data._Actions.DirectoryDialog.Paths();
            MessageBox.Show(ss);
        }
    }
}
