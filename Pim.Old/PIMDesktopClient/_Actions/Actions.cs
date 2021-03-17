using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WindowsClient._Data._Actions
{
    class Actions
    {
        public static string readText { get; set; }
        public static Process process = new Process();
        public static ProcessStartInfo Info = new ProcessStartInfo();

        public static void ShowFileContent(string fileName)
        {
            // Filename  
            string fullPath = DirectoryDialog.defaultRepo + "/" + fileName;
            // Read the entire file.
            readText = File.ReadAllText(fullPath);
            FileViewer Content = new FileViewer();
            Content.Show();
        }
    }
}
