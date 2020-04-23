using System;

namespace ExampleFunctionProject.Helpers
{
    internal static class SettingsHelper
    {
        /// <summary>
        /// Gets the value for the environment variable with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the environment variable to get the value for.</param>
        /// <returns>The value for the environment variable with name <paramref name="name"/>.</returns>
        internal static string GetEnvironmentVariable(string name) =>
            Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
    }
}