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

        public static void InsertAllInputs(float iLat, float iLong, float iHeight, float fLat, float fLong, float fHeight, float time, float dens, float aeroDinCo, float mass, string tab)
        {
            string folder = DirectoryDialog.defaultRepo;
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
            readLines[119 - 1] = $"            densiMeteor={dens}"; // observation object density
            readLines[120 - 1] = $" 	    M = {mass}.d-3"; // observation object mass
            readLines[127 - 1] = $"	    CD = {aeroDinCo}D0"; // aerodynamic coefficient
            readLines[140 - 1] = $"      T = {time}d0"; // time between initial and final catches
            readLines[144 - 1] = $"        H1={iHeight}d0"; // observation object initial height
            readLines[145 - 1] = $"        LON1= {iLong}d0"; // observation object initial longitude
            readLines[146 - 1] = $"        LAT1={iLat}d0"; // observation object initial latitude
            readLines[148 - 1] = $"      H2={fHeight}d0"; // observation object final height
            readLines[149 - 1] = $"        LON2={fLong}d0"; // observation object final longitude
            readLines[150 - 1] = $"        LAT2={fLat}d0"; // observation object final latitude
            readLines[387 - 1] = $"            densiMeteor={dens}"; // observation object density
            readLines[388 - 1] = $"	    M = {mass}.d-3"; // observation object mass
            readLines[396 - 1] = $"	    CD = {aeroDinCo}d0"; // aerodynamic coefficient
            File.WriteAllLines(fullPath, readLines);
            MessageBox.Show(readLines[140 - 1]);
        }
    }
}
