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
    // [Class.FileViewer] - A Gui to show file contents.
    public partial class FileViewer : Window
    {
        /// <summary> To create a Viewer in future.
        /// 
        /// </summary>
        public FileViewer()
        {
            InitializeComponent();
            Content.Content = Actions.readText;
        }
    }
}
