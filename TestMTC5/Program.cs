using System;

namespace TestMTC5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TransformToElephant("Муха");
            Console.WriteLine("Муха");
            //... custom application code
        }

        static void TransformToElephant(string text)
        {
            if (text == "Муха")
            {
                Console.WriteLine("Слон");
            }
            
        }
        // не думаю, что это возможно...А если и возможно, то приведет к огромному ряду проблем.
    }
}