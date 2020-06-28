using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WindowsClient._Data._Items;

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

        readonly HomeWindow home = new HomeWindow();
        readonly CalculatorForm calc = new CalculatorForm();

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

        #region defaultmenu

        private void MenuDefaultState()
        {
            // MainMenu buttons events

            //CalculatorForm.Visibility = Visibility.Hidden;
            //CalculatorForm.IsEnabled = false;
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

            ContentGrid.Children.Clear();

            if (menuselectedtab == "HomeBtn")
            {
                HomeBtnGrid.Children.Add(na);
                ContentGrid.Children.Add(home);
            }

            else if (menuselectedtab == "CalculatorBtn")
            {
                CalculatorBtnGrid.Children.Add(na);
                ContentGrid.Children.Add(calc);
            }

            else if (menuselectedtab == "DbBtn")
            {
                DbBtnGrid.Children.Add(na);
            }

            else if (menuselectedtab == "HelpBtn")
            {
                HelpBtnGrid.Children.Add(na);
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

        #endregion
    }
}
