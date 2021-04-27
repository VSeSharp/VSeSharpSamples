using Samples;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VSeSharpSamplesExplorer
{
    class Program
    {
        public abstract record Person(string FirstName, string LastName);
        public record Teacher(string FirstName, string LastName, int Grade);
        static void Main(string[] args)
        {
            //.SelectMany() clause in Language Integrated Query (LINQ)
            OneToManyRelationship();
            //at what point will the message in the finally{} block be written to the console?
            FinallyBlock();
            //define a Function <TResult> delegate to a non static method
            FuncDelegateToANonStaticMethod();
            //using the Func<TResult> delegate with anonymous methods  
            FuncDelegateWithAnonymousMethods();

            List<int> ages = new List<int> { 21, 46, 46, 46, 56, 55, 17, 21, 55, 55, 55 };
            //.Distinct() in Language Integrated Query (LINQ)
            LINQDistinc(ages);
            //.Average() in Language Integrated Query (LINQ)
            LINQAverage(ages);
            //What's new in C# 9.0 : Record types
            RecordType();
            //what type will the compiler conclude lengths to be? - IEnumerable<int>
            LINQIEnumerable();

            Console.ReadKey();
        }

        static void OneToManyRelationship()
        {
            Developer[] devs = {
                new Developer {
                    FirstName = "VSeSharp",
                    Languages = new List<ProgrammingLanguage>{
                        new ProgrammingLanguage() { Name = "C#" },
                        new ProgrammingLanguage() { Name = "Java" }
                    }
                },
                new Developer {
                    FirstName = "Yoda",
                    Languages = new List<ProgrammingLanguage>{
                        new ProgrammingLanguage() { Name = "Python" }
                    }
                },
                new Developer {
                    FirstName = "Emmanuel",
                    Languages = new List<ProgrammingLanguage>{
                        new ProgrammingLanguage() { Name = "Python" },
                        new ProgrammingLanguage() { Name = "Ruby" }
                    }
                }
            };

            //SelectMany() returns a flattened projection of the array developers.
            var query =
                devs.SelectMany(dev => dev.Languages,
                (dev, pl) => new
                {
                    dev,
                    pl
                })
                .Select(devpl =>
                    new
                    {
                        Developer = devpl.dev.FirstName,
                        Language = devpl.pl.Name
                    }
            );

            ConsoleUtilities.Print(query);
        }
        //Once the enumeration is complete, the message in the finally{} block will be written to the console
        static IEnumerable<string> FinallyBlock()
        {
            try
            {
                yield return "Hello";
                yield return "World";
                yield return "!";
            }
            finally
            {
                ConsoleUtilities.Print("In finally block!");
            }
        }
        static void FuncDelegateWithAnonymousMethods()
        {
            Developer developer = new Developer() { FirstName = "VSeSharp" };
            Func<string> introduceMethodCall = delegate () { return developer.IntroduceDeveloper(); };
            ConsoleUtilities.Print(introduceMethodCall());
        }
        static void FuncDelegateToANonStaticMethod()
        {
            Developer developer = new Developer() { FirstName = "VSeSharp" };
            Func<string> introduceMethodCall = developer.IntroduceDeveloper;
            ConsoleUtilities.Print(introduceMethodCall());
        }
        static void LINQDistinc(List<int> ages)
        {
            var distinctAges = ages.Distinct();
            ConsoleUtilities.Print(distinctAges);
        }
        static void LINQAverage(List<int> ages)
        {
            double average = ages.Distinct().Average();
            ConsoleUtilities.Print(average);
        }
        //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
        static void RecordType()
        {
            Teacher teacher = new("Nancy", "Davolio", 5);
            Console.WriteLine(teacher);
            ConsoleUtilities.PrintLine();
        }
        static void LINQIEnumerable()
        {
            string[] names = { "C#", "VB", "F#" };
            var lengths = from name in names
                          select name.Length;
            ConsoleUtilities.Print(lengths);
        }
    }
}
