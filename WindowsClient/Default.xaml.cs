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
            MenuDefaultState();

            // Preloading Controls Elements
            na.Margin = new Thickness(0, 0, 186, 0);
            na.Background = (Brush)bc.ConvertFrom("#FFD3E556");
        }

        private void MenuDefaultState()
        {
            HomeForm.Visibility = Visibility.Hidden;
            HomeForm.IsEnabled = false;

            CalculatorForm.Visibility = Visibility.Hidden;
            CalculatorForm.IsEnabled = false;

            DbForm.Visibility = Visibility.Hidden;
            DbForm.IsEnabled = false;

            HelpForm.Visibility = Visibility.Hidden;
            HelpForm.IsEnabled = false;
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
            if(menuselectedtab == "HomeBtn")
            {
                HomeBtn.Background = (Brush)bc.ConvertFrom("#19FFFFFF");
            }
            else if(menuselectedtab == "CalculatorBtn")
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
            string folder = txtCordDirectory.Text;
            // Filename  
            string fileName = "Coordinates.for";
            // Fullpath. You can direct hardcode it if you like.  
            string fullPath = folder + "/" + fileName;
            // An array of strings  
            string[] coordinates = { txtLatP1.Text, txtLongP1.Text, txtHeightP1.Text, txtLatP2.Text, txtLongP2.Text, txtHeightP2.Text, txtTimeP2P.Text, txtMass.Text };
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine("T = 0.56d0");
                writer.WriteLine("");
                writer.WriteLine("");
                writer.WriteLine("");
                writer.WriteLine("");
                writer.WriteLine("H1 = " + coordinates[3]);
                writer.WriteLine("LON1 = " + coordinates[2]);
                writer.WriteLine("LAT1 = " + coordinates[1]);
                writer.WriteLine("");
                writer.WriteLine("H2 = " + coordinates[6]);
                writer.WriteLine("LON2 = " + coordinates[5]);
                writer.WriteLine("LAT2 = " + coordinates[4]);
            }
            // Read a file  
            string readText = File.ReadAllText(fullPath);
            MessageBox.Show(readText);
        }
    }
}
