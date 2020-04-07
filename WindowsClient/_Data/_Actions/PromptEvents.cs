using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClient._Data._Actions
{
    class PromptEvents
    {
        public static Process process = new Process();
        public static ProcessStartInfo Info = new ProcessStartInfo();

        // [Method.Compile] - Use uses compiler previously defined by the software to compile a specific file.
        public static void Compile(string directory, string compiler, string inputfilename, string outputfilename, string format)
        {
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.FileName = $"cmd.exe";
            // if don't use [/C] don't work, u need add a directory string and input in Info.Arguments.
            Info.Arguments = $"/C cd {directory} & {compiler} {inputfilename}.{format} -o {outputfilename}.{format}";
            process.StartInfo = Info;
            process.Start();
        }
    }
}
