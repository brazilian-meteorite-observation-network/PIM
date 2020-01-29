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
using System.Windows.Shapes;

namespace WindowsClient
{
    /// <summary>
    /// Interaction logic for Default.xaml
    /// </summary>
    public partial class Default : Window
    {
        public Default()
        {
            InitializeComponent();
            DefaultConfig();
        }

        private void DefaultConfig()
        {
            HomeForm.Visibility = Visibility.Visible;
            CalculatorForm.Visibility = Visibility.Collapsed;
            DataForm.Visibility = Visibility.Collapsed;
            HelpForm.Visibility = Visibility.Collapsed;
        }

        private void OpenHome()
        {
            /*while (HomeBtn.MouseUp==true)
            {
                MessageBox.Show("ok");
            }*/
        }
    }
}
