using System;

namespace task1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("The program reads the line from the file and displays the result in a formatted form.");
            string str = null;
            try
            {
                FormatExpression obj = new FormatExpression();
                str = obj.FormatStr();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occurred");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}