using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClient.utils
{
    public static class GlobalEnvironmentVariables
    {
        public static void Set(string variable, string value)
        {
            Environment.SetEnvironmentVariable(variable, value, EnvironmentVariableTarget.Machine);
        }

        public static string Get(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
        }

        public static void Remove(string variable)
        {
            Environment.SetEnvironmentVariable(variable, null, EnvironmentVariableTarget.Machine);
        }
    }
}
