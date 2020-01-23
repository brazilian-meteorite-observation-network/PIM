using System;

namespace WindowsClient._Data._Actions
{
    public static class GlobalEnvironmentVariables
    {
        /// <summary>
        /// Method to set or update a new environment variable to communicate between softwares.
        /// </summary>
        /// <param name="variable">Environment variable name</param>
        /// <param name="latitude">Object's latitude</param>
        /// <param name="longitude">Object's longitude</param>
        /// <param name="height">Object's height</param>
        public static void Set(string variable, float latitude, float longitude, string height)
        {
            Environment.SetEnvironmentVariable(variable, $"{latitude},{longitude},{height}", EnvironmentVariableTarget.Machine);
        }

        /// <summary>
        /// Method to get the value from the environment variable.
        /// </summary>
        /// <param name="variable">Environment variable name</param>
        /// <returns></returns>
        public static string Get(string variable)
        {
            return Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
        }
    }
}
