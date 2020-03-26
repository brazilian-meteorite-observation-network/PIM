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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjE2Nzk0QDMxMzcyZTM0MmUzMG9Vc3J3b3lvZkVTMnc1UXgxdHJlT3hxUFhmdGw4ZUVLVTR5eEFuUVJFL289;MjE2Nzk1QDMxMzcyZTM0MmUzMEpJMWZ5cVU2RVpaWHpDSGhjSUxyRUl3cnZKNWh3Zm1GaSs2SlFBMlgvN3c9;MjE2Nzk2QDMxMzcyZTM0MmUzMFNYa2NHU2ZqUXNZQmNMWDU5bkZxcElLaXM0NDNvOWdocnl3bjJ1ZkdHNms9;MjE2Nzk3QDMxMzcyZTM0MmUzMFJBZ1Exa29SdUpIOFE4VmZ6cnlzemhVcWcxblZHSjdoVktiQlRUU0ZmNzg9;MjE2Nzk4QDMxMzcyZTM0MmUzMGMyT1BhVkttVXZMR1gzMDRJYXZkSFVmQk5ET0NhN3I5bGtnSTYwWllFTFk9;MjE2Nzk5QDMxMzcyZTM0MmUzMGJFdTdkbmhVdW1qZ2NVWGNpcU1Vb2JTNXo1TW8rbFVBcU9nWHJFeStwTFE9");
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

        /*private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _Data._Actions.ModelConfig.InsertAllInputs(1, 2, 3);
        }*/

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string ss = _Data._Actions.DirectoryDialog.Paths();
            MessageBox.Show(ss);
        }
    }
}
