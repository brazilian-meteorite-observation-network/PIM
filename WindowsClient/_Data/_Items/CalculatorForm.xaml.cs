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

namespace WindowsClient._Data._Items
{
    /// <summary>
    /// Interaction logic for CalculatorForm.xaml
    /// </summary>
    public partial class CalculatorForm : UserControl
    {
        public CalculatorForm()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjE2Nzk0QDMxMzcyZTM0MmUzMG9Vc3J3b3lvZkVTMnc1UXgxdHJlT3hxUFhmdGw4ZUVLVTR5eEFuUVJFL289;MjE2Nzk1QDMxMzcyZTM0MmUzMEpJMWZ5cVU2RVpaWHpDSGhjSUxyRUl3cnZKNWh3Zm1GaSs2SlFBMlgvN3c9;MjE2Nzk2QDMxMzcyZTM0MmUzMFNYa2NHU2ZqUXNZQmNMWDU5bkZxcElLaXM0NDNvOWdocnl3bjJ1ZkdHNms9;MjE2Nzk3QDMxMzcyZTM0MmUzMFJBZ1Exa29SdUpIOFE4VmZ6cnlzemhVcWcxblZHSjdoVktiQlRUU0ZmNzg9;MjE2Nzk4QDMxMzcyZTM0MmUzMGMyT1BhVkttVXZMR1gzMDRJYXZkSFVmQk5ET0NhN3I5bGtnSTYwWllFTFk9;MjE2Nzk5QDMxMzcyZTM0MmUzMGJFdTdkbmhVdW1qZ2NVWGNpcU1Vb2JTNXo1TW8rbFVBcU9nWHJFeStwTFE9");
            InitializeComponent();
            PlaceHolderBehavior();
        }

        private void PlaceHolderBehavior()
        {
            // CalculateForm Configs
            FPLatitude.InsertValues("Firs Point Latitude", "Initial Object Latitude Coordinates", "Ex: -22.801866");
            FPLongitude.InsertValues("Initial longitude", "Initial Frame Longitude Coordinates", "Ex: -45.190323");
            FPHeight.InsertValues("Initial height in meters", "Initial Frame Height", "in meters above mean sea level, Ex: 566.");

            SPLatitude.InsertValues("Final latitude", "Final Frame Latitude Coordinates", "Ex: -7.148470");
            SPLongitude.InsertValues("Final longitude", "Final Frame Longitude Coordinates", "Ex: -34.798074");
            SPHeight.InsertValues("Final height in meters", "Final Frame Height", "in meters above mean sea level, Ex: 20.");

            // PTime.InsertValues("0.56", "Time interval between frames", "in seconds, Ex: 0.56");
            PDensity.InsertValues("Meteorite Density", "Meteorite Density", "in miligrams per cm³, Ex: 3.25", 3.25);
            PMass.InsertValues("Meteorite Mass", "Meteority Mass", "in kilos, Ex: 1");
        }

        private void ButtonAdv_Click(object sender, RoutedEventArgs e)
        {
            _Data._Actions.Actions.ShowFileContent("Model3d_newdens.for");
        }
    }
}
