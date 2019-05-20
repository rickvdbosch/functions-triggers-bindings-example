using System;

namespace ExampleFunctionProject.Helpers
{
    internal static class SettingsHelper
    {
        internal static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}