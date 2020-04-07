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
        public static string PIMFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".PIM");
        public static ProcessStartInfo Info = new ProcessStartInfo();

        public static void ShowFileContent(string fileName)
        {
            // to %AppData% + foldername
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".PIM");
            // Filename  
            string fullPath = folder + "/" + fileName;
            // Read the entire file.
            readText = File.ReadAllText(fullPath);
            FileViewer Content = new FileViewer();
            Content.Show();
        }

        public static void Compile(string directory, string compiler, string inputfilename, string outputfilename, string format)
        {
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.FileName = "cmd.exe";
            // if don't use [/C] don't work, u need add a directory string and input in Info.Arguments.
            Info.Arguments = $"/C cd {directory} & {compiler} {inputfilename}.{format} -o {outputfilename}.{format} & {outputfilename}.{format}";
            process.StartInfo = Info;
            process.Start();
        }
    }
}
