using System;

namespace WindowsClient._Data._Actions
{
    public static class GlobalEnvironmentVariables
    {
        public static void Set(string variable, string h1, float latitude, float longitude)
        {
            Environment.SetEnvironmentVariable(variable, $"{h1},{latitude},{longitude}", EnvironmentVariableTarget.Machine);
        }

        public static string Get(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
        }
    }
}
