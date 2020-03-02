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
            string folder = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData), ".PIM");
            // Filename  
            string fullPath = folder + "/" + fileName;
            // Read the entire file.
            readText = File.ReadAllText(fullPath);
            FileViewer Content = new FileViewer();
            Content.Show();
        }
    }
}
