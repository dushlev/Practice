using System;
using System.Linq;
using System.Data.Entity;

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
            //Console.WriteLine(str);
            try
            {
                using (UserContext db = new UserContext())
                {
                    Expression exp1 = new Expression { ExpressionStr = str };
                    db.Expressions.Add(exp1);
                    
                    db.SaveChanges();
                    Console.WriteLine("Objects saved successfully");

                    var users = db.Expressions;
                    
                    var lastResult = db.Expressions.OrderBy(b => b.Id)
.Skip(Math.Max(0, db.Expressions.OrderBy(b => b.Id).Count() - 5));
                    foreach (Expression exp in lastResult)
                    {
                        Console.WriteLine("{0}.{1}", exp.Id, exp.ExpressionStr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception has occurred");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}