

using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;



namespace HW_07_10
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите мат. выражение");
                string input = Console.ReadLine();

                if(input.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    var result = CalculateExpression(input);
                    Console.WriteLine($"Result: {result}");

                }
                catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static async Task<double> CalculateExpression(string expression)
        {
            var options = ScriptOptions.Default
                .AddReferences (typeof(Math).Assembly)
                .AddImports("System","SystemMath");

            return await CSharpScript.EvaluateAsync<double>(expression, options);
        }
    }
}
