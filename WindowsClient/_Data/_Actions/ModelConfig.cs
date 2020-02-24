using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;

namespace WindowsClient._Data._Actions
{
    class ModelConfig
    {
        public static Process process = new Process();
        public static ProcessStartInfo Info = new ProcessStartInfo();

        public static void InsertAllInputs(float lat1, float lat2, float time)
        {
            string folder = "C:/Users/BREWERTONTHIAGOOLIVE/Desktop";//_Data._Actions.DirectoryDialog.Path();
            // Filename  
            string fileName = "Model3d_newdens.for";
            string fullPath = folder + "/" + fileName;
            // An array of strings  

            /*using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(coordinates[0]);
            }*/
            // Read the entire file.
            //string readText = File.ReadAllText(fullPath);
            // Read all file lines.
            string[] readLines = File.ReadAllLines(fullPath);
            // edit time var.
            readLines[119 - 1] = (/*densidade g/cm3)*/"");
            readLines[120 - 1] = (/*massa g( M =)  */"");
            readLines[127 - 1] = (/* CD coeficiente aerodinâmico(CD =) */"");
            readLines[140 - 1] = (/* tempo entre as capturas segundos(T=) */"");
            readLines[144 - 1] = (/* altura 1 km (h1=) */"");
            readLines[145 - 1] = (/* longitude 1 em graus (lon1=) */"");
            readLines[146 - 1] = (/* latitude 1 em graus(lat1=) */"");
            readLines[148 - 1] = (/* longitude 1 em graus(lon1=) */"");
            readLines[149 - 1] = (/* longitude 1 em graus(lon1=) */"");
            readLines[150 - 1] = (/* latitude em graus(lat1=) */"");
            readLines[387 - 1] = (/* densidade g/cm3 (densiMeteor=)*/"");
            readLines[388 - 1] = (/* massa kg(M=) */"");
            readLines[396 - 1] = (/* CD coeficiente aerodinâmico */"");
            readLines[140 - 1] = ("	T = " + time + "d0");
            readLines[141 - 1] = (" Teste");
            // here -- readLines[14]
            File.WriteAllLines(fullPath, readLines);
            MessageBox.Show(readLines[140 - 1]);
        }

        public static void Compile(string directory, string compiler, string inputfilename, string outputfilename, string format)
        {            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.FileName = "cmd.exe";
            // if don't use [/C] don't work, u need add a directory string and input in Info.Arguments.
            Info.Arguments = $"/C cd c:/Users/BREWERTONTHIAGOOLIVE/Desktop & {compiler} {inputfilename}.{format} -o {outputfilename}.{format}";
            process.StartInfo = Info;
            process.Start();
        }
    }
}
