using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WeatherAPI.Helper
{
  public static class Utilities
  {
    public static void DisplayEnvVaraibles()
    {
      Console.WriteLine($"------------Enviroment varaibles --------------");

      DisplayEnvVariable("ASPNETCORE_ENVIRONMENT");
      DisplayEnvVariable("ASPNETCORE_URLS");
      DisplayEnvVariable("ASPNETCORE_HTTPS_PORT");
      DisplayEnvVariable("ASPNETCORE_Kestrel__Certificates__Default__Path");
      DisplayEnvVariable("ASPNETCORE_Kestrel__Certificates__Default__Password");


    }


    static void DisplayEnvVariable(string envVariableName)
    {
      string _envVariableValue = Environment.GetEnvironmentVariable(envVariableName);
      Console.WriteLine($"{envVariableName}={_envVariableValue}");
      if (String.IsNullOrEmpty(_envVariableValue)) Console.WriteLine($"ERROR : {envVariableName} Not found in Enviroment Variables or is Null or empty");
    }
  }
}
