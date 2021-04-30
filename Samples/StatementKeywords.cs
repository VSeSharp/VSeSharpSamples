using System.Collections.Generic;

namespace Samples
{
    public static class StatementKeywords
    {
        public static bool FinallyClauseReached;
        //At what point will the message in the finally{} block be written to the console?
        public static IEnumerable<string> FinallyBlock()
        {
            try
            {
                yield return "Hello";
                yield return "World";
                yield return "!";
            }
            finally
            {
                //Once the enumeration is complete, the message in the finally{} block will be written to the console
                FinallyClauseReached = true;
            }
        }
    }
}
