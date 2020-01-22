using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClient._Data._Actions
{
    public static class GlobalEnvironmentVariables
    {
        public static bool Set(string variable, string value)
        {
            if (value.Split(',').Length == 3)
            {
                Environment.SetEnvironmentVariable(variable, value, EnvironmentVariableTarget.Machine);

                return true;
            }
            else return false;
        }

        public static string Get(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
        }
    }
}
