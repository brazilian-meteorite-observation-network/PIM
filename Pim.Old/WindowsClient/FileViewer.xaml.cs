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
using WindowsClient._Data._Actions;

namespace WindowsClient
{
    /// <summary>
    /// Interaction logic for FileViewer.xaml
    /// </summary>
    public partial class FileViewer : Window
    {
        public FileViewer()
        {
            InitializeComponent();
            Content.Content = Actions.readText;
        }
    }
}
