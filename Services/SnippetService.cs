using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Samples;
using System;
using System.Collections.Generic;
using System.Linq;

//DI, Logging: Serilog, Settings

namespace Services
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
            #region LINQ

            //.SelectMany() clause in Language Integrated Query (LINQ)
            LINQ.OneToManyRelationship();
            //.Distinct() in Language Integrated Query (LINQ)
            Tuple<int, int> sizes = LINQ.Distinct();
            _log.LogInformation("Size before Distinct() {before}, size after {after}", sizes.Item1, sizes.Item2);
            //.Average() in Language Integrated Query (LINQ)
            double average = LINQ.Average();
            _log.LogInformation("Result after Distinct() {average}", average);
            //what type will the compiler conclude lengths to be? - IEnumerable<int>
            var result = LINQ.LINQIEnumerable();
            _log.LogInformation("Result after LINQIEnumerable() {result}", result);

            #endregion

            #region StatementKeywords

            //At what point will the message in the finally{} block be written to the console?
            var yieldResult = StatementKeywords.FinallyBlock();
            _log.LogInformation("Yield returned ? {variable}", yieldResult);
            _log.LogInformation("Was finally block reached ? {variable}", StatementKeywords.FinallyClauseReached);

            #endregion

            #region Func

            //using the Func<TResult> delegate with anonymous methods  
            string whatDoesHeSaid = Func.FuncDelegateWithAnonymousMethods();
            _log.LogInformation(whatDoesHeSaid);
            //define a Function <TResult> delegate to a non static method
            whatDoesHeSaid = Func.FuncDelegateToANonStaticMethod();
            _log.LogInformation(whatDoesHeSaid);

            #endregion

            //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
            #region Record

            //What's new in C# 9.0 : Record types
            var teacher = Record.RecordType();
            _log.LogInformation("Teacher {teacher}", teacher);

            #endregion
        }
    }
}
