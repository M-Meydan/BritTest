using System;
using System.IO;
using Microsoft.Practices.Unity;

namespace BritApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UnityConfig.RegisterTypes();
                AppInit();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.Message}");
            }

            Console.ReadLine();
        }

        private static void AppInit()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InputFolder", "InputFile.txt");

            var calculator = UnityConfig.Container.Resolve<ICalculator>();

            calculator.Load(filePath);

            calculator.ValidateLines();

            var result = calculator.ExecuteInstructions();

            Console.WriteLine($"Result: {result}");
        }
    }
}
