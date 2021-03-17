using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsClient._Data._Actions
{
    // Manipulate OpenFileDialog Property
    class DirectoryDialog
    {
        public static string defaultRepo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".PIM");
        public static string Paths()
        {
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            // dont use "/' don't work.
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Fortran (*.for;*.f)|*.for;*.f|C (*.c)|*.c|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
            }

            return filePath;
        }
    }
}
