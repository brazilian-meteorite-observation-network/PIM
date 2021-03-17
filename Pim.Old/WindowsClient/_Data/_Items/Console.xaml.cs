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
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class Console : UserControl
    {
        public Console()
        {
            InitializeComponent();
        }

        public void Status(int status, int msg)
        {
            switch (status)
            {
                case 0:
                    Viewer.Text += "Initialized; \n";
                    break;
                case 1:
                    statusMessage("[ ACTION ]", msg);
                    break;
                default:
                    Viewer.Text += "Initialization Errror.\n";
                    break;
            }
        }

        public void Status(int status, int msg, string errorDesc)
        {
            switch (status)
            {
                case 0:
                    Viewer.Text += "Initialized; \n";
                    break;
                case 1:
                    statusMessage("[ ERROR ]", msg, errorDesc);
                    break;
                default:
                    Viewer.Text += "Initialization Errror.\n";
                    break;
            }
        }

        private void statusMessage(string status, int msg)
        {
            switch (msg)
            {
                case 0:
                    Viewer.Text += $"{status} - Show Source Code\n";
                    break;
                default:
                    Viewer.Text += $"{status} - Nothing to do.\n";
                    break;
            }
        }

        private void statusMessage(string status, int msg, string errorDesc)
        {
            switch (msg)
            {
                case 0:
                    Viewer.Text += $"{status} - {errorDesc}. Could ot open the file.\n";
                    break;
                default:
                    Viewer.Text += $"{status} - Nothing to do.\n";
                    break;
            }
        }
    }
}
