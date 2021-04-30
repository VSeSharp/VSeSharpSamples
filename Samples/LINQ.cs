using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples
{
    public static class LINQ
    {
        static readonly List<int> _ages = new List<int> { 21, 46, 46, 46, 56, 55, 17, 21, 55, 55, 55 };
        public static void OneToManyRelationship()
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
        private static IEnumerable<int> ApplyDistinct() => _ages.Distinct();
        public static Tuple<int, int> Distinct() => new Tuple<int, int>(_ages.Count, ApplyDistinct().Count());
        public static double Average() => ApplyDistinct().Average();
        public static IEnumerable<int> LINQIEnumerable()
        {
            string[] names = { "C#", "VB", "F#" };
            var lengths = from name in names
                          select name.Length;
            return lengths;
        }
    }
}
