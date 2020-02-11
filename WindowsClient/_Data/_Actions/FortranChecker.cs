using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsClient._Data._Helpers;

namespace WindowsClient._Data._Actions
{
    public static class Fortran
    {
        public static readonly string PATH = @"C:\";

        public static bool Exists(string path)
        {
            return File.Exists(path);
        }

        public static void Execute(string path, string name = "gfortran-windows.exe")
        {
            Process.Start(Path.Combine(path, name));
        }
    }
}
