using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClient._Data._Helpers
{
    public static class CurrentDirectory
    {
        public static readonly string PATH = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString());
    }
}
