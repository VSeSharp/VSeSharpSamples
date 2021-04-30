
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using static ConsoleUI.Program;

//DI, Logging: Serilog, Settings

namespace ConsoleUI
{
    public class SnippetService : ISnippetService
    {
        private readonly ILogger<SnippetService> _log;
        private readonly IConfiguration _config;
        public SnippetService(ILogger<SnippetService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public ILogger<SnippetService> Log { get; }

        public void Run()
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
        }

        private void OneToManyRelationship()
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
        }
        //Once the enumeration is complete, the message in the finally{} block will be written to the console
        private IEnumerable<string> FinallyBlock()
        {
            try
            {
                yield return "Hello";
                yield return "World";
                yield return "!";
            }
            finally
            {
                _log.LogInformation("finally clause");
            }
        }
        private void FuncDelegateWithAnonymousMethods()
        {
            Developer developer = new Developer() { FirstName = "VSeSharp" };
            Func<string> introduceMethodCall = delegate () { return developer.IntroduceDeveloper(); };
        }
        private void FuncDelegateToANonStaticMethod()
        {
            Developer developer = new Developer() { FirstName = "VSeSharp" };
            Func<string> introduceMethodCall = developer.IntroduceDeveloper;
        }
        private void LINQDistinc(List<int> ages)
        {
            var distinctAges = ages.Distinct();
        }
        private void LINQAverage(List<int> ages)
        {
            double average = ages.Distinct().Average();
        }
        //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
        private void RecordType()
        {
            Teacher teacher = new("Nancy", "Davolio", 5);
            _log.LogInformation("Teacher {teacher}", teacher);
        }
        private void LINQIEnumerable()
        {
            string[] names = { "C#", "VB", "F#" };
            var lengths = from name in names
                          select name.Length;
        }
    }
}
